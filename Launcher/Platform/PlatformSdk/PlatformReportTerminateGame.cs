using System;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004572 RID: 17778
	public class PlatformReportTerminateGame : PlatformSdkReportBaseData
	{
		// Token: 0x0602EBF9 RID: 191481 RVA: 0x00B12673 File Offset: 0x00B10873
		public PlatformReportTerminateGame()
		{
			this.event_id = 60101;
			this.event_name = "game_terminate";
		}
	}
}
