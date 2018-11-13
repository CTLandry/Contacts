using ContactsDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactsDemo.ViewModel
{
    public class ViewModel_ContactDetail : _Base_ViewModel
    {
        private IContact _Contact;
        public IContact PropertyContact
        {
            set { SetProperty(ref _Contact, value); }
            get { return _Contact; }
        }

        public ViewModel_ContactDetail(IContact contact)
        {
            PropertyContact = contact;
        }

       
    }
}
