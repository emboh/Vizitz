using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System;
using System.Text;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.Models.Exception;

namespace Vizitz
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentityCore<User>(q => { q.User.RequireUniqueEmail = true; })
                .AddRoles<Role>()
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
        {
            var jwtSettings = Configuration.GetSection("Jwt");

            // TODO : move to secure location
            var key = "918471de-9195-457a-b1e8-08d912b91e58";
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("Issuer").Value,
                    IssuerSigningKey = secret,
                };
            });
        }

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(error => {
                error.Run(async context => {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        Log.Error($"Something went wrong in the {contextFeature.Error}");

                        await context.Response.WriteAsync(new Error
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error. Please try again later."
                        }.ToString());
                    }
                });
            });
        }
    }
}
