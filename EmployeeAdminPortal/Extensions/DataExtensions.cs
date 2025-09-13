using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Services;

namespace EmployeeAdminPortal.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeeService>();
            return services;
        }
    }
}
