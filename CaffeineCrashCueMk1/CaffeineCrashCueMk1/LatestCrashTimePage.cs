using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCueMk1
{
	public class LatestCrashTimePage : ContentPage
	{
		public LatestCrashTimePage()
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
						HorizontalTextAlignment = TextAlignment.Center,
						FontSize = 48
					}
				}
			};

			Button homeButton = new Button
			{
				Text = "Home",
				BackgroundColor = Color.FloralWhite,
				TextColor = Color.SaddleBrown
			};

			homeButton.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new MainPage());
			};

			FlexLayout flexContent = Content as FlexLayout;
			flexContent.Children.Add(homeButton);
		}
	}
}