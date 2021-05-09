using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vizitz.IEntities;

namespace Vizitz.Entities
{
    public class User : IdentityUser<Guid>, IHasTimestamps
    {
        public const string RoleAdmin = "Admin";

        public const string RoleVisitor = "Visitor";

        public const string RoleProprietor = "Proprietor";

        public static string[] Roles = { RoleVisitor, RoleProprietor };

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public override int Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        //public string Avatar { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }

        // Visitor
        public virtual IList<Visit> Visits { get; set; }

        // Proprietor
        public virtual IList<Venue> Venues { get; set; }
    }
}
