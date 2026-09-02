using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004597 RID: 17815
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportUploadPsnBillFail : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC20 RID: 191520 RVA: 0x00B12C0C File Offset: 0x00B10E0C
		public PlatformReportUploadPsnBillFail()
		{
			this.event_id = 60162;
			this.event_name = "upload_psnbill_fail";
		}

		// Token: 0x0401A946 RID: 108870
		public string psn_scene = "";

		// Token: 0x0401A947 RID: 108871
		public string psnenvlssuer = "";

		// Token: 0x0401A948 RID: 108872
		public string code = "";

		// Token: 0x0401A949 RID: 108873
		public string msg = "";
	}
}
