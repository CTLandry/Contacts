using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContactsDemo.Interfaces;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(ContactsDemo.iOS.Email.Email_iOS))]
namespace ContactsDemo.iOS.Email
{
    public class Email_iOS : IEmail
    {
        public void OpenEmailClient(string toEmail)
        {
            var urlToSend = new NSUrl("mailto:" + toEmail);

            Device.BeginInvokeOnMainThread(() =>
            {
                if (UIApplication.SharedApplication.CanOpenUrl(urlToSend))
                {
                    UIApplication.SharedApplication.OpenUrl(urlToSend);

                }
                else
                {
                    App.MasterNavigation.DisplayAlert("Cannot send E-mail", "Cannot send e-mail from iOS simulator use a real device", "Ok");

                }

            });
        }
    }
}