using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML_learning.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async private void Button_Clicked(object sender, EventArgs e)
        {
            var response = await DisplayAlert("Warning", "Are you sure", "Yes", "No");
            if (response == true)
                await DisplayAlert("Done", "Your response will be saved!", "Ok");
            else
                await DisplayAlert("Canceled", "Your response will be saved!", "Ok");

        }

        async private void Button_Clicked_1(object sender, EventArgs e)
        {
            var response = await DisplayActionSheet("Title", "Cancel", "Delete", "Copy link", "Message", "Email");
            await DisplayAlert("Response", response, "Ok");

        }
    }
}