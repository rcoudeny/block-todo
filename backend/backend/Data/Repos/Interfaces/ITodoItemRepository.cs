using System;
using System.Collections.Generic;
using backend.Models;
namespace backend.Data.Repos.Interfaces
{
    public interface ITodoItemRepository
    {
        TodoItem GetBy(Guid id);

        IEnumerable<TodoItem> GetAll();

        IEnumerable<TodoItem> GetTodoItemsBetweenDates(DateTime start, DateTime end);

        IEnumerable<TodoItem> GetUnplannedTodoItems();

        void Add(TodoItem todoItem);

        void Update(TodoItem todoItem);

        void Delete(TodoItem todoItem);

        void SaveChanges();
    }
}
