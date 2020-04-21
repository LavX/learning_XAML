using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.Models;

namespace XAML_learning.MasterDetailPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsPage : MasterDetailPage
    {
        public ContactsPage()
        {
            InitializeComponent();
            ContactList.ItemsSource = new List<Contact>
            {
                new Contact { Name = "John"},
                new Contact { Name = "Dave", Status="Hey, let's talk!"}
            };
        }

        private void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var contact = e.SelectedItem as Contact;
            Detail = new NavigationPage(new ContactDetailPage(contact));
            IsPresented = false;
        }
    }
}