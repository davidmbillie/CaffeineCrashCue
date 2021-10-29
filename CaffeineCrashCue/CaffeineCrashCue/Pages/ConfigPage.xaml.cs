using CaffeineCrashProvider;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCue
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigPage : ContentPage
	{
		private double F_alc = 1;
		private double F_bc = 1;
		private double F_ex = 1;
		private double F_gfj = 1;
		private double F_preg = 1;
		private double F_smoke = 1;
		private double F_vgc = 1;
		private double F_weight = 1;

		public ConfigPage()
		{
			BackgroundImageSource = CueConstants.BackgroundImage;
			Title = "Personalize";

			InitializeComponent();

			alcoholSwitch.IsToggled = Preferences.Get("F_alc", false);
			birthControlSwitch.IsToggled = Preferences.Get("F_bc", false);
			exerciseSwitch.IsToggled = Preferences.Get("F_ex", false);
			grapefruitSwitch.IsToggled = Preferences.Get("F_gfj", false);
			pregnantSwitch.IsToggled = Preferences.Get("F_preg", false);
			smokerSwitch.IsToggled = Preferences.Get("F_smoke", false);
			vegAndGrilledSwitch.IsToggled = Preferences.Get("F_vgc", false);
			weightEntry.Text = Preferences.Get("F_weight", "150");

			saveButton.BackgroundColor = Color.FloralWhite;
			saveButton.TextColor = Color.SaddleBrown;
		}

		private void Alc_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_alc = CoefficientConstants.alcohol;
			}
			else
			{
				F_alc = 1;
			}
			Preferences.Set("F_alc", e.Value);
		}

		private void BC_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_bc = CoefficientConstants.birthControl;
			}
			else
			{
				F_bc = 1;
			}
			Preferences.Set("F_bc", e.Value);
		}

		private void Ex_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_ex = CoefficientConstants.exercise;
			}
			else
			{
				F_ex = 1;
			}
			Preferences.Set("F_ex", e.Value);
		}

		private void GFJ_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_gfj = CoefficientConstants.grapefruitJuice;
			}
			else
			{
				F_gfj = 1;
			}
			Preferences.Set("F_gfj", e.Value);

		}

		private void Preg_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_preg = CoefficientConstants.pregnant;
			}
			else
			{
				F_preg = 1;
			}
			Preferences.Set("F_preg", e.Value);
		}

		private void Smoke_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_smoke = CoefficientConstants.smoker;
			}
			else
			{
				F_smoke = 1;
			}
			Preferences.Set("F_smoke", e.Value);
		}

		private void VGC_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value)
			{
				F_vgc = CoefficientConstants.vegetableAndGrilledChickenDiet;
			}
			else
			{
				F_vgc = 1;
			}
			Preferences.Set("F_vgc", e.Value);
		}

		private void Weight_Changed(object sender, TextChangedEventArgs e)
		{
			weightEntry.Text = e.NewTextValue.ToNaturalNumericString();
		}

		private async void SaveClicked(object sender, EventArgs e)
		{
			string weightText = weightEntry.Text;
			if (string.IsNullOrWhiteSpace(weightText))
			{
				weightText = Preferences.Get("F_weight", "150");
			}
			Preferences.Set("F_weight", weightText);
			F_weight = Formulas.WeightFactor(Convert.ToDouble(weightText));
			double coeff = F_alc * F_bc * F_ex * F_gfj * F_preg * F_smoke * F_vgc * F_weight;
			Preferences.Set(CueConstants.CoeffPrefKey, coeff);
			await Navigation.PushAsync(new MainPage());
		}
	}
}