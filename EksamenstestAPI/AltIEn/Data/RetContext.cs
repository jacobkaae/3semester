using System;
using System.Collections.Generic;
using AltIEn.Model;
using Microsoft.EntityFrameworkCore;

namespace AltIEn.Data
{
    public class RetContext : DbContext
    {
        public DbSet<Ret> Retter { get; set; }
        public DbSet<Ingrediens> Ingredienser { get; set; }

        public RetContext(DbContextOptions<RetContext> options)
                  : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}

