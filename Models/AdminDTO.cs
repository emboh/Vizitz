using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class AdminDTO : CreateAdminDTO
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }

    public class CreateAdminDTO
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DefaultValue(true)]
        public bool? IsActive { get; set; }
    }
}
