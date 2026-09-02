using System;
using System.Runtime.CompilerServices;

// Token: 0x0200213E RID: 8510
[NullableContext(1)]
[Nullable(0)]
public class ActivityViewOpenLogData : PlayerCommonLogData
{
	// Token: 0x17001398 RID: 5016
	// (get) Token: 0x060103BB RID: 66491 RVA: 0x0047598A File Offset: 0x00473B8A
	// (set) Token: 0x060103BC RID: 66492 RVA: 0x00475992 File Offset: 0x00473B92
	public override string event_id { get; set; } = "1019";

	// Token: 0x04007E33 RID: 32307
	public int i_open_way;
}
