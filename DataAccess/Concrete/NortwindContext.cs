using Core.Enitities.Concrete;
using Enitites.Concarete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class NortwindContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-CI2TQ0HV\\HALIL; Database = Northwind; Uid = sa; Password =sanane123; TrustServerCertificate = True; ");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OparationClaim> OparationClaims { get; set; }
        public DbSet<UserOparationClaim> UserOparationClaims { get; set; }
    }
}
