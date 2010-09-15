using System.Collections.Generic;
using System.Linq;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories.Entity
{
    public class EntityUserRepository : IUserRepository
    {
        private EasyCRMDBEntities _entities = EntityRepository.GetEntities();

        #region IUSerRepository Members
        public User Create(User userToCreate)
        {
            _entities.AddToUserSet(userToCreate);
            _entities.SaveChanges();
            return userToCreate;

        }

        public void Delete(User userToDelete)
        {
            var originalUser = Get(userToDelete.Id);
            _entities.DeleteObject(originalUser);
            _entities.SaveChanges();

        }

        public User Update(User userToUpdate)
        {
            var originalUser = Get(userToUpdate.Id);
            _entities.ApplyCurrentValues(originalUser.EntityKey.EntitySetName, userToUpdate);
            _entities.SaveChanges();
            return userToUpdate;

        }

        public User Get(int id)
        {
            return _entities.UserSet.First(user => user.Id == id);
        }

        public User Get(string userName)
        {
            return _entities.UserSet.First(user => user.UserName == userName);
        }

        public IEnumerable<User> ListAll()
        {
            return _entities.UserSet.ToList();
        } 
        #endregion
    }
}
