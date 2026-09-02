using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004596 RID: 17814
	[NullableContext(1)]
	[Nullable(0)]
	public class PlatformReportUploadPsnBillSuccess : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1F RID: 191519 RVA: 0x00B12BD6 File Offset: 0x00B10DD6
		public PlatformReportUploadPsnBillSuccess()
		{
			this.event_id = 60161;
			this.event_name = "upload_psnbill_succ";
		}

		// Token: 0x0401A944 RID: 108868
		public string psn_scene = "";

		// Token: 0x0401A945 RID: 108869
		public string psnenvlssuer = "";
	}
}
