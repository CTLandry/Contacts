using Plugin.Permissions;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsDemo.Database
{
    public class Contacts_DB
    {

        private static SQLiteAsyncConnection database;

        public Contacts_DB(string dbPath)
        {

            if (database == null)
            {
                database = new SQLiteAsyncConnection(dbPath);
                database.CreateTableAsync<Models.Model_Contact>().Wait();
            }

        }

        public async Task SyncContacts()
        {
            var currentContacts = await GetContactsAsync();
            var devicecontacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();

            if (currentContacts.Count != devicecontacts.Count)
            {
                await database.DeleteAllAsync<Models.Model_Contact>();
                List<Models.Model_Contact> newcontacts = new List<Models.Model_Contact>();
                foreach (Plugin.ContactService.Shared.Contact devicecontact in (IList<Plugin.ContactService.Shared.Contact>)devicecontacts)
                {
                    newcontacts.Add(new Models.Model_Contact(devicecontact.Name, devicecontact.Email, devicecontact.Number, false, devicecontact.PhotoUri));
                }
                await database.InsertAllAsync(newcontacts);
            }
        }

        public async Task<List<Models.Model_Contact>> GetContactsAsync()
        {
            return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts ORDER BY isFavorite, Name");
        }

        public async Task<List<Models.Model_Contact>> GetContactsAsync(string name)
        {
            return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE Name LIKE '%" + name + "%' ORDER BY isFavorite, Name");
        }

        public async Task<Models.Model_Contact> GetContactsAsync(int contactid)
        {
            var contactfound = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts _ContactID = ?", contactid);
            return contactfound[0] ?? null;
        }

        public async Task<int> SaveContactAsycn(Models.Model_Contact item)
        {
            if (await GetContactsAsync(item._ContactID) != null)
            {
                return await database.UpdateAsync(item);
            }
            else
            {
                return await database.InsertAsync(item);
            }
        }

        public async Task<Models.Model_Contact> GetFavorite()
        {

            var query = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE isFavorite = ?", true);
            return query[0] ?? null;

        }

    }
}
