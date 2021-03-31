using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vizitz.Entities
{
    public class Schedule
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Venue))]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public int Capacity { get; set; }

        public string Note { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public virtual IList<Visit> Visits { get; set; }
    }
}
