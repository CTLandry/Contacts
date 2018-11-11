using ContactsDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.Models
{
    public class Model_Address : _Base_Model, IMappable
    {
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int AddressType { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
