using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class VisitDTO : CreateVisitDTO
    {
        public int Id { get; set; }

        public ScheduleDTO Schedule { get; set; }

        public VisitorDTO Visitor { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }
    }

    public class CreateVisitDTO
    {
        [DataType(DataType.DateTime)]
        [DefaultValue(null)]
        public DateTime StartedAt { get; set; }

        [DataType(DataType.DateTime)]
        [DefaultValue(null)]
        public DateTime FinishedAt { get; set; }

        [DefaultValue(null)]
        [StringLength(255)]
        public string Note { get; set; }

        [DefaultValue(null)]
        [Range(1, 5)]
        public int Rate { get; set; }

        [DefaultValue(true)]
        public bool? IsValid { get; set; }

        [Required]
        public int VisitorId { get; set; }

        [Required]
        public int VenueId { get; set; }
    }
}
