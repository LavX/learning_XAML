using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAML_learning.Models;

namespace XAML_learning.InstagramApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InstaFeed : ContentPage
    {
        public InstaFeed()
        {
            InitializeComponent();
            List<InstaUsers> Users = GenerateUsers();
            FeedList.ItemsSource = GenerateFeed(Users);
        }

        List<InstaUsers> GenerateUsers() 
        {
            List<InstaUsers> users = new List<InstaUsers>
            {
                new InstaUsers { FirstName = "Melissa", LastName = "Suarez", NickName = "Lissa", ImageUrl = "https://loremflickr.com/320/240/woman"},
                new InstaUsers { FirstName = "Nicole", LastName = "Glenn", NickName = "Nikki", ImageUrl = "https://loremflickr.com/320/241/woman"},
                new InstaUsers { FirstName = "Amanda", LastName = "Ayala", NickName = "Manda", ImageUrl = "https://loremflickr.com/320/242/woman"},
                new InstaUsers { FirstName = "Sarah", LastName = "Duran", NickName = "Sadie", ImageUrl = "https://loremflickr.com/320/243/woman"},
                new InstaUsers { FirstName = "Jessica", LastName = "Deleon", NickName = "Jess", ImageUrl = "https://loremflickr.com/320/244/woman"}
            };
            return users;
        }

        List<InstaFeedGenerator> GenerateFeed(List<InstaUsers> users)
        {
            int EventType;
            int UserId;
            List<InstaFeedGenerator> FeedItems = new List<InstaFeedGenerator>();
            Random rnd = new Random();
            InstaFeedGenerator Generate = new InstaFeedGenerator();
            for (int i = 0; i < 10; i++)
            {
                EventType = rnd.Next(1, 5);
                switch (EventType)
                {
                    case 1:
                        UserId = rnd.Next(users.Count);
                        FeedItems.Add(new InstaFeedGenerator() 
                        { 
                            Notification = Generate.Registration(
                            firstName: users[UserId].FirstName,
                            lastName: users[UserId].LastName),
                            Avatar = users[UserId].ImageUrl,
                            firstName = users[UserId].FirstName,
                            lastName = users[UserId].LastName,
                            nickName = users[UserId].NickName
                        });
                        break;
                    case 2:
                        UserId = rnd.Next(users.Count);
                        FeedItems.Add(new InstaFeedGenerator()
                        {
                            Notification = Generate.Following(
                            nickName: users[UserId].NickName),
                            Avatar = users[UserId].ImageUrl,
                            firstName = users[UserId].FirstName,
                            lastName = users[UserId].LastName,
                            nickName = users[UserId].NickName
                        });
                        break;
                    case 3:
                        UserId = rnd.Next(users.Count);
                        FeedItems.Add(new InstaFeedGenerator()
                        {
                            Notification = Generate.Like(
                            nickName: users[UserId].NickName),
                            Avatar = users[UserId].ImageUrl,
                            firstName = users[UserId].FirstName,
                            lastName = users[UserId].LastName,
                            nickName = users[UserId].NickName
                        });
                        break;
                    case 4:
                        UserId = rnd.Next(users.Count);
                        FeedItems.Add(new InstaFeedGenerator()
                        {
                            Notification = Generate.Photo(
                            nickName: users[UserId].FirstName,
                            nickName2: users[rnd.Next(users.Count)].LastName),
                            Avatar = users[UserId].ImageUrl,
                            firstName = users[UserId].FirstName,
                            lastName = users[UserId].LastName,
                            nickName = users[UserId].NickName
                        });
                        break;

                }
            }
            return FeedItems;
        }

        async private void FeedList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;
            var feedItem = e.SelectedItem as InstaFeedGenerator;
            await Navigation.PushAsync(new UserPage(feedItem));
            FeedList.SelectedItem = null;
        }

        private void FeedList_Refreshing(object sender, EventArgs e)
        {
            List<InstaUsers> Users = GenerateUsers();
            FeedList.ItemsSource = GenerateFeed(Users);
            FeedList.EndRefresh();
        }
    }
}