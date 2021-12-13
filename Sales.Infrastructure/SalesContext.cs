using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public SalesContext()
        {
        }


        public SalesContext(DbContextOptions<SalesContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile($"appsettings.json")
              .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SalesDB"));
        }
    }
}
