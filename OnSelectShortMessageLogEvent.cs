using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A4 RID: 8612
[NullableContext(1)]
[Nullable(0)]
public class OnSelectShortMessageLogEvent : PlayerCommonLogData
{
	// Token: 0x170013FB RID: 5115
	// (get) Token: 0x060104E7 RID: 66791 RVA: 0x00476A88 File Offset: 0x00474C88
	// (set) Token: 0x060104E8 RID: 66792 RVA: 0x00476A90 File Offset: 0x00474C90
	public override string event_id { get; set; } = "1816";

	// Token: 0x04007FCC RID: 32716
	public int i_id;

	// Token: 0x04007FCD RID: 32717
	public int i_type;

	// Token: 0x04007FCE RID: 32718
	public int i_reason;

	// Token: 0x04007FCF RID: 32719
	public long l_received_time;

	// Token: 0x04007FD0 RID: 32720
	public int i_role_id;
}
