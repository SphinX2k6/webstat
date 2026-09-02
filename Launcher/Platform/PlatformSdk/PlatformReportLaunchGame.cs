using System;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004571 RID: 17777
	public class PlatformReportLaunchGame : PlatformSdkReportBaseData
	{
		// Token: 0x0602EBF8 RID: 191480 RVA: 0x00B12655 File Offset: 0x00B10855
		public PlatformReportLaunchGame()
		{
			this.event_id = 60100;
			this.event_name = "game_launch";
		}
	}
}
