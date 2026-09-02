using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B37 RID: 23351
	[NullableContext(1)]
	[Nullable(0)]
	public class HonamiTowerSuccessData : IHonamiTowerSuccessData
	{
		// Token: 0x1700971B RID: 38683
		// (get) Token: 0x0603B106 RID: 241926 RVA: 0x00EF2A1D File Offset: 0x00EF0C1D
		// (set) Token: 0x0603B107 RID: 241927 RVA: 0x00EF2A25 File Offset: 0x00EF0C25
		public IHonamiTowerRecordData[] RecordItemList { get; set; }

		// Token: 0x1700971C RID: 38684
		// (get) Token: 0x0603B108 RID: 241928 RVA: 0x00EF2A2E File Offset: 0x00EF0C2E
		// (set) Token: 0x0603B109 RID: 241929 RVA: 0x00EF2A36 File Offset: 0x00EF0C36
		public RewardItemData[] RewardItemList { get; set; }
	}
}
