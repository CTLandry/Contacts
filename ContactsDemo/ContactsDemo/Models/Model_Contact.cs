using ContactsDemo.Interfaces;

using Xamarin.Forms;

namespace ContactsDemo.Models
{
    
    public class Model_Contact : _Base_Model, IContact
    {
       public Model_Contact()
        {

        }

        public Model_Contact(string pName, string pCompany, string pEmail, string pPhone,
            bool pIsFavorite, string pContactImageSource)
        {
            Name = Name ?? "Empty";           
            Company = pCompany ?? "Empty";           
            Email = pEmail ?? "Empty";
            Phone = pPhone ?? "Empty";
            isFavorite = pIsFavorite;            
            ContactImageSource = pContactImageSource ?? "defaultcontact.png";

        }
                   
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        private bool _isFavorite { get; set; }
        public bool isFavorite
        {
            get { return _isFavorite; }
            set
            {
                _isFavorite = value;
                FavorateImageSource = (isFavorite == true) ?  "starfavorited.png" :  "starempty.png";               
            }
        }
        
        public string ContactImageSource { get; set; }
        public string FavorateImageSource { get; set; }

        public override string ToString()
        {
           return Name;
        }
    }
}
