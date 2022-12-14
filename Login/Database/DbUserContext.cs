using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;  
using System.Text;
using System.Threading.Tasks;

namespace Login.Model.Entities
{
    internal class DbUserContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = usersDb.db");
            base.OnConfiguring(optionsBuilder);
        }
        public  DbSet<User> Users { get; set; }
    }
}
