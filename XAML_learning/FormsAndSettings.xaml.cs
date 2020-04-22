using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML_learning
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormsAndSettings : ContentPage
    {
        public class ContactMethods
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }
        public FormsAndSettings()
        {
            InitializeComponent();
            _contactMethods = GetContactMethods();
            foreach (var method in _contactMethods)
                contactMethod2.Items.Add(method.Name);
        }
        private IList<ContactMethods> GetContactMethods()
        {
            return new List<ContactMethods>
            {
            new ContactMethods { Id = 1, Name = "SMS"},
            new ContactMethods { Id = 2, Name = "E-mail" }
            };
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            label.IsVisible = e.Value;
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            EntryLabel2.Text = "Completed";
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            EntryLabel.Text = e.NewTextValue;
        }

        private void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ContactMethod = contactMethod.Items[contactMethod.SelectedIndex];
            DisplayAlert("Selection", ContactMethod, "Ok");
        }
        private IList<ContactMethods> _contactMethods;
        private void contactMethod2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = contactMethod2.Items[contactMethod2.SelectedIndex];
            var contactMethod = _contactMethods.Single(cm => cm.Name == name);
            
            DisplayAlert("Selection", name, "Ok");
        }
    }
}