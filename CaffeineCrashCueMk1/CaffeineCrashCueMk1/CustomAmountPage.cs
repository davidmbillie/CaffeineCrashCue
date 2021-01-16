using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class CustomAmountPage : ContentPage
	{
		private static string defaultAmount = Preferences.Get("a_CustomAmount", "100");
		private static bool defaultExtended = Preferences.Get("a_Extended", false);
		public CustomAmountPage(double coeff)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Title = "Enter Custom Amount (mg)";
			Content = new FlexLayout()
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly
			};
			FlexLayout flexLayout = (FlexLayout)Content;

			Entry amountEntry = new Entry()
			{
				Text = defaultAmount,
				Keyboard = Keyboard.Numeric,
				MaxLength = 5,
				FontSize = 48,
				HorizontalTextAlignment = TextAlignment.Center,
				WidthRequest = 140
			};

			amountEntry.TextChanged += (sender, e) =>
			{
				if (e.NewTextValue.IndexOf('.') != e.NewTextValue.LastIndexOf('.'))
				{
					amountEntry.Text = e.OldTextValue;
				}
				amountEntry.Text = e.NewTextValue.ToNumericString();
			};

			Label extendedLabel = new Label()
			{
				Text = "Extended Release",
				FontSize = 16,
				VerticalTextAlignment = TextAlignment.Center
			};

			CheckBox extendedCheck = new CheckBox()
			{
				Color = Color.SaddleBrown,
				IsChecked = Preferences.Get("a_Extended", false)
			};

			StackLayout extendedLayout = new StackLayout()
			{
				Orientation = StackOrientation.Horizontal,
				Children =
				{
					extendedLabel,
					extendedCheck
				}
			};

			Button amountButton = new Button()
			{
				Text = "Total",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};

			amountButton.Clicked += async (sender, e) =>
			{
				string amountText = amountEntry.Text;
				if (string.IsNullOrWhiteSpace(amountText))
				{
					amountText = defaultAmount;
				}
				Preferences.Set("a_CustomAmount", amountText);
				Preferences.Set("a_Extended", extendedCheck.IsChecked);
				double amount = Convert.ToDouble(amountText);
				if (amountText == "999")
				{
					//using "999" for notification testing
					await Navigation.PushAsync(new TimePage());
				}
				else
				{
					if (extendedCheck.IsChecked == true)
					{
						amount = amount * 2;
					}
					await Navigation.PushAsync(new TimePage(coeff, amount));
				}
			};

			Button perOunceButton = new Button()
			{
				Text = "Per Ounce",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};


			perOunceButton.Clicked += async (sender, e) =>
			{
				string amountText = amountEntry.Text;
				if (string.IsNullOrWhiteSpace(amountText))
				{
					amountText = defaultAmount;
				}
				Preferences.Set("a_CustomAmount", amountText);
				Preferences.Set("a_Extended", extendedCheck.IsChecked);
				double amount = Convert.ToDouble(amountText);
				if (extendedCheck.IsChecked == true)
				{
					amount = amount * 2;
				}
				await Navigation.PushAsync(new OuncePage(coeff, amount));
			};

			Button perServingButton = new Button()
			{
				Text = "Per Serving",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};

			perServingButton.Clicked += async (sender, e) =>
			{
				string amountText = amountEntry.Text;
				if (string.IsNullOrWhiteSpace(amountText))
				{
					amountText = defaultAmount;
				}
				Preferences.Set("a_CustomAmount", amountText);
				Preferences.Set("a_Extended", extendedCheck.IsChecked);
				double amount = Convert.ToDouble(amountText);
				if (extendedCheck.IsChecked == true)
				{
					amount = amount * 2;
				}
				await Navigation.PushAsync(new QuantityPage(coeff, amount));
			};

			flexLayout.Children.Add(amountEntry);
			flexLayout.Children.Add(extendedLayout);
			flexLayout.Children.Add(amountButton);
			flexLayout.Children.Add(perOunceButton);
			flexLayout.Children.Add(perServingButton);
		}
	}
}