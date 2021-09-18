using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class VisitDTO
    {
        public string Id { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Note { get; set; }

        public int? Rate { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual ScheduleDTO Schedule { get; set; }

        public virtual VisitorDTO Visitor { get; set; }
    }

    public class CreateVisitDTO
    {
        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Note { get; set; }

        public int? Rate { get; set; }

        public bool? IsValid { get; set; }

        public string ScheduleId { get; set; }

        public string VisitorId { get; set; }
    }

    public class UpdateVisitDTO
    {
        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Note { get; set; }

        public int? Rate { get; set; }

        public bool? IsValid { get; set; }

        public string ScheduleId { get; set; }

        public string VisitorId { get; set; }
    }
}
