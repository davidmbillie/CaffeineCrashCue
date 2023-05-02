using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace AdMob.CustomRenders
{
    public class AdBanner : View
    {
        public enum Sizes { Standardbanner, LargeBanner, MediumRectangle, FullBanner, Leaderboard, SmartBannerPortrait }
        public Sizes Size { get; set; }
        public AdBanner()
        {
            this.BackgroundColor = Colors.Transparent;
        }
    }
}
