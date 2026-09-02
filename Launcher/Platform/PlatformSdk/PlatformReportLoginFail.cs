using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004587 RID: 17799
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportLoginFail : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC0F RID: 191503 RVA: 0x00B1292A File Offset: 0x00B10B2A
		public PlatformReportLoginFail()
		{
			this.event_id = 60133;
			this.event_name = "login_fail";
		}

		// Token: 0x0602EC10 RID: 191504 RVA: 0x00B1295E File Offset: 0x00B10B5E
		public static PlatformReportLoginFail Create(bool mailLogin, string code, string msg)
		{
			return new PlatformReportLoginFail
			{
				account_type = (mailLogin ? 23 : 22),
				code = code,
				msg = msg
			};
		}

		// Token: 0x0401A92E RID: 108846
		public string code = "";

		// Token: 0x0401A92F RID: 108847
		public string msg = "";

		// Token: 0x0401A930 RID: 108848
		public int account_type;
	}
}
