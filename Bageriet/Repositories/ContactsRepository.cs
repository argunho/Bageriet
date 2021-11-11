using Bageriet.Context;
using Bageriet.Interfaces;
using Bageriet.Models;
using Bageriet.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bageriet.Repositories
{
    public class ContactsRepository : IContacts
    {
        private readonly DBContext db;

        public ContactsRepository(DBContext db)
        {
            this.db = db;
        }

        public IEnumerable<Contacts> AllContacts
        {
            get
            {
                return db.contacts.Where(x => x.Visible);
            }
        }

        public Contacts GetContact(int id)
        {
            return db.contacts.FirstOrDefault(x => x.Id == id && x.Visible);
        }

        public void Add(Contacts contact)
        {
            db.contacts.Add(contact);
        }

        public void Edit(ContactsViewModel model)
        {
            var contacts = GetContact(model.Id);
            contacts.Email = model.Email;
            contacts.Phone = model.Phone;
            contacts.Address = model.Address;
            contacts.City = model.City;
            contacts.Zip = model.Zip;
        }

        public void Delete(int id)
        {

        }

        // Method Save DB
        public bool Save()
        {
            try { db.SaveChanges(); return true; }
            catch (Exception e) { return false; }
        }
    }
}
