using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vizitz.Data;
using Vizitz.Entities;

namespace Vizitz
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services
                .AddIdentityCore<User>(q => { q.User.RequireUniqueEmail = true; })
                .AddRoles<IdentityRole<Guid>>();

            builder.AddEntityFrameworkStores<DatabaseContext>();

            builder.AddDefaultTokenProviders();
        }
    }
}
