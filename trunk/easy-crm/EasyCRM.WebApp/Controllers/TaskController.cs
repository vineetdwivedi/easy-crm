using System.Net;
using System.Web.Mvc;
using EasyCRM.Model.Domains;
using EasyCRM.Model.Services;
using EasyCRM.Model.Services.Impl;
using EasyCRM.WebApp.ViewModels;

namespace EasyCRM.WebApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {

        ITaskService _taskService;
        IUserService _userService;

        public TaskController()
        {
            _taskService = new TaskService(new ModelStateWrapper(this.ModelState));
            _userService = new UserService(new ModelStateWrapper(this.ModelState));
        }

        public TaskController(ITaskService service, IUserService userService)
        {
            _taskService = service;
            _userService = userService;
        }

        //
        // GET: /Task/

        public ActionResult Index()
        {
            //we list all tasks of the user from db, and pass them to the view
            string userName = this.User.Identity.Name;

            var tasks = _taskService.ListTasksByCriteria(
                task => task.ResponsibleUser.UserName == userName);
           
            return View(tasks);
        }

        //
        // GET: /Task/Details/5

        public ActionResult Details(int id)
        {
            Task task = _taskService.GetTask(id);

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
            return View(new TaskViewModel());
        }

        //
        // POST: /Task/Create

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Id")]Task task)
        {           
            string userName = this.User.Identity.Name;
            //we get the user responsible for the task
            User responsibleUser = _userService.GetUser(userName);

            task.ResponsibleUser = responsibleUser;
            responsibleUser.Tasks.Add(task); //maybe useless, as EF takes care of that

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
            Task task = _taskService.GetTask(id);

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
        public ActionResult Edit(int id, FormCollection formValues)
        {
            // we retrieve existing task from the db
            Task task = _taskService.GetTask(id);

            if (task == null)
            {
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return View("NotFound");
            }

            // we update the task with form posted values
            TryUpdateModel(task, "Task" /*prefix, as the task is inside the Task editor"*/);

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
            Task task = _taskService.GetTask(id);

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
        public ActionResult Delete(Task task)
        {
            if (!_taskService.DeleteTask(task))
                return View(task);
            return RedirectToAction("Index");
        }


        //
        // GET: /Task/Search

       public ActionResult Search()
        {
            return View(new SearchTaskViewModel());
        }

        //
        // POST: /Task/Search/5

        [HttpPost]
       public ActionResult Search(FormCollection formValues)
        {
            //we get the tasks matching the criteria from the db, and pass them to Index view
            string status = formValues["Status"];
            string priority = formValues["Priority"];
            string userName = this.User.Identity.Name;

            var tasks = _taskService.ListTasksByCriteria(task => (task.ResponsibleUser.UserName == userName) &&
                                                                 task.Status.Contains(status) && task.Priority.Contains(priority));

            return View("Index", tasks);
        }
    }
}
