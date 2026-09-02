using System;
using System.Runtime.CompilerServices;

// Token: 0x0200219A RID: 8602
[NullableContext(1)]
[Nullable(0)]
public class SubPackageDownLoadLogEvent : CommonLogData
{
	// Token: 0x170013F2 RID: 5106
	// (get) Token: 0x060104CB RID: 66763 RVA: 0x004768B8 File Offset: 0x00474AB8
	// (set) Token: 0x060104CC RID: 66764 RVA: 0x004768C0 File Offset: 0x00474AC0
	public override string event_id { get; set; } = "1706";

	// Token: 0x04007F9A RID: 32666
	public string s_suit_name = "";

	// Token: 0x04007F9B RID: 32667
	public bool b_if_storage_alert;

	// Token: 0x04007F9C RID: 32668
	public int i_peak_speed;

	// Token: 0x04007F9D RID: 32669
	public int i_download_time;

	// Token: 0x04007F9E RID: 32670
	public int i_download_status;

	// Token: 0x04007F9F RID: 32671
	public int i_resource_type;

	// Token: 0x04007FA0 RID: 32672
	public int i_resource_size;

	// Token: 0x04007FA1 RID: 32673
	public int i_state;

	// Token: 0x04007FA2 RID: 32674
	public int i_role_id;
}
