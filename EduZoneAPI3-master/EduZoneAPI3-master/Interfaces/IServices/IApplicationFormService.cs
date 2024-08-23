using EduZoneAPI3.Model.ApplicationForm;
using EduZoneAPI3.Model.Users;

namespace EduZoneAPI3.Interfaces.IServices
{
    public interface IApplicationFormService
    {
        IEnumerable<ApplicationForm> GetAll();
        ApplicationForm GetById(string id);

        void Delete(string id);
    }
}
