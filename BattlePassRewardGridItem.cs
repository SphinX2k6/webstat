using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002384 RID: 9092
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class BattlePassRewardGridItem : GridProxyAbstract<BattlePassRewardData>
{
	// Token: 0x060116C5 RID: 71365 RVA: 0x004CD67C File Offset: 0x004CB87C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060116C6 RID: 71366 RVA: 0x004CD734 File Offset: 0x004CB934
	private void ClickCallFree(MediumItemGridExtendCallback callbackParameter)
	{
		int itemId = ((TItem)callbackParameter.Data).ItemData.ItemId;
		this.OnClickItem(this.RewardData.FreeRewardItem[0].ItemType.Value, itemId, BattlePassType.Free);
	}

	// Token: 0x060116C7 RID: 71367 RVA: 0x004CD77A File Offset: 0x004CB97A
	private void OnClickItem(EBattlePassItemType itemType, int itemId, BattlePassType payType)
	{
		if (itemType == EBattlePassItemType.CanGet)
		{
			ControllerBase<BattlePassController>.Instance.RequestTakeBattlePassReward(payType, this.RewardData.Level.Value, itemId, base.GridIndex);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
	}

	// Token: 0x060116C8 RID: 71368 RVA: 0x004CD7B0 File Offset: 0x004CB9B0
	private void ClickCallPayItem1(MediumItemGridExtendCallback callbackParameter)
	{
		int itemId = ((TItem)callbackParameter.Data).ItemData.ItemId;
		this.OnClickItem(this.RewardData.PayRewardItem[0].ItemType.Value, itemId, BattlePassType.Pay);
	}

	// Token: 0x060116C9 RID: 71369 RVA: 0x004CD7F8 File Offset: 0x004CB9F8
	private void ClickCallPayItem2(MediumItemGridExtendCallback callbackParameter)
	{
		int itemId = ((TItem)callbackParameter.Data).ItemData.ItemId;
		this.OnClickItem(this.RewardData.PayRewardItem[1].ItemType.Value, itemId, BattlePassType.Pay);
	}

	// Token: 0x060116CA RID: 71370 RVA: 0x004CD840 File Offset: 0x004CBA40
	protected override void OnStart()
	{
		BattlePassSmallGridItem battlePassSmallGridItem = new BattlePassSmallGridItem();
		battlePassSmallGridItem.Initialize(base.GetItem(1).GetOwner());
		battlePassSmallGridItem.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.ClickCallFree));
		this.CommonItemGridViews.Add(battlePassSmallGridItem);
		BattlePassSmallGridItem battlePassSmallGridItem2 = new BattlePassSmallGridItem();
		battlePassSmallGridItem2.Initialize(base.GetItem(2).GetOwner());
		battlePassSmallGridItem2.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.ClickCallPayItem1));
		this.CommonItemGridViews.Add(battlePassSmallGridItem2);
		BattlePassSmallGridItem battlePassSmallGridItem3 = new BattlePassSmallGridItem();
		battlePassSmallGridItem3.Initialize(base.GetItem(3).GetOwner());
		battlePassSmallGridItem3.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.ClickCallPayItem2));
		this.CommonItemGridViews.Add(battlePassSmallGridItem3);
	}

	// Token: 0x060116CB RID: 71371 RVA: 0x004CD8F0 File Offset: 0x004CBAF0
	public override void Refresh(BattlePassRewardData data, bool isLoop, int gridIndex)
	{
		this.RewardData = data;
		base.GetText(0).SetText(data.Level.Value.ToString(), true);
		if (data.FreeRewardItem.Count == 1)
		{
			int index = 0;
			BattlePassSmallGridItem battlePassSmallGridItem = this.CommonItemGridViews[index];
			battlePassSmallGridItem.SetActive(true);
			battlePassSmallGridItem.RefreshItem(data.FreeRewardItem[index].Item.Value, data.FreeRewardItem[index].ItemType.Value);
		}
		else
		{
			this.CommonItemGridViews[0].SetActive(false);
		}
		if (data.PayRewardItem.Count == 2)
		{
			BattlePassSmallGridItem battlePassSmallGridItem2 = this.CommonItemGridViews[1];
			BattlePassSmallGridItem battlePassSmallGridItem3 = this.CommonItemGridViews[2];
			battlePassSmallGridItem2.SetActive(true);
			battlePassSmallGridItem3.SetActive(true);
			battlePassSmallGridItem2.RefreshItem(data.PayRewardItem[0].Item.Value, data.PayRewardItem[0].ItemType.Value);
			battlePassSmallGridItem3.RefreshItem(data.PayRewardItem[1].Item.Value, data.PayRewardItem[1].ItemType.Value);
			return;
		}
		if (data.PayRewardItem.Count == 1)
		{
			this.CommonItemGridViews[1].SetActive(true);
			this.CommonItemGridViews[2].SetActive(false);
			this.CommonItemGridViews[1].RefreshItem(data.PayRewardItem[0].Item.Value, data.PayRewardItem[0].ItemType.Value);
			return;
		}
		this.CommonItemGridViews[1].SetActive(false);
		this.CommonItemGridViews[2].SetActive(false);
	}

	// Token: 0x060116CC RID: 71372 RVA: 0x004CDABC File Offset: 0x004CBCBC
	public int GetGirdLevel()
	{
		BattlePassRewardData rewardData = this.RewardData;
		return ((rewardData != null) ? rewardData.Level : null).GetValueOrDefault(-1);
	}

	// Token: 0x040088C6 RID: 35014
	private readonly List<BattlePassSmallGridItem> CommonItemGridViews = new List<BattlePassSmallGridItem>();

	// Token: 0x040088C7 RID: 35015
	[Nullable(2)]
	private BattlePassRewardData RewardData;

	// Token: 0x0200869F RID: 34463
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402D88D RID: 186509
		LevelText,
		// Token: 0x0402D88E RID: 186510
		Item1,
		// Token: 0x0402D88F RID: 186511
		Item2,
		// Token: 0x0402D890 RID: 186512
		Item3
	}
}
