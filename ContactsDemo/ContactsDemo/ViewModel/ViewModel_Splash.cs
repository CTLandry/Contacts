using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsDemo.ViewModel
{
    class ViewModel_Splash : _Base_ViewModel
    {
        public ViewModel_Splash()
        {
           
            Task.Run(async () => await InitializeApp());
        }

        public async Task InitializeApp()
        {
           
            await App.ContactsDatabase.SyncContacts();
            await App.MasterNavigation.PushAsync(new Views.Page_ContactList());
            App.Current.MainPage = App.MasterNavigation;
        }     

    }
}
