using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Interfaces
{
    interface IContact
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Company { get; set; }       
        string Email { get; set; }
        string Phone { get; set; }
        Models.Model_Address Address { get; set; }
    }
}
