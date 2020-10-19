using CaffeineCrashProvider;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CaffeineCrashCueMk1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimePage : ContentPage
	{
		private const string crashTimeDescriptor = "Your estimated crash time is: ";
		public TimePage()
		{
			InitializeComponent();
		}

		public TimePage(double coeff, double amount)
		{
			double crash = Formulas.CalculateCrash(coeff, amount);
			DateTime crashTime = DateTime.Now.AddHours(crash);
			string crashTimeText = crashTime.ToShortTimeString();

			InitializeComponent();

			CrashLabel.Text = crashTimeDescriptor + crashTimeText;
		}
	}
}