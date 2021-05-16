using System.Collections.Generic;

namespace Vizitz.Models
{
    public class RoleDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public IList<UserRoleDTO> UserRoles { get; set; }
    }
}
