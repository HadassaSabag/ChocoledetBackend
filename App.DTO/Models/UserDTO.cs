

namespace App.DTO.Models
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public virtual ICollection<OrderDTO> Orders { get; set; } = new List<OrderDTO>();
    }
}
