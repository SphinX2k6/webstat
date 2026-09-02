using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A3 RID: 8611
[NullableContext(1)]
[Nullable(0)]
public class OnOpenPhoneViewLogEvent : PlayerCommonLogData
{
	// Token: 0x170013FA RID: 5114
	// (get) Token: 0x060104E4 RID: 66788 RVA: 0x00476A64 File Offset: 0x00474C64
	// (set) Token: 0x060104E5 RID: 66789 RVA: 0x00476A6C File Offset: 0x00474C6C
	public override string event_id { get; set; } = "1815";

	// Token: 0x04007FC9 RID: 32713
	public int i_open_way;

	// Token: 0x04007FCA RID: 32714
	public int i_reason;
}
