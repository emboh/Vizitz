using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models.Account
{
    public class LoginDTO
    {
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 6)]
        public virtual string Password { get; set; }
    }
}
