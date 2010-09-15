using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface IUserRepository
    {
        User Create(User userToCreate);
        void Delete(User userToDelete);
        User Update(User userToUpdate);
        User Get(int id);
        User Get(string  userName);
        IEnumerable<User> ListAll();
    }
}
