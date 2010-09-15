using System.Collections.Generic;
using System.Linq;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories.Entity
{
    public class EntityContactRepository : IContactRepository
    {
        private EasyCRMDBEntities _entities = EntityRepository.GetEntities();


        #region IContactRepository Members
        public Contact Create(Contact contactToCreate)
        {
            _entities.AddToContactSet(contactToCreate);
            _entities.SaveChanges();
            return contactToCreate;

        }

        public void Delete(Contact contactToDelete)
        {
            var originalContact = Get(contactToDelete.Id);
            _entities.DeleteObject(originalContact);
            _entities.SaveChanges();

        }

        public Contact Update(Contact contactToUpdate)
        {
            var originalContact = Get(contactToUpdate.Id);
            _entities.ApplyCurrentValues(originalContact.EntityKey.EntitySetName, contactToUpdate);
            _entities.SaveChanges();
            return contactToUpdate;

        }

        public Contact Get(int id)
        {
            return _entities.ContactSet.First(contact => contact.Id == id);
        }

        public IEnumerable<Contact> ListAll()
        {
            return _entities.ContactSet.ToList();
        } 
        #endregion
    }
}
