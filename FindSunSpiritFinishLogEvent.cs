using System;
using System.Runtime.CompilerServices;

// Token: 0x020021AC RID: 8620
[NullableContext(1)]
[Nullable(0)]
public class FindSunSpiritFinishLogEvent : PlayerCommonLogData
{
	// Token: 0x17001403 RID: 5123
	// (get) Token: 0x060104FF RID: 66815 RVA: 0x00476BBE File Offset: 0x00474DBE
	// (set) Token: 0x06010500 RID: 66816 RVA: 0x00476BC6 File Offset: 0x00474DC6
	public override string event_id { get; set; } = "1820";

	// Token: 0x04007FF8 RID: 32760
	public int i_config_id;

	// Token: 0x04007FF9 RID: 32761
	public int i_id;

	// Token: 0x04007FFA RID: 32762
	public string s_type_name = "";

	// Token: 0x04007FFB RID: 32763
	public int i_paint_count;

	// Token: 0x04007FFC RID: 32764
	public int i_count;
}
