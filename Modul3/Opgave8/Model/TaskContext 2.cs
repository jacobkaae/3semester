using System;
using System.Collections.Generic;
using Opgave8.Model;
using Microsoft.EntityFrameworkCore;

namespace Opgave8.Model
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        public string DbPath { get; }

        public TaskContext(DbContextOptions<TaskContext> options)
            : base(options)
        {
            DbPath = "bin/Task.db";

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().ToTable("Tasks");
        }
    }
}

