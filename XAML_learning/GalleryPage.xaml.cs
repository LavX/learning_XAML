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
    public partial class GalleryPage : ContentPage
    {
        int num = 0;
        PictureChanger GalleryImg = new PictureChanger();

        public GalleryPage()
        {
            InitializeComponent();
            var ImageSourceBG = new UriImageSource { Uri = new Uri(GalleryImg.PicUrl[num]) };
            ImageSourceBG.CachingEnabled = false;
            GalleryPicture.Source = ImageSourceBG;
        }

        private void Button_Pressed_Back(object sender, EventArgs e)
        {
            if (num > 0)
            {
                num--;
                GalleryPicture.Source = GalleryImg.PicUrl[num];
            }
            else
            {
                num = GalleryImg.PicUrl.Length - 1;
                GalleryPicture.Source = GalleryImg.PicUrl[num];
            }
        }

        private void Button_Pressed_Next(object sender, EventArgs e)
        {
            if (num < GalleryImg.PicUrl.Length - 1)
            {
                num++;
                GalleryPicture.Source = GalleryImg.PicUrl[num];
            }
            else
            {
                num = 0;
                num++;
                GalleryPicture.Source = GalleryImg.PicUrl[num];
            }
        }

        public class PictureChanger
        {
            public string[] PicUrl = new string[5];
            public PictureChanger()
            {
                PicUrl[0] = "https://edelenyizsolt.hu/wp-content/uploads/2019/12/aurora-borealis.jpg";
                PicUrl[1] = "https://kep.cdn.index.hu/1/0/2011/20111/201112/20111208_1268824_56bd6a4882299773c9dd7c12f9356899_wm.jpg";
                PicUrl[2] = "https://kep.cdn.index.hu/1/0/2756/27561/275616/27561607_2114251_e127387151e5d9cbdf08a1432c21f784_wm.jpg";
                PicUrl[3] = "https://hadlerdmc.com/wp-content/uploads/2013/10/NO-opera-og-ballet.jpg";
                PicUrl[4] = "https://roadster.hu/app/uploads/2019/06/DSC_1491s.jpg";
            }
        }
    }
}