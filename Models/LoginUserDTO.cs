using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models
{
    public class LoginUserDTO
    {
        [EmailAddress]
        [DefaultValue(null)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
