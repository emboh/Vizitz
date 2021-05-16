using System.Runtime.Serialization;

namespace Vizitz.Models
{
    public class UserRoleDTO
    {
        [IgnoreDataMember]
        public string UserId { get; set; }

        [IgnoreDataMember]
        public UserDTO User { get; set; }

        [IgnoreDataMember]
        public string RoleId { get; set; }

        public RoleDTO Role { get; set; }
    }
}
