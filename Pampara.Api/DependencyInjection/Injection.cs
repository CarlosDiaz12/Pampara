using Microsoft.Extensions.DependencyInjection;
using Pampara.BusinessLogic.Service;
using Pampara.DataAccess.Interface;
using Pampara.DataAccess.Model;
using Pampara.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pampara.Api.DependencyInjection
{
    public static class Injection
    {
        public static IServiceCollection AddPamparaServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Employee>, EmployeeRepository>();
            services.AddScoped<EmployeeService, EmployeeService>();
            return services;
        }

    }
}
