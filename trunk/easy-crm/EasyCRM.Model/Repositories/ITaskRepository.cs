using System.Collections.Generic;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface ITaskRepository
    {
        Task Create(Task taskToCreate);
        void Delete(Task taskToDelete);
        Task Update(Task taskToUpdate);
        Task Get(int id);
        IEnumerable<Task> ListAll();

    }
}
