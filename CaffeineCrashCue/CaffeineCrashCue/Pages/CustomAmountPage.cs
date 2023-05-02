using AdMob.CustomRenders;
using CaffeineCrashProvider;
using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Layouts;

namespace CaffeineCrashCue
{
    public class CustomAmountPage : ContentPage
    {
        private string DefaultAmount
        {
            get
            {
                return Preferences.Get("a_CustomAmount", "100");
            }
            set
            {
                Preferences.Set("a_CustomAmount", value);
            }
        }

        private bool DefaultExtended
        {
            get
            {
                return Preferences.Get(CueConstants.ExtendedReleaseKey, false);
            }
            set
            {
                Preferences.Set(CueConstants.ExtendedReleaseKey, value);
            }
        }

        private void SetDefaults(string Amount, bool Extended)
        {
            DefaultAmount = Amount;
            DefaultExtended = Extended;
        }

        public CustomAmountPage(double coeff)
        {
            BackgroundImageSource = CueConstants.BackgroundImage;

            Title = "Enter Custom Amount (mg)";

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

            Entry amountEntry = new Entry()
            {
                AutomationId = "txtAmount",
                Text = DefaultAmount,
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
                TextColor = Colors.Black,
                FontSize = 16,
                VerticalTextAlignment = TextAlignment.Center
            };

            CheckBox extendedCheck = new CheckBox()
            {
                AutomationId = "chkExtended",
                Color = Colors.Black,
                IsChecked = DefaultExtended
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
                AutomationId = "btnTotal",
                Text = "Total",
                BackgroundColor = Colors.FloralWhite,
                TextColor = Colors.SaddleBrown
            };

            amountButton.Clicked += async (sender, e) =>
            {
                string amountText = amountEntry.Text;
                if (string.IsNullOrWhiteSpace(amountText))
                {
                    amountText = DefaultAmount;
                }

                SetDefaults(amountText, extendedCheck.IsChecked);

                double amount = Convert.ToDouble(amountText);
                if (amountText == "999")
                {
                    //using "999" for notification testing
                    await Navigation.PushAsync(new TimePage());
                }
                else
                {
                    await Navigation.PushAsync(new TimePage(coeff, amount, extendedCheck.IsChecked));
                }
            };

            Button perOunceButton = new Button()
            {
                AutomationId = "btnOz",
                Text = "Per Ounce",
                BackgroundColor = Colors.FloralWhite,
                TextColor = Colors.SaddleBrown
            };


            perOunceButton.Clicked += async (sender, e) =>
            {
                string amountText = amountEntry.Text;
                if (string.IsNullOrWhiteSpace(amountText))
                {
                    amountText = DefaultAmount;
                }

                SetDefaults(amountText, extendedCheck.IsChecked);
                double amount = Convert.ToDouble(amountText);
                await Navigation.PushAsync(new OuncePage(coeff, amount, extendedCheck.IsChecked));
            };

            Button perMlButton = new Button()
            {
                AutomationId = "btnMl",
                Text = "Per Milliliter",
                Background = Colors.FloralWhite,
                TextColor = Colors.SaddleBrown
            };

            perMlButton.Clicked += async (sender, e) =>
            {
                string amountText = amountEntry.Text;
                if (string.IsNullOrWhiteSpace(amountText))
                {
                    amountText = DefaultAmount;
                }

                SetDefaults(amountText, extendedCheck.IsChecked);
                double amount = Convert.ToDouble(amountText);
                await Navigation.PushAsync(new MilliliterPage(coeff, amount, extendedCheck.IsChecked));
            };

            Button perServingButton = new Button()
            {
                AutomationId = "btnServing",
                Text = "Per Serving",
                BackgroundColor = Colors.FloralWhite,
                TextColor = Colors.SaddleBrown
            };

            perServingButton.Clicked += async (sender, e) =>
            {
                string amountText = amountEntry.Text;
                if (string.IsNullOrWhiteSpace(amountText))
                {
                    amountText = DefaultAmount;
                }

                SetDefaults(amountText, extendedCheck.IsChecked);
                double amount = Convert.ToDouble(amountText);
                await Navigation.PushAsync(new QuantityPage(coeff, amount, extendedCheck.IsChecked));
            };

            flexLayout.Children.Add(amountEntry);
            flexLayout.Children.Add(extendedLayout);
            flexLayout.Children.Add(amountButton);
            flexLayout.Children.Add(perOunceButton);
            flexLayout.Children.Add(perMlButton);
            flexLayout.Children.Add(perServingButton);

            stackContent.Children.Add(flexLayout);
            stackContent.AddAdBanner();
        }
    }
}