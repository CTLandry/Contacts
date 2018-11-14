using System;
using Android.Content;
using Xamarin.Forms;
using ContactsDemo.Interfaces;
using Plugin.CurrentActivity;

[assembly: Dependency(typeof(ContactsDemo.Droid.Email.Email_Android))]
namespace ContactsDemo.Droid.Email
{
    public class Email_Android : IEmail
    {
        public void OpenEmailClient(string toEmail)
        {
            var intent = new Intent(Intent.ActionSend);
            intent.SetType("message/rfc822");
            intent.PutExtra(Intent.ExtraEmail, new[] { toEmail });
            CrossCurrentActivity.Current.Activity.StartActivity(Intent.CreateChooser(intent, "Send email"));
        }

       
    }
}