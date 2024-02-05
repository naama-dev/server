using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IUser
    {
        Task<List<User>> getAllUsers();
        Task<bool> AddUser(User user);
        Task<bool> DeleteUser(int id);
        Task<bool> UpdateUser(int id, User user);
    }
}
