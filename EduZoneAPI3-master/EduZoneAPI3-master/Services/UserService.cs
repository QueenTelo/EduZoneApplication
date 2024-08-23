using AutoMapper;
using EduZoneAPI3.DbContexts;
using EduZoneAPI3.Interfaces.IServices;
using EduZoneAPI3.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace EduZoneAPI3.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public IEnumerable<Users> GetAll()
        {
            return _context.Users;
        }

        public Users GetById(string id)
        {
            return  _context.Users.Find(id);
        }

        public void Delete(string id)
        {
            var user = _context.Users.Find(id);

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
