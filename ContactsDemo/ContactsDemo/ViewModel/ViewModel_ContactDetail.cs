using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.ViewModel
{
    public class ViewModel_ContactDetail : _Base_ViewModel
    {
        private Models.Model_Contact _Contact;
        public Models.Model_Contact PropertyContact
        {
            set { SetProperty(ref _Contact, value); }
            get { return _Contact; }
        }

        public ViewModel_ContactDetail(Models.Model_Contact contact)
        {
            PropertyContact = contact;
        }

       
    }
}
