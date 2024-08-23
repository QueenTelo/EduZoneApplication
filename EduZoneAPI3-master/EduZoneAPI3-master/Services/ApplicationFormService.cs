using EduZoneAPI3.DbContexts;
using EduZoneAPI3.Interfaces.IServices;
using EduZoneAPI3.Model.ApplicationForm;
using EduZoneAPI3.Model.Users;

namespace EduZoneAPI3.Services
{
    public class ApplicationFormService: IApplicationFormService
    {
        private ApplicationDbContext _context;

        public ApplicationFormService(ApplicationDbContext context)
        {
            _context = context;

        }

        public ApplicationForm GetById(string id)
        {
            return _context.Applications.Find(id);
        }

        public void Delete(string id)
        {
            var applicant = _context.Applications.Find(id);

            _context.Applications.Remove(applicant);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationForm> GetAll()
        {
           return _context.Applications;
        }
    }
}
