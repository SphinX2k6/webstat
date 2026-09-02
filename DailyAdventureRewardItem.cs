using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012CB RID: 4811
[NullableContext(1)]
[Nullable(0)]
public class DailyAdventureRewardItem : UiPanelBase
{
	// Token: 0x06008133 RID: 33075 RVA: 0x00222490 File Offset: 0x00220690
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.RequestReward));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06008134 RID: 33076 RVA: 0x00222620 File Offset: 0x00220820
	protected override UniTask OnBeforeStartAsync()
	{
		DailyAdventureRewardItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DailyAdventureRewardItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06008135 RID: 33077 RVA: 0x00222663 File Offset: 0x00220863
	protected override void OnBeforeDestroy()
	{
		this.RewardItemList.Clear();
	}

	// Token: 0x06008136 RID: 33078 RVA: 0x00222670 File Offset: 0x00220870
	private UniTask CreateRewardItem(AActor item)
	{
		DailyAdventureRewardItem.<CreateRewardItem>d__6 <CreateRewardItem>d__;
		<CreateRewardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateRewardItem>d__.<>4__this = this;
		<CreateRewardItem>d__.item = item;
		<CreateRewardItem>d__.<>1__state = -1;
		<CreateRewardItem>d__.<>t__builder.Start<DailyAdventureRewardItem.<CreateRewardItem>d__6>(ref <CreateRewardItem>d__);
		return <CreateRewardItem>d__.<>t__builder.Task;
	}

	// Token: 0x06008137 RID: 33079 RVA: 0x002226BC File Offset: 0x002208BC
	private void HandleRewardItemClick(MediumItemGridExtendCallback parameter)
	{
		if (this.Data == null)
		{
			return;
		}
		if (this.Data.RewardState != ERewardState.FinishedAndUnClaimed)
		{
			IItemGridData itemGridData = parameter.Data as IItemGridData;
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemGridData.Item.ItemData.ItemId, true, null);
			return;
		}
		ControllerBase<ActivityDailyAdventureController>.Instance.RequestPointReward(this.Data.RewardId);
	}

	// Token: 0x06008138 RID: 33080 RVA: 0x00222720 File Offset: 0x00220920
	public void Refresh(DailyAdventureRewardData data)
	{
		this.Data = data;
		DailyAdventurePoint? dailyAdventurePointConfig = ConfigBase<ActivityDailyAdventureConfig>.Instance.GetDailyAdventurePointConfig(data.RewardId);
		if (dailyAdventurePointConfig == null)
		{
			return;
		}
		List<TItem> previewReward = this.GetPreviewReward(dailyAdventurePointConfig.Value.Drop);
		for (int i = 0; i < this.RewardItemList.Count; i++)
		{
			bool flag = previewReward.Count > i;
			DailyAdventureSmallGridItem dailyAdventureSmallGridItem = this.RewardItemList[i];
			if (flag)
			{
				ItemGridData data2 = new ItemGridData
				{
					Item = previewReward[i],
					HasClaimed = (this.Data.RewardState == ERewardState.FinishedAndClaimed)
				};
				dailyAdventureSmallGridItem.Refresh(data2, this.Data.RewardState == ERewardState.FinishedAndUnClaimed, this.Data.RewardState == ERewardState.Progress);
			}
			dailyAdventureSmallGridItem.SetActive(flag);
		}
		base.GetText(2).SetText(dailyAdventurePointConfig.Value.NeedPt.ToString(), true);
		this.RefreshState(data.RewardState);
	}

	// Token: 0x06008139 RID: 33081 RVA: 0x00222824 File Offset: 0x00220A24
	private void RefreshState(ERewardState state)
	{
		switch (state)
		{
		case ERewardState.FinishedAndUnClaimed:
			this.SetTextChangeColor(true);
			base.GetText(5).ShowTextNew("Text_ActivityTaskReceive_Text");
			base.GetItem(1).SetUIActive(false);
			base.GetItem(6).SetUIActive(true);
			base.GetItem(7).SetUIActive(true);
			base.GetItem(8).SetUIActive(false);
			return;
		case ERewardState.Progress:
			this.SetTextChangeColor(false);
			base.GetText(5).ShowTextNew("Text_ActivityTaskOngoing_Text");
			base.GetItem(1).SetUIActive(true);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(false);
			return;
		case ERewardState.FinishedAndClaimed:
			this.SetTextChangeColor(false);
			base.GetText(5).ShowTextNew("Text_ActivityTaskClaimed_Text");
			base.GetItem(1).SetUIActive(true);
			base.GetItem(6).SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
			base.GetItem(8).SetUIActive(true);
			return;
		default:
			return;
		}
	}

	// Token: 0x0600813A RID: 33082 RVA: 0x0022292C File Offset: 0x00220B2C
	private void SetTextChangeColor(bool useChangeColor)
	{
		UUIItem text = base.GetText(5);
		FColor? fcolor = new FColor?(base.GetText(5).changeColor);
		text.SetChangeColor(useChangeColor, fcolor);
	}

	// Token: 0x0600813B RID: 33083 RVA: 0x0022295C File Offset: 0x00220B5C
	private List<TItem> GetPreviewReward(int dropId)
	{
		DropPackage? dropPackage;
		Dictionary<int, int> dictionary = (ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId) != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		List<TItem> list = new List<TItem>();
		if (dictionary == null)
		{
			return list;
		}
		foreach (KeyValuePair<int, int> keyValuePair in dictionary)
		{
			int key = keyValuePair.Key;
			int value = keyValuePair.Value;
			TItem item = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(key, 0),
				Count = value
			};
			list.Add(item);
		}
		return list;
	}

	// Token: 0x0600813C RID: 33084 RVA: 0x00222A18 File Offset: 0x00220C18
	private void RequestReward()
	{
		if (this.Data == null || this.Data.RewardState != ERewardState.FinishedAndUnClaimed)
		{
			return;
		}
		ControllerBase<ActivityDailyAdventureController>.Instance.RequestPointReward(this.Data.RewardId);
	}

	// Token: 0x04003DB6 RID: 15798
	[Nullable(2)]
	protected DailyAdventureRewardData Data;

	// Token: 0x04003DB7 RID: 15799
	private readonly List<DailyAdventureSmallGridItem> RewardItemList = new List<DailyAdventureSmallGridItem>();

	// Token: 0x0200763D RID: 30269
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04028C0E RID: 166926
		public const int Button = 0;

		// Token: 0x04028C0F RID: 166927
		public const int SpriteBase = 1;

		// Token: 0x04028C10 RID: 166928
		public const int TxtNum = 2;

		// Token: 0x04028C11 RID: 166929
		public const int Item1 = 3;

		// Token: 0x04028C12 RID: 166930
		public const int Item2 = 4;

		// Token: 0x04028C13 RID: 166931
		public const int TxtState = 5;

		// Token: 0x04028C14 RID: 166932
		public const int SpriteReceive = 6;

		// Token: 0x04028C15 RID: 166933
		public const int PanelReceive = 7;

		// Token: 0x04028C16 RID: 166934
		public const int SpriteDone = 8;
	}
}
