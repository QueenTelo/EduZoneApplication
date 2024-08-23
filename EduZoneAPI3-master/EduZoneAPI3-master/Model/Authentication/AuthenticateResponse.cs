using System.ComponentModel.DataAnnotations;

namespace EduZoneAPI3.Model.Authentication
{
    public class AuthenticateResponse
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
