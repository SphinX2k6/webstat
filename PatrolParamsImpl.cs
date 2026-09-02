using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.LevelGamePlay;

// Token: 0x020030D0 RID: 12496
[NullableContext(2)]
[Nullable(0)]
public class PatrolParamsImpl : IPatrolParams
{
	// Token: 0x170022C7 RID: 8903
	// (get) Token: 0x06019C47 RID: 105543 RVA: 0x00781436 File Offset: 0x0077F636
	// (set) Token: 0x06019C48 RID: 105544 RVA: 0x0078143E File Offset: 0x0077F63E
	public bool? DebugMode { get; set; }

	// Token: 0x170022C8 RID: 8904
	// (get) Token: 0x06019C49 RID: 105545 RVA: 0x00781447 File Offset: 0x0077F647
	// (set) Token: 0x06019C4A RID: 105546 RVA: 0x0078144F File Offset: 0x0077F64F
	public bool? ReturnFalseWhenNavigationFailed { get; set; }

	// Token: 0x170022C9 RID: 8905
	// (get) Token: 0x06019C4B RID: 105547 RVA: 0x00781458 File Offset: 0x0077F658
	// (set) Token: 0x06019C4C RID: 105548 RVA: 0x00781460 File Offset: 0x0077F660
	public EPatrolStartMode? StartMode { get; set; }

	// Token: 0x170022CA RID: 8906
	// (get) Token: 0x06019C4D RID: 105549 RVA: 0x00781469 File Offset: 0x0077F669
	// (set) Token: 0x06019C4E RID: 105550 RVA: 0x00781471 File Offset: 0x0077F671
	public List<double> RandomDistanceRange { get; set; }

	// Token: 0x170022CB RID: 8907
	// (get) Token: 0x06019C4F RID: 105551 RVA: 0x0078147A File Offset: 0x0077F67A
	// (set) Token: 0x06019C50 RID: 105552 RVA: 0x00781482 File Offset: 0x0077F682
	public bool? IsFollowStrictly { get; set; }

	// Token: 0x170022CC RID: 8908
	// (get) Token: 0x06019C51 RID: 105553 RVA: 0x0078148B File Offset: 0x0077F68B
	// (set) Token: 0x06019C52 RID: 105554 RVA: 0x00781493 File Offset: 0x0077F693
	public int? StartPointIndex { get; set; }

	// Token: 0x170022CD RID: 8909
	// (get) Token: 0x06019C53 RID: 105555 RVA: 0x0078149C File Offset: 0x0077F69C
	// (set) Token: 0x06019C54 RID: 105556 RVA: 0x007814A4 File Offset: 0x0077F6A4
	public int? EndPointIndex { get; set; }

	// Token: 0x170022CE RID: 8910
	// (get) Token: 0x06019C55 RID: 105557 RVA: 0x007814AD File Offset: 0x0077F6AD
	// (set) Token: 0x06019C56 RID: 105558 RVA: 0x007814B5 File Offset: 0x0077F6B5
	public bool? NoRequestServer { get; set; }

	// Token: 0x170022CF RID: 8911
	// (get) Token: 0x06019C57 RID: 105559 RVA: 0x007814BE File Offset: 0x0077F6BE
	// (set) Token: 0x06019C58 RID: 105560 RVA: 0x007814C6 File Offset: 0x0077F6C6
	public bool? NoSyncPoint { get; set; }

	// Token: 0x170022D0 RID: 8912
	// (get) Token: 0x06019C59 RID: 105561 RVA: 0x007814CF File Offset: 0x0077F6CF
	// (set) Token: 0x06019C5A RID: 105562 RVA: 0x007814D7 File Offset: 0x0077F6D7
	public Action<int> OnArrivePointHandle { get; set; }

	// Token: 0x170022D1 RID: 8913
	// (get) Token: 0x06019C5B RID: 105563 RVA: 0x007814E0 File Offset: 0x0077F6E0
	// (set) Token: 0x06019C5C RID: 105564 RVA: 0x007814E8 File Offset: 0x0077F6E8
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<IList<ActionInfo>> OnTriggerActionsHandle { [return: Nullable(new byte[]
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

	// Token: 0x170022D2 RID: 8914
	// (get) Token: 0x06019C5D RID: 105565 RVA: 0x007814F1 File Offset: 0x0077F6F1
	// (set) Token: 0x06019C5E RID: 105566 RVA: 0x007814F9 File Offset: 0x0077F6F9
	public Action<ELevelEventState> OnPatrolEndHandle { get; set; }

	// Token: 0x170022D3 RID: 8915
	// (get) Token: 0x06019C5F RID: 105567 RVA: 0x00781502 File Offset: 0x0077F702
	// (set) Token: 0x06019C60 RID: 105568 RVA: 0x0078150A File Offset: 0x0077F70A
	public Action OnResetLocationCallback { get; set; }
}
