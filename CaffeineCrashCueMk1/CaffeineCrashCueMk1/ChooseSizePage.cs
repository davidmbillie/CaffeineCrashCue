using CaffeineCrashProvider.Sizes;
using CaffeineCrashProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class ChooseSizePage : ContentPage
	{
		public ChooseSizePage(SizesSet sizes, string source, Type caffeineType)
		{
			Title = "Choose Size";
			Content = new StackLayout();

			StackLayout stackContent = (StackLayout)Content;

			HashSet<Button> sizeButtons = new HashSet<Button>();
			FieldInfo sizeInfo = caffeineType.GetField(source);
			Dictionary<string, Beverage> sizePairs = (Dictionary<string, Beverage>)sizeInfo.GetValue(sizes);
			foreach (KeyValuePair<string, Beverage> sizePair in sizePairs)
			{
				sizeButtons.Add(new Button { Text = sizePair.Key + ": " + sizePair.Value.Oz });
			}
			foreach (Button button in sizeButtons)
			{
				stackContent.Children.Add(button);
			}
		}
	}
}