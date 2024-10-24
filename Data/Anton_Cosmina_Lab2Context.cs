using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Anton_Cosmina_Lab2.Models;

namespace Anton_Cosmina_Lab2.Data
{
    public class Anton_Cosmina_Lab2Context : DbContext
    {
        public Anton_Cosmina_Lab2Context (DbContextOptions<Anton_Cosmina_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Anton_Cosmina_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Anton_Cosmina_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Anton_Cosmina_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Anton_Cosmina_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
