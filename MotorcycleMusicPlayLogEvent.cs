using System;
using System.Runtime.CompilerServices;

// Token: 0x020021A9 RID: 8617
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleMusicPlayLogEvent : PlayerCommonLogData
{
	// Token: 0x17001400 RID: 5120
	// (get) Token: 0x060104F6 RID: 66806 RVA: 0x00476B47 File Offset: 0x00474D47
	// (set) Token: 0x060104F7 RID: 66807 RVA: 0x00476B4F File Offset: 0x00474D4F
	public override string event_id { get; set; } = "101702";

	// Token: 0x04007FE5 RID: 32741
	public int i_item_id;

	// Token: 0x04007FE6 RID: 32742
	public int i_album_id;
}
