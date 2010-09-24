using System;
using System.Web.Security;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services.Impl
{
    public class MembershipService : IMembershipService
    {
        private readonly MembershipProvider _provider;
        private IUserService _userService;

        public MembershipService(IUserService userService)
        {
            _provider = Membership.Provider;
            _userService = userService;
        }

        public MembershipService(MembershipProvider provider, IUserService userService)
        {
            _provider = provider ?? Membership.Provider;
            _userService = userService;
        }

        public int MinPasswordLength
        {
            get
            {
                return _provider.MinRequiredPasswordLength;
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            //convert null values to empty strings
            userName = userName ?? "";
            password = password ?? "";

            return _provider.ValidateUser(userName, password);
        }

        public MembershipCreateStatus CreateUser(User userToCreate)
        {
            //convert null values to empty strings
            string userName = userToCreate.UserName ?? "";
            string password = userToCreate.Password ?? "";
            string email = userToCreate.Email ?? "";

            MembershipCreateStatus status;
            //we try to create the user in the aspnet membership management database
            _provider.CreateUser(userName, password,email, null, null, true, null, out status);

            //we create our "representation" of the user in our application database
            if (status == MembershipCreateStatus.Success)
            {
                if (_userService.CreateUser(userToCreate))
                {
                    _provider.DeleteUser(userName, true);
                    return MembershipCreateStatus.ProviderError;
                }
            }
            else
            {
                _userService.AddError("otherError", MembershipService.ErrorCodeToString(status));
            }
            return status;

        }

        public bool DeleteUser(User userToDelete)
        {
            string userName = userToDelete.UserName ?? "";

            //we delete the user in the aspnet membership management database
            if (_provider.DeleteUser(userToDelete.UserName, false))
            {  //we delete our "representation" of the user in our application database
                return _userService.DeleteUser(userToDelete);
            }
            return false;
        }

        public User GetUser(String userName)
        {
            return _userService.GetUser(userName);
        }

        public bool UpdateUser(User userToUpdate, string oldPassword)
        {
            string newPassword = userToUpdate.Password ?? "";

            if (newPassword.Length < this.MinPasswordLength)
            {
                _userService.AddError("Password", "The password must be at least " + MinPasswordLength + " characters long.");
                return false;
            } 

            // The underlying ChangePassword() will throw an exception rather
            // than return false in certain failure scenarios.
            try
            {
                int nb;
                MembershipUserCollection v = _provider.GetAllUsers(0,10,out nb);
                MembershipUser currentUser = _provider.GetUser(userToUpdate.UserName, true /* userIsOnline */);

                //we update the password of the user in the aspnet membership management database
                if (currentUser.ChangePassword(oldPassword, userToUpdate.Password))
                    //we also update the password of the user in our application database
                    return _userService.EditUser(userToUpdate);

                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            catch (MembershipPasswordException)
            {
                return false;
            }

        }

        public static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "UserName already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
    }

}