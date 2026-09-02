using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004618 RID: 17944
	public class SdkResourceDownloadFail : SdkReportData
	{
		// Token: 0x0602EE7A RID: 192122 RVA: 0x00B1BD6F File Offset: 0x00B19F6F
		public SdkResourceDownloadFail([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE7B RID: 192123 RVA: 0x00B1BD78 File Offset: 0x00B19F78
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Resource_Download_Fail";
		}
	}
}
