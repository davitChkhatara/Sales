using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sales.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sales.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SalesContext>(options => options.UseSqlServer(configuration.GetConnectionString("SalesDB")));

            services.AddScoped<ISalesContext>(provider => provider.GetService<SalesContext>());

            return services;
        }
    }
}
