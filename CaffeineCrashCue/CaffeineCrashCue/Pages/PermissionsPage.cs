using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace CaffeineCrashCue
{
    public class PermissionsPage : ContentPage
    {
        public PermissionsPage()
        {
            BackgroundImageSource = CueConstants.BackgroundImage;

            Title = "Request Permissions";

            Content = new StackLayout();
            StackLayout stackContent = (StackLayout)Content;

            FlexLayout flexLayout = new FlexLayout()
            {
                Direction = FlexDirection.Column,
                AlignItems = FlexAlignItems.Center,
                JustifyContent = FlexJustify.SpaceEvenly,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Label permissionsLabel = new Label
            {
                Text = "Please review the following permissions to ensure that the notification is able to be set.",
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                //Text = "New battery optimizations can cause scheduled notifications to be lost. " +
                //"The following permissions are highly recommended for the notifications to be displayed, " +
                //"but device-specific settings may still need to be set. " +
                //"Regardless, resuming or re-opening the app will automatically refresh the scheduling of the notification.",
                TextColor = Color.Black,
                FontSize = 20.0,
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

            flexLayout.Children.Add(permissionsLabel);
            flexLayout.Children.Add(exactAlarmsButton);
            flexLayout.Children.Add(batteryButton);

            stackContent.Children.Add(flexLayout);
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