using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EFB RID: 3835
public class SdkReportFirstUpFiveStarHero : SdkReportData
{
	// Token: 0x06005EAE RID: 24238 RVA: 0x0017A9FE File Offset: 0x00178BFE
	public SdkReportFirstUpFiveStarHero([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005EAF RID: 24239 RVA: 0x0017AA07 File Offset: 0x00178C07
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "first_up_5star_hero";
		}
		return "";
	}
}
