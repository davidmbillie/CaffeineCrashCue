using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaffeineCrashProvider.Sizes;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Lower_Right_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesFastFood())));
        }
    }
}
