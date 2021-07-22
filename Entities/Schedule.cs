using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Vizitz.IEntities;

namespace Vizitz.Entities
{
    public class Schedule : IHasTimestamps
    {
        public Guid Id { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public int Capacity { get; set; }

        public string Note { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }

        public virtual Venue Venue { get; set; }

        public virtual IList<Visit> Visits { get; set; }
    }
}
