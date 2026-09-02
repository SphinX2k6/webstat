using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B10 RID: 23312
	public interface IEncircleRewardInfo : IRewardInfo
	{
		// Token: 0x1700969F RID: 38559
		// (get) Token: 0x0603AFFB RID: 241659
		// (set) Token: 0x0603AFFC RID: 241660
		bool IsSuccess { get; set; }

		// Token: 0x170096A0 RID: 38560
		// (get) Token: 0x0603AFFD RID: 241661
		// (set) Token: 0x0603AFFE RID: 241662
		int? Score { get; set; }

		// Token: 0x170096A1 RID: 38561
		// (get) Token: 0x0603AFFF RID: 241663
		// (set) Token: 0x0603B000 RID: 241664
		int? RecordScore { get; set; }

		// Token: 0x170096A2 RID: 38562
		// (get) Token: 0x0603B001 RID: 241665
		// (set) Token: 0x0603B002 RID: 241666
		[Nullable(new byte[]
		{
			2,
			1
		})]
		List<RewardItemData> CommonItems { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
