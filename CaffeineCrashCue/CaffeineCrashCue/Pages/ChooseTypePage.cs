﻿using AdMob.CustomRenders;
using CaffeineCrashProvider.Sizes;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace CaffeineCrashCue
{
    public class ChooseTypePage : ContentPage
    {
        public ChooseTypePage(SizesSet sizesSet, double coeff)
        {
            BackgroundImageSource = CueConstants.BackgroundImage;

            Title = "Choose Type";
            Content = new ScrollView();
            ScrollView scrollView = (ScrollView)Content;

            StackLayout stackContent = new StackLayout();

            if (sizesSet.QuantOnly.ContainsKey(CueConstants.EspressoShot))
            {
                Button espressoButton = new Button
                {
                    AutomationId = "btnEspresso",
                    BackgroundColor = Colors.FloralWhite,
                    TextColor = Colors.SaddleBrown,
                    Text = "Espresso Shot"
                };
                espressoButton.Clicked += async (sender, e) =>
                {
                    await Navigation.PushAsync(new QuantityPage(coeff, sizesSet.QuantOnly[CueConstants.EspressoShot]));
                };
                stackContent.Children.Add(espressoButton);
            }

            HashSet<Button> buttonHash = new HashSet<Button>();
            foreach (string source in sizesSet.Sources)
            {
                buttonHash.Add(new Button { Text = source.Replace('_', ' ') });
            }

            int x = 1;
            foreach (Button button in buttonHash)
            {
                button.AutomationId = $"choice{x}";
                if (button.Text.Contains("Tea") || button.Text.Contains("Energy") || button.Text.Contains("Dew"))
                {
                    button.TextColor = Colors.ForestGreen;
                }
                else
                {
                    button.TextColor = Colors.SaddleBrown;
                }
                button.BackgroundColor = Colors.FloralWhite;
                button.Clicked += async (sender, e) =>
                {
                    await Navigation.PushAsync(new ChooseSizePage(sizesSet, button.Text.Replace(' ', '_'), sizesSet.GetType(), coeff));
                };
                stackContent.Children.Add(button);
                x++;
            }

            stackContent.AddAdBanner();

            scrollView.Content = stackContent;
        }
    }
}