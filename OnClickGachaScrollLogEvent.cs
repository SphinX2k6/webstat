using System;
using System.Runtime.CompilerServices;

// Token: 0x0200214C RID: 8524
[NullableContext(1)]
[Nullable(0)]
public class OnClickGachaScrollLogEvent : PlayerCommonLogData
{
	// Token: 0x170013A4 RID: 5028
	// (get) Token: 0x060103E1 RID: 66529 RVA: 0x00475B97 File Offset: 0x00473D97
	// (set) Token: 0x060103E2 RID: 66530 RVA: 0x00475B9F File Offset: 0x00473D9F
	public override string event_id { get; set; } = "1822";

	// Token: 0x04007E65 RID: 32357
	public int i_gacha_id;
}
