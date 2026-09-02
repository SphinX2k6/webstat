using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004595 RID: 17813
	public class PlatformReportUploadPsnBill : PlatformSdkReportBaseData
	{
		// Token: 0x0602EC1E RID: 191518 RVA: 0x00B12BAD File Offset: 0x00B10DAD
		public PlatformReportUploadPsnBill()
		{
			this.event_id = 60160;
			this.event_name = "upload_psnbill";
		}

		// Token: 0x0401A943 RID: 108867
		[Nullable(1)]
		public string psn_scene = "";
	}
}
