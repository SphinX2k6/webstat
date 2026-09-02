using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.WheelTower
{
	// Token: 0x02006219 RID: 25113
	[NullableContext(2)]
	public interface IWheelTowerResultViewData
	{
		// Token: 0x17009BDB RID: 39899
		// (get) Token: 0x0603F5B9 RID: 259513
		// (set) Token: 0x0603F5BA RID: 259514
		bool EndlessMode { get; set; }

		// Token: 0x17009BDC RID: 39900
		// (get) Token: 0x0603F5BB RID: 259515
		// (set) Token: 0x0603F5BC RID: 259516
		int TotalRound { get; set; }

		// Token: 0x17009BDD RID: 39901
		// (get) Token: 0x0603F5BD RID: 259517
		// (set) Token: 0x0603F5BE RID: 259518
		int CurrentRound { get; set; }

		// Token: 0x17009BDE RID: 39902
		// (get) Token: 0x0603F5BF RID: 259519
		// (set) Token: 0x0603F5C0 RID: 259520
		int TotalScore { get; set; }

		// Token: 0x17009BDF RID: 39903
		// (get) Token: 0x0603F5C1 RID: 259521
		// (set) Token: 0x0603F5C2 RID: 259522
		int CurrentScore { get; set; }

		// Token: 0x17009BE0 RID: 39904
		// (get) Token: 0x0603F5C3 RID: 259523
		// (set) Token: 0x0603F5C4 RID: 259524
		[Nullable(1)]
		List<IBossItemData> BossInfoList { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17009BE1 RID: 39905
		// (get) Token: 0x0603F5C5 RID: 259525
		// (set) Token: 0x0603F5C6 RID: 259526
		IWheelTowerResultViewButtonData LeftButtonData { get; set; }

		// Token: 0x17009BE2 RID: 39906
		// (get) Token: 0x0603F5C7 RID: 259527
		// (set) Token: 0x0603F5C8 RID: 259528
		IWheelTowerResultViewButtonData CenterButtonData { get; set; }

		// Token: 0x17009BE3 RID: 39907
		// (get) Token: 0x0603F5C9 RID: 259529
		// (set) Token: 0x0603F5CA RID: 259530
		IWheelTowerResultViewButtonData RightButtonData { get; set; }

		// Token: 0x17009BE4 RID: 39908
		// (get) Token: 0x0603F5CB RID: 259531
		// (set) Token: 0x0603F5CC RID: 259532
		bool? ShowEndlessUnlockTips { get; set; }
	}
}
