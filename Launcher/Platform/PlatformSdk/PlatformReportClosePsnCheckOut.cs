using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004594 RID: 17812
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportClosePsnCheckOut : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1D RID: 191517 RVA: 0x00B12B6E File Offset: 0x00B10D6E
		public PlatformReportClosePsnCheckOut()
		{
			this.event_id = 60157;
			this.event_name = "close_psncheckout";
		}

		// Token: 0x0401A940 RID: 108864
		public string product_id = "";

		// Token: 0x0401A941 RID: 108865
		public string goodsId = "";

		// Token: 0x0401A942 RID: 108866
		public string psnenvlssuer = "";
	}
}
