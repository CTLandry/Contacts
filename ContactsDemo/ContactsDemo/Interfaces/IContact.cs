using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Interfaces
{
    public interface IContact
    {
        string Name { get; set; }        
        string Email { get; set; }
        string Phone { get; set; }        
    }
}
