using Bageriet.Models;
using Bageriet.ViewModels;
using System.Collections.Generic;

namespace Bageriet.Interfaces
{
    public interface IContacts
    {
        IEnumerable<Contacts> AllContacts { get; }
        Contacts GetContact(int id);
        void Add(Contacts contact);
        void Edit(ContactsViewModel model);
        void Delete(int id);
        bool Save();
    }
}