using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.Models;

namespace XAML_learning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();

            NameList.ItemsSource = new List<ContactGroup> {
            new ContactGroup("A", "A")
            {
            new Contact { Name = "Alexa", ImageUrl = "http://placekitten.com/100/99" },
            },
            new ContactGroup("E", "E")
            {
            new Contact { Name = "Elizabeth", ImageUrl = "http://placekitten.com/100/101", Status="Hey, let's talk!" }
            },
                new ContactGroup("L", "L")
            {
                new Contact { Name = "Laszlo", ImageUrl = "http://placekitten.com/100/100"},
            }
            };
        }
    }
}