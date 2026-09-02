using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A6 RID: 8614
[NullableContext(1)]
[Nullable(0)]
public class OnClickShortMessageLogEvent : PlayerCommonLogData
{
	// Token: 0x170013FD RID: 5117
	// (get) Token: 0x060104ED RID: 66797 RVA: 0x00476AD0 File Offset: 0x00474CD0
	// (set) Token: 0x060104EE RID: 66798 RVA: 0x00476AD8 File Offset: 0x00474CD8
	public override string event_id { get; set; } = "1860";

	// Token: 0x04007FD9 RID: 32729
	public int i_id;

	// Token: 0x04007FDA RID: 32730
	public int i_type;

	// Token: 0x04007FDB RID: 32731
	public int i_role_id;

	// Token: 0x04007FDC RID: 32732
	public long l_received_time;

	// Token: 0x04007FDD RID: 32733
	public int i_config_id;
}
