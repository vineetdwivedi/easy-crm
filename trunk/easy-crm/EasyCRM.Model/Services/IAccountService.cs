using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface IAccountService
    {
        bool CreateAccount(Account accountToCreate);
        bool DeleteAccount(Account accountToDelete);
        bool EditAccount(Account accountToEdit);
        Account GetAccount(int id);
        IEnumerable<Account> ListAccounts();

    }
}
