using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x0200458E RID: 17806
	public class PlatformReportGetGoodsListSuccess : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC17 RID: 191511 RVA: 0x00B12A57 File Offset: 0x00B10C57
		public PlatformReportGetGoodsListSuccess()
		{
			this.event_id = 60151;
			this.event_name = "get_goodsidlist_succ";
		}

		// Token: 0x0401A935 RID: 108853
		[Nullable(1)]
		public string channel_goodsid = "";

		// Token: 0x0401A936 RID: 108854
		public int channel_goodsid_count;
	}
}
