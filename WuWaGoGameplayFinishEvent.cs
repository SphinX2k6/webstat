using System;
using System.Runtime.CompilerServices;

// Token: 0x020021D0 RID: 8656
[NullableContext(1)]
[Nullable(0)]
public class WuWaGoGameplayFinishEvent : PlayerCommonLogData
{
	// Token: 0x17001424 RID: 5156
	// (get) Token: 0x06010565 RID: 66917 RVA: 0x0047713F File Offset: 0x0047533F
	// (set) Token: 0x06010566 RID: 66918 RVA: 0x00477147 File Offset: 0x00475347
	public override string event_id { get; set; } = "1929";

	// Token: 0x040080AB RID: 32939
	public int i_level_play_id;

	// Token: 0x040080AC RID: 32940
	public int i_result_type;

	// Token: 0x040080AD RID: 32941
	public int savepoint_count;

	// Token: 0x040080AE RID: 32942
	public int back_count;

	// Token: 0x040080AF RID: 32943
	public int reset_count;

	// Token: 0x040080B0 RID: 32944
	public int tip_count;
}
