using System;
using System.Collections.Generic;
using System.Text;

namespace XAML_learning.Models
{
    class History
    {
        public string Location { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string Duration { get { return StartDate + " - " + EndDate; } }
    }
}
