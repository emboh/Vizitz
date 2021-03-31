using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class ProprietorDTO : CreateProprietorDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual IList<VenueDTO> Venues { get; set; }
    }

    public class CreateProprietorDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        [DefaultValue(null)]
        public string Address { get; set; }

        [Phone]
        [DefaultValue(null)]
        public string Phone { get; set; }

        [EmailAddress]
        [DefaultValue(null)]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
