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
    public class ContactController : Controller
    {

        IContactService _contactService;
        IUserService _userService;
        ITaskService _taskService;

        public ContactController()
        {
            _contactService = new ContactService(new ModelStateWrapper(this.ModelState));
            _userService = new UserService(new ModelStateWrapper(this.ModelState));
            _taskService = new TaskService(new ModelStateWrapper(this.ModelState));
        }

        public ContactController(IContactService service, IUserService userService, ITaskService taskService)
        {
            _contactService = service;
            _userService = userService;
            _taskService = taskService;
        }

        //
        // GET: /Contact/

        public ActionResult Index()
        {
            //we list all contacts of the user from db, and pass them to the view
            string userName = this.User.Identity.Name;

            var contacts = _contactService.ListContactsByCriteria(
                contact => contact.ResponsibleUser.UserName == userName);
           
            return View(contacts);
        }

        //
        // GET: /Contact/Details/5

        public ActionResult Details(int id)
        {
            Contact contact = _contactService.GetContact(id);

            if (contact == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(contact);
        }

        //
        // GET: /Contact/Create

        public ActionResult Create()
        {
            return View(new ContactViewModel());
        }

        //
        // POST: /Contact/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Contact contact)
        {           
            string userName = this.User.Identity.Name;
            //we get the user responsible for the contact
            User responsibleUser = _userService.GetUser(userName);

            contact.ResponsibleUser = responsibleUser;
            responsibleUser.Contacts.Add(contact); //maybe useless, as EF takes care of that

            if (!_contactService.CreateContact(contact))
            {
                return View(new ContactViewModel(contact));
            }
            
            return RedirectToAction("Index");
        }

        //
        // GET: /Contact/Edit/5

        public ActionResult Edit(int id)
        {
            //getting the contact to edit
            Contact contact = _contactService.GetContact(id);

            if (contact == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(new ContactViewModel(contact));

        }

        //
        // POST: /Contact/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection formValues)
        {
            // we retrieve existing contact from the db
            Contact contact = _contactService.GetContact(id);

            if (contact == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            // we update the contact with form posted values
            TryUpdateModel(contact, "Contact" /*prefix, as the contact is inside the Contact editor"*/);

            if (!_contactService.EditContact(contact))
            {
                return View(new ContactViewModel(contact));
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Contact/Delete/5

        public ActionResult Delete(int id)
        {
            Contact contact = _contactService.GetContact(id);

            if (contact == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(contact);
        }

        //
        // POST: /Contact/Delete/5

        [HttpPost]
        public ActionResult Delete(Contact contact)
        {
            if (!_contactService.DeleteContact(contact))
                return View(contact);
            return RedirectToAction("Index");
        }

        //
        // GET: /Contact/AddTask

        public ActionResult AddTask(int id /*id of the contact*/)
        {
            string userName = this.User.Identity.Name;

            //we retrieve from the db the tasks of the user, that haven't been assigned to an account yet
            var tasks = _taskService.ListTasksByCriteria(task => (task.ResponsibleUser.UserName == userName) &&
                                                                 (task.Contact == null));
            var viewModel = new AddTaskViewModel
            {
                Tasks = new SelectList(tasks, "Id", "Subject", 1)
            };

            return View(viewModel);
        }

        //
        // POST: /Contact/AddTask/5

        [HttpPost]
        public ActionResult AddTask(int id /*id of the contact*/, FormCollection formValues)
        {
            int taskId = Int32.Parse(formValues["TaskId"]);

            //we retrieve the task to add to the contact
            Task task = _taskService.GetTask(taskId);
            //we retrieve the contact to add the task to
            Contact contact = _contactService.GetContact(id);

            contact.Tasks.Add(task);

            if (!_contactService.EditContact(contact))
            {
                //we redisplay the form in case something goes wrong
                string userName = this.User.Identity.Name;

                //we retrieve from the db the tasks of the user, that haven't been assigned to an account yet
                var tasks = _taskService.ListTasksByCriteria(t => (t.ResponsibleUser.UserName == userName) &&
                                                                  (t.Contact == null));
                var viewModel = new AddTaskViewModel
                {
                    Tasks = new SelectList(tasks, "Id", "Subject", 1)
                };

                return View(viewModel);
            }

            return View("Details", contact);
        }

    }
}
