using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020015D4 RID: 5588
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class TimePointRewardItem : GridProxyAbstract<TimePointRewardData>
{
	// Token: 0x06009D41 RID: 40257 RVA: 0x00292A38 File Offset: 0x00290C38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickedButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06009D42 RID: 40258 RVA: 0x00292B64 File Offset: 0x00290D64
	protected override void OnStart()
	{
		this.RewardItemGrid = new SmallItemGrid();
		this.RewardItemGrid.Initialize(base.GetItem(1).GetOwner());
		this.RewardItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.RewardItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
	}

	// Token: 0x06009D43 RID: 40259 RVA: 0x00292BD4 File Offset: 0x00290DD4
	[NullableContext(1)]
	public override void Refresh(TimePointRewardData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		TimePointRewardActivity? timePointRewardById = ConfigBase<ActivityTimePointRewardConfig>.Instance.GetTimePointRewardById(this.Data.Id);
		if (timePointRewardById == null)
		{
			return;
		}
		List<TItem> list = new List<TItem>();
		for (int i = 0; i < timePointRewardById.Value.RewardItemLength; i++)
		{
			DicIntInt value = timePointRewardById.Value.RewardItem(i).Value;
			TItem item = new TItem
			{
				ItemData = new InventoryDefine.GetItemData(value.Key, 0),
				Count = value.Value
			};
			list.Add(item);
		}
		this.RewardItem = new TItem?(list[0]);
		UUIItem item2 = base.GetItem(3);
		UUIText text = base.GetText(4);
		switch (data.RewardState)
		{
		case ETimePointRewardState.Lock:
			item2.SetUIActive(false);
			text.ShowTextNew("TimePointRewardActivity_RewardDesc01");
			this.SetTextStateChangeColor(false);
			break;
		case ETimePointRewardState.UnlockAndUnClaimed:
			item2.SetUIActive(true);
			text.ShowTextNew("TimePointRewardActivity_RewardDesc02");
			this.SetTextStateChangeColor(false);
			break;
		case ETimePointRewardState.UnlockAndClaimed:
			item2.SetUIActive(false);
			text.ShowTextNew("TimePointRewardActivity_RewardDesc03");
			this.SetTextStateChangeColor(true);
			break;
		}
		this.SetIndex(gridIndex + 1);
		this.SetTime((double)this.Data.RewardTime);
		this.RefreshGrid();
	}

	// Token: 0x06009D44 RID: 40260 RVA: 0x00292D30 File Offset: 0x00290F30
	private void RefreshGrid()
	{
		PropSmallItemGrid parameters = new PropSmallItemGrid
		{
			Data = this.Data,
			ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
			BottomText = this.RewardItem.Value.Count.ToString()
		};
		this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
		SmallItemGrid rewardItemGrid = this.RewardItemGrid;
		TimePointRewardData data = this.Data;
		rewardItemGrid.SetReceivableVisible(data != null && data.RewardState == ETimePointRewardState.UnlockAndUnClaimed);
		SmallItemGrid rewardItemGrid2 = this.RewardItemGrid;
		TimePointRewardData data2 = this.Data;
		rewardItemGrid2.SetLockVisible(data2 != null && data2.RewardState == ETimePointRewardState.Lock);
		SmallItemGrid rewardItemGrid3 = this.RewardItemGrid;
		TimePointRewardData data3 = this.Data;
		rewardItemGrid3.SetReceivedVisible(data3 != null && data3.RewardState == ETimePointRewardState.UnlockAndClaimed);
	}

	// Token: 0x06009D45 RID: 40261 RVA: 0x00292DFC File Offset: 0x00290FFC
	private void SetTime(double timeStamp)
	{
		DateTime dataFromTimeStamp = Singleton<TimeUtil>.Instance.GetDataFromTimeStamp(timeStamp * Singleton<TimeUtil>.Instance.Millisecond);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "TimePointRewardActivity_TimeDesc01", new <>z__ReadOnlyArray<object>(new object[]
		{
			dataFromTimeStamp.Month,
			dataFromTimeStamp.Day
		}));
	}

	// Token: 0x06009D46 RID: 40262 RVA: 0x00292E60 File Offset: 0x00291060
	private void SetIndex(int index)
	{
		UUISprite spriteIndex = base.GetSprite(5);
		spriteIndex.SetUIActive(false);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SP_TimePointReward_Index0");
		defaultInterpolatedStringHandler.AppendFormatted<int>(index);
		string resourceId = defaultInterpolatedStringHandler.ToStringAndClear();
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, spriteIndex, false, null, delegate(bool _)
		{
			spriteIndex.SetUIActive(true);
		});
	}

	// Token: 0x06009D47 RID: 40263 RVA: 0x00292EE4 File Offset: 0x002910E4
	private void SetTextStateChangeColor(bool useChangeColor)
	{
		UUIItem text = base.GetText(4);
		FColor? fcolor = new FColor?(base.GetText(4).changeColor);
		text.SetChangeColor(useChangeColor, fcolor);
	}

	// Token: 0x06009D48 RID: 40264 RVA: 0x00292F12 File Offset: 0x00291112
	private void OnClickedButton()
	{
		TimePointRewardData data = this.Data;
		if (data != null && data.RewardState == ETimePointRewardState.UnlockAndUnClaimed)
		{
			Action<int> onClickToGet = this.OnClickToGet;
			if (onClickToGet == null)
			{
				return;
			}
			onClickToGet(this.Data.Id);
		}
	}

	// Token: 0x06009D49 RID: 40265 RVA: 0x00292F48 File Offset: 0x00291148
	[NullableContext(1)]
	private void OnClickedGrid(MediumItemGridExtendCallback callback)
	{
		TimePointRewardData data = this.Data;
		if (data == null || data.RewardState != ETimePointRewardState.UnlockAndUnClaimed)
		{
			if (this.RewardItem != null)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItem.Value.ItemData.ItemId, true, null);
			}
			return;
		}
		Action<int> onClickToGet = this.OnClickToGet;
		if (onClickToGet == null)
		{
			return;
		}
		onClickToGet(this.Data.Id);
	}

	// Token: 0x04004872 RID: 18546
	private TimePointRewardData Data;

	// Token: 0x04004873 RID: 18547
	private SmallItemGrid RewardItemGrid;

	// Token: 0x04004874 RID: 18548
	private TItem? RewardItem;

	// Token: 0x04004875 RID: 18549
	public Action<int> OnClickToGet;

	// Token: 0x0200798E RID: 31118
	[NullableContext(0)]
	private class EComponents
	{
		// Token: 0x04029BEC RID: 170988
		public const int Button = 0;

		// Token: 0x04029BED RID: 170989
		public const int ItemGrid = 1;

		// Token: 0x04029BEE RID: 170990
		public const int TxtDate = 2;

		// Token: 0x04029BEF RID: 170991
		public const int ItemCanReceive = 3;

		// Token: 0x04029BF0 RID: 170992
		public const int TxtState = 4;

		// Token: 0x04029BF1 RID: 170993
		public const int SpriteIndex = 5;
	}
}
