using System.Collections.Generic;
using System.Text.RegularExpressions;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Repositories;
using EasyCRM.Model.Repositories.Entity;

namespace EasyCRM.Model.Services.Impl
{
    public class UserService : IUserService
    {
        private IValidationDictionary _validationDictionary;
        private IUserRepository _repository;


        public UserService(IValidationDictionary validationDictionary)
            : this(validationDictionary, new UserEntityRepository())
        { }


        public UserService(IValidationDictionary validationDictionary, IUserRepository repository)
        {
            _validationDictionary = validationDictionary;
            _repository = repository;
        }


        public bool ValidateUser(User userToValidate)
        {
            if (userToValidate.FirstName.Trim().Length == 0)
                _validationDictionary.AddError("FirstName", "First Name is required.");
            if (userToValidate.LastName.Trim().Length == 0)
                _validationDictionary.AddError("LastName", "Last Name is required.");
            if (userToValidate.UserName.Trim().Length == 0)
                _validationDictionary.AddError("UserName", "User Name is required.");
            if (userToValidate.Password.Trim().Length == 0)
                _validationDictionary.AddError("Password", "Password is required.");
            if (userToValidate.Email.Length > 0 && !Regex.IsMatch(userToValidate.Email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                _validationDictionary.AddError("Email", "Invalid Email Address.");
            return _validationDictionary.IsValid;
        }

        public void addError(string key, string errorMessage)
        {
            _validationDictionary.AddError(key, errorMessage);
        }


        #region IUserService Members

        public bool CreateUser(User userToCreate)
        {
            // Validation logic
            if (!ValidateUser(userToCreate))
                return false;

            // Database logic
            try
            {
                _repository.Create(userToCreate);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool EditUser(User userToEdit)
        {
            // Validation logic
            if (!ValidateUser(userToEdit))
                return false;

            // Database logic
            try
            {
                _repository.Update(userToEdit);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool DeleteUser(User userToDelete)
        {
            try
            {
                _repository.Delete(userToDelete);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public User GetUser(int id)
        {
            return _repository.Get(id);
        }

        public User GetUser(string userName)
        {
            try
            {
                return _repository.Get(userName);
            }
            catch
            {
                return null;
            }
        }


        public IEnumerable<User> ListUsers()
        {
            return _repository.ListAll();
        }

        #endregion

    }
}
