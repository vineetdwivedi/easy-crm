using System;
using System.Net;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using EasyCRM.WebApp.ViewModels;

namespace EasyCRM.WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        IAccountService _accountService;
        IUserService _userService;
        IIndustrialSectorService _sectorService;
        ITaskService _taskService;
        IContactService _contactService;
        IOpportunityService _opportunityService;

        public AccountController()
        {
            _accountService = new AccountService(new ModelStateWrapper(this.ModelState));
            _userService = new UserService(new ModelStateWrapper(this.ModelState));
            _sectorService = new IndustrialSectorService(new ModelStateWrapper(this.ModelState));
            _taskService = new TaskService(new ModelStateWrapper(this.ModelState));
            _contactService = new ContactService(new ModelStateWrapper(this.ModelState));
            _opportunityService = new OpportunityService(new ModelStateWrapper(this.ModelState));
        }

        public AccountController(IAccountService service, IUserService userService, IIndustrialSectorService sectorService,
                                 ITaskService taskService, IContactService contactService, IOpportunityService opportunityService)
        {
            _accountService = service;
            _userService = userService;
            _sectorService = sectorService;
            _taskService = taskService;
            _contactService = contactService;
            _opportunityService = opportunityService;
        }

        //
        // GET: /Account/

        public ActionResult Index()
        {
            //we retrieve all accounts of the user from db, and pass them to the view
            string userName = this.User.Identity.Name;

            var accounts = _accountService.ListAccountsByCriteria(
                account => account.Owner.UserName == userName);

            return View(accounts);
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id)
        {
            Account account = _accountService.GetAccount(id);

            if (account == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(account);
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            var sectors = _sectorService.ListIndustrialSectors();
            var viewModel = new AccountViewModel
            {
                Sectors = new SelectList(sectors, "Id", "Sector")
            };

            return View(viewModel);
        }

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Account account)
        {
            string userName = this.User.Identity.Name;
            int sectorId = Int32.Parse(Request.Form["Account.SectorId"]);/*we prefix, as the sector is inside the Account editor*/
            /*and isn't directly bound as field of the Account*/

            //we get the owner the account
            User owner = _userService.GetUser(userName);

            //we get the industrial sector from the db
            IndustrialSector sector = _sectorService.GetIndustrialSector(sectorId);

            account.Owner = owner;
            account.IndustrialSector = sector;

            if (!_accountService.CreateAccount(account))
            {
                var sectors = _sectorService.ListIndustrialSectors();
                var viewModel = new AccountViewModel(account)
                {
                    Sectors = new SelectList(sectors, "Id", "Sector")
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id)
        {
            //getting the account to edit
            Account account = _accountService.GetAccount(id);

            if (account == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            var sectors = _sectorService.ListIndustrialSectors();
            var viewModel = new AccountViewModel(account)
            {
                Sectors = new SelectList(sectors, "Id", "Sector", account.IndustrialSector.Id)
            };

            return View(viewModel);

        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            // we retrieve existing account from the db
            Account account = _accountService.GetAccount(id);

            if (account == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            // we update the account with form posted values
            TryUpdateModel(account, "Account" /*prefix, as the account is inside the Account editor*/);
            
            int sectorId = Int32.Parse(Request.Form["Account.SectorId"]);/*we prefix, as the sector is inside the Account editor*/

            //if the account sector has changed, we update it in the model
            if (sectorId != account.IndustrialSector.Id)
            {
                account.IndustrialSector = _sectorService.GetIndustrialSector(sectorId);
            }

            if (!_accountService.EditAccount(account))
            {
                var sectors = _sectorService.ListIndustrialSectors();
                var viewModel = new AccountViewModel(account)
                {
                    Sectors = new SelectList(sectors, "Id", "Sector", account.IndustrialSector.Id)
                };

                return View(viewModel);
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id)
        {
            Account account = _accountService.GetAccount(id);

            if (account == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(account);
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(Account account)
        {
            if (!_accountService.DeleteAccount(account))
                return View(account);
            return RedirectToAction("Index");
        }


        //
        // GET: /Account/AddTask

        public ActionResult AddTask(int id /*id of the account*/)
        {
            string userName = this.User.Identity.Name;

            //we retrieve from the db the tasks of the user, that haven't been assigned to an account yet
            var tasks = _taskService.ListTasksByCriteria(task => (task.ResponsibleUser.UserName == userName) &&
                                                                 (task.Account == null));
            var viewModel = new AddTaskViewModel
            {
                AccountId = id,
                Tasks = new SelectList(tasks, "Id", "Subject", 1)
            };

            return View(viewModel);
        }

        //
        // POST: /Account/AddTask/5

        [HttpPost]
        public ActionResult AddTask(int id /*id of the account*/, FormCollection formValues)
        {
            int taskId = Int32.Parse(formValues["TaskId"]);

            //we retrieve the task to add to the account
            Task task = _taskService.GetTask(taskId);
            //we retrieve the account to add the task to
            Account account = _accountService.GetAccount(id);

            account.Tasks.Add(task);

            if (!_accountService.EditAccount(account))
            {
                //we redisplay the form in case something goes wrong
                string userName = this.User.Identity.Name;

                //we retrieve from the db the tasks of the user, that haven't been assigned to an account yet
                var tasks = _taskService.ListTasksByCriteria(t => (t.ResponsibleUser.UserName == userName) &&
                                                                  (t.Account == null));
                var viewModel = new AddTaskViewModel
                {
                    AccountId = id,
                    Tasks = new SelectList(tasks, "Id", "Subject", 1)
                };

                return View(viewModel);
            }

            return View("Details", account);
        }

        //
        // GET: /Account/AddTask

        public ActionResult AddContact(int id /*id of the account*/)
        {
            string userName = this.User.Identity.Name;

            //we retrieve from the db the contacts of the user, that haven't been assigned to an account yet
            var tasks = _contactService.ListContactsByCriteria(contact => (contact.ResponsibleUser.UserName == userName) &&
                                                                          (contact.Account == null));
            var viewModel = new AddContactViewModel
            {
                AccountId = id,
                Contacts = new SelectList(tasks, "Id", "Email", 1)
            };

            return View(viewModel);
        }

        //
        // POST: /Account/AddContact/5

        [HttpPost]
        public ActionResult AddContact(int id /*id of the account*/, FormCollection formValues)
        {
            int contactId = Int32.Parse(formValues["ContactId"]);

            //we retrieve the contact to add to the contact
            Contact contact = _contactService.GetContact(contactId);
            //we retrieve the account to add the contact to
            Account account = _accountService.GetAccount(id);

            account.Contacts.Add(contact);

            if (!_accountService.EditAccount(account))
            {
                //we redisplay the form in case something goes wrong
                string userName = this.User.Identity.Name;

                //we retrieve from the db the contacts of the user, that haven't been assigned to an account yet
                var contacts = _contactService.ListContactsByCriteria(c => (c.ResponsibleUser.UserName == userName) &&
                                                                           (c.Account == null));
                var viewModel = new AddContactViewModel
                {
                    AccountId = id,
                    Contacts = new SelectList(contacts, "Id", "Email", 1)
                };

                return View(viewModel);
            }

            return View("Details", account);
        }
    }
}
