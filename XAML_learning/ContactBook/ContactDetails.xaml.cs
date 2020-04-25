using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.Models;

namespace XAML_learning.ContactBook
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetails : ContentPage
    {
        public event EventHandler<ContactBookUser> ContactAdded;
        public event EventHandler<ContactBookUser> ContactUpdated;

        public ContactDetails(ContactBookUser contact)
        {
            if (contact == null)
                throw new ArgumentNullException(nameof(contact));

            InitializeComponent();

			// We do not use the given contact as the BindingContext. 
			// The reason for this is that if the user make changes and
			// clicks the back button (instead of Save), the changes 
			// should be reverted. So, we create a separate Contact object
			// based on the given Contact and use that temporarily on this
			// page. When Save is clicked, we raise an event and notify 
			// others (in this case ContactsPage) that a contact is added or 
			// updated.
			BindingContext = new ContactBookUser
			{
				Id = contact.Id,
				FirstName = contact.FirstName,
				LastName = contact.LastName,
				Phone = contact.Phone,
				Email = contact.Email,
				IsBlocked = contact.IsBlocked
			};
		}

		async private void Button_Clicked(object sender, EventArgs e)
		{
			var contact = BindingContext as ContactBookUser;
			if (String.IsNullOrWhiteSpace(contact.FullName))
			{
				await DisplayAlert("Error", "Please enter the name.", "OK");
				return;
			}

			if (contact.Id == 0)
			{
				// This is just a temporary hack to differentiate between a
				// new and an existing Contact object. In the next section, 
				// we'll store these Contact objects in a database. So, they
				// will automaticlaly get an Id.
				contact.Id = 1;

				// This is null-conditional operator in C#. It is the same as:
				// 
				// if (ContactAdded != null)
				// 		ContactAdded(this, contact);
				//
				// Read my blog post for more details:
				// http://programmingwithmosh.com/csharp/csharp-6-features-that-help-you-write-cleaner-code/
				//
				ContactAdded?.Invoke(this, contact);
			}
			else
			{
				ContactUpdated?.Invoke(this, contact);
			}

			await Navigation.PopAsync();
		}
	}
    
}