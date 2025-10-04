using EmployeeAdminPortal.Interfaces.Services;
using EmployeeAdminPortal.Interfaces.Validators;
using EmployeeAdminPortal.Services;
using EmployeeAdminPortal.Services.Validators;

namespace EmployeeAdminPortal.Extensions
{
    public static class DataExtensions
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeesService, EmployeeService>();
            services.AddScoped<IEmployeeValidator, EmployeeValidator>();
            return services;
        }
    }
}
