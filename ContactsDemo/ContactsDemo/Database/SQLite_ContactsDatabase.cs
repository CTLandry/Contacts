using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDemo.Database
{
    public class SQLite_ContactsDatabase
    {
        private SQLiteAsyncConnection database;

        public SQLite_ContactsDatabase(string DatabasePath)
        {
            database = new SQLiteAsyncConnection(DatabasePath);
            database.CreateTableAsync<Models.Model_Contact>().Wait();
        }

        public async Task SyncContacts()
        {
            IList<Plugin.ContactService.Shared.Contact> contacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();
           
            foreach(Plugin.ContactService.Shared.Contact x in contacts)
            {
                var newcontact = new Models.Model_Contact(x.Name, null, null, x.Email, x.Number, false, null, x.PhotoUriThumbnail);
                await SyncSave(newcontact);
            }
        }

        private async Task<int> SyncSave(Models.Model_Contact contact)
        {
            var exists = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE ContactID = ?", contact.ContactID);
            if(exists.Count > 0)
            {
                return 0; //do nothing do not want to overwrite sqlite with new sync
            }
            else
            {
                return await database.InsertAsync(contact);
            }
        }

        public async Task<int> SaveContact(Models.Model_Contact contact)
        {
            var exists = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE ContactID = ?", contact.ContactID);
            if (exists.Count > 0)
            {
                return await database.UpdateAsync(contact);
            }
            else
            {
                return await database.InsertAsync(contact);
            }
        }

         
        public async Task<List<Models.Model_Contact>> GetAllContacts()
        {
            return await database.Table<Models.Model_Contact>().ToListAsync();
        }

    }
}
