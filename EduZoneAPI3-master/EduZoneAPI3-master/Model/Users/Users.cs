using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduZoneAPI3.Model.Users
{
    public class Users : IdentityUser
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }        
        public string IdentityNumber { get; set; }
        public string PassportNumber { get; set; }
        public string PhoneNumber { get; set; }
       
    }
}
