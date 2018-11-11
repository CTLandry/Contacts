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
	public partial class Page_ContactList : ContentPage
	{
		public Page_ContactList ()
		{
			InitializeComponent ();
            BindingContext = new ViewModel.ViewModel_ContactList();
		}
	}
}