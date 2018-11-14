using ContactsDemo.Interfaces;
using Android.Content;
using System;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactsDemo.Droid.Phone.Phone_Android))]
namespace ContactsDemo.Droid.Phone
{
    public class Phone_Android : IPhone
    {
        public void PlaceCall(string number)
        {
            try
            {
                var uri = Android.Net.Uri.Parse("tel:" + number);
                var intent = new Intent(Intent.ActionDial, uri);
                CrossCurrentActivity.Current.Activity.StartActivity(intent);
            }
            catch (Exception ex)
            {
                App.MasterNavigation.DisplayAlert("Cannot make call", "Check if SIM card present and device can make calls", "Ok");
            }
        }
    }
}