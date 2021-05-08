using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Models.Account;

namespace Vizitz.Models
{
    public class AdminDTO : CreateAdminDTO
    {
        public string Id { get; set; }

        public DateTime? Added { get; set; }

        public DateTime? Modified { get; set; }
    }

    public class CreateAdminDTO : LoginDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
