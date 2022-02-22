//using DMS_App.Services;
using DMS_App.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DMS_App
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            {
                string token = Xamarin.Essentials.Preferences.Get("accessToken", string.Empty);
                if (string.IsNullOrEmpty(token))
                {
                    MainPage = new LoginPage();
                }
                else
                {
                    MainPage = new AppShell();

                }
             }

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
