using CaffeineCrashProvider.Sizes;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class ChooseTypePage : ContentPage
	{
		public ChooseTypePage(SizesSet sizesSet, double coeff)
		{
			Title = "Choose Type";
			Content = new StackLayout();

			StackLayout stackContent = (StackLayout)Content;

			HashSet<Button> buttonHash = new HashSet<Button>();
			foreach (string source in sizesSet.Sources)
			{
				buttonHash.Add(new Button { Text = source.Replace('_', ' ') });
			}
			foreach (Button button in buttonHash)
			{
				button.Clicked += async (sender, e) =>
				{
					await Navigation.PushAsync(new ChooseSizePage(sizesSet, button.Text.Replace(' ', '_'), sizesSet.GetType(), coeff));
				};
				stackContent.Children.Add(button);
			}
		}
	}
}