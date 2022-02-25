using System;
using System.Collections.Generic;
using System.Text;

namespace DMS_App.Models
{
    public class UsersPosts
    {
        public int post_id { get; set; }
        public string title { get; set; }
        public string student { get; set; }
        public string post { get; set; }
        public string pic { get; set; }
        public DateTime date { get; set; }
        public string fullpicUrl => "https://ditams.herokuapp.com"+pic;
        public int height => (string.IsNullOrEmpty(pic) ) ? 0 : 200;
    }
}
