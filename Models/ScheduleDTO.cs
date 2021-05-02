using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;

namespace Vizitz.Models
{
    public class ScheduleDTO : CreateScheduleDTO
    {
        public string Id { get; set; }

        public VenueDTO Venue { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VisitDTO> Visits { get; set; }
    }

    public class CreateScheduleDTO
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartedAt { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FinishedAt { get; set; }

        [Required]
        [Range(0, Int64.MaxValue)]
        public int Capacity { get; set; }

        [StringLength(255)]
        [DefaultValue(null)]
        public string Note { get; set; }

        [DefaultValue(true)]
        public bool IsValid { get; set; }

        [Required]
        public string VenueId { get; set; }
    }
}
