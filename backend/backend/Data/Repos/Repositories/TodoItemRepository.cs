using System;
using System.Collections.Generic;
using System.Linq;
using backend.Data.Repos.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data.Repos.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;
        private readonly DbSet<TodoItem> _todos;

        public TodoItemRepository(TodoContext dbContext)
        {
            _context = dbContext;
            _todos = dbContext.TodoItems;
        }

        public TodoItem GetBy(Guid id)
        {
            return _todos.FirstOrDefault(todo => todo.Id == id);
        }

        public IEnumerable<TodoItem> GetAll()
        {
            return _todos;
        }

        public IEnumerable<TodoItem> GetTodoItemsBetweenDates(DateTime start, DateTime end)
        {
            return _todos.Where(todo => todo.StartTime > start && todo.StartTime < end);
        }

        public IEnumerable<TodoItem> GetUnplannedTodoItems()
        {
            return _todos.Where(todo => todo.StartTime == null);
        }

        public void Add(TodoItem todoItem)
        {
            _todos.Add(todoItem);
        }

        public void Delete(TodoItem todoItem)
        {
            _todos.Remove(todoItem);
        }

        public void Update(TodoItem todoItem)
        {
            _todos.Update(todoItem);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
