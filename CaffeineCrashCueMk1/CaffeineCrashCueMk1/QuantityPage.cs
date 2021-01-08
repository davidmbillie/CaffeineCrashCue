using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class QuantityPage : ContentPage
	{
		public QuantityPage(double coeff, double caffeineAmount)
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Content = new FlexLayout
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly
			};
			FlexLayout flexContent = (FlexLayout)Content;

			Title = "Quantity";

			Stepper quantStepper = new Stepper
			{
				Value = 1.0,
				Maximum = 8.0,
				Minimum = 0.5,
				Increment = 0.5
			};

			Label quantLabel = new Label
			{
				Text = quantStepper.Value.ToString(),
				FontSize = 48.0,
				FontAttributes = FontAttributes.Bold
			};

			quantStepper.ValueChanged += (sender, e) =>
			{
				quantLabel.Text = quantStepper.Value.ToString();
			};

			Button calcButton = new Button
			{
				Text = "Calculate Crash Time"
			};
			calcButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new TimePage(coeff, caffeineAmount * quantStepper.Value));
			};

			flexContent.Children.Add(quantLabel);
			flexContent.Children.Add(quantStepper);
			flexContent.Children.Add(calcButton);
		}
	}
}