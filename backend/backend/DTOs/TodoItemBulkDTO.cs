using System;
namespace backend.DTOs
{
    public class TodoItemBulkDTO
    {
        public Guid Id { get; set; }
        public String Title { get; set; }

        public TodoItemBulkDTO()
        {
        }
    }
}
