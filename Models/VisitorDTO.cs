using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Annotations;
using Vizitz.Entities;
using Vizitz.Models.User;

namespace Vizitz.Models
{
    public class VisitorDTO : UpdateVisitorDTO
    {
        public string Id { get; set; }

        //public new string Avatar { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VisitDTO> Visits { get; set; }
    }

    public class UpdateVisitorDTO : RegisterDTO
    {
        [EmailAddress]
        public override string Email { get; set; }

        [StringLength(255, MinimumLength = 6)]
        public override string Password { get; set; }

        [StringLength(16, MinimumLength = 16)]
        public override string Identification { get; set; }

        [StringLength(255)]
        public override string Name { get; set; }

        [StringLength(255)]
        [DefaultValue(null)]
        public override string Address { get; set; }

        [Phone]
        [DefaultValue(null)]
        public override string Phone { get; set; }

        [Range(typeof(bool), "false", "true")]
        public bool? IsActive { get; set; }

        //[DefaultValue(null)]
        //[FileExtensions(Extensions = "jpg,jpeg,gif,png")]
        //[FileSize(5 * 1024 * 1024)]
        //public IFormFile Avatar { get; set; }
    }
}
