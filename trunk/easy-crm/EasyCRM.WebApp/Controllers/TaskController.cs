using System;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using EasyCRM.WebApp.ViewModels;
using System.Net;
using EasyCRM.WebApp.Services;
using EasyCRM.WebApp.Services.Impl;

namespace EasyCRM.WebApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {

        ITaskService _taskService;
        IMembershipService _membershipService;

        public TaskController()
        {
            _taskService = new TaskService(new ModelStateWrapper(this.ModelState));
            _membershipService = new MembershipService(new UserService(new ModelStateWrapper(this.ModelState)));
        }

        public TaskController(ITaskService service, IMembershipService membershipService)
        {
            _taskService = service;
            _membershipService = membershipService;
        }

        //
        // GET: /Task/

        public ActionResult Index()
        {
            //we list all tasks from db, and pass them to the view
            return View(_taskService.ListTasks());
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            var task = _taskService.GetTask(id);

            if (task == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(task);
        }

        //
        // GET: /Task/Create

        public ActionResult Create()
        {
            DateTime current = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour + 1, 0, 0);

            Task task = new Task
            {
                StartDate = current,
                LimitDate = current.AddDays(5),
                EndDate = current.AddDays(10)
            };

            return View(new TaskViewModel(task));
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Task task)
        {           
            string userName = this.User.Identity.Name;
            //we get the user responsible for the task
            User responsibleUser = _membershipService.GetUser(userName);

            task.ResponsibleUser = responsibleUser;
            responsibleUser.Tasks.Add(task);

            if (!_taskService.CreateTask(task))
            {
                return View(new TaskViewModel(task));
            }
            
            return RedirectToAction("Index");
        }

        //
        // GET: /Task/Edit/5

        public ActionResult Edit(int id)
        {
            //getting the task to edit
            var task = _taskService.GetTask(id);

            if (task == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(new TaskViewModel(task));

        }

        //
        // POST: /Task/Edit/5

        [HttpPost]
        public ActionResult Edit(Task task)
        {

            // normaly we should have those parameters : "Edit(int id, FormCollection values)"
            // So we would retrieve the existing task from db (by his id) and then update the 
            // fields with the form posted values.But in this specific case we can directly
            // pass an "Task" instance, the system will automatically bind the "id" 
            // field from the request(/Task/Edit/{id}) and the other fields from the form.
            // ...

            if (!_taskService.EditTask(task))
            {
                return View(new TaskViewModel(task));
            }

            return RedirectToAction("Index");
        }

        //
        // GET: /Task/Delete/5

        public ActionResult Delete(int id)
        {
            var task = _taskService.GetTask(id);

            if (task == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            return View(task);
        }

        //
        // POST: /Task/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection formValues)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
