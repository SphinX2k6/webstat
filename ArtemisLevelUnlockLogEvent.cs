using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A2 RID: 8610
[NullableContext(1)]
[Nullable(0)]
public class ArtemisLevelUnlockLogEvent : PlayerCommonLogData
{
	// Token: 0x170013F9 RID: 5113
	// (get) Token: 0x060104E1 RID: 66785 RVA: 0x00476A40 File Offset: 0x00474C40
	// (set) Token: 0x060104E2 RID: 66786 RVA: 0x00476A48 File Offset: 0x00474C48
	public override string event_id { get; set; } = "1814";

	// Token: 0x04007FC7 RID: 32711
	public int i_id;
}
