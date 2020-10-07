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

        private async void FastFoodClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesFastFood())));
        }

        private async void CoffeeHouseClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesCoffeehouse())));
        }

        private async void DonutClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesDonut())));
        }

        private async void BottleClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesBottle())));
        }

        private async void CanClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesCan())));
        }

        private async void Lower_Right_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NavigationPage(new ChooseTypePage(new SizesFastFood())));
        }
    }
}
