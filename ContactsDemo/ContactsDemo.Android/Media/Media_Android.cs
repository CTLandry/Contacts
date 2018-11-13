using Xamarin.Forms;
using Plugin.CurrentActivity;
using System;
using System.Threading.Tasks;
using Android.App;
using ContactsDemo.Interfaces;
using Android.Content;
using Android.OS;
using Android.Provider;
using Android.Database;
using System.Collections.Generic;
using System.IO;

[assembly: Dependency(typeof(ContactsDemo.Droid.Media.Media_Android))]
namespace ContactsDemo.Droid.Media
{
    class Media_Android : Activity, IMedia
    {
        //Having a bit of trouble resolving the local contact image from content://
        public Stream ResolveImage(string imagepath)
        {             
            return CrossCurrentActivity.Current.Activity.ContentResolver.OpenInputStream(Android.Net.Uri.Parse(imagepath));
        }

        //public List<Models.Model_Contact> FillContacts()
        //{



        //    Did not get anymore information about the contact photo from this approach than from the plugin
        //        var uri = ContactsContract.Contacts.ContentUri;
        //    string[] projection = {
        //        ContactsContract.Contacts.InterfaceConsts.Id,
        //        ContactsContract.Contacts.InterfaceConsts.DisplayName,
        //        ContactsContract.CommonDataKinds.Email.Address,
        //        ContactsContract.CommonDataKinds.Phone.Number,
        //        ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri
        //        };


        //    var loader = new CursorLoader(CrossCurrentActivity.Current.Activity, uri, projection, null, null, null);
        //    var cursor = (ICursor)loader.LoadInBackground();
        //    var contactList = new List<Models.Model_Contact>();
        //    if (cursor.MoveToFirst())
        //    {
        //        do
        //        {
        //            contactList.Add(
        //                new Models.Model_Contact
        //                ((cursor.GetLong(cursor.GetColumnIndex(projection[0])).ToString()),
        //                  cursor.GetString(cursor.GetColumnIndex(projection[1])),
        //                  cursor.GetString(cursor.GetColumnIndex(projection[2])),
        //                  cursor.GetString(cursor.GetColumnIndex(projection[3])),
        //                  false,
        //                  null));

        //        } while (cursor.MoveToNext());
        //    }

        //    return contactList;

        //}

    }
}