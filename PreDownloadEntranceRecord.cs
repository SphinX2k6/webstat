using System;
using System.Runtime.CompilerServices;

// Token: 0x02002160 RID: 8544
[NullableContext(1)]
[Nullable(0)]
public class PreDownloadEntranceRecord : PlayerCommonLogData
{
	// Token: 0x170013B8 RID: 5048
	// (get) Token: 0x0601041D RID: 66589 RVA: 0x00475E7D File Offset: 0x0047407D
	// (set) Token: 0x0601041E RID: 66590 RVA: 0x00475E85 File Offset: 0x00474085
	public override string event_id { get; set; } = "1054";

	// Token: 0x0601041F RID: 66591 RVA: 0x00475E8E File Offset: 0x0047408E
	public PreDownloadEntranceRecord(int entranceId)
	{
		this.i_entrance_id = entranceId;
	}

	// Token: 0x04007EA8 RID: 32424
	public int i_entrance_id;
}
