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
		private static Dictionary<string, Beverage> beverageMappings;
		private static double perOz;
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
		}
	}
}