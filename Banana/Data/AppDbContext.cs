using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banana.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Banana.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<User> Users { get; set; }

        
        /*
        public AppDbContext()
        {
            
        }
        */
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "server=(localdb)\\MSSQLLocalDB;Database=BNNMSSQL;MultipleActiveResultSets=true;Integrated Security=True");
            }
        }
        
        
    }
}
