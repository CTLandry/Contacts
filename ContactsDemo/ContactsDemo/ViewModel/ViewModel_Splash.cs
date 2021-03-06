﻿using Plugin.Permissions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ContactsDemo.Interfaces;

namespace ContactsDemo.ViewModel
{
    class ViewModel_Splash : _Base_ViewModel
    {
        private IContactsRepository ContactsRepo;

        public ViewModel_Splash()
        {
            ContactsRepo = new Repositories.ContactsRepository(App.RepoSource);
            Task.Run(async () => await InitializeApp());
        }

        public async Task InitializeApp()
        {
            if(Device.RuntimePlatform == Device.Android)
            {
                var contactsPermission = await Helpers.Permissions.RequestPermission(Plugin.Permissions.Abstractions.Permission.Contacts);
                if (!contactsPermission)
                {
                    Device.BeginInvokeOnMainThread(async () => await App.Current.MainPage.DisplayAlert("Denied", "Cannot show any contacts", "Ok"));
                }
            }

            await ContactsRepo.SyncContacts();
            await App.MasterNavigation.PushAsync(new Views.Page_ContactList());
            App.Current.MainPage = App.MasterNavigation;
        }     

    }
}
