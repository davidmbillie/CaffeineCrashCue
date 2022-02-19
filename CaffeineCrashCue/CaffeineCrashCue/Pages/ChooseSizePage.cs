using AdMob.CustomRenders;
using CaffeineCrashProvider;
using CaffeineCrashProvider.Sizes;
using CaffeineCrashProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Xamarin.Forms;

namespace CaffeineCrashCue
{
    public class ChooseSizePage : ContentPage
    {
        private readonly Dictionary<string, Beverage> beverageMappings;
        private readonly double perOz;
        public ChooseSizePage(SizesSet sizes, string source, Type caffeineType, double coeff)
        {
            BackgroundImageSource = CueConstants.BackgroundImage;

            beverageMappings = new Dictionary<string, Beverage>();

            Title = "Choose Size";
            Content = new StackLayout();

            StackLayout stackContent = (StackLayout)Content;

            HashSet<Button> sizeButtons = new HashSet<Button>();
            FieldInfo sizeInfo = caffeineType.GetField(source);
            Dictionary<string, Beverage> sizePairs = (Dictionary<string, Beverage>)sizeInfo.GetValue(sizes);
            Beverage firstBev = sizePairs.ElementAt(0).Value;
            perOz = firstBev.CaffeinePerOz;

            if (sizes is SizesSoda)
            {
                Label iceNoteLabel = new Label
                {
                    BackgroundColor = Color.SaddleBrown,
                    TextColor = Color.FloralWhite,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    Text = "Note: the cup sizes don't factor in ice, so using 0.5 or 0.75 on the next page would be recommended."
                };
                stackContent.Children.Add(iceNoteLabel);
            }

            foreach (KeyValuePair<string, Beverage> sizePair in sizePairs)
            {
                string btnText = $"{sizePair.Key}: {sizePair.Value.Oz} ({sizePair.Value.Caffeine} mg)";
                btnText = btnText.Replace('_', ' ');
                sizeButtons.Add(new Button { Text = btnText });
                beverageMappings.Add(btnText, sizePair.Value);
            }

            foreach (Button button in sizeButtons)
            {
                button.BackgroundColor = Color.FloralWhite;
                button.TextColor = Color.SaddleBrown;
                button.Clicked += async (sender, e) =>
                {
                    double caffeineAmount = Convert.ToDouble(beverageMappings[button.Text].Caffeine);
                    await Navigation.PushAsync(new QuantityPage(coeff, caffeineAmount));
                };
                stackContent.Children.Add(button);
            }

            Button customButton = new Button()
            {
                Text = "Custom Size",
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown
            };

            customButton.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new OuncePage(coeff, perOz));
            };

            stackContent.Children.Add(customButton);

            //AdBanner adBanner = new AdBanner()
            //{
            //    Size = AdBanner.Sizes.Standardbanner,
            //    HeightRequest = 90
            //};

            //stackContent.Children.Add(adBanner);
        }
    }
}