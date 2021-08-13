using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;
using WorkedHourControl.Infra.Authorization;

namespace WorkedHourControl.Infra
{
    public static class InfraModule
    {
        public static IServiceCollection RegisterInfra(this IServiceCollection services, IConfiguration configuration)
        {
            AddSecurity(services, configuration);

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
