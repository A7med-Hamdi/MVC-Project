using Microsoft.AspNetCore.Identity;

namespace ProjectLapDay2.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string address { get; set; }
    }
}
