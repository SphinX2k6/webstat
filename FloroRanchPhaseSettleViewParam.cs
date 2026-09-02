using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001C19 RID: 7193
[NullableContext(1)]
[Nullable(0)]
public struct FloroRanchPhaseSettleViewParam
{
	// Token: 0x040063E9 RID: 25577
	public FloroRanchStageEnd StageEndData;

	// Token: 0x040063EA RID: 25578
	public Action<bool> CloseCallback;
}
