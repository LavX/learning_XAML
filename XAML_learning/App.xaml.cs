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

            MainPage = new RecentSearchesList();
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
