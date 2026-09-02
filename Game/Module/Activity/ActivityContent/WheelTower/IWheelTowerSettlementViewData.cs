using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x0200621B RID: 25115
	[NullableContext(1)]
	public interface IWheelTowerSettlementViewData
	{
		// Token: 0x17009BEF RID: 39919
		// (get) Token: 0x0603F5E2 RID: 259554
		// (set) Token: 0x0603F5E3 RID: 259555
		bool EndlessMode { get; set; }

		// Token: 0x17009BF0 RID: 39920
		// (get) Token: 0x0603F5E4 RID: 259556
		// (set) Token: 0x0603F5E5 RID: 259557
		int TotalRound { get; set; }

		// Token: 0x17009BF1 RID: 39921
		// (get) Token: 0x0603F5E6 RID: 259558
		// (set) Token: 0x0603F5E7 RID: 259559
		int CurrentRound { get; set; }

		// Token: 0x17009BF2 RID: 39922
		// (get) Token: 0x0603F5E8 RID: 259560
		// (set) Token: 0x0603F5E9 RID: 259561
		int TotalScore { get; set; }

		// Token: 0x17009BF3 RID: 39923
		// (get) Token: 0x0603F5EA RID: 259562
		// (set) Token: 0x0603F5EB RID: 259563
		int CurrentScore { get; set; }

		// Token: 0x17009BF4 RID: 39924
		// (get) Token: 0x0603F5EC RID: 259564
		// (set) Token: 0x0603F5ED RID: 259565
		List<IBossItemData> BossInfoList { get; set; }

		// Token: 0x17009BF5 RID: 39925
		// (get) Token: 0x0603F5EE RID: 259566
		// (set) Token: 0x0603F5EF RID: 259567
		int MaxBossWaveNum { get; set; }

		// Token: 0x17009BF6 RID: 39926
		// (get) Token: 0x0603F5F0 RID: 259568
		// (set) Token: 0x0603F5F1 RID: 259569
		List<RoleDataWithBranch> RoleList { get; set; }

		// Token: 0x17009BF7 RID: 39927
		// (get) Token: 0x0603F5F2 RID: 259570
		// (set) Token: 0x0603F5F3 RID: 259571
		List<int> FinishedSeasonTaskIds { get; set; }

		// Token: 0x17009BF8 RID: 39928
		// (get) Token: 0x0603F5F4 RID: 259572
		// (set) Token: 0x0603F5F5 RID: 259573
		[Nullable(2)]
		IWheelTowerSettlementViewButtonData LeftButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BF9 RID: 39929
		// (get) Token: 0x0603F5F6 RID: 259574
		// (set) Token: 0x0603F5F7 RID: 259575
		[Nullable(2)]
		IWheelTowerSettlementViewButtonData CenterButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BFA RID: 39930
		// (get) Token: 0x0603F5F8 RID: 259576
		// (set) Token: 0x0603F5F9 RID: 259577
		[Nullable(2)]
		IWheelTowerSettlementViewButtonData RightButtonData { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x17009BFB RID: 39931
		// (get) Token: 0x0603F5FA RID: 259578
		// (set) Token: 0x0603F5FB RID: 259579
		bool? ShowEndlessUnlockTips { get; set; }
	}
}
