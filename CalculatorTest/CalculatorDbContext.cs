using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorTest
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<Diagnostics> Diagnostics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnostics>()
                .Property(log => log.Message)
                .IsRequired();

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\" +
                    "MSSQLLocalDB;Initial Catalog=CalculatorDB;Integrated Security=True;" +
                    "Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
                    "Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }
    }
}
