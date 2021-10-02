using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data.Repos.Interfaces;
using backend.DTOs;
using backend.DTOs.Mappers;
using backend.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace backend.Controllers
{

    [Route("api/todoitem")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoItemRepository _todoItemRepository;


        public TodoController(ITodoItemRepository todoItemRepository)
        {
            _todoItemRepository = todoItemRepository;
        }

        [HttpGet]
        public IEnumerable<TodoItemDTOWithId> GetAll()
        {
            return TodoItemMapper.GetTodoItemDTOsWithIdFromTodoItems(_todoItemRepository.GetAll());
        }

        [HttpGet("{guid}")]
        public TodoItemDTOWithId GetTodoItemDTOWithId(Guid guid)
        {
            return TodoItemMapper.GetTodoItemDTOWithIdFromTodoItem(_todoItemRepository.GetBy(guid));
        }

        [HttpGet("planned/{startTime}/{endTime}")]
        public IEnumerable<TodoItemDTOWithId> GetPlannedTodoItemBulkDTOs(DateTime? startTime, DateTime? endTime)
        {
            return TodoItemMapper.GetTodoItemDTOsWithIdFromTodoItems(_todoItemRepository.GetTodoItemsBetweenDates(startTime == null ? DateTime.MinValue : (DateTime)startTime, endTime == null ? DateTime.MaxValue : (DateTime)endTime));
        }

        [HttpGet("unplanned")]
        public IEnumerable<TodoItemDTOWithId> GetUnplannedTodoItemBulkDTOs()
        {
            return TodoItemMapper.GetTodoItemDTOsWithIdFromTodoItems(_todoItemRepository.GetUnplannedTodoItems());
        }

        [HttpPost]
        public ActionResult<Guid> PostTodoItem(TodoItemDTO todoItemDTO)
        {
            TodoItem todoItemToCreate = TodoItemMapper.GetTodoItemFromTodoItemDTO(todoItemDTO);
            todoItemToCreate.CreatedOn = DateTime.Now;
            _todoItemRepository.Add(todoItemToCreate);
            _todoItemRepository.SaveChanges();
            return todoItemToCreate.Id;
        }

        [HttpPut("{guid}")]
        public ActionResult<TodoItemDTO> UpdateTodoItem(Guid guid, TodoItemDTO todoItemDTO)
        {
            TodoItem todoItemToUpdate = _todoItemRepository.GetBy(guid);
            if (todoItemToUpdate == null)
            {
                return NotFound();
            }
            todoItemToUpdate.Title = todoItemDTO.Title;
            todoItemToUpdate.Description = todoItemDTO.Description;
            todoItemToUpdate.Duration = todoItemDTO.Duration;
            todoItemToUpdate.StartTime = todoItemDTO.StartTime;
            todoItemToUpdate.SubTodos = todoItemDTO.SubTodos;
            _todoItemRepository.Update(todoItemToUpdate);
            _todoItemRepository.SaveChanges();
            return todoItemDTO;
        }

        [HttpDelete("{guid}")]
        public ActionResult<TodoItemDTO> DeleteTodoItem(Guid guid)
        {
            TodoItem todoItemToDelete = _todoItemRepository.GetBy(guid);
            if (todoItemToDelete == null)
            {
                return NotFound();
            }
            _todoItemRepository.Delete(todoItemToDelete);
            _todoItemRepository.SaveChanges();
            return TodoItemMapper.GetTodoItemDTOFromTodoItem(todoItemToDelete);
        }
    }
}
