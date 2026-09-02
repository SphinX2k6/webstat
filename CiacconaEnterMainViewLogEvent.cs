using System;
using System.Runtime.CompilerServices;

// Token: 0x02002165 RID: 8549
[NullableContext(1)]
[Nullable(0)]
public class CiacconaEnterMainViewLogEvent : PlayerCommonLogData
{
	// Token: 0x170013BD RID: 5053
	// (get) Token: 0x0601042C RID: 66604 RVA: 0x00475F55 File Offset: 0x00474155
	// (set) Token: 0x0601042D RID: 66605 RVA: 0x00475F5D File Offset: 0x0047415D
	public override string event_id { get; set; } = "156003";

	// Token: 0x0601042E RID: 66606 RVA: 0x00475F66 File Offset: 0x00474166
	public CiacconaEnterMainViewLogEvent(int triggerType)
	{
		this.i_trigger_type = triggerType;
	}

	// Token: 0x04007EB2 RID: 32434
	public int i_trigger_type;
}
