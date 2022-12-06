using System.ComponentModel.DataAnnotations;

namespace ProjectLapDay2.Models
{
    public class RrgisteruserVM
    {
        [Required]
        public string username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string confirmpassword { get; set; }
        public string Address { get; set; }
    }
}
