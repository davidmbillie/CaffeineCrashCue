using AdMob.CustomRenders;
using Xamarin.Forms;

namespace CaffeineCrashCue
{
	public class HourEnergyPage : ContentPage
	{
		public HourEnergyPage()
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Content = new StackLayout();
			StackLayout stackContent = (StackLayout)Content;

			FlexLayout flexContent = new FlexLayout
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly,
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand
			};

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

			AdBanner adBanner = new AdBanner()
			{
				Size = AdBanner.Sizes.Standardbanner,
				HeightRequest = 90
			};

			flexContent.Children.Add(hourLabel);
			flexContent.Children.Add(hourStepper);
			flexContent.Children.Add(calcButton);

			stackContent.Children.Add(flexContent);
			stackContent.Children.Add(adBanner);
		}
	}
}