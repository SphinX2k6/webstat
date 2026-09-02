using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004592 RID: 17810
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportGetEntitlementLabelListFail : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1B RID: 191515 RVA: 0x00B12AFB File Offset: 0x00B10CFB
		public PlatformReportGetEntitlementLabelListFail()
		{
			this.event_id = 60155;
			this.event_name = "get_entitlementlabellist_fail";
		}

		// Token: 0x0401A93B RID: 108859
		public string code = "";

		// Token: 0x0401A93C RID: 108860
		public string msg = "";
	}
}
