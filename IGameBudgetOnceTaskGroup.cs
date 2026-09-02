using System;
using UnrealEngine;

// Token: 0x02000BC1 RID: 3009
public interface IGameBudgetOnceTaskGroup
{
	// Token: 0x170000AD RID: 173
	// (get) Token: 0x06003108 RID: 12552
	FName GroupId { get; }

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x06003109 RID: 12553
	int Priority { get; }

	// Token: 0x0600310A RID: 12554
	bool IsEmpty();

	// Token: 0x0600310B RID: 12555
	void Consume();
}
