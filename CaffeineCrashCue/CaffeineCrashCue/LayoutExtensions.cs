using AdMob.CustomRenders;
using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CaffeineCrashCue
{
    internal static class LayoutExtensions
    {
        public static void AddAdBanner(this StackLayout stackLayout)
        {
            AdBanner adBanner = new AdBanner()
            {
                Size = AdBanner.Sizes.Standardbanner,
                HeightRequest = 90
            };

            stackLayout.Children.Add(adBanner);
        }
    }
}
