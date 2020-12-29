using System;
using CaffeineCrashProvider.Sizes;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
    public partial class MainPage : ContentPage
    {
        private static double coeff = 1;
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(double config_coeff)
		{
            coeff = config_coeff;

            InitializeComponent();
        }

        private async void FastFoodClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ChooseTypePage(new SizesFastFood(), coeff));
        }

        private async void CoffeeHouseClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ChooseTypePage(new SizesCoffeehouse(), coeff));
        }

        private async void DonutClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ChooseTypePage(new SizesDonut(), coeff));
        }

        private async void BottleClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ChooseTypePage(new SizesBottle(), coeff));
        }

        private async void CanClicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ChooseTypePage(new SizesCan(), coeff));
        }

        private async void Lower_Right_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TimePage());
        }

        private async void Customize_Clicked(object sender, EventArgs e)
		{
            await Navigation.PushAsync(new ConfigPage());
		}
    }
}
