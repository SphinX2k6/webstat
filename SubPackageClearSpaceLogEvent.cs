using System;
using System.Runtime.CompilerServices;

// Token: 0x0200219C RID: 8604
[NullableContext(1)]
[Nullable(0)]
public class SubPackageClearSpaceLogEvent : CommonLogData
{
	// Token: 0x170013F4 RID: 5108
	// (get) Token: 0x060104D1 RID: 66769 RVA: 0x00476916 File Offset: 0x00474B16
	// (set) Token: 0x060104D2 RID: 66770 RVA: 0x0047691E File Offset: 0x00474B1E
	public override string event_id { get; set; } = "1710";

	// Token: 0x04007FAB RID: 32683
	public int i_task_id;

	// Token: 0x04007FAC RID: 32684
	public bool b_if_storage_alert;

	// Token: 0x04007FAD RID: 32685
	public int i_required_space;
}
