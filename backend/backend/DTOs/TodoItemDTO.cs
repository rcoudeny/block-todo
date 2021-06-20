using System;
namespace backend.DTOs
{
    public class TodoItemDTO
    {
        public String Title { get; set; }
        public String Description { get; set; }
        public String Duration { get; set; }
        public DateTime? StartTime { get; set; }
        public String SubTodos { get; set; }
        public DateTime CreatedOn { get; set; }

        public TodoItemDTO()
        {

        }

        public void SetDuration(TimeSpan? duration)
        {
            Duration = duration?.ToString();
        }

        public TimeSpan? GetDuration()
        {
            return Duration == null ? null : TimeSpan.Parse(Duration);
        }
    }


    public class TodoItemDTOWithId : TodoItemDTO
    {
        public Guid Id { get; set; }
    }
}
