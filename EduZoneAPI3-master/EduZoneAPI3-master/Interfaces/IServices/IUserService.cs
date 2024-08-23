
using EduZoneAPI3.Model.Users;


namespace EduZoneAPI3.Interfaces.IServices
{
    public interface IUserService
    {
       // AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<Users> GetAll();
        Users GetById(string id);
      //  string Register(Users users);
        //void Update(int id, UpdateRequest model);
       void Delete(string id);
    }
}
