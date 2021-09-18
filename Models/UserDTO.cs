using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vizitz.Models.Account;

namespace Vizitz.Models
{
    public class UserDTO
    {
        public string Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public string Email { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<UserRoleDTO> UserRoles { get; set; }
    }

    public class CreateUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public virtual IList<string> Roles { get; set; }
    }

    public class UpdateUserDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool? IsActive { get; set; }

        public virtual IList<string> Roles { get; set; }
    }
}
