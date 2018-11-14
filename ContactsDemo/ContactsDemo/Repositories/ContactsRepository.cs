using ContactsDemo.Interfaces;
using ContactsDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDemo.Repositories
{
    public class ContactsRepository : IContactsRepository
    {
        private static Database.SQLite_Database Repository;

        public ContactsRepository(Enums.Enum_RepositorySource.Repository reposource)
        {
            switch (reposource)
            {
                case Enums.Enum_RepositorySource.Repository.SQLite:
                    {
                        //Strong coupling, breaking encapsulation but there is a large performance gain in holding
                        //a single instantiation of a sqlite DB at the global level vs creating one everytime
                        //a repository needs it
                        Repository = App.LocalDatabase;
                        break;
                    }
                default:
                    {
                        throw new NotImplementedException();
                    }
            }

        }
              

        public async Task<List<Model_Contact>> GetContactsAsync()
        {
            return await Repository.GetContactsAsync();
        }

        public async Task<List<Model_Contact>> GetContactsAsync(string name)
        {
            return await Repository.GetContactsAsync(name);
        }

        public async Task<Model_Contact> GetContactByIDAsync(int? contactid)
        {
            return await Repository.GetContactByIDAsync(contactid);
        }

        public async Task<List<Model_Contact>> GetContactsByPhoneAsync(string phone)
        {
            return await Repository.GetContactsByPhoneAsync(phone);
        }
         

        public async Task<int> SaveContactAsync(IContact item)
        {
            return await Repository.SaveContactAsync(item);
        }

        public async Task<int> ClearFavorites()
        {
            return await Repository.ClearFavorites();
        }

        public async Task SyncContacts()
        {
            await Repository.SyncContacts();
        }
    }
}
