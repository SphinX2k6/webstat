using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F3A RID: 28474
	[NullableContext(1)]
	[Nullable(0)]
	public class JumpConfig : IJumpConfig, IMoveConfig
	{
		// Token: 0x1700A45B RID: 42075
		// (get) Token: 0x06044EDA RID: 282330 RVA: 0x011F152F File Offset: 0x011EF72F
		// (set) Token: 0x06044EDB RID: 282331 RVA: 0x011F1537 File Offset: 0x011EF737
		public float RotateSpeed { get; set; }

		// Token: 0x1700A45C RID: 42076
		// (get) Token: 0x06044EDC RID: 282332 RVA: 0x011F1540 File Offset: 0x011EF740
		// (set) Token: 0x06044EDD RID: 282333 RVA: 0x011F1548 File Offset: 0x011EF748
		public float JumpTime { get; set; }

		// Token: 0x1700A45D RID: 42077
		// (get) Token: 0x06044EDE RID: 282334 RVA: 0x011F1551 File Offset: 0x011EF751
		// (set) Token: 0x06044EDF RID: 282335 RVA: 0x011F1559 File Offset: 0x011EF759
		public float MoveBaseHeightOffset { get; set; }

		// Token: 0x1700A45E RID: 42078
		// (get) Token: 0x06044EE0 RID: 282336 RVA: 0x011F1562 File Offset: 0x011EF762
		// (set) Token: 0x06044EE1 RID: 282337 RVA: 0x011F156A File Offset: 0x011EF76A
		public float MaxRiseHeightEdge { get; set; }

		// Token: 0x1700A45F RID: 42079
		// (get) Token: 0x06044EE2 RID: 282338 RVA: 0x011F1573 File Offset: 0x011EF773
		// (set) Token: 0x06044EE3 RID: 282339 RVA: 0x011F157B File Offset: 0x011EF77B
		public float MaxFallHeightEdge { get; set; }

		// Token: 0x1700A460 RID: 42080
		// (get) Token: 0x06044EE4 RID: 282340 RVA: 0x011F1584 File Offset: 0x011EF784
		// (set) Token: 0x06044EE5 RID: 282341 RVA: 0x011F158C File Offset: 0x011EF78C
		public UCurveFloat MoveRiseCurve { get; set; }

		// Token: 0x1700A461 RID: 42081
		// (get) Token: 0x06044EE6 RID: 282342 RVA: 0x011F1595 File Offset: 0x011EF795
		// (set) Token: 0x06044EE7 RID: 282343 RVA: 0x011F159D File Offset: 0x011EF79D
		public UCurveFloat MoveFallCurve { get; set; }
	}
}
