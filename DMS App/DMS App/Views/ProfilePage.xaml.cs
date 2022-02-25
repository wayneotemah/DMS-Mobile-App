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

            if ( string.IsNullOrEmpty(Preferences.Get("email", string.Empty)) | string.IsNullOrEmpty(Preferences.Get("course_major", string.Empty)))
            {
                var accountinfo = await ApiService.GetStudentAccountInfo();
                var profileinfo = await ApiService.GetStudentProfileInfo();
                var detailsinfo = await ApiService.GetStudentDetailsInfo();
                if (accountinfo != null & profileinfo != null | detailsinfo != null)
                {
                    UsernameLabel.Text = Preferences.Get("username", string.Empty);
                    EmailLabel.Text = Preferences.Get("email", string.Empty);
                    PhoneLabel.Text = "No: "+Preferences.Get("phone_number", string.Empty);
                    AdmissionLabel.Text = Preferences.Get("admission_number", string.Empty);
                    CommunityNameLabel.Text = Preferences.Get("community_username",string.Empty);
                    StatusLabel.Text = Preferences.Get("status",string.Empty);
                    ImageProfile.Source = "https://ditams.herokuapp.com"+Preferences.Get("profile_photo", string.Empty);
                    CourseMajorLabel.Text = Preferences.Get("course_major", string.Empty);
                    BioLabel.Text =  Preferences.Get("bio", string.Empty);
                    YrLabel.Text = Preferences.Get("academic_year", string.Empty);
                    CourseMinLabel.Text = Preferences.Get("course_minor", "No Minor Course");
                    HobbiesLabel.Text =   Preferences.Get("hobbies_and_games", string.Empty);

                }
                else
                {
                    await DisplayAlert("Error", "Something went wrong while getting your data, please try again", "OK");

                }
            }
            else
            {
                UsernameLabel.Text = Preferences.Get("username", string.Empty);
                EmailLabel.Text = Preferences.Get("email", string.Empty);
                PhoneLabel.Text = Preferences.Get("phone_number", string.Empty);
                AdmissionLabel.Text = Preferences.Get("admission_number", string.Empty);
                CommunityNameLabel.Text = Preferences.Get("community_username", string.Empty);
                StatusLabel.Text = Preferences.Get("status", string.Empty);
                ImageProfile.Source  = new Uri("https://ditams.herokuapp.com"+Preferences.Get("profile_photo", string.Empty));
                CourseMajorLabel.Text = Preferences.Get("course_major", string.Empty);
                BioLabel.Text =  Preferences.Get("bio", string.Empty);
                YrLabel.Text = Preferences.Get("academic_year", string.Empty);
                CourseMinLabel.Text = Preferences.Get("course_minor", "No Minor Course");
                HobbiesLabel.Text =   Preferences.Get("hobbies_and_games", string.Empty);


            }

        }
    }
}