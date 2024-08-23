using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EduZoneAPI2.Model
{
    public class Login
    {

        [Key]

        public int Id {  get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
