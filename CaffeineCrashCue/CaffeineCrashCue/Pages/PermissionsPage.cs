using AdMob.CustomRenders;
using System;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CaffeineCrashCue
{
    public class PermissionsPage : ContentPage
    {
        public PermissionsPage()
        {
            BackgroundImageSource = CueConstants.BackgroundImage;

            Title = "Review Permissions";

            Content = new StackLayout();
            StackLayout stackContent = (StackLayout)Content;

            FlexLayout flexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Column,
                AlignItems = FlexAlignItems.Center,
                JustifyContent = FlexJustify.SpaceEvenly,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            Label permissionsLabel = new Label
            {
                Text = "Please review the following permissions to ensure that the notification is able to be received properly",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 20.0,
                FontAttributes = FontAttributes.Bold
            };

            Label exactAlarmsLabel = new Label
            {
                Text = "Necessary for Android 12.0+ (should have been automatically set)",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 16.0,
                FontAttributes = FontAttributes.Bold
            };

            Button exactAlarmsButton = new Button
            {
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown,
                Text = "Set Exact Alarms"
            };

            exactAlarmsButton.Clicked += async (sender, e) =>
            {
                await ExactAlarmsClicked(sender, e);
            };

            Label batteryLabel = new Label
            {
                Text = "Recommended in the case of battery optimizations eating notifications",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 16.0,
                FontAttributes = FontAttributes.Bold
            };

            Label batteryInstructionsLabel = new Label
            {
                Text = "Press button, go to 'All apps', find 'Caffeine Crash Cue', and set to 'Don't optimize'",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 14.0,
                FontAttributes = FontAttributes.Italic
            };

            Button batteryButton = new Button
            {
                BackgroundColor = Color.FloralWhite,
                TextColor = Color.SaddleBrown,
                Text = "Ignore Battery Optimizations"
            };

            batteryButton.Clicked += async (sender, e) =>
            {
                await BatteryClicked(sender, e);
            };

            Label notesLabel = new Label
            {
                Text = "Notes",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 18.0,
                FontAttributes = FontAttributes.Bold
            };

            Label manuNoteLabel = new Label
            {
                Text = "- Some manufacturers like Samsung may have additional power settings that may need to be addressed.",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 16.0,
            };

            Label notifLabel = new Label
            {
                Text = "- Resuming or reopening the app will automatically make sure the notification is still scheduled.",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontSize = 16.0
            };

            flexLayout.Children.Add(permissionsLabel);
            flexLayout.Children.Add(exactAlarmsLabel);
            flexLayout.Children.Add(exactAlarmsButton);
            flexLayout.Children.Add(batteryLabel);
            flexLayout.Children.Add(batteryButton);
            flexLayout.Children.Add(batteryInstructionsLabel);
            flexLayout.Children.Add(notesLabel);
            flexLayout.Children.Add(manuNoteLabel);
            flexLayout.Children.Add(notifLabel);

            //AdBanner adBanner = new AdBanner()
            //{
            //    Size = AdBanner.Sizes.Standardbanner,
            //    HeightRequest = 90
            //};


            stackContent.Children.Add(flexLayout);
            //stackContent.Children.Add(adBanner);
        }

        public async Task BatteryClicked(object sender, EventArgs e)
        {
            IPermissions permissions = DependencyService.Get<IPermissions>();
            if (permissions.IgnoreBatteryAlreadySet())
            {
                await DisplayAlert("Permissions", "The 'Battery Optimization' permission has already been set.", "OK");
                return;
            }
            else
            {
                permissions.IgnoreBatteryOptimizations();
            }
        }

        public async Task ExactAlarmsClicked(object sender, EventArgs e)
        {
            IPermissions permissions = DependencyService.Get<IPermissions>();
            if (!permissions.CanSetExactAlarmPermission())
            {
                await DisplayAlert("Permissions", "The 'Exact Alarms' permission is not needed on this device.", "OK");
                return;
            }
            else if (permissions.ExactAlarmPermissionAlreadySet())
            {
                await DisplayAlert("Permissions", "The 'Exact Alarms' permission has already been set.", "OK");
                return;
            }
            else
            {
                permissions.RequestScheduleExactAlarm();
            }
        }
    }
}