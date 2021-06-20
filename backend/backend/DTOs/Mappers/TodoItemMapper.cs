using System;
using System.Collections.Generic;
using System.Linq;
using backend.Models;

namespace backend.DTOs.Mappers
{
    public static class TodoItemMapper
    {
        public static TodoItemBulkDTO GetTodoItemBulkDTO(TodoItem todoItem)
        {
            return new TodoItemBulkDTO
            {
                Id = todoItem.Id,
                Title = todoItem.Title
            };
        }

        public static IEnumerable<TodoItemBulkDTO> GetTodoItemBulkDTOs(IEnumerable<TodoItem> todoItems)
        {
            return todoItems.Select(todoItem => GetTodoItemBulkDTO(todoItem));
        }

        public static IEnumerable<TodoItemDTOWithId> GetTodoItemDTOsWithIdFromTodoItems(IEnumerable<TodoItem> todoItems)
        {
            return todoItems.Select(todoItem => GetTodoItemDTOWithIdFromTodoItem(todoItem));
        }

        public static TodoItem GetTodoItemFromTodoItemDTO(TodoItemDTO todoItemDTO)
        {
            return new TodoItem
            {
                Title = todoItemDTO.Title,
                Description = todoItemDTO.Description,
                Duration = todoItemDTO.Duration,
                StartTime = todoItemDTO.StartTime,
                SubTodos = todoItemDTO.SubTodos
            };
        }

        public static TodoItemDTO GetTodoItemDTOFromTodoItem(TodoItem todoItem)
        {
            return new TodoItemDTO
            {
                Title = todoItem.Title,
                Description = todoItem.Description,
                Duration = todoItem.Duration,
                StartTime = todoItem.StartTime,
                CreatedOn = todoItem.CreatedOn,
                SubTodos = todoItem.SubTodos
            };
        }

        public static TodoItemDTOWithId GetTodoItemDTOWithIdFromTodoItem(TodoItem todoItem)
        {
            return new TodoItemDTOWithId
            {
                Id = todoItem.Id,
                Title = todoItem.Title,
                Description = todoItem.Description,
                Duration = todoItem.Duration,
                StartTime = todoItem.StartTime,
                CreatedOn = todoItem.CreatedOn,
                SubTodos = todoItem.SubTodos
            };
        }
    }
}
