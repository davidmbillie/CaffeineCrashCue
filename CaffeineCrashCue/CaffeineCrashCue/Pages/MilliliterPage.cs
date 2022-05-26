using CaffeineCrashProvider;
using CaffeineCrashProvider.Sizes;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCue
{
	public class MilliliterPage : ContentPage
	{
		public MilliliterPage(double coeff, double amount, bool extendedRelease = false)
		{
            BackgroundImageSource = CueConstants.BackgroundImage;

            Title = "Enter Milliliters";

            Content = new StackLayout();
            StackLayout stackContent = (StackLayout)Content;

            FlexLayout flexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Column,
                AlignItems = FlexAlignItems.Center,
                JustifyContent = FlexJustify.SpaceEvenly,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Entry mlEntry = new Entry()
            {
                Text = Preferences.Get("a_defaultMl", "200"),
                Keyboard = Keyboard.Numeric,
                MaxLength = 5,
                FontSize = 48,
                HorizontalTextAlignment = TextAlignment.Center,
                WidthRequest = 140
            };

            Label mlLabel = new Label()
            {
                Text = $"ml x{Environment.NewLine}{amount.ToString("0.##")} mg/ml",
                TextColor = Color.Black,
                FontSize = 24,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            StackLayout mlLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children =
                {
                    mlEntry,
                    mlLabel
                }
            };

            mlEntry.TextChanged += (sender, e) =>
            {
                if (e.NewTextValue.IndexOf('.') != e.NewTextValue.LastIndexOf('.'))
                {
                    mlEntry.Text = e.OldTextValue;
                }
                mlEntry.Text = e.NewTextValue.ToNumericString();
            };

            Button mlButton = new Button()
            {
                Text = "Calculate Crash Time",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
            };

            mlButton.Clicked += async (sender, e) =>
            {
                string mlText = mlEntry.Text;
                if (string.IsNullOrWhiteSpace(mlText))
                {
                    mlText = Preferences.Get("a_defaultMl", "200");
                }
                Preferences.Set("a_defaultMl", mlText);
                double mls = Convert.ToDouble(mlText);
                double totalAmount = amount * mls;
                await Navigation.PushAsync(new TimePage(coeff, totalAmount, extendedRelease));
            };

            flexLayout.Children.Add(mlLayout);
            flexLayout.Children.Add(mlButton);

            stackContent.Children.Add(flexLayout);
            stackContent.AddAdBanner();
        }
	}
}