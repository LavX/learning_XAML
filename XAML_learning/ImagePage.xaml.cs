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
    public partial class ImagePage : ContentPage
    {
        public ImagePage()
        {
            InitializeComponent();
            var ImageSourceLogo = new UriImageSource { Uri = new Uri("https://lavx.hu/assets/img/logo.png") };
            ImageSourceLogo.CachingEnabled = false;
            LogoImage.Source = ImageSourceLogo;
            
            var ImageSourceBG = new UriImageSource { Uri = new Uri("http://image.baidu.com/search/down?tn=download&ipn=dwnl&word=download&ie=utf8&fr=result&url=http%3A%2F%2Fhiphotos.baidu.com%2Fspace%2Fpic%2Fitem%2F472309f7905298222ed7df99d8ca7bcb0b46d480.jpg") };
            ImageSourceBG.CachingEnabled = false;
            BackgroundImage.Source = ImageSourceBG;

            // ServiceImage.Source = ImageSource.FromResource("XAML_learning.Images.signage.png");
        }
        }
}