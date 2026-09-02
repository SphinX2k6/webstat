using System;
using System.Runtime.CompilerServices;

// Token: 0x0200219B RID: 8603
[NullableContext(1)]
[Nullable(0)]
public class SubPackageOutOfSpaceLogEvent : CommonLogData
{
	// Token: 0x170013F3 RID: 5107
	// (get) Token: 0x060104CE RID: 66766 RVA: 0x004768E7 File Offset: 0x00474AE7
	// (set) Token: 0x060104CF RID: 66767 RVA: 0x004768EF File Offset: 0x00474AEF
	public override string event_id { get; set; } = "1707";

	// Token: 0x04007FA4 RID: 32676
	public string s_suit_name = "";

	// Token: 0x04007FA5 RID: 32677
	public int i_resource_type;

	// Token: 0x04007FA6 RID: 32678
	public bool b_if_storage_alert;

	// Token: 0x04007FA7 RID: 32679
	public int i_required_space;

	// Token: 0x04007FA8 RID: 32680
	public int i_remaining_space;

	// Token: 0x04007FA9 RID: 32681
	public int i_role_id;
}
