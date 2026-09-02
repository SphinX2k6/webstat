using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200457A RID: 17786
	public class PlatformReportSdkInitFail : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC01 RID: 191489 RVA: 0x00B1276E File Offset: 0x00B1096E
		public PlatformReportSdkInitFail()
		{
			this.event_id = 60110;
			this.event_name = "krsdk_init_fail";
		}

		// Token: 0x0401A92A RID: 108842
		[Nullable(1)]
		public string code = "";
	}
}
