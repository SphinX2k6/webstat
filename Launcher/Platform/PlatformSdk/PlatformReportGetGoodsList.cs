using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200458D RID: 17805
	public class PlatformReportGetGoodsList : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC16 RID: 191510 RVA: 0x00B12A2E File Offset: 0x00B10C2E
		public PlatformReportGetGoodsList()
		{
			this.event_id = 60150;
			this.event_name = "get_goodsidlist";
		}

		// Token: 0x0401A933 RID: 108851
		[Nullable(1)]
		public string goodsid = "";

		// Token: 0x0401A934 RID: 108852
		public int goodsid_count;
	}
}
