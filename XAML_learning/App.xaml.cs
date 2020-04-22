using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML_learning
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ToolbarItems.MainPage());
            //MainPage = new Popups.MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
