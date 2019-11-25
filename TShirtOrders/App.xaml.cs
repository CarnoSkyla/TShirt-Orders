using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TShirtOrders
{
    public partial class App : Application
    {
        private static TShirtDatabase database;
       
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Page1());

           
        }

        public static TShirtDatabase Database

        {

            get

            {

                if (database == null)

                {

                    database = new TShirtDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "tshirtorders.db3"));

                }

                return database;

            }

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
