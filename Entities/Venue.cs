using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vizitz.IEntities;

namespace Vizitz.Entities
{
    public class Venue : IHasTimestamps
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double Rating { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }

        //[ForeignKey(nameof(Proprietor))]
        //public Guid ProprietorId { get; set; }
        public User Proprietor { get; set; }

        public virtual IList<Schedule> Schedules { get; set; }
    }
}
