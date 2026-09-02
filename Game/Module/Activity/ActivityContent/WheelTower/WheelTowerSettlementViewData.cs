using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200621C RID: 25116
	[NullableContext(1)]
	[Nullable(0)]
	public class WheelTowerSettlementViewData : IWheelTowerSettlementViewData
	{
		// Token: 0x17009BFC RID: 39932
		// (get) Token: 0x0603F5FC RID: 259580 RVA: 0x0103EC94 File Offset: 0x0103CE94
		// (set) Token: 0x0603F5FD RID: 259581 RVA: 0x0103EC9C File Offset: 0x0103CE9C
		public bool EndlessMode { get; set; }

		// Token: 0x17009BFD RID: 39933
		// (get) Token: 0x0603F5FE RID: 259582 RVA: 0x0103ECA5 File Offset: 0x0103CEA5
		// (set) Token: 0x0603F5FF RID: 259583 RVA: 0x0103ECAD File Offset: 0x0103CEAD
		public int TotalRound { get; set; }

		// Token: 0x17009BFE RID: 39934
		// (get) Token: 0x0603F600 RID: 259584 RVA: 0x0103ECB6 File Offset: 0x0103CEB6
		// (set) Token: 0x0603F601 RID: 259585 RVA: 0x0103ECBE File Offset: 0x0103CEBE
		public int CurrentRound { get; set; }

		// Token: 0x17009BFF RID: 39935
		// (get) Token: 0x0603F602 RID: 259586 RVA: 0x0103ECC7 File Offset: 0x0103CEC7
		// (set) Token: 0x0603F603 RID: 259587 RVA: 0x0103ECCF File Offset: 0x0103CECF
		public int TotalScore { get; set; }

		// Token: 0x17009C00 RID: 39936
		// (get) Token: 0x0603F604 RID: 259588 RVA: 0x0103ECD8 File Offset: 0x0103CED8
		// (set) Token: 0x0603F605 RID: 259589 RVA: 0x0103ECE0 File Offset: 0x0103CEE0
		public int CurrentScore { get; set; }

		// Token: 0x17009C01 RID: 39937
		// (get) Token: 0x0603F606 RID: 259590 RVA: 0x0103ECE9 File Offset: 0x0103CEE9
		// (set) Token: 0x0603F607 RID: 259591 RVA: 0x0103ECF1 File Offset: 0x0103CEF1
		public List<IBossItemData> BossInfoList { get; set; } = new List<IBossItemData>();

		// Token: 0x17009C02 RID: 39938
		// (get) Token: 0x0603F608 RID: 259592 RVA: 0x0103ECFA File Offset: 0x0103CEFA
		// (set) Token: 0x0603F609 RID: 259593 RVA: 0x0103ED02 File Offset: 0x0103CF02
		public int MaxBossWaveNum { get; set; }

		// Token: 0x17009C03 RID: 39939
		// (get) Token: 0x0603F60A RID: 259594 RVA: 0x0103ED0B File Offset: 0x0103CF0B
		// (set) Token: 0x0603F60B RID: 259595 RVA: 0x0103ED13 File Offset: 0x0103CF13
		public List<RoleDataWithBranch> RoleList { get; set; } = new List<RoleDataWithBranch>();

		// Token: 0x17009C04 RID: 39940
		// (get) Token: 0x0603F60C RID: 259596 RVA: 0x0103ED1C File Offset: 0x0103CF1C
		// (set) Token: 0x0603F60D RID: 259597 RVA: 0x0103ED24 File Offset: 0x0103CF24
		public List<int> FinishedSeasonTaskIds { get; set; } = new List<int>();

		// Token: 0x17009C05 RID: 39941
		// (get) Token: 0x0603F60E RID: 259598 RVA: 0x0103ED2D File Offset: 0x0103CF2D
		// (set) Token: 0x0603F60F RID: 259599 RVA: 0x0103ED35 File Offset: 0x0103CF35
		[Nullable(2)]
		public IWheelTowerSettlementViewButtonData LeftButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009C06 RID: 39942
		// (get) Token: 0x0603F610 RID: 259600 RVA: 0x0103ED3E File Offset: 0x0103CF3E
		// (set) Token: 0x0603F611 RID: 259601 RVA: 0x0103ED46 File Offset: 0x0103CF46
		[Nullable(2)]
		public IWheelTowerSettlementViewButtonData CenterButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009C07 RID: 39943
		// (get) Token: 0x0603F612 RID: 259602 RVA: 0x0103ED4F File Offset: 0x0103CF4F
		// (set) Token: 0x0603F613 RID: 259603 RVA: 0x0103ED57 File Offset: 0x0103CF57
		[Nullable(2)]
		public IWheelTowerSettlementViewButtonData RightButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009C08 RID: 39944
		// (get) Token: 0x0603F614 RID: 259604 RVA: 0x0103ED60 File Offset: 0x0103CF60
		// (set) Token: 0x0603F615 RID: 259605 RVA: 0x0103ED68 File Offset: 0x0103CF68
		public bool? ShowEndlessUnlockTips { get; set; }
	}
}
