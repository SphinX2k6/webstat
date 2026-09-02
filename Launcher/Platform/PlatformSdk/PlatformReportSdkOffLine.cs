using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200458C RID: 17804
	public class PlatformReportSdkOffLine : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC15 RID: 191509 RVA: 0x00B12A05 File Offset: 0x00B10C05
		public PlatformReportSdkOffLine()
		{
			this.event_id = 60142;
			this.event_name = "sdkaccount_offline";
		}

		// Token: 0x0401A932 RID: 108850
		[Nullable(1)]
		public string offline_type = "";
	}
}
