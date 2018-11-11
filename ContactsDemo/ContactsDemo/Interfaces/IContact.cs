using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Interfaces
{
    interface IContact
    {
        string Name { get; set; }        
        string Company { get; set; }       
        string Email { get; set; }
        string Phone { get; set; }
        
    }
}
