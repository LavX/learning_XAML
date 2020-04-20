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
    public partial class RecentSearchesList : ContentPage
    {
        private ObservableCollection<History> _history;

        public RecentSearchesList()
        {
            InitializeComponent();
            _history = new ObservableCollection<History> {
                        new History { Location = "West Hollywood, CA, United States", StartDate = "May 1, 2020", EndDate = "May 14, 2020" },
                        new History { Location = "New York, NY, United States", StartDate = "May 3, 2020", EndDate = "May 10, 2020" },
                        new History { Location = "Toronto, On, Canada", StartDate = "May 6, 2020", EndDate = "May 30, 2020" },
                        new History { Location = "Bergen, Hordaland, Norway", StartDate = "May 1, 2020", EndDate = "May 24, 2020" },
                        };
            RecentSearches.ItemsSource = GetHistory();
        }
       

        IEnumerable<History> GetHistory(string searchText = null)
        {
            if (String.IsNullOrWhiteSpace(searchText))
                return _history;
            return _history.Where(c => c.Location.StartsWith(searchText));
        }

        private void RecentSearches_Refreshing(object sender, EventArgs e)
        {
            RecentSearches.ItemsSource = GetHistory();
            RecentSearches.EndRefresh();
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var DeleteHistoryItem = (sender as MenuItem).CommandParameter as History;
            _history.Remove(DeleteHistoryItem);
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            RecentSearches.ItemsSource = GetHistory(e.NewTextValue);
        }
    }
}