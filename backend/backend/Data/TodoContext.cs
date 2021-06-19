using System;
using backend.Data.Configurations;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class TodoContext : DbContext
    {

        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}
