using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Domain.Entities;
using System;

namespace Sales.Infrastructure.Configurations
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");

            builder.HasMany(j => j.SubEmployees)
                            .WithOne(j => j.Manager)
                            .HasForeignKey(j => j.ManagerId);

        }
    }

}
