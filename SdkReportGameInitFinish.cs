using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EEC RID: 3820
public class SdkReportGameInitFinish : SdkReportData
{
	// Token: 0x06005E6A RID: 24170 RVA: 0x0017A0C7 File Offset: 0x001782C7
	public SdkReportGameInitFinish([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E6B RID: 24171 RVA: 0x0017A0D0 File Offset: 0x001782D0
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "Game_Initialize";
		}
		return "";
	}
}
