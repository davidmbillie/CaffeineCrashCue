using System;
using System.Threading.Tasks;

namespace CaffeineCrashCue.Octo
{
	class Program
	{
		public static async Task Main(string[] args)
		{
			Console.WriteLine("Hello World!");
			OctoData octoData = new OctoData();
			await octoData.GetChecksData();
			Console.ReadKey();
		}
	}
}
