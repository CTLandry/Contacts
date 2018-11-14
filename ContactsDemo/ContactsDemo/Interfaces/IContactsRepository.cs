using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDemo.Interfaces
{
    public interface IContactsRepository
    {
        Task SyncContacts();
        Task<List<Models.Model_Contact>> GetContactsAsync();
        Task<List<Models.Model_Contact>> GetContactsAsync(string name);
        Task<List<Models.Model_Contact>> GetContactsByPhoneAsync(string phone);
        Task<Models.Model_Contact> GetContactByIDAsync(int? contactid);        
        Task<int> SaveContactAsync(IContact item);
        Task<int> ClearFavorites();

    }
}
