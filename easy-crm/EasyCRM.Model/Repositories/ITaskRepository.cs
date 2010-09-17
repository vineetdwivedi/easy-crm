using System.Collections.Generic;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Repositories
{
    public interface ITaskRepository
    {
        Task Create(Task taskToCreate);
        void Delete(Task taskToDelete);
        Task Update(Task taskToUpdate);
        Task Get(int id);
        IEnumerable<Task> ListAll();
        IEnumerable<Task> ListAllByCriteria(Expression<Func<Task, bool>> predicate);
    }
}
