using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Vizitz.Models.Account
{
    public class RegisterDTO
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Identification { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public IList<string> Roles { get; set; }
    }
}
