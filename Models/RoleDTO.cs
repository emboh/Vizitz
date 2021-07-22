using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Vizitz.Models
{
    public class RoleDTO
    {
        public string Id { get; set; }

        public string Name { get; set; }

        [IgnoreDataMember]
        public IList<UserRoleDTO> UserRoles { get; set; }
    }
}
