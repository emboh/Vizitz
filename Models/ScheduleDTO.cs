using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;

namespace Vizitz.Models
{
    public class ScheduleDTO
    {
        public string Id { get; set; }

        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public int Capacity { get; set; }

        public string Note { get; set; }

        public bool? IsValid { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual VenueDTO Venue { get; set; }

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

        public int Capacity { get; set; }

        public string Note { get; set; }

        public bool? IsValid { get; set; }

        public string VenueId { get; set; }
    }

    public class UpdateScheduleDTO
    {
        public DateTime StartedAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public int Capacity { get; set; }

        public string Note { get; set; }

        public bool? IsValid { get; set; }

        public string VenueId { get; set; }
    }
}
