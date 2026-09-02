using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.HotPatchKuroSdk
{
	// Token: 0x02004616 RID: 17942
	public class SdkResourceDownloadStart : SdkReportData
	{
		// Token: 0x0602EE76 RID: 192118 RVA: 0x00B1BD33 File Offset: 0x00B19F33
		public SdkResourceDownloadStart([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602EE77 RID: 192119 RVA: 0x00B1BD3C File Offset: 0x00B19F3C
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (!this.IfGlobalSdk)
			{
				return "";
			}
			return "Resource_Download_Start";
		}
	}
}
