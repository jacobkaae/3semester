using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Data
{
    public class BoardContext : DbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDo> ToDos { get; set; }

        public BoardContext(DbContextOptions<BoardContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }


    //public DbSet<Book> Books => Set<Book>();
    //public DbSet<Author> Authors => Set<Author>();


    //public BookContext(DbContextOptions<BookContext> options)
    //    : base(options)
    //{
    //    // Den her er tom. Men ": base(options)" sikre at constructor
    //    // på DbContext super-klassen bliver kaldt.
    //}
}

