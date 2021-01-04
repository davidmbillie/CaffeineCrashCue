using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class LatestCrashTime : ContentPage
	{
		public LatestCrashTime()
		{
			BackgroundImageSource = CueConstants.BackgroundImage;

			Title = "Latest Crash Time";
			Content = new FlexLayout
			{
				Direction = FlexDirection.Column,
				AlignItems = FlexAlignItems.Center,
				JustifyContent = FlexJustify.SpaceEvenly,
				Children = {
					new Label {
						Text = Preferences.Get(CueConstants.CrashTimePrefKey, "No recent crash times"),
						FontSize = 48
					}
				}
			};
		}
	}
}