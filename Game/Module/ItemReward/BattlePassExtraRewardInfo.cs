using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B17 RID: 23319
	[NullableContext(1)]
	[Nullable(0)]
	public class BattlePassExtraRewardInfo : RewardInfo, IBattlePassExtraRewardInfo, IRewardInfo
	{
		// Token: 0x170096B7 RID: 38583
		// (get) Token: 0x0603B02E RID: 241710 RVA: 0x00EF261E File Offset: 0x00EF081E
		// (set) Token: 0x0603B02F RID: 241711 RVA: 0x00EF2626 File Offset: 0x00EF0826
		public List<RewardItemData> CommonItems { get; set; }

		// Token: 0x170096B8 RID: 38584
		// (get) Token: 0x0603B030 RID: 241712 RVA: 0x00EF262F File Offset: 0x00EF082F
		// (set) Token: 0x0603B031 RID: 241713 RVA: 0x00EF2637 File Offset: 0x00EF0837
		public List<RewardItemData> ExtraItems { get; set; }

		// Token: 0x170096B9 RID: 38585
		// (get) Token: 0x0603B032 RID: 241714 RVA: 0x00EF2640 File Offset: 0x00EF0840
		// (set) Token: 0x0603B033 RID: 241715 RVA: 0x00EF2648 File Offset: 0x00EF0848
		[Nullable(2)]
		public string TipsTextId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170096BA RID: 38586
		// (get) Token: 0x0603B034 RID: 241716 RVA: 0x00EF2651 File Offset: 0x00EF0851
		// (set) Token: 0x0603B035 RID: 241717 RVA: 0x00EF2659 File Offset: 0x00EF0859
		public Action LeftAction { get; set; }

		// Token: 0x170096BB RID: 38587
		// (get) Token: 0x0603B036 RID: 241718 RVA: 0x00EF2662 File Offset: 0x00EF0862
		// (set) Token: 0x0603B037 RID: 241719 RVA: 0x00EF266A File Offset: 0x00EF086A
		public Action RightAction { get; set; }

		// Token: 0x170096BC RID: 38588
		// (get) Token: 0x0603B038 RID: 241720 RVA: 0x00EF2673 File Offset: 0x00EF0873
		// (set) Token: 0x0603B039 RID: 241721 RVA: 0x00EF267B File Offset: 0x00EF087B
		[Nullable(2)]
		public Action<bool> FinishCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
