using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Vizitz.Entities;

namespace Vizitz.Models // TODO : add to different namespace
{
    public class RegisterDTO : LoginDTO
    {
        [Required]
        [StringLength(16, MinimumLength = 16)]
        public virtual string Identification { get; set; }

        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }

        [StringLength(255)]
        [DefaultValue(null)]
        public virtual string Address { get; set; }

        [Phone]
        [DefaultValue(null)]
        public virtual string Phone { get; set; }

        // TODO : add rule for roles
        public ICollection<string> Roles { get; set; }
    }
}
