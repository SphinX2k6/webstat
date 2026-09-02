using System;
using System.Runtime.CompilerServices;

// Token: 0x02002167 RID: 8551
[NullableContext(1)]
[Nullable(0)]
public class DownloadVideoResNotEnoughSpaceLogData : CommonLogData
{
	// Token: 0x170013BF RID: 5055
	// (get) Token: 0x06010432 RID: 66610 RVA: 0x00475FA4 File Offset: 0x004741A4
	// (set) Token: 0x06010433 RID: 66611 RVA: 0x00475FAC File Offset: 0x004741AC
	public override string event_id { get; set; } = "1702";

	// Token: 0x04007EBD RID: 32445
	public int i_popup_type;

	// Token: 0x04007EBE RID: 32446
	public bool b_if_storage_alert;

	// Token: 0x04007EBF RID: 32447
	public int i_required_space;

	// Token: 0x04007EC0 RID: 32448
	public int i_remaining_space;
}
