using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;
using Vizitz.Models.User;

namespace Vizitz.Models
{
    public class ProprietorDTO : UpdateProprietorDTO
    {
        public string Id { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VenueDTO> Venues { get; set; }

        //public ICollection<string> Roles { get; set; }
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

        [Phone]
        public override string Phone { get; set; }

        [Range(typeof(bool), "false", "true")]
        public bool? IsActive { get; set; }
    }
}
