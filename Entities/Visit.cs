using System;
using System.ComponentModel.DataAnnotations.Schema;
using Vizitz.IEntities;

namespace Vizitz.Entities
{
    public class Visit : IHasTimestamps
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //[ForeignKey(nameof(Schedule))]
        //public Guid ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        //[ForeignKey(nameof(Visitor))]
        //public Guid VisitorId { get; set; }
        public User Visitor { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Note { get; set; }

        public int Rate { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }
    }
}
