using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF9 RID: 3833
public class SdkReportGetRougeLevel60 : SdkReportData
{
	// Token: 0x06005EAA RID: 24234 RVA: 0x0017A9C2 File Offset: 0x00178BC2
	public SdkReportGetRougeLevel60([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005EAB RID: 24235 RVA: 0x0017A9CB File Offset: 0x00178BCB
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "rogue_level60";
		}
		return "";
	}
}
