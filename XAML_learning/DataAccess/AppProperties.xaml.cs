using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XAML_learning.DataAccess
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppProperties : ContentPage
    {


        public AppProperties()
        {
            InitializeComponent();
            /*if (Application.Current.Properties.ContainsKey(TitleKey))
            title.Text = Application.Current.Properties[TitleKey].ToString();

            if (Application.Current.Properties.ContainsKey(NotificationsEnabledKey))
                notificationsEnabled.On = (bool) Application.Current.Properties[NotificationsEnabledKey]; */
            BindingContext = Application.Current;
            /*
            var app = Application.Current as App;
            title.Text = app.Title;
            notificationsEnabled.On = app.NotificationsEnabled;
            */
        }
        /*
        void OnChange(object sender, ToggledEventArgs e)
        {
            var app = Application.Current as App;
            app.Title = title.Text;
            app.NotificationsEnabled = notificationsEnabled.On;
            //Application.Current.Properties[TitleKey] = title.Text;
            //Application.Current.Properties[NotificationsEnabledKey] = notificationsEnabled.On;

            //Application.Current.SavePropertiesAsync(); //ASAP save
        }
        */
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}