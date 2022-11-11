using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HR.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace HRproject.Data
{
    static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration Configuration) => services
            .AddDbContext<ResourcesDepartmentDB>(opt =>
            {
                var type = Configuration["Type"];
                opt.UseSqlServer(Configuration.GetConnectionString(type));
            })
            
            ;
    }
}
