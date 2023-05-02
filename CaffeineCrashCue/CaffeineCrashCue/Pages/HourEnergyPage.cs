using AdMob.CustomRenders;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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
                AutomationId = "stepHour",
                Value = 5.0,
                Maximum = 8.0,
                Minimum = 0.5,
                Increment = 0.5
            };

            Label hourLabel = new Label
            {
                Text = hourStepper.Value.ToString(),
                TextColor = Colors.Black,
                FontSize = 48.0,
                FontAttributes = FontAttributes.Bold
            };

            hourStepper.ValueChanged += (sender, e) =>
            {
                hourLabel.Text = hourStepper.Value.ToString();
            };

            Button calcButton = new Button
            {
                AutomationId = "btnCalc",
                Text = "Set Crash Time",
                BackgroundColor = Colors.FloralWhite,
                TextColor = Colors.SaddleBrown
            };
            calcButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new TimePage(hourStepper.Value));
            };

            flexContent.Children.Add(hourLabel);
            flexContent.Children.Add(hourStepper);
            flexContent.Children.Add(calcButton);

            stackContent.Children.Add(flexContent);
            stackContent.AddAdBanner();
        }
    }
}