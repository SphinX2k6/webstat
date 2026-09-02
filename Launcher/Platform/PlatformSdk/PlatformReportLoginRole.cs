using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200458A RID: 17802
	public class PlatformReportLoginRole : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC13 RID: 191507 RVA: 0x00B129BE File Offset: 0x00B10BBE
		public PlatformReportLoginRole()
		{
			this.event_id = 60140;
			this.event_name = "login_role";
		}

		// Token: 0x0401A931 RID: 108849
		[Nullable(1)]
		public string level = "";
	}
}
