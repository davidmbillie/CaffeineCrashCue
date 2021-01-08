using CaffeineCrashProvider.Sizes;
using CaffeineCrashProvider.Models;
using System;
using System.Collections.Generic;
using System.Reflection;

using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class ChooseSizePage : ContentPage
	{
		private static Dictionary<string, Beverage> beverageMappings;
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
			foreach (KeyValuePair<string, Beverage> sizePair in sizePairs)
			{
				string btnText = sizePair.Key + ": " + sizePair.Value.Oz;
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
		}
	}
}