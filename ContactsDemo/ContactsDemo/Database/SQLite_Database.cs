using ContactsDemo.Interfaces;
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
    public class SQLite_Database : IContactsRepository
    {

        private static SQLiteAsyncConnection database;

        public SQLite_Database(string dbPath)
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
               
                foreach (Plugin.ContactService.Shared.Contact devicecontact in (IList<Plugin.ContactService.Shared.Contact>)devicecontacts)
                {
                    var newcontact = new Models.Model_Contact(devicecontact.Name, devicecontact.Email, devicecontact.Number, false, devicecontact.PhotoUri);
                    await database.InsertAsync(newcontact);
                }
                
            }
        }

        public async Task<List<Models.Model_Contact>> GetContactsAsync()
        {
            try
            {
                return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts ORDER BY isFavorite desc, Name LIMIT 500");
            }
            catch(SQLite.SQLiteException ex)
            {
                var error = ex.Message;
                return null;
            }
            
        }

        public async Task<List<Models.Model_Contact>> GetContactsAsync(string name)
        {
            return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE Name LIKE '%" + name + "%' ORDER BY isFavorite desc, Name LIMIT 500");
        }

        public async Task<List<Models.Model_Contact>> GetContactsByPhoneAsync(string phone)
        {
            return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE Phone LIKE '%" + phone + "%' ORDER BY isFavorite desc, Name LIMIT 500");
        }

        public async Task<Models.Model_Contact> GetContactByIDAsync(int? contactid)
        {
            try
            {
                var contactfound = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE Id = ?", contactid);
                return contactfound[0] ?? null;
            }
            catch(System.Exception ex)
            {
                var exmessage = ex.Message;
                return null;
            }
           
        }
        
        public async Task<int> SaveContactAsync(IContact item)
        {
            try
            {
                var exists = await GetContactByIDAsync(item.Id);

                if (exists != null)
                {
                    return await database.UpdateAsync(item);
                }
                else
                {
                    return await database.InsertAsync(item);
                }
            }
            catch(SQLite.SQLiteException ex)
            {
                var message = ex.Message;
                return 0;
            }
            catch(System.SystemException ex)
            {
                var message = ex.Message;
                return 0;
            }
           
        }

        public async Task<int> ClearFavorites()
        {
            var favorites = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE isFavorite = ?", true);
            if(favorites.Count > 0)
            {
                favorites[0].isFavorite = false;
                return await database.UpdateAsync(favorites[0]);
            }
            else
            {
                return 0;
            }
            


        }

    }
}
