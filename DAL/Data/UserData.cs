using DAL.Interface;
using Models.Models;
using Microsoft.EntityFrameworkCore;
namespace DAL.Data
{
    public class UserData:IUser
    {
        private readonly DataProjectContext _context;

        public UserData(DataProjectContext context)
        {
            _context = context;
        }
        public async Task<List<User>> getAllUsers()
        {
            List<User> users = await _context.User.ToListAsync();
            return users;
        }
        public async Task<bool> AddUser(User user)
        {
            //User user = new();
            await _context.User.AddAsync(user);
            try
            {
                var isOk = _context.SaveChanges() >= 0;
            }catch (Exception ex)
            {
                return false;
            }
            return true ;
        }
        public async Task<bool> DeleteUser(int id)
        {
            var idUser = _context.User.FirstOrDefault(x => x.Id == id);
            _context.User.Remove(idUser);
            var isOk = _context.SaveChanges() >= 0;
            return isOk;
        }
        public async Task<bool> UpdateUser(int id, User user)
        {
            var idUser = _context.User.FirstOrDefault(x => x.Id == id);
            if (idUser == null)
            {
                return false;
            }
            idUser.Name = user.Name;
            idUser.Address = user.Address;
            idUser.Email = user.Email;
            idUser.Phone = user.Phone;
            var isOk = _context.SaveChanges() > 0;
            return isOk;
        }
    }
}
