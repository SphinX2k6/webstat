using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B36 RID: 23350
	[NullableContext(1)]
	public interface IHonamiTowerSuccessData
	{
		// Token: 0x17009719 RID: 38681
		// (get) Token: 0x0603B102 RID: 241922
		// (set) Token: 0x0603B103 RID: 241923
		IHonamiTowerRecordData[] RecordItemList { get; set; }

		// Token: 0x1700971A RID: 38682
		// (get) Token: 0x0603B104 RID: 241924
		// (set) Token: 0x0603B105 RID: 241925
		RewardItemData[] RewardItemList { get; set; }
	}
}
