using System;
using System.Collections.Generic;
using System.Text;

namespace DMS_App.Models
{
    public class EventByID
    {
        public Events events { get; set; }
        public string location { get; set; }
        public DateTime date { get; set; }
    }
}
