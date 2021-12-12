using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sales.Domain.Entities;
using System;

namespace Sales.Application
{
    public interface ISalesContext
    {
        DatabaseFacade Database { get; }

        DbSet<Product> Products { get; set; }

        DbSet<SalesOrder> SalesOrders { get; set; }

        DbSet<ProductType> ProductTypes { get; set; }

        DbSet<Employee> Employees { get; set; }
    }
}
