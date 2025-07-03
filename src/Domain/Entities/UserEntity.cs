using SharedKernel.Domain.Seedwork;

namespace Domain.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Username { get; set; }
        public RoleEntity Role { get; set; }
    }
}