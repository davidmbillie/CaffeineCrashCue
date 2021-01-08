using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class HourEnergyPage : ContentPage
	{
		public HourEnergyPage()
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Content = new FlexLayout
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly
			};
			FlexLayout flexContent = (FlexLayout)Content;

			Title = "Hour Energy";

			Stepper hourStepper = new Stepper
			{
				Value = 5.0,
				Maximum = 8.0,
				Minimum = 0.5,
				Increment = 0.5,
				BackgroundColor = Color.FloralWhite
			};

			Label hourLabel = new Label
			{
				Text = hourStepper.Value.ToString(),
				FontSize = 48.0,
				FontAttributes = FontAttributes.Bold
			};

			hourStepper.ValueChanged += (sender, e) =>
			{
				hourLabel.Text = hourStepper.Value.ToString();
			};

			Button calcButton = new Button
			{
				Text = "Set Crash Time",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};
			calcButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new TimePage(hourStepper.Value));
			};

			flexContent.Children.Add(hourLabel);
			flexContent.Children.Add(hourStepper);
			flexContent.Children.Add(calcButton);
		}
	}
}