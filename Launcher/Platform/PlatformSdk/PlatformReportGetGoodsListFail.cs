using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200458F RID: 17807
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportGetGoodsListFail : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC18 RID: 191512 RVA: 0x00B12A80 File Offset: 0x00B10C80
		public PlatformReportGetGoodsListFail()
		{
			this.event_id = 60152;
			this.event_name = "get_goodsidlist_fail";
		}

		// Token: 0x0401A937 RID: 108855
		public string code = "";

		// Token: 0x0401A938 RID: 108856
		public string msg = "";
	}
}
