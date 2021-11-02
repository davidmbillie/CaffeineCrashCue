using Octokit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CaffeineCrashCue.Octo
{
	public class OctoData
	{
		GitHubClient client;

		public OctoData()
		{
			ProductHeaderValue productHeaderValue = new ProductHeaderValue("CaffeineCrashCue");
			client = new GitHubClient(productHeaderValue);

		}

		public async Task GetChecksData()
		{
			try
			{
				IChecksClient checksClient = client.Check;
				ICheckRunsClient checkRunsClient = checksClient.Run;
				CheckRunsResponse runsResponse = await checkRunsClient.GetAllForReference("davidmbillie", "CaffeineCrashCue", "android-with-reports");
				IReadOnlyList<CheckRun> checkRuns = runsResponse.CheckRuns;
				CheckRun firstCheckRun = checkRuns[0];
				CheckRunOutputResponse checkRunOutputResponse = firstCheckRun.Output;
				string outputText = checkRunOutputResponse.Text;
			}
			catch (Exception ex)
			{
				string msg = ex.Message;
			}
		}
	}
}
