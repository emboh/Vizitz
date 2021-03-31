using System;
using System.Collections.Generic;

namespace Vizitz.Entities
{
    public class User
    {
        public const string RoleAdmin = "Admin";

        public const string RoleVisitor = "Visitor";

        public const string RoleProprietor = "Proprietor";

        public int Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        //public string Username { get; set; }

        //public string Password { get; set; }

        //public string Avatar { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Visitor
        public virtual IList<Visit> Visits { get; set; }

        // Proprietor
        public virtual IList<Venue> Venues { get; set; }
    }
}
