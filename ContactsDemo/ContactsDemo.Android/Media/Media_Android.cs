﻿using Xamarin.Forms;
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
using Java.IO;

[assembly: Dependency(typeof(ContactsDemo.Droid.Media.Media_Android))]
namespace ContactsDemo.Droid.Media
{
    class Media_Android : Activity, IMedia
    {           

        public Stream ResolveImage(string imagepath)
        {
            try
            {
                //if I had it to do over again I would have rolled my own like the below
                //I did not realize that photoID and the uri passed back from the plugin
                //was going to be so unreliable
                var photoID = ContentUris.ParseId(Android.Net.Uri.Parse(imagepath));
                var uri = ContentUris.WithAppendedId(ContactsContract.Contacts.ContentUri, photoID);
                var contactphoto = ContactsContract.Contacts.OpenContactPhotoInputStream(CrossCurrentActivity.Current.Activity.ContentResolver, uri);

                return contactphoto;
            }
            catch(System.Exception ex)
            {
                var error = ex.Message;
                return null;
            }
          
            
         
        }

        //potential native call for getting contacts
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