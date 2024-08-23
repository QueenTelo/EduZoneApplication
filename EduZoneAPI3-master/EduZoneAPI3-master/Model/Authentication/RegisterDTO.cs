using System.ComponentModel.DataAnnotations;

namespace EduZoneAPI3.Model.Authentication
{
    public class RegisterDTO
    {
       // public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string IdentityNumber { get; set; }

        public string PassportNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        public string PhoneNumber { get; set; }
        public string? Password { get; set; }
    }
}
