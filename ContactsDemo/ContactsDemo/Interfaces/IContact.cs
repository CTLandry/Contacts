using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using SQLitePCL;

namespace ContactsDemo.Interfaces
{
    public interface IContact
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        int? Id { get; set; }
        string Name { get; set; }        
        string Email { get; set; }
        string Phone { get; set; }        
        bool isFavorite { get; set; }
        string OriginalContactImageSource { get; set; } 
        [SQLite.Ignore]
        ImageSource ContactImageSource { get; set; }
        [SQLite.Ignore]
        ImageSource FavoriteImageSource { get; set; }
    }
}
