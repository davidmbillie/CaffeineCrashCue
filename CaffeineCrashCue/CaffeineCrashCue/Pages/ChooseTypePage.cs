using AdMob.CustomRenders;
using CaffeineCrashProvider.Sizes;
using System.Collections.Generic;

using Xamarin.Forms;

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
                    BackgroundColor = Color.FloralWhite,
                    TextColor = Color.SaddleBrown,
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
            foreach (Button button in buttonHash)
            {
                if (button.Text.Contains("Tea") || button.Text.Contains("Energy") || button.Text.Contains("Dew"))
                {
                    button.TextColor = Color.ForestGreen;
                }
                else
                {
                    button.TextColor = Color.SaddleBrown;
                }
                button.BackgroundColor = Color.FloralWhite;
                button.Clicked += async (sender, e) =>
                {
                    await Navigation.PushAsync(new ChooseSizePage(sizesSet, button.Text.Replace(' ', '_'), sizesSet.GetType(), coeff));
                };
                stackContent.Children.Add(button);
            }

            stackContent.AddAdBanner();

            scrollView.Content = stackContent;
        }
    }
}