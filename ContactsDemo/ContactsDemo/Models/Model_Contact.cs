using ContactsDemo.Interfaces;
using SQLite;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;

namespace ContactsDemo.Models
{
    [Table("Contacts")]
    public class Model_Contact : _Base_Model, IContact
    {
        private static readonly string defaultcontactimage = "defaultcontact.png";
        private static readonly string favoriteimage = "starfavorited.png";
        private static readonly string notfavoritimage = "starempty.png";

        public Model_Contact()
        {

        }

        public Model_Contact(string pName, string pEmail, string pPhone,
            bool pIsFavorite, string pContactImageSource)
        {            
            Name = pName ?? "Empty";            
            Email = pEmail ?? "Empty";
            Phone = pPhone ?? "Empty";
            isFavorite = pIsFavorite;
            OriginalContactImageSource = pContactImageSource;
        }

        [PrimaryKey]
        public int ContactID { get; private set; }

        private string _Name;
        public string Name
        {
            set { SetProperty(ref _Name, value); }
            get { return _Name; }
        }

        private string _LastName;
        public string LastName
        {
            set { SetProperty(ref _LastName, value); }
            get { return _LastName; }
        }
        
        private string _Email;
        public string Email
        {
            set { SetProperty(ref _Email, value); }
            get { return _Email; }
        }

        private string _Phone;
        public string Phone
        {
            set { SetProperty(ref _Phone, value); }
            get { return _Phone; }
        }

        private bool _isFavorite;
        public bool isFavorite
        {
            set
            {
                SetProperty(ref _isFavorite, value);
                FavoriteImageSource = (isFavorite) ? favoriteimage : notfavoritimage;
            }
            get { return _isFavorite; }
        }
        
        public string OriginalContactImageSource { get; set; }

        private ImageSource _ContactImageSource;    
        [Ignore]
        public ImageSource ContactImageSource
        {
            set
            {
                SetProperty(ref _ContactImageSource, value);
            }
            get
            {
                if (OriginalContactImageSource != null)
                {
                    return ImageSource.FromStream(() => DependencyService.Get<IMedia>().ResolveImage(OriginalContactImageSource));
                }
                else
                {
                    return defaultcontactimage;
                }
            }
        }

        private ImageSource _FavoriteImageSource;
        [Ignore]
        public ImageSource FavoriteImageSource
        {
            set
            {
                SetProperty(ref _FavoriteImageSource, value);
            }
            get
            {
                return _FavoriteImageSource;
            }
        }

    }
}
