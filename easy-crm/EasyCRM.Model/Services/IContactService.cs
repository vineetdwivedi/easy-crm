using System.Collections.Generic;
using EasyCRM.Model.Domains;
using System.Linq.Expressions;
using System;

namespace EasyCRM.Model.Services
{
    public interface IContactService
    {
        bool CreateContact(Contact contactToCreate);
        bool DeleteContact(Contact contactToDelete);
        bool EditContact(Contact contactToEdit);
        Contact GetContact(int id);
        IEnumerable<Contact> ListContacts();
        IEnumerable<Contact> ListContactsByCriteria(Expression<Func<Contact,bool>> predicate);

    }
}
