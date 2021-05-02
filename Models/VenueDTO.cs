using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class VenueDTO : CreateVenueDTO
    {
        public string Id { get; set; }

        public ProprietorDTO Proprietor { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<ScheduleDTO> Schedules { get; set; }
    }

    public class CreateVenueDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }

        [Range(-90, 90)]
        [DefaultValue(null)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        [DefaultValue(null)]
        public double Longitude { get; set; }

        [Range(0, 5)]
        [DefaultValue(null)]
        public double Rating { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }

        [Required]
        public string ProprietorId { get; set; }
    }
}
