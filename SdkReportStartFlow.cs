using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF3 RID: 3827
[NullableContext(1)]
[Nullable(0)]
public class SdkReportStartFlow : SdkReportData
{
	// Token: 0x06005E85 RID: 24197 RVA: 0x0017A40B File Offset: 0x0017860B
	public SdkReportStartFlow([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E86 RID: 24198 RVA: 0x0017A414 File Offset: 0x00178614
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "Anime_end";
		}
		return "";
	}

	// Token: 0x06005E87 RID: 24199 RVA: 0x0017A429 File Offset: 0x00178629
	public static bool IfNeedReport(int flowId, int stateId)
	{
		return flowId == 1 && stateId == 1;
	}

	// Token: 0x06005E88 RID: 24200 RVA: 0x0017A438 File Offset: 0x00178638
	protected override string GetEventDataJson()
	{
		this.EventData = new Dictionary<string, string>();
		this.EventData["eventId"] = "123000";
		this.EventData["FlowId"] = this.FlowId.ToString();
		return base.GetEventDataJson();
	}

	// Token: 0x04002DCF RID: 11727
	public int FlowId;
}
