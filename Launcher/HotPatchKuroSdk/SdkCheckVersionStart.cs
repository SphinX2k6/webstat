using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004613 RID: 17939
	public class SdkCheckVersionStart : SdkReportData
	{
		// Token: 0x0602EE70 RID: 192112 RVA: 0x00B1BCD9 File Offset: 0x00B19ED9
		public SdkCheckVersionStart([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE71 RID: 192113 RVA: 0x00B1BCE2 File Offset: 0x00B19EE2
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Version_Checking_Start";
		}
	}
}
