using DMS_App.Models;
using DMS_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DMS_App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (Preferences.Get("email", string.Empty) != null)
            {
                UsernameLabel.Text = Preferences.Get("username", string.Empty);
                EmailLabel.Text = "Email: "+Preferences.Get("email", string.Empty);
                PhoneNoLabel.Text = "No: "+Preferences.Get("phone_number", string.Empty);
                AdmissionLabel.Text = Preferences.Get("admission_number", string.Empty);
                
            }
            else
            {
                var result = await ApiService.GetStudentAccountInfo();
                if (result != null)
                {
                    UsernameLabel.Text = Preferences.Get("username", string.Empty);
                    EmailLabel.Text = "Email: "+Preferences.Get("email", string.Empty);
                    PhoneNoLabel.Text = "No: "+Preferences.Get("phone_number", string.Empty);
                    AdmissionLabel.Text = Preferences.Get("admission_number", string.Empty);

                }
            }
        }
    }
}