using System.Collections.Generic;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Services
{
    public interface IAccountService
    {
        bool CreateAccount(Account accountToCreate);
        bool DeleteAccount(Account accountToDelete);
        bool EditAccount(Account accountToEdit);
        Account GetAccount(int id);
        IEnumerable<Account> ListAccounts();
        IEnumerable<Account> ListAccountsByCriteria(Expression<Func<Account, bool>> predicate);
    }
}
