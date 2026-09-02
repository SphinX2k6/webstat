using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EEF RID: 3823
[NullableContext(1)]
[Nullable(0)]
public class SdkReportCreateRole : SdkReportData
{
	// Token: 0x06005E70 RID: 24176 RVA: 0x0017A121 File Offset: 0x00178321
	public SdkReportCreateRole([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E71 RID: 24177 RVA: 0x0017A12A File Offset: 0x0017832A
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "Completed_Registration";
		}
		return "event_1";
	}

	// Token: 0x06005E72 RID: 24178 RVA: 0x0017A140 File Offset: 0x00178340
	protected override string GetEventDataJson()
	{
		if (this.IfGlobalSdk)
		{
			this.EventData = new Dictionary<string, string>();
			this.EventData["eventId"] = "101104";
			return base.GetEventDataJson();
		}
		this.EventData = new Dictionary<string, string>();
		this.EventData["param1"] = "101104";
		return base.GetEventDataJson();
	}
}
