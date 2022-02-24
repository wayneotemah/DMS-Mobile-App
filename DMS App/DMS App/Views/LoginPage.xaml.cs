using DMS_App.Services;
using DMS_App.ViewModels;
using DMS_App.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DMS_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            Preferences.Set("accessToken", "");
            Preferences.Set("admission_number", "");
            Preferences.Set("username", "");
            Preferences.Set("email", "");
            Preferences.Set("phone_number", "");
            Preferences.Set("community_username", "");
            Preferences.Set("status", "");
            Preferences.Set("profile_photo", "");

            var login = new Login();
            BindingContext = login;
            login.DisplayLoginMsgPrompt += () => DisplayAlert("Error", "Something went wrong, try again", "OK");
            InitializeComponent();
        }
    }
}