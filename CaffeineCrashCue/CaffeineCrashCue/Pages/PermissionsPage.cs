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
                Text = "New battery optimizations can cause scheduled notifications to be lost. " +
                "The following permissions are highly recommended for the notifications to be displayed, " +
                "but device-specific settings may still need to be set. " +
                "Regardless, resuming or re-opening the app will automatically refresh the scheduling of the notification.",
                TextColor = Color.Black,
                FontSize = 16.0,
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
            flexLayout.Children.Add(batteryButton);

            stackContent.Children.Add(flexLayout);
        }

        public async Task BatteryClicked(object sender, EventArgs e)
        {
            IPermissions permissions = DependencyService.Get<IPermissions>();
            if (permissions.IgnoreBatteryAlreadySet())
            {
                await DisplayAlert("Permissions", "Battery permission has already been set", "OK");
                return;
            }
            else
            {
                permissions.IgnoreBatteryOptimizations();
            }
        }
    }
}