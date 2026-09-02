using System;
using System.Runtime.InteropServices;
using UnrealEngine;

// Token: 0x02000BC0 RID: 3008
public interface IGameBudgetManagedObject
{
	// Token: 0x060030FE RID: 12542
	void ScheduledTick(float deltaSeconds, int deltaFrames, float distance);

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x060030FF RID: 12543
	bool HasScheduledAfterTick { get; }

	// Token: 0x06003100 RID: 12544 RVA: 0x0001B229 File Offset: 0x00019429
	void ScheduledAfterTick(float deltaSeconds, int deltaFrames, float distance)
	{
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x06003101 RID: 12545
	bool HasOnEnabledChange { get; }

	// Token: 0x06003102 RID: 12546 RVA: 0x0001B22B File Offset: 0x0001942B
	void OnEnabledChange(bool enable, float distance)
	{
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x06003103 RID: 12547
	bool HasOnWasRecentlyRenderedOnScreenChange { get; }

	// Token: 0x06003104 RID: 12548 RVA: 0x0001B22D File Offset: 0x0001942D
	void OnWasRecentlyRenderedOnScreenChange(bool wasRecentlyRenderedOnScreen)
	{
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x06003105 RID: 12549 RVA: 0x0001B22F File Offset: 0x0001942F
	bool HasLocationProxyFunction
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06003106 RID: 12550 RVA: 0x0001B234 File Offset: 0x00019434
	FVectorDouble? LocationProxyFunction()
	{
		return null;
	}

	// Token: 0x06003107 RID: 12551
	GCHandle GetGCHandle();
}
