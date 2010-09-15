using System;
using System.Web.Security;

namespace EasyCRM.WebApp.Services.Impl
{
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the UserController
    // code unit testable.



    public class FormsAuthenticationService : IFormsAuthenticationService
    {
        public void SignIn(string login, bool createPersistentCookie)
        {
            if (String.IsNullOrEmpty(login)) throw new ArgumentException("Value cannot be null or empty.", "login");

            FormsAuthentication.SetAuthCookie(login, createPersistentCookie);
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}