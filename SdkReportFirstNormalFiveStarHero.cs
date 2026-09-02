using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EFA RID: 3834
public class SdkReportFirstNormalFiveStarHero : SdkReportData
{
	// Token: 0x06005EAC RID: 24236 RVA: 0x0017A9E0 File Offset: 0x00178BE0
	public SdkReportFirstNormalFiveStarHero([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005EAD RID: 24237 RVA: 0x0017A9E9 File Offset: 0x00178BE9
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "first_normal_5star_hero";
		}
		return "";
	}
}
