using EduZoneAPI3.Model.Users;

namespace EduZoneAPI3.Interfaces.IServices
{
    public interface ITokenService
    {
        string CreateToken(Users users);
    }
}
