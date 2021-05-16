﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models.Account
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
        public virtual string PhoneNumber { get; set; }

        [MinLength(1)]
        public virtual IList<string> Roles { get; set; }
    }
}
