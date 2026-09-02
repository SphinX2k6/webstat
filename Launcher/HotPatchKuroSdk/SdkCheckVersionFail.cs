using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004615 RID: 17941
	public class SdkCheckVersionFail : SdkReportData
	{
		// Token: 0x0602EE74 RID: 192116 RVA: 0x00B1BD15 File Offset: 0x00B19F15
		public SdkCheckVersionFail([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE75 RID: 192117 RVA: 0x00B1BD1E File Offset: 0x00B19F1E
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Version_Checking_Fail";
		}
	}
}
