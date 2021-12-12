using Microsoft.EntityFrameworkCore;
using Sales.Application;
using Sales.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Sales.Infrastructure
{
    public class SalesContext : DbContext, ISalesContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<SalesOrder> SalesOrders { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
