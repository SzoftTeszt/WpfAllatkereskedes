using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAllatkereskedes
{
    public class AnimalContext:DbContext
    {
        public AnimalContext()
        {
        }

        public DbSet<Animal> Animals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=AnimalShop;Trusted_Connection=True;");
        }

    }
}
