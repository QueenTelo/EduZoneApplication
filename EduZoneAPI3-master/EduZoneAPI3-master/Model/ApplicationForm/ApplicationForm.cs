using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduZoneAPI3.Model.ApplicationForm
{
    public class ApplicationForm
    {
        [Key]
        public int ApplicationId { get; set; }
        public int UserId { get; set; }
        public string ApplicantName { get; set; }
        public string ApplicantSurname { get; set; }
        public string ApplicantDateOfBirth { get; set; }
        public string ApplicantGender { get; set; }
        public string ApplicantPhoneNumber { get; set; }
        public string ApplicantEmail { get; set; }
        public string ApplicantIDNo { get; set; }
        public string ApplicantPassPortNumber { get; set; }//
        public string ApplicantAddress { get; set; }
        public string ApplicantGradeLevel { get; set; }//
        public string ApplicantSchoolYear { get; set; }//



    }
}
