using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Vizitz.Data;
using Vizitz.Entities;
using Vizitz.IdentityUserCustom;

namespace Vizitz
{
    public static class ServiceExtensions
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            IdentityBuilder builder = services.AddIdentityCore<User>(q => { q.User.RequireUniqueEmail = true; });

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders(); ;

        //    builder.AddIdentity<ApplicationUser, Role>()
        //.AddEntityFrameworkStores<DatabaseContext, Guid>()
        //.AddDefaultTokenProviders()
        //.AddUserStore<UserStore<ApplicationUser, Role, DatabaseContext, Guid>>()
        //.AddRoleStore<RoleStore<Role, DatabaseContext, Guid>>();
        }
    }
}
