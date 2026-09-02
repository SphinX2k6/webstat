using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.ThinkDataReport
{
	// Token: 0x0200452B RID: 17707
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ThinkDataLaunchReporter : Singleton<ThinkDataLaunchReporter>
	{
		// Token: 0x0602EA4C RID: 191052 RVA: 0x00B0CBF5 File Offset: 0x00B0ADF5
		public void InitializeInstance()
		{
			RealThinkDataLaunchReporter.InitializeInstance();
			RealKRDataLaunchReporter.InitializeInstance();
		}

		// Token: 0x0602EA4D RID: 191053 RVA: 0x00B0CC01 File Offset: 0x00B0AE01
		public void CalibrateInstanceTime()
		{
			RealThinkDataLaunchReporter.CalibrateInstanceTime();
			RealKRDataLaunchReporter.CalibrateInstanceTime();
		}

		// Token: 0x0602EA4E RID: 191054 RVA: 0x00B0CC0D File Offset: 0x00B0AE0D
		public void Report(string key, string jsonLog)
		{
			RealThinkDataLaunchReporter.Report(key, jsonLog);
			RealKRDataLaunchReporter.Report(key, jsonLog);
		}

		// Token: 0x0401A7BB RID: 108475
		public const bool ENABLE_THINKING_ANALYTICS = true;

		// Token: 0x0401A7BC RID: 108476
		public const bool ENABLE_KD_ANALYTICS = true;

		// Token: 0x0401A7BD RID: 108477
		public const int EXIT_WAIT_TIME = 1;

		// Token: 0x0401A7BE RID: 108478
		public const int MAX_PENDING_LOG = 1000;

		// Token: 0x0401A7BF RID: 108479
		public const int SEND_HTTP_TIMEOUT = 10000;

		// Token: 0x0401A7C0 RID: 108480
		public const int CALIBRATE_INTERVAL = 10;

		// Token: 0x0401A7C1 RID: 108481
		public const bool CALIBRATE_STOP_TIMER = true;

		// Token: 0x0401A7C2 RID: 108482
		public string ClientVersion = "";
	}
}
