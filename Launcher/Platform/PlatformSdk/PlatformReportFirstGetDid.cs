using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x02004577 RID: 17783
	public class PlatformReportFirstGetDid : PlatformSdkReportBaseData
	{
		// Token: 0x0602EBFE RID: 191486 RVA: 0x00B12709 File Offset: 0x00B10909
		public PlatformReportFirstGetDid()
		{
			this.event_id = 60106;
			this.event_name = "first_did";
		}

		// Token: 0x0401A929 RID: 108841
		[Nullable(1)]
		public string first_check_id = "";
	}
}
