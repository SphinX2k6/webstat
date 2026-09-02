using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B3F RID: 23359
	[NullableContext(1)]
	public interface IRewardDataInterface
	{
		// Token: 0x1700972E RID: 38702
		// (get) Token: 0x0603B14B RID: 241995
		// (set) Token: 0x0603B14C RID: 241996
		[Nullable(2)]
		IExtendRewardInfo ExtendRewardInfo { [NullableContext(2)] get; [NullableContext(2)] set; }

		// Token: 0x1700972F RID: 38703
		// (get) Token: 0x0603B14D RID: 241997
		// (set) Token: 0x0603B14E RID: 241998
		Dictionary<int, RewardItemData> ItemConfigIdMap { get; set; }

		// Token: 0x17009730 RID: 38704
		// (get) Token: 0x0603B14F RID: 241999
		// (set) Token: 0x0603B150 RID: 242000
		Dictionary<int, RewardItemData> ItemUniqueIdMap { get; set; }

		// Token: 0x0603B151 RID: 242001
		void SetItemList([Nullable(new byte[]
		{
			2,
			1
		})] List<RewardItemData> rewardItemList);

		// Token: 0x0603B152 RID: 242002
		void AddItem(RewardItemData rewardItemData);

		// Token: 0x0603B153 RID: 242003
		void SetExploreRecordInfo(IRewardExploreRecord exploreRecordInfo);

		// Token: 0x0603B154 RID: 242004
		void AddItemList(IReadOnlyList<RewardItemData> itemList);

		// Token: 0x0603B155 RID: 242005
		void SetExploreBarDataList(List<IRewardExploreBar> exploreBarDataList);

		// Token: 0x0603B156 RID: 242006
		void SetProgressQueue([Nullable(new byte[]
		{
			2,
			1
		})] List<IRewardProgress> progressQueue = null);

		// Token: 0x0603B157 RID: 242007
		void SetExploreFriendDataList(List<IRewardExploreFriendData> friendDataList);

		// Token: 0x0603B158 RID: 242008
		void SetButtonInfoList(List<IRewardExploreConfirmButton> buttonInfoList);
	}
}
