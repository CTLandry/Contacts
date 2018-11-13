using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsDemo.Interfaces
{
    public interface IMedia
    {
        // System.IO.Stream ResolveImage(string imagepath);
         List<Models.Model_Contact> FillContacts();
    }
}
