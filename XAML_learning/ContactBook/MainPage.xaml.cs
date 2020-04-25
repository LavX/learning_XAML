using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.MasterDetail;
using XAML_learning.Models;

namespace XAML_learning.ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ContactBookUser> _contacts;
        public MainPage()
        {
            InitializeComponent();
            _contacts = new ObservableCollection<ContactBookUser>
            {
                new ContactBookUser { Id=1, FirstName = "John", LastName = "Smith", Phone="+36009911222", Email="john.smith@js.com", IsBlocked=false},
                new ContactBookUser { Id=2, FirstName = "Laszlo", LastName = "Toth", Phone="+36309073238", Email="laszlo.toth@lavx.hu", IsBlocked=false}
            };
            ContactList.ItemsSource = _contacts;
        }

        async private void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            var selectedContact = e.SelectedItem as ContactBookUser;

            ContactList.SelectedItem = null;

            var page = new ContactDetails(selectedContact);


            page.ContactUpdated += (source, ContactBookUser) =>
            {
                selectedContact.Id = ContactBookUser.Id;
                selectedContact.FirstName = ContactBookUser.FirstName;
                selectedContact.LastName = ContactBookUser.LastName;
                selectedContact.Phone = ContactBookUser.Phone;
                selectedContact.Email = ContactBookUser.Email;
                selectedContact.IsBlocked = ContactBookUser.IsBlocked;
            };

            await Navigation.PushAsync(page);
        }

        async private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            var page = new ContactDetails(new ContactBookUser());

            page.ContactAdded += (source, contact) =>
            {
                _contacts.Add(contact);
            };
            await Navigation.PushAsync(page);
        }

       async private void MenuItem_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as ContactBookUser;

            if (await DisplayAlert("Warning", $"Are you sure you want to delete {contact.FullName}?", "Yes", "No"))
                _contacts.Remove(contact);
        }
    }
}