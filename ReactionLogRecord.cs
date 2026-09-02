using System;
using System.Runtime.CompilerServices;

// Token: 0x0200211F RID: 8479
[NullableContext(1)]
[Nullable(0)]
public class ReactionLogRecord : PlayerCommonLogData
{
	// Token: 0x1700137C RID: 4988
	// (get) Token: 0x0601035F RID: 66399 RVA: 0x00474EFE File Offset: 0x004730FE
	// (set) Token: 0x06010360 RID: 66400 RVA: 0x00474F06 File Offset: 0x00473106
	public override string event_id { get; set; } = "102703";

	// Token: 0x04007D13 RID: 32019
	public string s_battle_id = "";

	// Token: 0x04007D14 RID: 32020
	public string s_reports = "";
}
