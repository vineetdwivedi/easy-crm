using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Repositories;
using EasyCRM.Model.Repositories.Entity;

namespace EasyCRM.Model.Services.Impl
{
    public class ContactService : IContactService
    {
        private IValidationDictionary _validationDictionary;
        private IContactRepository _repository;


        public ContactService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new ContactEntityRepository())
        { }


        public ContactService(IValidationDictionary validationDictionary, IContactRepository repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }


        public bool ValidateContact(Contact contactToValidate)
        {
            if (contactToValidate.FirstName.Trim().Length == 0)
                _validationDictionary.AddError("Contact.FirstName", "First name is required.");
            if (contactToValidate.LastName.Trim().Length == 0)
                _validationDictionary.AddError("Contact.LastName", "Last name is required.");
            if (contactToValidate.Address.Trim().Length == 0)
                _validationDictionary.AddError("Contact.Address", "Address is required.");
            if (contactToValidate.Email.Length > 0 && !Regex.IsMatch(contactToValidate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                _validationDictionary.AddError("Contact.Email", "Invalid email address.");
            return _validationDictionary.IsValid;
        }


        #region IContactService Members

        public bool CreateContact(Contact contactToCreate)
        {
            // Validation logic
            if (!ValidateContact(contactToCreate))
                return false;

            // Database logic
            try
            {
                _repository.Create(contactToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditContact(Contact contactToEdit)
        {
            // Validation logic
            if (!ValidateContact(contactToEdit))
                return false;

            // Database logic
            try
            {
                _repository.Update(contactToEdit);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteContact(Contact contactToDelete)
        {
            try
            {
                _repository.Delete(contactToDelete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public Contact GetContact(int id)
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

        public IEnumerable<Contact> ListContacts()
        {
            return _repository.ListAll();
        }

        public IEnumerable<Contact> ListContactsByCriteria(Expression<Func<Contact, bool>> predicate)
        {
            return _repository.ListAllByCriteria(predicate);
        }

        #endregion

    }
}
