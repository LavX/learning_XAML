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
    public partial class QuotePage : ContentPage
    {
        int num=0;
        QuoteChanger QuoteLabel = new QuoteChanger();
        public QuotePage()
        {
            InitializeComponent();
            QuoteLabel.GetText(num);
            quote.Text = QuoteLabel.msg;
        }

        private void Button_Pressed(object sender, EventArgs e)
        {
            if (num < QuoteLabel.quotes.Length-1)
            {
                num++;
                QuoteLabel.GetText(num);
                quote.Text = QuoteLabel.msg;
            }
            else
            {
                num=0;
                QuoteLabel.GetText(num);
                quote.Text = QuoteLabel.msg;
            }
        }

        public class QuoteChanger
        {
            public string[] quotes = new string[5];
            public string msg;
            public QuoteChanger()
            {
                quotes[0] = "Because I believe in God and have faith in God, it doesn't mean I am immortal. It doesn't mean I am immune, as has been claimed. I am as scared as anyone of getting hurt, especially driving a Formula One car. - Ayrton Senna";
                quotes[1] = "People enjoy watching sports at the weekend and watching motor racing and whatever sports, and Formula One is the number one global platform which is competing regularly - not like the Olympic Games or the World Cup - so the macro case was this is something that we should be part of because it's going to grow, and it does. - Toto Wolff";
                quotes[2] = "Nothing can really prepare you for when you get in the Formula One car. Knowing that you're driving a multimillion-dollar car, and if you crash it it's going to cost a lot of money, and they might not give you another chance, is scary. - Lewis Hamilton";
                quotes[3] = "I'm not desperate to stay in Formula One. It needs to be sensible and it needs to be the right deal. - Nico Hülkenberg";
                quotes[4] = "I have always been very calm on the outside. I'm not too stressed now just because I'm in formula one. For me, tomorrow will be another day whether I finish first or last. I have to do the maximum and I cannot ask any more from myself. - Fernando Alonso";
            }
            public void GetText(int ind)
            {
              msg=quotes[ind];
            }

        }
}
}