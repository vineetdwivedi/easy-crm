using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Repositories;
using EasyCRM.Model.Repositories.Entity;

namespace EasyCRM.Model.Services.Impl
{
    public class AccountService : IAccountService
    {
        private IValidationDictionary _validationDictionary;
        private IAccountRepository _repository;


        public AccountService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new AccountEntityRepository())
        { }


        public AccountService(IValidationDictionary validationDictionary, IAccountRepository repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }


        public bool ValidateAccount(Account accountToValidate)
        {
            //convert null values to empty strings
            accountToValidate.Name = accountToValidate.Name ?? "";
            accountToValidate.Address = accountToValidate.Address ?? "";
            accountToValidate.Description = accountToValidate.Description ?? "";

            if (accountToValidate.Name.Trim().Length == 0)
                _validationDictionary.AddError("Name", "Name is required.");
            if (accountToValidate.Address.Trim().Length == 0)
                _validationDictionary.AddError("Address", "Address is required.");
            if (accountToValidate.Description.Trim().Length == 0)
                _validationDictionary.AddError("Description", "Description is required.");
            return _validationDictionary.IsValid;
        }


        #region IAccountService Members

        public bool CreateAccount(Account accountToCreate)
        {
            // Validation logic
            if (!ValidateAccount(accountToCreate))
                return false;

            // Database logic
            try
            {
                _repository.Create(accountToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditAccount(Account accountToEdit)
        {
            // Validation logic
            if (!ValidateAccount(accountToEdit))
                return false;

            // Database logic
            try
            {
                _repository.Update(accountToEdit);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteAccount(Account accountToDelete)
        {
            try
            {
                _repository.Delete(accountToDelete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Account GetAccount(int id)
        {
            try
            {
                return _repository.Get(id);
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Account> ListAccounts()
        {
            return _repository.ListAll();
        }

        public IEnumerable<Account> ListAccountsByCriteria(Expression<Func<Account, bool>> predicate)
        {
            return _repository.ListAllByCriteria(predicate);
        }
        #endregion

    }
}
