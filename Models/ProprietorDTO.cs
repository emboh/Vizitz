using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Models
{
    public class ProprietorDTO
    {
        public string Id { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VenueDTO> Venues { get; set; }

        public virtual IList<UserRoleDTO> UserRoles { get; set; }
    }

    public class CreateProprietorDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }
    }

    public class UpdateProprietorDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public virtual IList<string> Roles { get; set; }
    }
}
