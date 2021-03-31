using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Annotations;

namespace Vizitz.Models
{
    public class VisitorDTO : CreateVisitorDTO
    {
        public int Id { get; set; }

        //public new string Avatar { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public virtual IList<VisitDTO> Visits { get; set; }
    }

    public class CreateVisitorDTO
    {
        //[DefaultValue(null)]
        //[FileExtensions(Extensions = "jpg,jpeg,gif,png")]
        //[FileSize(5 * 1024 * 1024)]
        //public IFormFile Avatar { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 16)]
        public string Identification { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        [DefaultValue(null)]
        public string Address { get; set; }

        [Phone]
        [DefaultValue(null)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
