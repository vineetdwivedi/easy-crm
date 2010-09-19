using System.Collections.Generic;
using System.Linq;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Repositories.Entity
{
    public class AccountEntityRepository : IAccountRepository
    {
        private EasyCRMDBEntities _entities = EntityRepository.GetEntities();

        #region IAccountRepository Members
        public Account Create(Account accountToCreate)
        {
            _entities.AddToAccountSet(accountToCreate);
            _entities.SaveChanges();
            return accountToCreate;

        }

        public void Delete(Account accountToDelete)
        {
            var originalAccount = Get(accountToDelete.Id);
            _entities.DeleteObject(originalAccount);
            _entities.SaveChanges();

        }

        public Account Update(Account accountToUpdate)
        {
            var originalAccount = Get(accountToUpdate.Id);
            _entities.ApplyCurrentValues(originalAccount.EntityKey.EntitySetName, accountToUpdate);
            _entities.SaveChanges();
            return accountToUpdate;

        }

        public Account Get(int id)
        {
            return _entities.AccountSet.First(account => account.Id == id);
        }

        public IEnumerable<Account> ListAll()
        {
            return _entities.AccountSet.ToList();
        }

        public IEnumerable<Account> ListAllByCriteria(Expression<Func<Account, bool>> predicate)
        {
            return _entities.AccountSet.Where(predicate);
        }
        #endregion

    }
}
