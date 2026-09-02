using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x02003086 RID: 12422
[NullableContext(2)]
[Nullable(0)]
public class CharacterDynamicFlowData
{
	// Token: 0x0400CBD5 RID: 52181
	public DynamicFlowActorInfo MasterInfo;

	// Token: 0x0400CBD6 RID: 52182
	public AddPlayBubble BubbleData;

	// Token: 0x0400CBD7 RID: 52183
	public EDynamicFlowType? Type;

	// Token: 0x0400CBD8 RID: 52184
	public Action Callback;
}
