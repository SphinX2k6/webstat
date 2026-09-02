using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004582 RID: 17794
	public class PlatformReportLoginWindow : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC09 RID: 191497 RVA: 0x00B12869 File Offset: 0x00B10A69
		public PlatformReportLoginWindow()
		{
			this.event_id = 60125;
			this.event_name = "login_window";
		}

		// Token: 0x0401A92B RID: 108843
		[Nullable(1)]
		public string login_way = "23";
	}
}
