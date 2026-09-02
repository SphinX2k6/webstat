using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Skin.Tab.Weapon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001689 RID: 5769
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerSeasonRewardInfoPanel : UiPanelBase
{
	// Token: 0x0600A106 RID: 41222 RVA: 0x002A3BA8 File Offset: 0x002A1DA8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 3;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLook));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickLeft));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickRight));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600A107 RID: 41223 RVA: 0x002A3D18 File Offset: 0x002A1F18
	protected override UniTask OnBeforeStartAsync()
	{
		WheelTowerSeasonRewardInfoPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<WheelTowerSeasonRewardInfoPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600A108 RID: 41224 RVA: 0x002A3D5C File Offset: 0x002A1F5C
	public void RefreshDataList(List<IWheelTowerSeasonScoreData> dataList)
	{
		this.DataList = dataList;
		int num = dataList.Count - 1;
		for (int i = 0; i < dataList.Count; i++)
		{
			if (!dataList[i].IsReceived)
			{
				num = i;
				break;
			}
		}
		this.CurIndex = num;
		this.Refresh(dataList[num]);
	}

	// Token: 0x0600A109 RID: 41225 RVA: 0x002A3DB0 File Offset: 0x002A1FB0
	private void Refresh(IWheelTowerSeasonScoreData data)
	{
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.DropId);
		if (dropPackagePreviewItemList.Count <= 0)
		{
			return;
		}
		TItem titem = dropPackagePreviewItemList[0];
		WheelTowerSeasonRewardInfoItem rewardInfoItem = this.RewardInfoItem;
		if (rewardInfoItem != null)
		{
			rewardInfoItem.Refresh(titem, data.PreviewIcon);
		}
		this.RewardItem = new TItem?(titem);
		this.MotorPreviewId = data.MotorPreviewId;
		this.WeaponPreviewId = data.WeaponPreviewId;
		CSharpScript.Game.Module.Inventory.ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(titem.ItemData.ItemId);
		if (itemConfigData != null)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), itemConfigData.Name, Array.Empty<object>());
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "WheelTower_SeasonScore_TotalScoreGet", new <>z__ReadOnlySingleElementList<object>(data.Score));
		UUIButtonComponent button = base.GetButton(3);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(this.CurIndex > 0);
			}
		}
		UUIButtonComponent button2 = base.GetButton(4);
		if (button2 == null)
		{
			return;
		}
		UUIItem uuiitem2 = button2.RootUIComp.Get();
		if (uuiitem2 == null)
		{
			return;
		}
		uuiitem2.SetUIActive(this.DataList != null && this.CurIndex < this.DataList.Count - 1);
	}

	// Token: 0x0600A10A RID: 41226 RVA: 0x002A3EE8 File Offset: 0x002A20E8
	private void OnClickLook()
	{
		if (this.RewardItem == null)
		{
			return;
		}
		if (this.MotorPreviewId > 0)
		{
			this.ReportRewardPreviewEvent(0, 0, this.MotorPreviewId);
			ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(this.MotorPreviewId);
			return;
		}
		if (this.WeaponPreviewId > 0)
		{
			this.ReportRewardPreviewEvent(0, 0, this.WeaponPreviewId);
			ControllerBase<WeaponSkinController>.Instance.OpenWeaponSkinShowView(new List<int>
			{
				this.WeaponPreviewId
			});
			return;
		}
		int itemId = this.RewardItem.Value.ItemData.ItemId;
		this.ReportRewardPreviewEvent(0, itemId, 0);
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(itemId, true, null);
	}

	// Token: 0x0600A10B RID: 41227 RVA: 0x002A3F8C File Offset: 0x002A218C
	private void ReportRewardPreviewEvent(int goodsId = 0, int itemId = 0, int skinId = 0)
	{
		NewTowerRewardPreviewEvent newTowerRewardPreviewEvent = new NewTowerRewardPreviewEvent();
		newTowerRewardPreviewEvent.i_goods_id = goodsId;
		newTowerRewardPreviewEvent.i_item_id = itemId;
		newTowerRewardPreviewEvent.i_skin_id = skinId;
		ControllerBase<LogReportController>.Instance.LogReport(newTowerRewardPreviewEvent);
	}

	// Token: 0x0600A10C RID: 41228 RVA: 0x002A3FC0 File Offset: 0x002A21C0
	private void OnClickLeft()
	{
		if (this.DataList == null || this.DataList.Count == 0)
		{
			return;
		}
		this.CurIndex = Singleton<MathUtils>.Instance.Clamp(this.CurIndex - 1, 0, this.DataList.Count - 1);
		Action playSwitchTween = this.PlaySwitchTween;
		if (playSwitchTween != null)
		{
			playSwitchTween();
		}
		this.Refresh(this.DataList[this.CurIndex]);
	}

	// Token: 0x0600A10D RID: 41229 RVA: 0x002A4034 File Offset: 0x002A2234
	private void OnClickRight()
	{
		if (this.DataList == null || this.DataList.Count == 0)
		{
			return;
		}
		this.CurIndex = Singleton<MathUtils>.Instance.Clamp(this.CurIndex + 1, 0, this.DataList.Count - 1);
		Action playSwitchTween = this.PlaySwitchTween;
		if (playSwitchTween != null)
		{
			playSwitchTween();
		}
		this.Refresh(this.DataList[this.CurIndex]);
	}

	// Token: 0x04004AE1 RID: 19169
	[Nullable(2)]
	public Action PlaySwitchTween;

	// Token: 0x04004AE2 RID: 19170
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<IWheelTowerSeasonScoreData> DataList;

	// Token: 0x04004AE3 RID: 19171
	[Nullable(2)]
	private WheelTowerSeasonRewardInfoItem RewardInfoItem;

	// Token: 0x04004AE4 RID: 19172
	private TItem? RewardItem;

	// Token: 0x04004AE5 RID: 19173
	private int MotorPreviewId;

	// Token: 0x04004AE6 RID: 19174
	private int WeaponPreviewId;

	// Token: 0x04004AE7 RID: 19175
	private int CurIndex;
}
