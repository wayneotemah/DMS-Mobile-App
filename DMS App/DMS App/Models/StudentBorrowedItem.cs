using System;
using System.Collections.Generic;
using System.Text;

namespace DMS_App.Models
{
    public class StudentBorrowedItem
    {
        public int id { get; set; }
        public Studentaccount studentaccount { get; set; }
        public Resources resources { get; set; }
        public DateTime date_inquied { get; set; }
        public string status { get; set; }
        public object date_taken { get; set; }
        public int period_days { get; set; }
    }
}
