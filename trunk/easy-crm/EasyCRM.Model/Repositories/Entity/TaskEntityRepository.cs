using System.Collections.Generic;
using System.Linq;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Repositories.Entity
{
    public class TaskEntityRepository : ITaskRepository
    {
        private EasyCRMDBEntities _entities = EntityRepository.GetEntities();

        #region ITaskRepository Members
        public Task Create(Task taskToCreate)
        {
            _entities.AddToTaskSet(taskToCreate);
            _entities.SaveChanges();
            return taskToCreate;

        }

        public void Delete(Task taskToDelete)
        {
            var originalTask = Get(taskToDelete.Id);
            _entities.DeleteObject(originalTask);
            _entities.SaveChanges();

        }

        public Task Update(Task taskToUpdate)
        {
            var originalTask = Get(taskToUpdate.Id);
            _entities.ApplyCurrentValues(originalTask.EntityKey.EntitySetName, taskToUpdate);
            _entities.SaveChanges();
            return taskToUpdate;

        }

        public Task Get(int id)
        {
            return _entities.TaskSet.First(task => task.Id == id);
        }

        public IEnumerable<Task> ListAll()
        {
            return _entities.TaskSet.ToList();
        }

        public IEnumerable<Task> ListAllByCriteria(Expression<Func<Task, bool>> predicate)
        {
            return _entities.TaskSet.Where(predicate);
        } 

        #endregion
    }
}


