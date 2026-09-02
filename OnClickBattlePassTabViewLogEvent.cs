using System;
using System.Runtime.CompilerServices;

// Token: 0x02002157 RID: 8535
[NullableContext(1)]
[Nullable(0)]
public class OnClickBattlePassTabViewLogEvent : PlayerCommonLogData
{
	// Token: 0x170013AF RID: 5039
	// (get) Token: 0x06010402 RID: 66562 RVA: 0x00475D23 File Offset: 0x00473F23
	// (set) Token: 0x06010403 RID: 66563 RVA: 0x00475D2B File Offset: 0x00473F2B
	public override string event_id { get; set; } = "1831";

	// Token: 0x04007E88 RID: 32392
	public int i_tabIndex;
}
