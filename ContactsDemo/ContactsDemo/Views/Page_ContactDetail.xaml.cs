using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page_ContactDetail : ContentPage
	{
		public Page_ContactDetail (Models.Model_Contact contact)
		{
			InitializeComponent ();
            BindingContext = new ViewModel.ViewModel_ContactDetail(contact);
		}
	}
}