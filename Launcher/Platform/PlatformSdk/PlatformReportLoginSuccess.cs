using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004586 RID: 17798
	public class PlatformReportLoginSuccess : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC0D RID: 191501 RVA: 0x00B128EC File Offset: 0x00B10AEC
		public PlatformReportLoginSuccess()
		{
			this.event_id = 60132;
			this.event_name = "login_succ";
		}

		// Token: 0x0602EC0E RID: 191502 RVA: 0x00B1290A File Offset: 0x00B10B0A
		[NullableContext(1)]
		public static PlatformReportLoginSuccess Create(bool mailLogin, bool isregister)
		{
			return new PlatformReportLoginSuccess
			{
				account_type = (mailLogin ? 23 : 22),
				isregister = ((isregister > false) ? 1 : 0)
			};
		}

		// Token: 0x0401A92C RID: 108844
		public int account_type;

		// Token: 0x0401A92D RID: 108845
		public int isregister;
	}
}
