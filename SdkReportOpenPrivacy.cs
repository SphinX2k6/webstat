using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EED RID: 3821
public class SdkReportOpenPrivacy : SdkReportData
{
	// Token: 0x06005E6C RID: 24172 RVA: 0x0017A0E5 File Offset: 0x001782E5
	public SdkReportOpenPrivacy([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E6D RID: 24173 RVA: 0x0017A0EE File Offset: 0x001782EE
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "Game_Privacy";
		}
		return "";
	}
}
