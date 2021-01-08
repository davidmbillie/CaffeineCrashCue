using CaffeineCrashProvider;
using System;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class CustomAmountPage : ContentPage
	{
		private const string defaultAmount = "100";
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
				MaxLength = 3,
				FontSize = 48
			};

			amountEntry.TextChanged += (sender, e) =>
			{
				amountEntry.Text = amountEntry.Text.ToNumericString();
			};

			Button amountButton = new Button()
			{
				Text = "Calculate Crash Time"
			};

			amountButton.Clicked += async (sender, e) =>
			{
				string amountText = amountEntry.Text;
				if (string.IsNullOrWhiteSpace(amountText))
				{
					amountText = defaultAmount;
				}
				double amount = Convert.ToDouble(amountText);
				if (amountText == "4")
				{
					//using "4" for notification testing
					await Navigation.PushAsync(new TimePage());
				}
				else
				{
					await Navigation.PushAsync(new TimePage(coeff, amount));
				}
			};

			flexLayout.Children.Add(amountEntry);
			flexLayout.Children.Add(amountButton);
		}
	}
}