using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RentApp
{
    public partial class App : Application
    {
        public static NavigationPage Navigation { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = navigation(new Views.Session.LoginPage());
        }


        private NavigationPage navigation(Page page)
        {
            Navigation = new NavigationPage(page);
            return Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
