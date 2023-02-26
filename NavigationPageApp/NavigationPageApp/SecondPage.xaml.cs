using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NavigationPageApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
        }

        private async void  Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}