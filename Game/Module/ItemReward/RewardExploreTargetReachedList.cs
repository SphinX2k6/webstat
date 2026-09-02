using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B5E RID: 23390
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreTargetReachedList : UiPanelBase
	{
		// Token: 0x0603B2A8 RID: 242344 RVA: 0x00EF89B0 File Offset: 0x00EF6BB0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B2A9 RID: 242345 RVA: 0x00EF8A19 File Offset: 0x00EF6C19
		protected override void OnStart()
		{
			this.BarVerticalItem = base.GetItem(0);
			this.RewardExploreBarItem = base.GetItem(1);
			UUIItem rewardExploreBarItem = this.RewardExploreBarItem;
			if (rewardExploreBarItem == null)
			{
				return;
			}
			rewardExploreBarItem.SetUIActive(false);
		}

		// Token: 0x0603B2AA RID: 242346 RVA: 0x00EF8A46 File Offset: 0x00EF6C46
		protected override void OnBeforeDestroy()
		{
			this.BarVerticalItem = null;
			this.RewardExploreBarItem = null;
			this.ClearAllRewardExploreBar();
		}

		// Token: 0x0603B2AB RID: 242347 RVA: 0x00EF8A5C File Offset: 0x00EF6C5C
		public void SetBarList(IRewardExploreTargetReached[] exploreBarDataList)
		{
			this.ClearAllRewardExploreBar();
			UUIItem item = base.GetItem(0);
			if (exploreBarDataList == null || exploreBarDataList.Length == 0)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			foreach (IRewardExploreTargetReached rewardTargetReachedData in exploreBarDataList)
			{
				this.NewRewardExploreBar(rewardTargetReachedData);
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}

		// Token: 0x0603B2AC RID: 242348 RVA: 0x00EF8AB0 File Offset: 0x00EF6CB0
		private void NewRewardExploreBar(IRewardExploreTargetReached rewardTargetReachedData)
		{
			LguiUtil instance = Singleton<LguiUtil>.Instance;
			UUIItem rewardExploreBarItem = this.RewardExploreBarItem;
			RewardExploreTargetReached rewardExploreTargetReached = new RewardExploreTargetReached(instance.DuplicateActor((rewardExploreBarItem != null) ? rewardExploreBarItem.GetOwner() : null, this.BarVerticalItem));
			rewardExploreTargetReached.Refresh(rewardTargetReachedData);
			rewardExploreTargetReached.SetActive(true);
			this.RewardExploreBarList.Add(rewardExploreTargetReached);
		}

		// Token: 0x0603B2AD RID: 242349 RVA: 0x00EF8B00 File Offset: 0x00EF6D00
		private void ClearAllRewardExploreBar()
		{
			foreach (RewardExploreTargetReached rewardExploreTargetReached in this.RewardExploreBarList)
			{
				rewardExploreTargetReached.Destroy(null);
			}
			this.RewardExploreBarList.Clear();
		}

		// Token: 0x0402159C RID: 136604
		private UUIItem RewardExploreBarItem;

		// Token: 0x0402159D RID: 136605
		private UUIItem BarVerticalItem;

		// Token: 0x0402159E RID: 136606
		private readonly List<RewardExploreTargetReached> RewardExploreBarList = new List<RewardExploreTargetReached>();

		// Token: 0x0200BB6A RID: 47978
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039D37 RID: 236855
			public const int BarVerticalItem = 0;

			// Token: 0x04039D38 RID: 236856
			public const int RewardTargetReachedItem = 1;
		}
	}
}
