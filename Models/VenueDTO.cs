using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Vizitz.Models
{
    public class VenueDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? Rating { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual ProprietorDTO Proprietor { get; set; }

        public virtual IList<ScheduleDTO> Schedules { get; set; }
    }

    public class CreateVenueDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? Rating { get; set; }

        public bool? IsActive { get; set; }

        public string ProprietorId { get; set; }
    }

    public class UpdateVenueDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public double? Rating { get; set; }

        public bool? IsActive { get; set; }

        public string ProprietorId { get; set; }
    }
}
