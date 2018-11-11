using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDemo.ViewModel
{
    class ViewModel_ContactList : _Base_ViewModel
    {
        private ObservableCollection<Models.Model_Contact> _Contacts;
        public ObservableCollection<Models.Model_Contact> PropertyContacts
        {
            set { SetProperty(ref _Contacts, value); }
            get { return _Contacts; }
        }

        private Models.Model_Contact _selectedContact;
        public Models.Model_Contact PropertySelectedContact
        {
            set { SetProperty(ref _selectedContact, value); }
            get { return _selectedContact; }
        }

        public ViewModel_ContactList()
        {
            PropertyIsBusy = true;
            PropertyUIVisible = false;
            Task.Run(async () => await LoadUI());
        }

        private async Task LoadUI()
        {
            PropertyContacts = await GetContactList();
            PropertyIsBusy = false;
            PropertyUIVisible = true;
        }

        private async Task<ObservableCollection<Models.Model_Contact>> GetContactList()
        {           
            return new ObservableCollection<Models.Model_Contact>(await App.ContactsDatabase.GetAllContacts());
        }

    }
}
