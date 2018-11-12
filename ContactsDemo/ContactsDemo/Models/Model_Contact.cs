using ContactsDemo.Interfaces;
using SQLite;
using Xamarin.Forms;

namespace ContactsDemo.Models
{
    [Table("Contacts")]
    public class Model_Contact : _Base_Model, IContact
    {
      
       public Model_Contact()
        {

        }

        public Model_Contact(string pName, string pCompany, string pEmail, string pPhone,
            bool pIsFavorite, string pContactImageSource)
        {
            ContactID = System.Guid.NewGuid().ToString();
            Name = pName ?? "Empty";           
            Company = pCompany ?? "Empty";           
            Email = pEmail ?? "Empty";
            Phone = pPhone ?? "Empty";
            isFavorite = pIsFavorite;            
            ContactImageSource = "defaultcontact.png";

        }

        [PrimaryKey]
        public string ContactID { get; private set; }                   
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        bool _isFavorite;
        public bool isFavorite
        {
            set { SetProperty(ref _isFavorite, value);
                FavorateImageSource = (isFavorite) ? "starfavorited.png" : "starempty.png";
            }
            get { return _isFavorite; }                     
        }
        
        private string _ContactImageSource;
        public string ContactImageSource
        {
            set
            {
                SetProperty(ref _ContactImageSource, value);
            }
            get { return _ContactImageSource; }
        }

        private string _FavoriteImageSource;
        public string FavorateImageSource
        {
            set
            {
                SetProperty(ref _FavoriteImageSource, value);
            }
            get { return _FavoriteImageSource; }
        }

        public override string ToString()
        {
           return Name;
        }
    }
}
