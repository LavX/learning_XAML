using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.Models;


namespace XAML_learning.InstagramApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserPage : ContentPage
    {
        public UserPage(InstaFeedGenerator feedItem)
        {
            if (feedItem == null)
                throw new ArgumentException();
            BindingContext = feedItem;
            InitializeComponent();
            ProfileTitle.Title = feedItem.firstName + " " + feedItem.lastName;
            FullName.Text = feedItem.firstName + " " + feedItem.lastName;
            Description.Text = "Hello! My name is " + feedItem.firstName+" "+ feedItem.lastName;
        }
    }
}