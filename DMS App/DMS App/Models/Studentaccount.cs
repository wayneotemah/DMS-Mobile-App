using DMS_App.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DMS_App.Models
{
    public class Studentaccount: INotifyPropertyChanged
    {
        public string admission_number { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }


        public string Admission_number
        {
            get { return admission_number; }
            set 
            { 
                admission_number = value;
                OnPropertyChanged("admission_number");
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

        public string Email
        {
            get { return email; }
            set 
            {
                email = value;
                OnPropertyChanged("email");
            }

        }

        public string PhoneNumber
        {
            get { return phone_number; }
            set 
            {
                phone_number = value;
                OnPropertyChanged("phone_number");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
