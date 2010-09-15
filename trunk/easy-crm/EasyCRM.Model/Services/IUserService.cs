using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IUserService
    {
        //we need this, because this service can be coupled with a other
        //( eg: in the mvc app, it's coupled with the MembershipService
        void addError(string key, string errorMessage);

        bool CreateUser(User userToCreate);
        bool DeleteUser(User userToDelete);
        bool EditUser(User userToEdit);
        User GetUser(int id);
        User GetUser(string userName);
        IEnumerable<User> ListUsers();



    }
}
