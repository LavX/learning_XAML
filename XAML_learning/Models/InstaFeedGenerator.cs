using System;
using System.Collections.Generic;
using System.Text;

namespace XAML_learning.Models
{
    public class InstaFeedGenerator
    {
        public string Notification { set; get; }
        public string Avatar { set; get; }
        public string firstName { set; get; }
        public string lastName { set; get; }
        public string nickName { set; get; }
        public string FullName
        {
            get { return $"{firstName} {lastName}"; }
        }


        public string Registration(string firstName, string lastName)
        {
            string msg = "Your Facebook friend "+firstName+" "+lastName+" is on Instagram";
            return msg;
        }
        public string Following(string nickName)
        {
            string msg = nickName+" started following you";
            return msg;
        }
        public string Like(string nickName)
        {
            string msg = nickName+" liked your photo";
            return msg;
        }
        public string Photo(string nickName, string nickName2)
        {
            string msg = nickName+" sent a photo posted by @"+nickName2;
            return msg;
        }
    }
}
