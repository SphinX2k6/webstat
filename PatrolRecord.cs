using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030CD RID: 12493
[NullableContext(2)]
[Nullable(0)]
public class PatrolRecord
{
	// Token: 0x06019C2B RID: 105515 RVA: 0x007813EF File Offset: 0x0077F5EF
	[NullableContext(1)]
	public PatrolRecord(IPatrolParams config)
	{
		this.OnArrivePointHandle = config.OnArrivePointHandle;
		this.OnTriggerActionsHandle = config.OnTriggerActionsHandle;
		this.OnPatrolEndHandle = config.OnPatrolEndHandle;
		this.OnResetLocationCallback = config.OnResetLocationCallback;
	}

	// Token: 0x0400CD94 RID: 52628
	public bool IsActive;

	// Token: 0x0400CD95 RID: 52629
	public EPatrolState PatrolState;

	// Token: 0x0400CD96 RID: 52630
	public int LastPointIndex = -1;

	// Token: 0x0400CD97 RID: 52631
	public Action<int> OnArrivePointHandle;

	// Token: 0x0400CD98 RID: 52632
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<IList<ActionInfo>> OnTriggerActionsHandle;

	// Token: 0x0400CD99 RID: 52633
	public Action<ELevelEventState> OnPatrolEndHandle;

	// Token: 0x0400CD9A RID: 52634
	public Action OnResetLocationCallback;
}
