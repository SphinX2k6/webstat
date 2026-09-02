using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001CD4 RID: 7380
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaAccumulateRewardItemStage : GridProxyAbstract<GachaAccumulateRewardItemStageData>
{
	// Token: 0x0600D863 RID: 55395 RVA: 0x0039E6F8 File Offset: 0x0039C8F8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D864 RID: 55396 RVA: 0x0039E7E8 File Offset: 0x0039C9E8
	protected override void OnStart()
	{
		this.CommonItemGrid = new CommonItemSmallItemGrid();
		this.CommonItemGrid.CreateThenShowByActor(base.GetItem(3).GetOwner());
		this.CommonItemGrid.SetAllowClickBack(false);
		this.CommonItemGrid.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
		{
			this.OnClickButton();
		});
		this.CommonItemGrid.ShowReceivedCallBack = delegate(TItem _)
		{
			GachaAccumulateRewardItemStageData data = this.Data;
			if (data == null)
			{
				return false;
			}
			GachaAccumulateRewardData data2 = data.Data;
			return ((data2 != null) ? new EGachaAccumulateRewardStatus?(data2.Status) : null).GetValueOrDefault() == EGachaAccumulateRewardStatus.Claimed;
		};
		this.CommonItemGrid.ShowReceivableCallBack = delegate(TItem _)
		{
			GachaAccumulateRewardItemStageData data = this.Data;
			if (data == null)
			{
				return false;
			}
			GachaAccumulateRewardData data2 = data.Data;
			return ((data2 != null) ? new EGachaAccumulateRewardStatus?(data2.Status) : null).GetValueOrDefault() == EGachaAccumulateRewardStatus.CanClaim;
		};
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnClickButton));
	}

	// Token: 0x0600D865 RID: 55397 RVA: 0x0039E8A4 File Offset: 0x0039CAA4
	protected override void OnBeforeDestroy()
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle != null)
		{
			extendToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnToggleStateChange));
		}
		UUIExtendToggle extendToggle2 = base.GetExtendToggle(0);
		if (extendToggle2 == null)
		{
			return;
		}
		extendToggle2.OnUndeterminedClicked.Remove(new Action(this.OnClickButton));
	}

	// Token: 0x0600D866 RID: 55398 RVA: 0x0039E8F6 File Offset: 0x0039CAF6
	public override void Refresh(GachaAccumulateRewardItemStageData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshStateSubPanel(data);
		this.RefreshItem(data);
		base.GetText(5).SetText(data.Data.GachaNum.ToString(), true);
	}

	// Token: 0x0600D867 RID: 55399 RVA: 0x0039E92C File Offset: 0x0039CB2C
	private void RefreshStateSubPanel(GachaAccumulateRewardItemStageData data)
	{
		EGachaAccumulateRewardStatus status = data.Data.Status;
		base.GetItem(1).SetUIActive(status == EGachaAccumulateRewardStatus.NotReached);
		base.GetItem(2).SetUIActive(status == EGachaAccumulateRewardStatus.CanClaim);
		base.GetItem(4).SetUIActive(status == EGachaAccumulateRewardStatus.Claimed);
	}

	// Token: 0x0600D868 RID: 55400 RVA: 0x0039E978 File Offset: 0x0039CB78
	private void RefreshItem(GachaAccumulateRewardItemStageData data)
	{
		RewardItemData rewardItemData = data.Data.GetRewardItemList()[0];
		TItem data2 = new TItem
		{
			ItemData = new InventoryDefine.GetItemData(rewardItemData.ConfigId, 0),
			Count = rewardItemData.Count
		};
		this.CommonItemGrid.Refresh(data2);
		this.CommonItemGrid.SetRedDotVisible(new bool?(data.Data.Status == EGachaAccumulateRewardStatus.CanClaim));
		if (data.Data.Status == EGachaAccumulateRewardStatus.Claimed)
		{
			this.CommonItemGrid.SetReceivedColor("eae4ab");
		}
	}

	// Token: 0x0600D869 RID: 55401 RVA: 0x0039EA05 File Offset: 0x0039CC05
	private void OnToggleStateChange(EToggleState _)
	{
		this.OnClickButton();
	}

	// Token: 0x0600D86A RID: 55402 RVA: 0x0039EA10 File Offset: 0x0039CC10
	private void OnClickButton()
	{
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(this.Data.AccumulateId);
		EGachaAccumulateRewardStatus status = this.Data.Data.Status;
		if (status == EGachaAccumulateRewardStatus.NotReached || status == EGachaAccumulateRewardStatus.Claimed)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.Data.Data.GetRewardItemList()[0].ConfigId, true, null);
			return;
		}
		List<int> list = accumulateData.CollectAllClaimableRewardIds();
		ControllerBase<GachaAccumulateController>.Instance.ClaimAccumulateRewardAsync(this.Data.AccumulateId, list.ToArray(), Array.Empty<int>()).Forget<bool>();
	}

	// Token: 0x04006735 RID: 26421
	private const string ReceivedCheckColor = "eae4ab";

	// Token: 0x04006736 RID: 26422
	[Nullable(2)]
	private GachaAccumulateRewardItemStageData Data;

	// Token: 0x04006737 RID: 26423
	[Nullable(2)]
	private CommonItemSmallItemGrid CommonItemGrid;
}
