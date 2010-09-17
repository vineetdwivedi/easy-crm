using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EasyCRM.Model.Domains;

namespace EasyCRM.Model.Repositories
{
    public interface IContactRepository
    {
        Contact Create(Contact contactToCreate);
        void Delete(Contact contactToDelete);
        Contact Update(Contact contactToUpdate);
        Contact Get(int id);
        IEnumerable<Contact> ListAll();
        IEnumerable<Contact> ListAllByCriteria(Expression<Func<Contact, bool>> predicate);
    }
}
