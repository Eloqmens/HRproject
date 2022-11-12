using HRproject.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HRproject.Service
{
    static class ServiceRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services       
            //.AddTransient<IEmployeeService, IEmployeeService>()
            ;
    }
}
