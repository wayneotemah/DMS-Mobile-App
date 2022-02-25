using DMS_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DMS_App.Models
{
    public class Login : INotifyPropertyChanged
    {
        public Login()
        {
            LoginCommand = new Command(OnSubmit);
        }


        public string username { get; set; }
        public string password { get; set; }

        public string isLoading { get; set; }
        

        public string IsLoading
        {
            get { return isLoading; }
            set 
            { 
                isLoading = value;
                OnPropertyChanged("isLoading");

            }

        }
        
        public string Username
        {
            get { return username; }
            set 
            { 
                username = value;
                OnPropertyChanged("username");
            
            }
        }


        public string Password
        {
            get { return password; }
            set
            { 
                password = value;
                OnPropertyChanged("password");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public Action DisplayLoginMsgPrompt;

        public ICommand LoginCommand { protected set; get; }
        
        
        
        public async void OnSubmit()
        {
            IsLoading = "True";
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                DisplayLoginMsgPrompt();
                IsLoading = "False";
            }
            else
            {
                var response = await ApiService.LoginStudent(username, password);
                Preferences.Set("Username", username);

                if (response)
                {
                    Application.Current.MainPage = new AppShell();
                }
                else
                {
                    DisplayLoginMsgPrompt();
                }
                IsLoading = "False";

            }


        }


    }
}
