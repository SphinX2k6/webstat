using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030CF RID: 12495
[NullableContext(2)]
public interface IPatrolParams
{
	// Token: 0x170022BA RID: 8890
	// (get) Token: 0x06019C2D RID: 105517
	// (set) Token: 0x06019C2E RID: 105518
	bool? DebugMode { get; set; }

	// Token: 0x170022BB RID: 8891
	// (get) Token: 0x06019C2F RID: 105519
	// (set) Token: 0x06019C30 RID: 105520
	bool? ReturnFalseWhenNavigationFailed { get; set; }

	// Token: 0x170022BC RID: 8892
	// (get) Token: 0x06019C31 RID: 105521
	// (set) Token: 0x06019C32 RID: 105522
	EPatrolStartMode? StartMode { get; set; }

	// Token: 0x170022BD RID: 8893
	// (get) Token: 0x06019C33 RID: 105523
	// (set) Token: 0x06019C34 RID: 105524
	List<double> RandomDistanceRange { get; set; }

	// Token: 0x170022BE RID: 8894
	// (get) Token: 0x06019C35 RID: 105525
	// (set) Token: 0x06019C36 RID: 105526
	bool? IsFollowStrictly { get; set; }

	// Token: 0x170022BF RID: 8895
	// (get) Token: 0x06019C37 RID: 105527
	// (set) Token: 0x06019C38 RID: 105528
	int? StartPointIndex { get; set; }

	// Token: 0x170022C0 RID: 8896
	// (get) Token: 0x06019C39 RID: 105529
	// (set) Token: 0x06019C3A RID: 105530
	int? EndPointIndex { get; set; }

	// Token: 0x170022C1 RID: 8897
	// (get) Token: 0x06019C3B RID: 105531
	// (set) Token: 0x06019C3C RID: 105532
	bool? NoRequestServer { get; set; }

	// Token: 0x170022C2 RID: 8898
	// (get) Token: 0x06019C3D RID: 105533
	// (set) Token: 0x06019C3E RID: 105534
	bool? NoSyncPoint { get; set; }

	// Token: 0x170022C3 RID: 8899
	// (get) Token: 0x06019C3F RID: 105535
	// (set) Token: 0x06019C40 RID: 105536
	Action<int> OnArrivePointHandle { get; set; }

	// Token: 0x170022C4 RID: 8900
	// (get) Token: 0x06019C41 RID: 105537
	// (set) Token: 0x06019C42 RID: 105538
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	Action<IList<ActionInfo>> OnTriggerActionsHandle { [return: Nullable(new byte[]
	{
		2,
		1,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1,
		1
	})] set; }

	// Token: 0x170022C5 RID: 8901
	// (get) Token: 0x06019C43 RID: 105539
	// (set) Token: 0x06019C44 RID: 105540
	Action<ELevelEventState> OnPatrolEndHandle { get; set; }

	// Token: 0x170022C6 RID: 8902
	// (get) Token: 0x06019C45 RID: 105541
	// (set) Token: 0x06019C46 RID: 105542
	Action OnResetLocationCallback { get; set; }
}
