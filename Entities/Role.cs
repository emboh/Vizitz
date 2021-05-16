using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Vizitz.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public const string Administrator = "Administrator";

        public const string Visitor = "Visitor";

        public const string Proprietor = "Proprietor";

        public static string[] AllowedRoles = { Visitor, Proprietor };

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
