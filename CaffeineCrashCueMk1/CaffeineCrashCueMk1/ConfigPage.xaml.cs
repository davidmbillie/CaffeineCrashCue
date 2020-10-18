using CaffeineCrashProvider;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCueMk1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfigPage : ContentPage
	{
		private static double F_alc = 1;
		private static double F_bc = 1;
		private static double F_ex = 1;
		private static double F_gjf = 1;
		private static double F_preg = 1;
		private static double F_smoke = 1;
		private static double F_vgc = 1;
		private static double F_weight = 1;

		public ConfigPage()
		{
			InitializeComponent();
		}

		private void Alc_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_alc = CoefficientConstants.alcohol;
			}
			else
			{
				F_alc = 1;
			}
		}

		private void BC_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_bc = CoefficientConstants.birthControl;
			}
			else
			{
				F_bc = 1;
			}
		}

		private void Ex_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_ex = CoefficientConstants.exercise;
			}
			else
			{
				F_ex = 1;
			}
		}

		private void GFJ_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_gjf = CoefficientConstants.grapefruitJuice;
			}
			else
			{
				F_gjf = 1;
			}
		}

		private void Preg_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_preg = CoefficientConstants.pregnant;
			}
			else
			{
				F_preg = 1;
			}
		}

		private void Smoke_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_smoke = CoefficientConstants.smoker;
			}
			else
			{
				F_smoke = 1;
			}
		}

		private void VGC_Toggled(object sender, ToggledEventArgs e)
		{
			if (e.Value == true)
			{
				F_vgc = CoefficientConstants.vegetableAndGrilledChickenDiet;
			}
			else
			{
				F_vgc = 1;
			}
		}

		private async void SaveClicked(object sender, EventArgs e)
		{
			F_weight = Formulas.WeightFactor(Convert.ToDouble(weightText.Text));
			double coeff = F_alc * F_bc * F_ex * F_gjf * F_preg * F_smoke * F_vgc * F_weight;
			await Navigation.PushAsync(new NavigationPage(new MainPage(coeff)));
		}
	}
}