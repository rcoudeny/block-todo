using System;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data.Configurations
{
    public class TodoItemConfiguration : IEntityTypeConfiguration<TodoItem>
    {
        public TodoItemConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {
            builder.ToTable("todo-item");
            builder.HasKey(todoItem => todoItem.Id);
        }
    }
}
