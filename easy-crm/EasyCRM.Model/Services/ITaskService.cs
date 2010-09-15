using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Services
{
    public interface ITaskService
    {
        bool CreateTask(Task taskToCreate);
        bool DeleteTask(Task taskToDelete);
        bool EditTask(Task taskToEdit);
        Task GetTask(int id);
        IEnumerable<Task> ListTasks();
        IEnumerable<Task> ListTasksByUser(string userName);
        IEnumerable<Task> ListTasksByCriteria(string userName, string status, string priority);

    }
}
