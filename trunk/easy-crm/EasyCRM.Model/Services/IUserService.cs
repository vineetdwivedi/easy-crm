using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IUserService
    {
        //we need this, because this service can be coupled with an other
        //( eg:  the MembershipService
        void AddError(string key, string errorMessage);

        bool CreateUser(User userToCreate);
        bool DeleteUser(User userToDelete);
        bool EditUser(User userToEdit);
        User GetUser(int id);
        User GetUser(string userName);
        IEnumerable<User> ListUsers();



    }
}
