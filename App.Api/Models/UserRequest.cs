
namespace App.Api.Models
{
    public class UserRequest
    {
        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        public bool IsDeleted { get; set; } = false;
        public string? Phone { get; set; } 
    }
}
