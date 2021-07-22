using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Models
{
    public class ProprietorDTO : UpdateProprietorDTO
    {
        public string Id { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VenueDTO> Venues { get; set; }

        public IList<UserRoleDTO> UserRoles { get; set; }

        [IgnoreDataMember]
        public override IList<string> Roles { get; set; }
    }

    public class CreateProprietorDTO : RegisterDTO
    {
        [IgnoreDataMember]
        public override IList<string> Roles { get; set; }
    }

    public class UpdateProprietorDTO : RegisterDTO
    {
        [EmailAddress]
        public override string Email { get; set; }

        [StringLength(255, MinimumLength = 6)]
        public override string Password { get; set; }

        [StringLength(16, MinimumLength = 16)]
        public override string Identification { get; set; }

        [StringLength(255)]
        public override string Name { get; set; }

        [StringLength(255)]
        public override string Address { get; set; }

        [Range(typeof(bool), "false", "true")]
        public bool? IsActive { get; set; }

        public override IList<string> Roles { get; set; }
    }
}
