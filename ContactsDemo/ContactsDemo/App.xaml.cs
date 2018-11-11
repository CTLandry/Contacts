using ContactsDemo.Database;
using ContactsDemo.Views;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ContactsDemo
{
    public partial class App : Application
    {
        public static NavigationPage MasterNavigation;
        static SQLite_ContactsDatabase database;

        public static SQLite_ContactsDatabase ContactsDatabase
        {
            get
            {
                if (database == null)
                {
                    database = new SQLite_ContactsDatabase(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Contacts.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MasterNavigation = new NavigationPage();
            MainPage = new Page_Splash();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

      
    }
}
