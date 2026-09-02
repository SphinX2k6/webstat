using System;
using System.Runtime.CompilerServices;

// Token: 0x02002166 RID: 8550
[NullableContext(1)]
[Nullable(0)]
public class DownloadVideoResLogData : CommonLogData
{
	// Token: 0x170013BE RID: 5054
	// (get) Token: 0x0601042F RID: 66607 RVA: 0x00475F80 File Offset: 0x00474180
	// (set) Token: 0x06010430 RID: 66608 RVA: 0x00475F88 File Offset: 0x00474188
	public override string event_id { get; set; } = "1701";

	// Token: 0x04007EB4 RID: 32436
	public int i_task_id;

	// Token: 0x04007EB5 RID: 32437
	public bool b_if_storage_alert;

	// Token: 0x04007EB6 RID: 32438
	public int i_peak_speed;

	// Token: 0x04007EB7 RID: 32439
	public int i_download_time;

	// Token: 0x04007EB8 RID: 32440
	public int i_download_status;

	// Token: 0x04007EB9 RID: 32441
	public int i_role_id;

	// Token: 0x04007EBA RID: 32442
	public int i_resource_type;

	// Token: 0x04007EBB RID: 32443
	public double i_resource_size;
}
