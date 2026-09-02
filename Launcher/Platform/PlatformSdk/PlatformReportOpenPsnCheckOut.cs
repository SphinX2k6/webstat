using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004593 RID: 17811
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportOpenPsnCheckOut : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1C RID: 191516 RVA: 0x00B12B2F File Offset: 0x00B10D2F
		public PlatformReportOpenPsnCheckOut()
		{
			this.event_id = 60156;
			this.event_name = "open_psncheckout";
		}

		// Token: 0x0401A93D RID: 108861
		public string product_id = "";

		// Token: 0x0401A93E RID: 108862
		public string goodsId = "";

		// Token: 0x0401A93F RID: 108863
		public string psnenvlssuer = "";
	}
}
