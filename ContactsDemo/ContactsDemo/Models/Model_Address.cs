using ContactsDemo.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Models
{
    public class Model_Address : _Base_Model, IMappable
    {

        public Model_Address()
        {

        }

        public Model_Address(string pAddress, string pCity, string pState, string pPostalCode, double pLatitude, double pLongitude, int ContactID)
        {

        }

        [PrimaryKey, AutoIncrement]
        public int AddressID { get; private set; }

        public int ContactID { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }           

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
