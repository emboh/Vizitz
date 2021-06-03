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

        // HACK : Constant roles
#pragma warning disable CA2211 // Non-constant fields should not be visible
        public static string[] AllowedRoles = { Visitor, Proprietor };
#pragma warning restore CA2211 // Non-constant fields should not be visible

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
