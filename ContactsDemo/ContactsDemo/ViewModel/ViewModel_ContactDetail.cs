using ContactsDemo.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

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

        private ICommand _PhoneCall;
        public ICommand PhoneCall
        {
            get
            {
                return _PhoneCall ?? (_PhoneCall = new Command(async (phonenumber) => await ExecutePhoneCall((string)phonenumber)));
            }
        }

        public async Task ExecutePhoneCall(string number)
        {
            await Task.Run(() =>
            {
                DependencyService.Get<IPhone>().PlaceCall(number);
            });
        }

        private ICommand _SendEmail;
        public ICommand SendEmail
        {
            get
            {
                return _SendEmail ?? (_SendEmail = new Command(async (toemail) => await ExecuteSendEmail((string)toemail)));
            }
        }

        public async Task ExecuteSendEmail(string toEmail)
        {
            await Task.Run(() =>
            {
                DependencyService.Get<IEmail>().OpenEmailClient(toEmail);
            });
        }


    }
}
