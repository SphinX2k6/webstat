using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.TrainingDegree;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B4F RID: 23375
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardExploreBarList : UiPanelBase
	{
		// Token: 0x0603B23B RID: 242235 RVA: 0x00EF6898 File Offset: 0x00EF4A98
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
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
		}

		// Token: 0x0603B23C RID: 242236 RVA: 0x00EF690C File Offset: 0x00EF4B0C
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

		// Token: 0x0603B23D RID: 242237 RVA: 0x00EF6939 File Offset: 0x00EF4B39
		protected override void OnBeforeDestroy()
		{
			this.BarVerticalItem = null;
			this.RewardExploreBarItem = null;
			this.ClearAllRewardExploreBar();
		}

		// Token: 0x0603B23E RID: 242238 RVA: 0x00EF6950 File Offset: 0x00EF4B50
		public void Refresh(string tipsTextId, IReadOnlyList<IRewardExploreBar> exploreBarDataList)
		{
			bool flag = !StringUtils.IsEmpty(tipsTextId);
			if (flag)
			{
				this.SetTitleText(tipsTextId);
			}
			this.SetTitleTextVisible(flag);
			this.SetBarList(exploreBarDataList);
		}

		// Token: 0x0603B23F RID: 242239 RVA: 0x00EF6980 File Offset: 0x00EF4B80
		private void SetBarList(IReadOnlyList<IRewardExploreBar> exploreBarDataList)
		{
			this.ClearAllRewardExploreBar();
			UUIItem item = base.GetItem(0);
			if (exploreBarDataList == null || exploreBarDataList.Count == 0)
			{
				if (item != null)
				{
					item.SetUIActive(false);
				}
				return;
			}
			foreach (IRewardExploreBar rewardExploreBarData in exploreBarDataList)
			{
				this.NewRewardExploreBar(rewardExploreBarData);
			}
			if (item != null)
			{
				item.SetUIActive(true);
			}
		}

		// Token: 0x0603B240 RID: 242240 RVA: 0x00EF69F8 File Offset: 0x00EF4BF8
		private void SetTitleText(string titleTextId)
		{
		}

		// Token: 0x0603B241 RID: 242241 RVA: 0x00EF69FA File Offset: 0x00EF4BFA
		private void SetTitleTextVisible(bool bVisible)
		{
		}

		// Token: 0x0603B242 RID: 242242 RVA: 0x00EF69FC File Offset: 0x00EF4BFC
		private void NewRewardExploreBar(IRewardExploreBar rewardExploreBarData)
		{
			TrainingItem trainingItem = new TrainingItem(Singleton<LguiUtil>.Instance.CopyItem(this.RewardExploreBarItem, this.BarVerticalItem));
			trainingItem.SetData(rewardExploreBarData.TrainingData);
			trainingItem.SetActive(true);
			this.RewardExploreBarListItem.Add(trainingItem);
		}

		// Token: 0x0603B243 RID: 242243 RVA: 0x00EF6A44 File Offset: 0x00EF4C44
		private void ClearAllRewardExploreBar()
		{
			foreach (TrainingItem trainingItem in this.RewardExploreBarListItem)
			{
				trainingItem.Destroy(null);
			}
			this.RewardExploreBarListItem.Clear();
		}

		// Token: 0x04021576 RID: 136566
		[Nullable(2)]
		private UUIItem BarVerticalItem;

		// Token: 0x04021577 RID: 136567
		[Nullable(2)]
		private UUIItem RewardExploreBarItem;

		// Token: 0x04021578 RID: 136568
		private readonly List<TrainingItem> RewardExploreBarListItem = new List<TrainingItem>();

		// Token: 0x0200BB4F RID: 47951
		[NullableContext(0)]
		private class EChildType
		{
			// Token: 0x04039CDC RID: 236764
			public const int BarVerticalItem = 0;

			// Token: 0x04039CDD RID: 236765
			public const int RewardExploreBarItem = 1;
		}
	}
}
