﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vizitz.Data;
using Vizitz.IRepository;
using Vizitz.Repository;
using Microsoft.AspNetCore.Identity;
using Vizitz.IdentityUserCustom;

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vizitz", Version = "v1" });
            });

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DataBaseContext")
                )
            );

            services.AddAuthentication();

            services.ConfigureIdentity();

            //services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(
            //    identity =>
            //    {
            //        identity.User.RequireUniqueEmail = true;
            //        identity.Password.RequiredLength = 8;
            //    })
            //    .AddEntityFrameworkStores<DatabaseContext>()
            //    .AddDefaultTokenProviders();

            services.AddCors(options => 
                options.AddPolicy("AllowAll", builder => 
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                )
            );

            services.AddAutoMapper(typeof(MapInitializer));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
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

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
