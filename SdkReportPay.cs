using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF5 RID: 3829
public class SdkReportPay : SdkReportData
{
	// Token: 0x06005E91 RID: 24209 RVA: 0x0017A5BF File Offset: 0x001787BF
	public SdkReportPay([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E92 RID: 24210 RVA: 0x0017A5C8 File Offset: 0x001787C8
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "";
		}
		return "event_4";
	}
}
