using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vizitz.Data;
using Vizitz.IRepository;
using Vizitz.Repository;
using Vizitz.Services;
using AspNetCoreRateLimit;

namespace Vizitz
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.ConfigureSwagger();

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DataBaseContext"))
                .EnableSensitiveDataLogging(false)
            );

            services.AddMemoryCache();

            services.AddInMemoryRateLimiting();

            services.ConfigureRateLimiting();

            services.AddHttpContextAccessor();

            services.ConfigureHttpCacheHeaders();

            services.AddAuthentication();

            services.ConfigureIdentity();

            services.ConfigureJWT(Configuration);

            services.AddCors(options =>
                options.AddPolicy("AllowAll", builder =>
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                )
            );

            services.AddAutoMapper(typeof(MapInitializer));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAuthManager, AuthManager>();

            services.AddControllers(/*config => {
                config.CacheProfiles.Add("ResourceList", new CacheProfile
                {
                    Duration = 120
                });

                config.CacheProfiles.Add("ResourceItem", new CacheProfile
                {
                    Duration = 60
                });
            }*/).AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.ConfigureVersioning();

            services.ConfigureValidation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vizitz v1");
                c.DefaultModelsExpandDepth(-1);
            });

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseResponseCaching();

            app.UseHttpCacheHeaders();

            app.UseIpRateLimiting();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
