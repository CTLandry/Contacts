using ContactsDemo.Interfaces;
using ContactsDemo.Models;
using System;
using System.Collections.Generic;
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

        public async Task<Model_Contact> GetContactsAsync(int contactid)
        {
            return await Repository.GetContactsAsync(contactid);
        }

        public async Task<List<Model_Contact>> GetContactsByPhoneAsync(string phone)
        {
            return await Repository.GetContactsAsync(phone);
        }

        public async Task<Model_Contact> GetFavoriteAsync()
        {
            return await Repository.GetFavoriteAsync();
        }

        public async Task<int> SaveContactAsync(Model_Contact item)
        {
            return await Repository.SaveContactAsync(item);
        }

        public async Task SyncContacts()
        {
            await Repository.SyncContacts();
        }
    }
}
