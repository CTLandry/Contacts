using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsDemo.ViewModel
{
    public class ViewModel_ContactList : _Base_ViewModel
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
            Task.Run(async () => PropertyContacts = await LoadContacts());
        }

        private async Task<ObservableCollection<Models.Model_Contact>> LoadContacts()
        {
            var contacts = await App.ContactsDatabase.GetContacts();
            return new ObservableCollection<Models.Model_Contact>(contacts);
        }

        private ICommand _contactSelected;
        public ICommand ContactSelected
        {
            get
            {
                return _contactSelected ?? (_contactSelected = new Command(async (e) => await ExecuteContactSelected((Models.Model_Contact)e)));
            }
        }

        private async Task ExecuteContactSelected(Models.Model_Contact contact)
        {

            await App.MasterNavigation.PushAsync(new Views.Page_ContactDetail(contact));
        }

        private ICommand _favoriteSelected;
        public ICommand FavoriteSelected
        {
            get
            {
                return _favoriteSelected ?? (_favoriteSelected = new Command(async (e) => await ExecuteFavoriteSelected((Models.Model_Contact)e)));
            }
        }

        private async Task ExecuteFavoriteSelected(Models.Model_Contact selectedContact)
        {
            var test = selectedContact;
        }

    }
}
