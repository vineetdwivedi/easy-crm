using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface IAccountRepository
    {
        Account Create(Account accountToCreate);
        void Delete(Account accountToDelete);
        Account Update(Account accountToUpdate);
        Account Get(int id);
        IEnumerable<Account> ListAll();

    }
}
