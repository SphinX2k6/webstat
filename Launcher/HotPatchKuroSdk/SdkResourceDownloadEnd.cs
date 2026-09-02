using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004617 RID: 17943
	public class SdkResourceDownloadEnd : SdkReportData
	{
		// Token: 0x0602EE78 RID: 192120 RVA: 0x00B1BD51 File Offset: 0x00B19F51
		public SdkResourceDownloadEnd([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE79 RID: 192121 RVA: 0x00B1BD5A File Offset: 0x00B19F5A
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Resource_Download_End";
		}
	}
}
