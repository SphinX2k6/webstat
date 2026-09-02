using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004614 RID: 17940
	public class SdkCheckVersionEnd : SdkReportData
	{
		// Token: 0x0602EE72 RID: 192114 RVA: 0x00B1BCF7 File Offset: 0x00B19EF7
		public SdkCheckVersionEnd([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE73 RID: 192115 RVA: 0x00B1BD00 File Offset: 0x00B19F00
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Version_Checking_End";
		}
	}
}
