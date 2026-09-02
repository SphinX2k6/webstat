using System;
using System.Runtime.CompilerServices;

// Token: 0x0200301A RID: 12314
[NullableContext(2)]
[Nullable(0)]
internal class ActionQueueEntry
{
	// Token: 0x0400C51F RID: 50463
	public EPerformMode Mode;

	// Token: 0x0400C520 RID: 50464
	public EPerformAction ActionType;

	// Token: 0x0400C521 RID: 50465
	[Nullable(1)]
	public IActionParamMap Param;

	// Token: 0x0400C522 RID: 50466
	public Action<int> OnBeforeExecute;

	// Token: 0x0400C523 RID: 50467
	public Action<int> OnAfterExecute;

	// Token: 0x0400C524 RID: 50468
	public bool Persistent;

	// Token: 0x0400C525 RID: 50469
	public EPerformGroup Group;

	// Token: 0x0400C526 RID: 50470
	public int LoadId;

	// Token: 0x0400C527 RID: 50471
	public bool Loaded;
}
