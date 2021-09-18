using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Vizitz.Annotations;
using Vizitz.Entities;
using Vizitz.Models.Account;

namespace Vizitz.Models
{
    public class VisitorDTO
    {
        public string Id { get; set; }

        // TODO : add avatar file image
        //public new string Avatar { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }

        public virtual IList<VisitDTO> Visits { get; set; }

        public virtual IList<UserRoleDTO> UserRoles { get; set; }
    }

    public class CreateVisitorDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }
    }

    public class UpdateVisitorDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public bool? IsActive { get; set; }

        public virtual IList<string> Roles { get; set; }

        //[DefaultValue(null)]
        //[FileExtensions(Extensions = "jpg,jpeg,gif,png")]
        //[FileSize(5 * 1024 * 1024)]
        //public IFormFile Avatar { get; set; }
    }
}
