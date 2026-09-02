using System;
using System.Runtime.CompilerServices;

// Token: 0x0200219D RID: 8605
[NullableContext(1)]
[Nullable(0)]
public class SubPackageClearSpaceFinishLogEvent : CommonLogData
{
	// Token: 0x170013F5 RID: 5109
	// (get) Token: 0x060104D4 RID: 66772 RVA: 0x0047693A File Offset: 0x00474B3A
	// (set) Token: 0x060104D5 RID: 66773 RVA: 0x00476942 File Offset: 0x00474B42
	public override string event_id { get; set; } = "1711";

	// Token: 0x04007FAF RID: 32687
	public int i_task_id;

	// Token: 0x04007FB0 RID: 32688
	public int i_required_space;

	// Token: 0x04007FB1 RID: 32689
	public int i_remaining_space;

	// Token: 0x04007FB2 RID: 32690
	public bool b_if_storage_alert;
}
