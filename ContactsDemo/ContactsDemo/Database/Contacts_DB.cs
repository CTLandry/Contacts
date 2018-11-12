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
            var currentlist = await GetContacts();
            
                      
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Contacts);

            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var requestpermissionresult = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Contacts);

                if (requestpermissionresult[Plugin.Permissions.Abstractions.Permission.Contacts] != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    Device.BeginInvokeOnMainThread(() => App.MasterNavigation.CurrentPage.DisplayAlert("Denied Permission", "This demo cannot show contacts without permission to see them.", "Ok"));
                }
            }

            var devicecontacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();
            List<Models.Model_Contact> newcontacts = new List<Models.Model_Contact>();

            foreach (Plugin.ContactService.Shared.Contact x in (IList<Plugin.ContactService.Shared.Contact>)devicecontacts)
            {                
                newcontacts.Add(new Models.Model_Contact(x.Name, null, x.Email, x.Number, false, x.PhotoUriThumbnail));                
            }

            await database.DeleteAllAsync<Models.Model_Contact>();
            await database.InsertAllAsync(newcontacts);


        }

        
        public async Task<List<Models.Model_Contact>> GetContacts()
        {
            return await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts Order By isFavorite, Name");
        }

        public async Task<Models.Model_Contact> GetContactsByID(string id)
        {
            var exists = await database.QueryAsync<Models.Model_Contact>("SELECT * FROM Contacts WHERE ContactID = ?", id);
            if (exists != null && exists.Count == 1)
            {
                return exists[0];
            }
            else
            {
                return null;
            }
        }

        public Task<int> SaveContactAsync(Models.Model_Contact item)
        {

            if (GetContactsByID(item.ContactID) != null)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

    }
}
