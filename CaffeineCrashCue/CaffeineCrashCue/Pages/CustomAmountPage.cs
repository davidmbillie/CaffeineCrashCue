using AdMob.CustomRenders;
using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

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
                TextColor = Color.Black,
                FontSize = 16,
                VerticalTextAlignment = TextAlignment.Center
            };

            CheckBox extendedCheck = new CheckBox()
            {
                Color = Color.Black,
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
                Text = "Total",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
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
                Text = "Per Ounce",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
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
                Text = "Per Milliliter",
                Background = Color.FloralWhite,
                TextColor = Color.SaddleBrown
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
                Text = "Per Serving",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
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