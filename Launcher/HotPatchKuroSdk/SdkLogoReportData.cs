using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004612 RID: 17938
	public class SdkLogoReportData : SdkReportData
	{
		// Token: 0x0602EE6E RID: 192110 RVA: 0x00B1BCBB File Offset: 0x00B19EBB
		public SdkLogoReportData([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE6F RID: 192111 RVA: 0x00B1BCC4 File Offset: 0x00B19EC4
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Logo";
		}
	}
}
