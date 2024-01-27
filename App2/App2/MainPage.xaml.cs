using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public string[] quote = new string[3];
        public MainPage()
        {
            InitializeComponent();
            quote[0] = "Dzień dobry";
            quote[1] = "Good morning";
            quote[2] = "Buenos diás";

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            if(QuoteLabel.Text == quote[0])
                QuoteLabel.Text = quote[1];
            else if (QuoteLabel.Text == quote[1])
                    QuoteLabel.Text = quote[2];
            else if (QuoteLabel.Text == quote[2])
                QuoteLabel.Text = quote[0];
        }

        private void SliderValue_DragCompleted(object sender, EventArgs e)
        {
            int value = (int)SliderValue.Value;
            LabelValue.Text = "Rozmiar: " + value.ToString();
            QuoteLabel.FontSize = value;

        }
    }

}
