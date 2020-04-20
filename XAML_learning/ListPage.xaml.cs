using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        IEnumerable<Contact> GetContacts(string searchText = null)
        {
            var contacts = new List<Contact> {
                        new Contact { Name = "Alexa", ImageUrl = "http://placekitten.com/100/99" },
                        new Contact { Name = "Elizabeth", ImageUrl = "http://placekitten.com/100/101", Status="Hey, let's talk!" },
                        new Contact { Name = "Laszlo", ImageUrl = "http://placekitten.com/100/100"}

                        };
            if (String.IsNullOrWhiteSpace(searchText))
                return contacts;
            return contacts.Where(c => c.Name.StartsWith(searchText));
        }
        //private ObservableCollection<Contact> _contacts;

        public ListPage()
        {
            InitializeComponent();
            /*
                        _contacts = new ObservableCollection<Contact> {

                        new Contact { Name = "Alexa", ImageUrl = "http://placekitten.com/100/99" },

                        new Contact { Name = "Elizabeth", ImageUrl = "http://placekitten.com/100/101", Status="Hey, let's talk!" },

                        new Contact { Name = "Laszlo", ImageUrl = "http://placekitten.com/100/100"}

                        };
                        NameList.ItemsSource = _contacts;
            }
            */
            NameList.ItemsSource = GetContacts();
            /*
            private void NameList_ItemTapped(object sender, ItemTappedEventArgs e)
            {
                var contact = e.Item as Contact;
                DisplayAlert("Tapped", contact.Name, "OK");
            }

            private void NameList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
            {
                NameList.SelectedItem = null;
            }
            
            private void Call_Clicked(object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            var contact = menuItem.CommandParameter as Contact;
            DisplayAlert("Calling", contact.Name, "OK");
        }
        private void Delete_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            _contacts.Remove(contact);
        }
        */
        }

        private void NameList_Refreshing(object sender, EventArgs e)
        {
            NameList.ItemsSource = GetContacts();
            //NameList.IsRefreshing = false;
            NameList.EndRefresh();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            NameList.ItemsSource = GetContacts(e.NewTextValue);
        }

    }
}