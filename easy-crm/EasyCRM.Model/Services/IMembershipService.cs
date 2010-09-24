using System.Web.Security;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string login, string password);
        bool UpdateUser(User userToUpdate, string oldPassword);
        User GetUser(string userName);
        MembershipCreateStatus CreateUser(User userToCreate);
        bool DeleteUser(User userToDelete);
        
    }
}
