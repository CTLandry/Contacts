using System;
using System.Collections.Generic;
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
            await Task.Delay(1000); //for effect
            await App.MasterNavigation.PushAsync(new Views.Page_ContactList());
            App.Current.MainPage = App.MasterNavigation;
        }
    }
}
