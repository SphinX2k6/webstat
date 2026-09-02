using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001CD8 RID: 7384
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateStageCyclicPanel : UiPanelBase
{
	// Token: 0x0600D879 RID: 55417 RVA: 0x0039EE4C File Offset: 0x0039D04C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 10;
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
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D87A RID: 55418 RVA: 0x0039EFC0 File Offset: 0x0039D1C0
	protected override void OnStart()
	{
		this.ItemGrid = new CommonItemSmallItemGrid();
		this.ItemGrid.CreateThenShowByActor(base.GetItem(1).GetOwner());
		this.ItemGrid.SetAllowClickBack(false);
		this.ItemGrid.ShowReceivableCallBack = ((TItem _) => this.ShowReceivable);
		this.ItemGrid.ShowReceivedCallBack = ((TItem _) => this.ShowReceived);
		base.GetExtendToggle(0).OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		base.GetExtendToggle(0).OnUndeterminedClicked.Add(new Action(this.OnClickPanel));
	}

	// Token: 0x0600D87B RID: 55419 RVA: 0x0039F064 File Offset: 0x0039D264
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
		extendToggle2.OnUndeterminedClicked.Remove(new Action(this.OnClickPanel));
	}

	// Token: 0x0600D87C RID: 55420 RVA: 0x0039F0B8 File Offset: 0x0039D2B8
	public void Refresh(int accumulateId, GachaAccumulateRewardData reward, GachaAccumulateData accumulateData)
	{
		this.AccumulateId = accumulateId;
		this.RewardId = reward.Id;
		int curGachaNum = accumulateData.CurGachaNum;
		int cyclicBaseGachaNum = accumulateData.GetCyclicBaseGachaNum();
		int cyclicPendingClaimCount = reward.GetCyclicPendingClaimCount(curGachaNum, cyclicBaseGachaNum);
		bool flag = accumulateData.IsCyclicExhausted(reward);
		bool flag2 = curGachaNum >= cyclicBaseGachaNum;
		bool flag3 = !flag2;
		bool flag4 = flag2 && flag;
		bool flag5 = flag2 && !flag && cyclicPendingClaimCount > 0;
		bool uiactive = flag2 && !flag && cyclicPendingClaimCount == 0;
		this.ShowReceivable = flag5;
		this.ShowReceived = flag4;
		RewardItemData rewardItemData = reward.GetRewardItemList()[0];
		this.ItemGrid.Refresh(new TItem
		{
			ItemData = new InventoryDefine.GetItemData(rewardItemData.ConfigId, 0),
			Count = rewardItemData.Count
		});
		if (flag4)
		{
			this.ItemGrid.SetReceivedColor("eae4ab");
		}
		int gachaNum = reward.GachaNum;
		int num;
		if (reward.CycleCount == -1)
		{
			num = curGachaNum - cyclicBaseGachaNum - reward.CycleRewardedTimes * gachaNum;
		}
		else if (flag)
		{
			num = gachaNum;
		}
		else
		{
			num = curGachaNum - cyclicBaseGachaNum;
			int num2 = reward.CycleCount * gachaNum;
			if (num > num2)
			{
				num = num2;
			}
		}
		if (num < 0)
		{
			num = 0;
		}
		base.GetText(3).SetText(num.ToString(), true);
		UUIText text = base.GetText(4);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(gachaNum);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		base.GetItem(8).SetUIActive(flag3);
		base.GetItem(7).SetUIActive(flag4);
		base.GetItem(6).SetUIActive(flag5);
		base.GetItem(5).SetUIActive(uiactive);
		base.GetItem(2).SetUIActive(!flag3);
		UUIText text2 = base.GetText(9);
		UUIItem uuiitem = text2;
		bool bUseChangeColor = flag5;
		FColor? fcolor = new FColor?(text2.changeColor);
		uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		this.ItemGrid.SetRedDotNumCount(flag5 ? new int?(cyclicPendingClaimCount) : null);
		base.GetExtendToggle(0).SetSelfInteractive(!flag3);
		UUIExtendToggle itemGridExtendToggle = this.ItemGrid.GetItemGridExtendToggle();
		if (itemGridExtendToggle == null)
		{
			return;
		}
		itemGridExtendToggle.SetSelfInteractive(!flag3);
	}

	// Token: 0x0600D87D RID: 55421 RVA: 0x0039F2D6 File Offset: 0x0039D4D6
	private void OnToggleStateChange(EToggleState _)
	{
		this.OnClickPanel();
	}

	// Token: 0x0600D87E RID: 55422 RVA: 0x0039F2E0 File Offset: 0x0039D4E0
	private void OnClickPanel()
	{
		GachaAccumulateData accumulateData = ModelBase<GachaAccumulateModel>.Instance.GetAccumulateData(this.AccumulateId);
		if (accumulateData == null)
		{
			return;
		}
		GachaAccumulateRewardData gachaAccumulateRewardData = accumulateData.GroupData.RewardInfos.Find((GachaAccumulateRewardData reward) => reward.Id == this.RewardId);
		if (gachaAccumulateRewardData == null)
		{
			return;
		}
		if (gachaAccumulateRewardData.GetCyclicPendingClaimCount(accumulateData.CurGachaNum, accumulateData.GetCyclicBaseGachaNum()) <= 0)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(gachaAccumulateRewardData.GetRewardItemList()[0].ConfigId, true, null);
			return;
		}
		List<int> list = accumulateData.CollectAllClaimableRewardIds();
		ControllerBase<GachaAccumulateController>.Instance.ClaimAccumulateRewardAsync(this.AccumulateId, list.ToArray(), Array.Empty<int>()).Forget<bool>();
	}

	// Token: 0x0400674B RID: 26443
	private const string ReceivedCheckColor = "eae4ab";

	// Token: 0x0400674C RID: 26444
	[Nullable(2)]
	private CommonItemSmallItemGrid ItemGrid;

	// Token: 0x0400674D RID: 26445
	private int AccumulateId;

	// Token: 0x0400674E RID: 26446
	private int RewardId;

	// Token: 0x0400674F RID: 26447
	private bool ShowReceivable;

	// Token: 0x04006750 RID: 26448
	private bool ShowReceived;
}
