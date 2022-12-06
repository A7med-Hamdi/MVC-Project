using System.ComponentModel.DataAnnotations;

namespace ProjectLapDay2.Models
{
    public class login
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
