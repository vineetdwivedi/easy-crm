using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IUserService
    {
        bool CreateUser(User userToCreate);
        bool DeleteUser(User userToDelete);
        bool EditUser(User userToEdit);
        User GetUser(int id);
        User GetUser(string userName);
        IEnumerable<User> ListUsers();



    }
}
