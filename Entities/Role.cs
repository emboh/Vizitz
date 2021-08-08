using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Vizitz.Entities
{
    public class Role : IdentityRole<Guid>
    {
        public const string Administrator = "Administrator";

        public const string AdministratorId = "b6f768d5-6d77-4814-8a93-a679f97b6448";

        public const string Visitor = "Visitor";

        public const string VisitorId = "889ef87a-ba2c-4e6e-b71c-03786981e437";

        public const string Proprietor = "Proprietor";

        public const string ProprietorId = "1fe125cd-2a32-4a6e-aed9-7ff821627b38";

        public virtual IList<UserRole> UserRoles { get; set; }
    }
}
