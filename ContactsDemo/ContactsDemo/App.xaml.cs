using ContactsDemo.Database;
using ContactsDemo.Views;
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
        static SQLite_Database contactsSQLiteDB;

        public static SQLite_Database LocalDatabase
        {
            get
            {
                if (contactsSQLiteDB == null)
                {
                    contactsSQLiteDB = new SQLite_Database(
                      Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ContactsSQLite.db3"));
                }
                return contactsSQLiteDB;
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
