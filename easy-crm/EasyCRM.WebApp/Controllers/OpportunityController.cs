using System.Net;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using EasyCRM.WebApp.ViewModels;
using System;

namespace EasyCRM.WebApp.Controllers
{
    [Authorize]
    public class OpportunityController : Controller
    {

        IOpportunityService _opportunityService;
        IUserService _userService;
        IAccountService _accountService;

        public OpportunityController()
        {
            _opportunityService = new OpportunityService(new ModelStateWrapper(this.ModelState));
            _userService = new UserService(new ModelStateWrapper(this.ModelState));
            _accountService = new AccountService(new ModelStateWrapper(this.ModelState));
        }

        public OpportunityController(IOpportunityService service, IUserService userService, IAccountService accountService)
        {
            _opportunityService = service;
            _userService = userService;
            _accountService = accountService;
        }

        //
        // GET: /Opportunity/

        public ActionResult Index()
        {
            //we list all opportunities of the user from db, and pass them to the view
            string userName = this.User.Identity.Name;

            var opportunities = _opportunityService.ListOpportunitiesByCriteria(
                opportunity => opportunity.ResponsibleUser.UserName == userName);
           
            return View(opportunities);
        }

        //
        // GET: /Opportunity/Details/5

        public ActionResult Details(int id)
        {
            Opportunity opportunity = _opportunityService.GetOpportunity(id);

            if (opportunity == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(opportunity);
        }

        //
        // GET: /Opportunity/Create

        public ActionResult Create()
        {
            var accounts = _accountService.ListAccounts();
            var viewModel = new OpportunityViewModel
            {
                Accounts = new SelectList(accounts, "Id", "Name")
            };

            return View(viewModel);
        }

        //
        // POST: /Opportunity/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Opportunity opportunity)
        {           
            string userName = this.User.Identity.Name;
            int accountId = Int32.Parse(Request.Form["Opportunity.AccountId"]);/*we prefix, as the account is inside the Opportunity editor*/
            
            //we get the user responsible for the opportunity
            User responsibleUser = _userService.GetUser(userName);
            //we get the account from the db
            Account account = _accountService.GetAccount(accountId);

            opportunity.ResponsibleUser = responsibleUser;
            opportunity.Account = account;

            if (!_opportunityService.CreateOpportunity(opportunity))
            {
                var accounts = _accountService.ListAccounts();
                var viewModel = new OpportunityViewModel(opportunity)
                {
                    Accounts = new SelectList(accounts, "Id", "Name")
                };

                return View(viewModel);
            }
            
            return RedirectToAction("Index");
        }

        //
        // GET: /Opportunity/Edit/5

        public ActionResult Edit(int id)
        {
            //getting the opportunity to edit
            Opportunity opportunity = _opportunityService.GetOpportunity(id);

            if (opportunity == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            var accounts = _accountService.ListAccounts();
            var viewModel = new OpportunityViewModel(opportunity)
            {
                Accounts = new SelectList(accounts, "Id", "Name")
            };

            return View(viewModel);

        }

        //
        // POST: /Opportunity/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            // we retrieve existing opportunity from the db
            Opportunity opportunity = _opportunityService.GetOpportunity(id);

            if (opportunity == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            // we update the opportunity with form posted values
            TryUpdateModel(opportunity, "Opportunity" /*prefix, as the opportunity is inside the Opportunity editor"*/);

            int accountId = Int32.Parse(Request.Form["Opportunity.AccountId"]);/*we prefix, as the account is inside the Opportunity editor*/

            //if the opportunity account has changed, we update it in the model
            if (accountId != opportunity.Account.Id)
            {
                opportunity.Account = _accountService.GetAccount(accountId);
            }


            if (!_opportunityService.EditOpportunity(opportunity))
            {
                var accounts = _accountService.ListAccounts();
                var viewModel = new OpportunityViewModel(opportunity)
                {
                    Accounts = new SelectList(accounts, "Id", "Name")
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Opportunity/Delete/5

        public ActionResult Delete(int id)
        {
            Opportunity opportunity = _opportunityService.GetOpportunity(id);

            if (opportunity == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(opportunity);
        }

        //
        // POST: /Opportunity/Delete/5

        [HttpPost]
        public ActionResult Delete(Opportunity opportunity)
        {
            if (!_opportunityService.DeleteOpportunity(opportunity))
                return View(opportunity);
            return RedirectToAction("Index");
        }


        //
        // GET: /Opportunity/Search

       public ActionResult Search()
        {
            return View(new SearchOpportunityViewModel());
        }

        //
        // POST: /Opportunity/Search/5

        [HttpPost]
       public ActionResult Search(FormCollection formValues)
        {
            //we get the opportunities matching the criteria from the db, and pass them to Index view
            string status = formValues["Status"];
            string userName = this.User.Identity.Name;

            var opportunities = _opportunityService.ListOpportunitiesByCriteria(opportunity => (opportunity.ResponsibleUser.UserName == userName) &&
                                                                                opportunity.Status.Contains(status) );

            return View("Index", opportunities);
        }
    }
}
