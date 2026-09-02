using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002C01 RID: 11265
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TowerRewardItem : GridProxyAbstract<TowerReward>
{
	// Token: 0x060167A6 RID: 92070 RVA: 0x0063F73C File Offset: 0x0063D93C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickRewardButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060167A7 RID: 92071 RVA: 0x0063F866 File Offset: 0x0063DA66
	protected override void OnStart()
	{
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(0), new Func<CommonItemSmallItemGrid>(this.InitRewardItem), null, false, null);
	}

	// Token: 0x060167A8 RID: 92072 RVA: 0x0063F889 File Offset: 0x0063DA89
	protected override void OnBeforeDestroy()
	{
		this.RewardScrollView = null;
	}

	// Token: 0x060167A9 RID: 92073 RVA: 0x0063F894 File Offset: 0x0063DA94
	public override void Refresh(TowerReward data, bool isSelected, int gridIndex)
	{
		this.RewardReceived = data.IsReceived.GetValueOrDefault();
		this.RewardIndex = data.Index;
		List<TItem> challengeRewards = this.GetChallengeRewards(data.RewardId);
		this.RewardScrollView.RefreshByData(challengeRewards, delegate
		{
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.RewardScrollView.GetScrollItemList())
			{
				commonItemSmallItemGrid.SetReceivedVisible(this.RewardReceived);
			}
		}, false);
		int difficultyMaxStars = ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(ModelBase<TowerModel>.Instance.CurrentSelectDifficulties, false);
		base.GetText(1).SetText(data.Target.ToString(), true);
		base.GetItem(3).SetUIActive(this.RewardReceived);
		base.GetItem(4).SetUIActive(difficultyMaxStars < data.Target);
		base.GetItem(5).SetUIActive(difficultyMaxStars >= data.Target && !this.RewardReceived);
	}

	// Token: 0x060167AA RID: 92074 RVA: 0x0063F95A File Offset: 0x0063DB5A
	private CommonItemSmallItemGrid InitRewardItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060167AB RID: 92075 RVA: 0x0063F964 File Offset: 0x0063DB64
	private List<TItem> GetChallengeRewards(int dropId)
	{
		DropPackage? dropPackage;
		Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		List<TItem> list = new List<TItem>();
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			TItem item = new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value);
			list.Add(item);
		}
		return list;
	}

	// Token: 0x060167AC RID: 92076 RVA: 0x0063F9FC File Offset: 0x0063DBFC
	private void OnClickRewardButton()
	{
		int currentSelectDifficulties = ModelBase<TowerModel>.Instance.CurrentSelectDifficulties;
		int getReachedStars = ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(currentSelectDifficulties, false);
		List<TowerReward> difficultyReward = ModelBase<TowerModel>.Instance.GetDifficultyReward(currentSelectDifficulties);
		List<TowerReward> list = (difficultyReward != null) ? difficultyReward.FindAll(delegate(TowerReward item)
		{
			bool? isReceived = item.IsReceived;
			bool flag = false;
			return (isReceived.GetValueOrDefault() == flag & isReceived != null) && getReachedStars >= item.Target;
		}) : null;
		List<int> list2;
		if (list == null)
		{
			list2 = null;
		}
		else
		{
			list2 = list.ConvertAll<int>((TowerReward item) => item.Index);
		}
		List<int> rewardIndexList = list2 ?? new List<int>();
		ControllerBase<TowerController>.Instance.TowerRewardRequest(currentSelectDifficulties, this.RewardIndex, rewardIndexList);
		base.GetItem(3).SetUIActive(true);
		base.GetItem(5).SetUIActive(false);
	}

	// Token: 0x0400ADF7 RID: 44535
	private bool RewardReceived;

	// Token: 0x0400ADF8 RID: 44536
	private int RewardIndex;

	// Token: 0x0400ADF9 RID: 44537
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

	// Token: 0x02008EFC RID: 36604
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x0403008F RID: 196751
		ScrollView,
		// Token: 0x04030090 RID: 196752
		TitleText,
		// Token: 0x04030091 RID: 196753
		RewardButton,
		// Token: 0x04030092 RID: 196754
		ReceivedItem,
		// Token: 0x04030093 RID: 196755
		NotReachedItem,
		// Token: 0x04030094 RID: 196756
		NotReceivedItem
	}
}
