using System;
using System.Web.Mvc;
using System.Web.Security;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using EasyCRM.WebApp.Services;
using EasyCRM.WebApp.Services.Impl;
using EasyCRM.WebApp.ViewModels;
using System.Web.UI;
using System.Net;

namespace EasyCRM.WebApp.Controllers
{

    [HandleError]
    public class UserController : Controller
    {

        public IFormsAuthenticationService _formsService;
        public IMembershipService _membershipService;

        public UserController()
        {
            _formsService = new FormsAuthenticationService();
            _membershipService = new MembershipService(new UserService(new ModelStateWrapper(this.ModelState)));

        }

        public UserController(IFormsAuthenticationService formsService, IMembershipService membershipService)
        {
            _formsService = formsService;
            _membershipService = membershipService;

        }

        // 
        // URL: /User/LogOn

        public ActionResult LogOn()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (_membershipService.ValidateUser(model.UserName, model.Password))
                {
                    _formsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name and / or password provided are incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // 
        // URL: /User/LogOff
        [Authorize]
        public ActionResult LogOff()
        {
            _formsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // 
        // URL: /User/Register

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = _membershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register([Bind(Exclude = "Id,IsAdmin")]User user)
        {
            if (ModelState.IsValid)
            {
                user.IsAdmin = false;
                // Attempt to register the user
                MembershipCreateStatus createStatus = _membershipService.CreateUser(user);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    _formsService.SignIn(user.UserName, false /* createPersistentCookie*/ );
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", MembershipService.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = _membershipService.MinPasswordLength;
            return View(user);
        }

        // 
        // URL: /User/Edit/

        [Authorize]
        public ActionResult Edit(String userName)
        {
            ViewData["PasswordLength"] = _membershipService.MinPasswordLength;

            //convert userName to empty string if null
            userName = userName ?? "";

            //we get the user form db by is username, and send it to the view     
            User user = _membershipService.GetUser(userName);

            if (user == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(string userName, FormCollection formValues)
        {
            // we retrieve existing user from the db
            User user = _membershipService.GetUser(userName);

            string oldPassword = user.Password;

            // we update user with form posted values
            TryUpdateModel(user);

            if (ModelState.IsValid)
            {
                if (_membershipService.UpdateUser(user, oldPassword))
                {
                    return View("Success");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = _membershipService.MinPasswordLength;
            return View(user);
        }


    }
}
