using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TodoItem
    {
        [Key]
        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        private TimeSpan? _duration;
        public String Duration
        {
            get { return _duration?.ToString(); }
            set { _duration = value == null ? null : TimeSpan.Parse(value); }
        }
        public DateTime? StartTime { get; set; }
        public String SubTodos { get; set; }

        public TodoItem()
        {
        }
    }
}
