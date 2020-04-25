using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;


namespace XAML_learning.Models
{
    public class ContactBookUser
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public bool IsBlocked { set; get; }
        public string FullName { get { return FirstName + " " + LastName; } }
    }
}
