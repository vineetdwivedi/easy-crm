using System.Collections.Generic;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Services
{
    public interface ITaskService
    {
        bool CreateTask(Task taskToCreate);
        bool DeleteTask(Task taskToDelete);
        bool EditTask(Task taskToEdit);
        Task GetTask(int id);
        IEnumerable<Task> ListTasks();
        IEnumerable<Task> ListTasksByCriteria(Expression<Func<Task, bool>> predicate);
    }
}
