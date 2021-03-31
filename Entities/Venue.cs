using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vizitz.Entities
{
    public class Venue
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Rating { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
        
        [ForeignKey(nameof(Proprietor))]
        public int ProprietorId { get; set; }
        public User Proprietor { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }
    }
}
