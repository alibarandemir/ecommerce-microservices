using Microsoft.AspNetCore.Identity;

namespace Identity.Models
{
    public class ApplicationUser:IdentityUser
    {
        public String fullName { get; set; }
    }
}
