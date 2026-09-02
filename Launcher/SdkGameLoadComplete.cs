using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

namespace CSharpScript.Launcher
{
	// Token: 0x02004495 RID: 17557
	public class SdkGameLoadComplete : SdkReportData
	{
		// Token: 0x0602E511 RID: 189713 RVA: 0x00ADEF9E File Offset: 0x00ADD19E
		public SdkGameLoadComplete([Nullable(new byte[]
		{
			2,
			1,
			1
		})] Dictionary<string, string> eventData) : base(eventData)
		{
		}

		// Token: 0x0602E512 RID: 189714 RVA: 0x00ADEFA7 File Offset: 0x00ADD1A7
		[NullableContext(1)]
		public override string GetEventName()
		{
			if (this.IfGlobalSdk)
			{
				return "game_load_complete";
			}
			return "";
		}
	}
}
