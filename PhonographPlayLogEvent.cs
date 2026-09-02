using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A8 RID: 8616
[NullableContext(1)]
[Nullable(0)]
public class PhonographPlayLogEvent : PlayerCommonLogData
{
	// Token: 0x170013FF RID: 5119
	// (get) Token: 0x060104F3 RID: 66803 RVA: 0x00476B23 File Offset: 0x00474D23
	// (set) Token: 0x060104F4 RID: 66804 RVA: 0x00476B2B File Offset: 0x00474D2B
	public override string event_id { get; set; } = "101701";

	// Token: 0x04007FE2 RID: 32738
	public int i_item_id;

	// Token: 0x04007FE3 RID: 32739
	public int i_album_id;
}
