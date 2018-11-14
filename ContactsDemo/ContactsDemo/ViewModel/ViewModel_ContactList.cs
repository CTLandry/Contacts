using ContactsDemo.Interfaces;
using ContactsDemo.Repositories;
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

        private ObservableCollection<IContact> _Contacts;
        public ObservableCollection<IContact> PropertyContacts
        {
            set { SetProperty(ref _Contacts, value); }
            get { return _Contacts; }
        }

        private IContact _selectedContact;
        public IContact PropertySelectedContact
        {
            set { SetProperty(ref _selectedContact, value); }
            get { return _selectedContact; }
        }

        private IContactsRepository ContactsRepo;

        public ViewModel_ContactList()
        {
            ContactsRepo = new ContactsRepository(App.RepoSource);
            Task.Run(async () => PropertyContacts = await LoadContacts());            
        }

        private async Task<ObservableCollection<IContact>> LoadContacts()
        {
            try
            {
                var contacts = await ContactsRepo.GetContactsAsync();
                return new ObservableCollection<IContact>(contacts);       
            }
            catch(SystemException ex)
            {
                var error = ex.Message;
                return null;
            }
          
        }

        private ICommand _contactSelected;
        public ICommand ContactSelected
        {
            get
            {
                return _contactSelected ?? (_contactSelected = new Command(async (contact) => await ExecuteContactSelected((IContact)contact)));
            }
        }

        private async Task ExecuteContactSelected(IContact contact)
        {

            await App.MasterNavigation.PushAsync(new Views.Page_ContactDetail(contact));
        }

        private ICommand _favoriteSelected;
        public ICommand FavoriteSelected
        {
            get
            {
                return _favoriteSelected ?? (_favoriteSelected = new Command(async (contact) => await ExecuteFavoriteSelected((IContact)contact)));
            }
        }

        private async Task ExecuteFavoriteSelected(IContact selectedContact)
        {
            if(!selectedContact.isFavorite)
            {
                
                selectedContact.isFavorite = true;
                await ContactsRepo.ClearFavorites();
                await ContactsRepo.SaveContactAsync(selectedContact);
                PropertyContacts = await LoadContacts();
            }
            
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                return _searchCommand ?? (_searchCommand = new Command<string>(async (text) => await ExecuteSearchContacts(text)));
              
            }
        }

        private async Task ExecuteSearchContacts(string searchcriteria)
        {
            bool AlphaMatch = false;
            
            await Task.Run(() =>
            {
                AlphaMatch = Helpers.Regex.Alpha(searchcriteria);               
            });

            if(AlphaMatch)
            {
                PropertyContacts = new ObservableCollection<IContact>( await ContactsRepo.GetContactsAsync(searchcriteria));
            }
            else 
            {
                PropertyContacts = new ObservableCollection<IContact>(await ContactsRepo.GetContactsByPhoneAsync(searchcriteria));
            }
        }

    }
}
