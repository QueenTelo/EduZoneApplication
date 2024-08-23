using System.ComponentModel.DataAnnotations;

namespace EduZoneAPI3.Model
{
    public class Guardian
    {
        [Key]
        public int GaudianId { get; set; }
        public string GardianName { get; set; }
        public string GardianSurname { get; set; }
        public string GuardianOccupation {get; set;}
        public string GuardianPhoneNumber { get; set;}

    }
}
