using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B16 RID: 23318
	[NullableContext(1)]
	public interface IBattlePassExtraRewardInfo : IRewardInfo
	{
		// Token: 0x170096B1 RID: 38577
		// (get) Token: 0x0603B022 RID: 241698
		// (set) Token: 0x0603B023 RID: 241699
		List<RewardItemData> CommonItems { get; set; }

		// Token: 0x170096B2 RID: 38578
		// (get) Token: 0x0603B024 RID: 241700
		// (set) Token: 0x0603B025 RID: 241701
		List<RewardItemData> ExtraItems { get; set; }

		// Token: 0x170096B3 RID: 38579
		// (get) Token: 0x0603B026 RID: 241702
		// (set) Token: 0x0603B027 RID: 241703
		[Nullable(2)]
		string TipsTextId { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x170096B4 RID: 38580
		// (get) Token: 0x0603B028 RID: 241704
		// (set) Token: 0x0603B029 RID: 241705
		Action LeftAction { get; set; }

		// Token: 0x170096B5 RID: 38581
		// (get) Token: 0x0603B02A RID: 241706
		// (set) Token: 0x0603B02B RID: 241707
		Action RightAction { get; set; }

		// Token: 0x170096B6 RID: 38582
		// (get) Token: 0x0603B02C RID: 241708
		// (set) Token: 0x0603B02D RID: 241709
		[Nullable(2)]
		Action<bool> FinishCallback { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
