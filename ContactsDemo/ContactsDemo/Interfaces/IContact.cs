using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContactsDemo.Interfaces
{
    public interface IContact
    {      

       
        int ContactID { get; }
        string Name { get; set; }        
        string Email { get; set; }
        string Phone { get; set; }        
        bool isFavorite { get; set; }
        string OriginalContactImageSource { get; set; }        
        ImageSource ContactImageSource { get; set; }        
        ImageSource FavoriteImageSource { get; set; }
    }
}
