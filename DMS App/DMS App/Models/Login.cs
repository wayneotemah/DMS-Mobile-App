using System;
using System.Collections.Generic;
using System.Text;

namespace DMS_App.Models
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

    }
}
