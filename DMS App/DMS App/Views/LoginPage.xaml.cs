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
            InitializeComponent();
            BindingContext = new Login();
            //this.BindingContext = new LoginViewModel();

        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUsernameEntry.Text) || string.IsNullOrEmpty(LoginPasswordEntry.Text))
            {
                await DisplayAlert("Empty Values", "Please enter Email and Password", "OK");
            }
            else
            {
                var response = await ApiService.LoginStudent(LoginUsernameEntry.Text, LoginPasswordEntry.Text);
                if (response)
                {
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    await DisplayAlert("Oops!", "Problem logging you in, check log in details then try again", "OK");
                }
            }
        }
    }
}