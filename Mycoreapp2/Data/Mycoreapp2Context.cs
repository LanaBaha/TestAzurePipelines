using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mycoreapp2.Models
{
    public class Mycoreapp2Context : DbContext
    {
        public Mycoreapp2Context (DbContextOptions<Mycoreapp2Context> options)
            : base(options)
        {
        }

        public DbSet<Mycoreapp2.Models.Movie> Movie { get; set; }
    }
}
