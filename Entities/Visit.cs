using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Vizitz.IEntities;

namespace Vizitz.Entities
{
    public class Visit : IHasTimestamps
    {
        public Guid Id { get; set; }

        public DateTime? StartedAt { get; set; }

        public DateTime? FinishedAt { get; set; }

        public string Note { get; set; }

        public int? Rate { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }

        [Required]
        public Guid ScheduleId { get; set; }

        public virtual Schedule Schedule { get; set; }

        [Required]
        public Guid VisitorId { get; set; }

        public virtual User Visitor { get; set; }
    }
}
