using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using ContactsDemo.Interfaces;
using System.IO;
using System.Threading.Tasks;
using ContactsDemo.Models;

[assembly: Dependency(typeof(ContactsDemo.iOS.Media.Media_iOS))]
namespace ContactsDemo.iOS.Media
{
    class Media_iOS : IMedia
    {
       
        public Stream ResolveImage(string imagepath)
        {
            //TODO
            return null;
        }
             
              
    }
}