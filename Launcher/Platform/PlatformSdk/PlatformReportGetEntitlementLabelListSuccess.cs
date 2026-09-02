using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004591 RID: 17809
	public class PlatformReportGetEntitlementLabelListSuccess : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1A RID: 191514 RVA: 0x00B12AD2 File Offset: 0x00B10CD2
		public PlatformReportGetEntitlementLabelListSuccess()
		{
			this.event_id = 60154;
			this.event_name = "get_entitlementlabellist_succ";
		}

		// Token: 0x0401A939 RID: 108857
		[Nullable(1)]
		public string channel_goodsid = "";

		// Token: 0x0401A93A RID: 108858
		public int channel_goodsid_count;
	}
}
