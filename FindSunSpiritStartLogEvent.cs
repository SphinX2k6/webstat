using System;
using System.Runtime.CompilerServices;

// Token: 0x020021AB RID: 8619
[NullableContext(1)]
[Nullable(0)]
public class FindSunSpiritStartLogEvent : PlayerCommonLogData
{
	// Token: 0x17001402 RID: 5122
	// (get) Token: 0x060104FC RID: 66812 RVA: 0x00476B8F File Offset: 0x00474D8F
	// (set) Token: 0x060104FD RID: 66813 RVA: 0x00476B97 File Offset: 0x00474D97
	public override string event_id { get; set; } = "1819";

	// Token: 0x04007FF3 RID: 32755
	public int i_config_id;

	// Token: 0x04007FF4 RID: 32756
	public int i_id;

	// Token: 0x04007FF5 RID: 32757
	public string s_type_name = "";

	// Token: 0x04007FF6 RID: 32758
	public int i_paint_count;
}
