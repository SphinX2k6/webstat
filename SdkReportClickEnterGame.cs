using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF0 RID: 3824
public class SdkReportClickEnterGame : SdkReportData
{
	// Token: 0x06005E73 RID: 24179 RVA: 0x0017A1A2 File Offset: 0x001783A2
	public SdkReportClickEnterGame([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E74 RID: 24180 RVA: 0x0017A1AB File Offset: 0x001783AB
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "click_entergame";
		}
		return "event_2";
	}
}
