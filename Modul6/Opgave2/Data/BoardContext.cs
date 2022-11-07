using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Opgave1.Model
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<ToDo> ToDo { get; set; }



        public string DbPath { get; }

        public BoardContext()
        {
            DbPath = "bin/Boards.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}

