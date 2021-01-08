using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;

using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class OuncePage : ContentPage
	{
		private static string defaultOz = Preferences.Get("a_defaultOz", "6");
		public OuncePage(double coeff, double amount)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Title = "Enter Ounces";
			Content = new FlexLayout()
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly
			};
			FlexLayout flexLayout = (FlexLayout)Content;

			Entry ounceEntry = new Entry()
			{
				Text = defaultOz,
				Keyboard = Keyboard.Numeric,
				MaxLength = 3,
				FontSize = 48,
				HorizontalTextAlignment = TextAlignment.Center,
				WidthRequest = 100
			};

			ounceEntry.TextChanged += (sender, e) =>
			{
				ounceEntry.Text = ounceEntry.Text.ToNumericString();
			};

			Button ounceButton = new Button()
			{
				Text = "Calculate Crash Time",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};

			ounceButton.Clicked += async (sender, e) =>
			{
				string ounceText = ounceEntry.Text;
				if (string.IsNullOrWhiteSpace(ounceText))
				{
					ounceText = defaultOz;
				}
				Preferences.Set("a_defaultOz", ounceText);
				double ounces = Convert.ToDouble(ounceText);
				double totalAmount = amount * ounces;
				await Navigation.PushAsync(new TimePage(coeff, totalAmount));
			};

			flexLayout.Children.Add(ounceEntry);
			flexLayout.Children.Add(ounceButton);
		}
	}
}