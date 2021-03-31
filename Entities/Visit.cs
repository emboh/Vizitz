using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vizitz.Entities
{
    public class Visit
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Schedule))]
        public int ScheduleId { get; set; }
        public Schedule Schedule { get; set; }

        [ForeignKey(nameof(Visitor))]
        public int VisitorId { get; set; }
        public User Visitor { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Note { get; set; }

        public int Rate { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
