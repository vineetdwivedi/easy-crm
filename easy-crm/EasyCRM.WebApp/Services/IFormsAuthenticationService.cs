using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasyCRM.WebApp.Services
{
    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the UserController
    // code unit testable.

    public interface IFormsAuthenticationService
    {
        void SignIn(string login, bool createPersistentCookie);
        void SignOut();
    }
}
