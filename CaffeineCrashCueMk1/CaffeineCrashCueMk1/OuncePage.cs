using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class OuncePage : ContentPage
	{
		public OuncePage(double coeff, double amount, bool extendedRelease = false)
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
				Text = Preferences.Get("a_defaultOz", "6"),
				Keyboard = Keyboard.Numeric,
				MaxLength = 5,
				FontSize = 48,
				HorizontalTextAlignment = TextAlignment.Center,
				WidthRequest = 140
			};

			Label ounceLabel = new Label()
			{
				Text = $"oz. x{Environment.NewLine}{amount} mg",
				FontSize = 24,
				HorizontalTextAlignment = TextAlignment.Center,
				VerticalTextAlignment = TextAlignment.Center
			};

			StackLayout ounceLayout = new StackLayout
			{
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					ounceEntry,
					ounceLabel
				}
			};
;
			ounceEntry.TextChanged += (sender, e) =>
			{
				if (e.NewTextValue.IndexOf('.') != e.NewTextValue.LastIndexOf('.'))
				{
					ounceEntry.Text = e.OldTextValue;
				}
				ounceEntry.Text = e.NewTextValue.ToNumericString();
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
					ounceText = Preferences.Get("a_defaultOz", "6");
				}
				Preferences.Set("a_defaultOz", ounceText);
				double ounces = Convert.ToDouble(ounceText);
				double totalAmount = amount * ounces;
				await Navigation.PushAsync(new TimePage(coeff, totalAmount, extendedRelease));
			};

			flexLayout.Children.Add(ounceLayout);
			flexLayout.Children.Add(ounceButton);
		}
	}
}