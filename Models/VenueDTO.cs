using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Vizitz.Models
{
    public class VenueDTO : UpdateVenueDTO
    {
        public string Id { get; set; }

        public ProprietorDTO Proprietor { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<ScheduleDTO> Schedules { get; set; }
    }

    public class UpdateVenueDTO : CreateVenueDTO
    {
        [StringLength(255)]
        public override string Name { get; set; }

        [StringLength(255)]
        public override string Address { get; set; }

        [Phone]
        public override string Phone { get; set; }

        [IgnoreDataMember]
        public override string ProprietorId { get; set; }
    }

    public class CreateVenueDTO
    {
        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Address { get; set; }

        [StringLength(255)]
        public virtual string Description { get; set; }

        [Required]
        [Phone]
        public virtual string Phone { get; set; }

        [Range(-90, 90)]
        [DefaultValue(null)]
        public virtual double Latitude { get; set; }

        [Range(-180, 180)]
        [DefaultValue(null)]
        public virtual double Longitude { get; set; }

        [Range(0, 5)]
        [DefaultValue(null)]
        public virtual double Rating { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }

        [Required]
        public virtual string ProprietorId { get; set; }
    }
}
