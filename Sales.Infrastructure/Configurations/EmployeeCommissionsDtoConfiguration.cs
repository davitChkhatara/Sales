using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sales.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure.Configurations
{
    public class EmployeeCommissionsDtoConfiguration : IEntityTypeConfiguration<EmployeeCommissionsDto>
    {
        public void Configure(EntityTypeBuilder<EmployeeCommissionsDto> builder)
        {
            builder.HasNoKey().ToView(null);

        }
    }
}
