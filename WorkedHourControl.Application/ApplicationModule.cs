using Microsoft.Extensions.DependencyInjection;
using WorkedHourControl.Application.Services.EmployeeServices;
using WorkedHourControl.Application.Services.UserServices;

namespace WorkedHourControl.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection RegisterApplication(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            return services;
        }
    }
}
