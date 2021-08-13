using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WorkedHourControl.Domain.Repositories;
using WorkedHourControl.Infra.Authorization;
using WorkedHourControl.Infra.Data;
using WorkedHourControl.Infra.Data.Repositories;

namespace WorkedHourControl.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection RegisterInfra(this IServiceCollection services, IConfiguration configuration)
        {
            AddSecurity(services, configuration);

            services.AddDbContext<WorkedHourContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IApplicationBuilder ConfigureInfra(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();

            return app;
        }

        private static IServiceCollection AddSecurity(IServiceCollection services, IConfiguration configuration)
        {
            var secret = configuration.GetValue<string>("Secret");
            services.AddSingleton<ITokenService>(x => new TokenService(secret));

            var key = Encoding.ASCII.GetBytes(secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
