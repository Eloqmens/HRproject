using HR.DAL.Models;
using HRproject.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.DAL
{
    public static class RepositoryRegistrator
    {
        public static IServiceCollection AddRepositoriesInDB(this IServiceCollection services) => services
            .AddTransient<IRepository<Department>, DbRepository<Department>>()          
            .AddTransient<IRepository<Position>, DbRepository<Position>>()
            .AddTransient<IRepository<Employee>, EmployeeRepository>()
            ;
    }
}
