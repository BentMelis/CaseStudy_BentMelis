using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy_BentMelis
{
    public class UserDataContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data source = DataFile.db");
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recept> Recepten { get; set; }

    }
}
