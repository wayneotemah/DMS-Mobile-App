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

namespace DMS_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {

            var login = new Login();
            BindingContext = login;
            login.DisplayLoginMsgPrompt += () => DisplayAlert("Error", "Something went wrong, try again", "OK");
            InitializeComponent();


        }
    }
}