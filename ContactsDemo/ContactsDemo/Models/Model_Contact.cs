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

        public Model_Contact(string pFirstName, string pLastName, string pCompany, string pEmail, string pPhone,
            bool pIsFavorite, Model_Address pAddress, string pContactImageSource)
        {
            FirstName = pFirstName ?? "Empty";
            LastName = pLastName ?? "Empty";
            Company = pCompany ?? "Empty";           
            Email = pEmail ?? "Empty";
            Phone = pPhone ?? "Empty";
            isFavorite = pIsFavorite;
            Address = pAddress;
            ContactImageSource = pContactImageSource ?? "defaultcontact.png";

        }

        [PrimaryKey, AutoIncrement]
        public int ContactID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isFavorite
        {
            get { return isFavorite; }
            set
            {
                isFavorite = value;
                FavorateImageSource = (isFavorite == true) ?  "starfavorited.png" :  "starempty.png";               
            }
        }
        public Model_Address Address { get; set; }
        public string ContactImageSource { get; set; }
        public string FavorateImageSource { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }
    }
}
