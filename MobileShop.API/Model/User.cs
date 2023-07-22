using Microsoft.EntityFrameworkCore;

namespace MobileShop.API.Model
{
    public class User// UserDto DTO-Data Transfer Object
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }
    }
}
