using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B8D RID: 11149
public abstract class SurvivorsRogueCommandView : ISurvivorsRogueCommandView
{
	// Token: 0x17001CF4 RID: 7412
	// (get) Token: 0x06016367 RID: 90983
	[Nullable(1)]
	public abstract SurvivorsRogueCommandBase Command { [NullableContext(1)] get; }

	// Token: 0x17001CF5 RID: 7413
	// (get) Token: 0x06016368 RID: 90984
	public abstract int CommandIncId { get; }

	// Token: 0x06016369 RID: 90985
	public abstract void Refresh();

	// Token: 0x0601636A RID: 90986
	public abstract void CloseView();
}
