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
            try
            {
                PropertyIsBusy = true;
                PropertyUIVisible = false;

                Task.Run(async () => PropertyContacts = await LoadContacts());
            }
            catch(System.Exception ex)
            {
                var error = ex.Message;
            }
            finally
            {
                PropertyIsBusy = false;
                PropertyUIVisible = true;
            }
            
        }
       
        private async Task<ObservableCollection<Models.Model_Contact>> LoadContacts()
        {
            ObservableCollection<Models.Model_Contact> contacts = new ObservableCollection<Models.Model_Contact>();
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Contacts);

            if (status != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
            {
                var requestpermissionresult = await CrossPermissions.Current.RequestPermissionsAsync(Plugin.Permissions.Abstractions.Permission.Contacts);

                if (requestpermissionresult[Plugin.Permissions.Abstractions.Permission.Contacts] != Plugin.Permissions.Abstractions.PermissionStatus.Granted)
                {
                    Device.BeginInvokeOnMainThread(() => App.MasterNavigation.CurrentPage.DisplayAlert("Denied Permission", "This demo cannot show contacts without permission to see them.", "Ok"));
                    return contacts;
                }
            }

            var devicecontacts = await Plugin.ContactService.CrossContactService.Current.GetContactListAsync();

            foreach (Plugin.ContactService.Shared.Contact x in (IList<Plugin.ContactService.Shared.Contact>)devicecontacts)
            {
                contacts.Add(new Models.Model_Contact(x.Name,null, x.Email, x.Number, false, x.PhotoUriThumbnail));
            }

            return contacts;
        }

        private ICommand _contactSelected;
        public ICommand ContactSelected
        {
            get
            {
                return _contactSelected ?? (_contactSelected = new Command(async (e) => await ExecuteContactSelected((Models.Model_Contact)e)));
            }
        }

        private async Task ExecuteContactSelected(Models.Model_Contact selectedContact)
        {
            await App.MasterNavigation.PushAsync(new Views.Page_ContactDetail(selectedContact));
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

        }

    }
}
