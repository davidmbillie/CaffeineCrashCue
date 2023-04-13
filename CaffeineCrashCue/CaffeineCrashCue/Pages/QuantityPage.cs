using AdMob.CustomRenders;
using Xamarin.Forms;

namespace CaffeineCrashCue
{
    public class QuantityPage : ContentPage
    {
        public QuantityPage(double coeff, double caffeineAmount, bool extendedRelease = false)
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

            Title = "Quantity";

            Stepper quantStepper = new Stepper
            {
                AutomationId = "stepQuant",
                Value = 1.0,
                Maximum = 8.0,
                Minimum = 0.25,
                Increment = 0.25,
            };

            Label quantLabel = new Label
            {
                Text = quantStepper.Value.ToString(),
                TextColor = Color.Black,
                FontSize = 48.0,
                FontAttributes = FontAttributes.Bold
            };

            Label amountLabel = new Label
            {
                Text = $"x {caffeineAmount} mg",
                TextColor = Color.Black,
                FontSize = 24.0,
            };

            quantStepper.ValueChanged += (sender, e) =>
            {
                quantLabel.Text = $"{quantStepper.Value}";
            };

            Button calcButton = new Button
            {
                AutomationId = "btnCalc",
                Text = "Calculate Crash Time",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
            };

            calcButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TimePage(coeff, caffeineAmount * quantStepper.Value, extendedRelease));
            };

            flexContent.Children.Add(quantLabel);
            flexContent.Children.Add(amountLabel);
            flexContent.Children.Add(quantStepper);
            flexContent.Children.Add(calcButton);

            stackContent.Children.Add(flexContent);
            stackContent.AddAdBanner();
        }
    }
}