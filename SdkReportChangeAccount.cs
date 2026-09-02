using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EEE RID: 3822
public class SdkReportChangeAccount : SdkReportData
{
	// Token: 0x06005E6E RID: 24174 RVA: 0x0017A103 File Offset: 0x00178303
	public SdkReportChangeAccount([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E6F RID: 24175 RVA: 0x0017A10C File Offset: 0x0017830C
	[NullableContext(1)]
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return "Change_account";
		}
		return "";
	}
}
