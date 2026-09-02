using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002304 RID: 8964
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyOverviewView : UiViewBase
{
	// Token: 0x06011019 RID: 69657 RVA: 0x004AAA03 File Offset: 0x004A8C03
	public MotorcycleDiyOverviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601101A RID: 69658 RVA: 0x004AAA24 File Offset: 0x004A8C24
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
	}

	// Token: 0x0601101B RID: 69659 RVA: 0x004AAA94 File Offset: 0x004A8C94
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyOverviewView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyOverviewView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601101C RID: 69660 RVA: 0x004AAAD8 File Offset: 0x004A8CD8
	protected override void OnBeforeShow()
	{
		int index = this.CurrentSelectPart - 1;
		this.PartTabComponent.SelectToggleByIndex(index, false, true);
	}

	// Token: 0x0601101D RID: 69661 RVA: 0x004AAAFC File Offset: 0x004A8CFC
	private MotorcycleDiyPartTabItem InitPartTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyPartTabItem();
	}

	// Token: 0x0601101E RID: 69662 RVA: 0x004AAB04 File Offset: 0x004A8D04
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		this.CurrentSelectPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
	}

	// Token: 0x0601101F RID: 69663 RVA: 0x004AAB37 File Offset: 0x004A8D37
	private MotorcycleDiyStickerDecoItem CreateOverviewItem()
	{
		return new MotorcycleDiyStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickOverView)
		};
	}

	// Token: 0x06011020 RID: 69664 RVA: 0x004AAB50 File Offset: 0x004A8D50
	private List<MotorcycleDiyStickerDecoItemData> GetItemDataList(int partId)
	{
		if (this.CurrentOutlookType == EOutlookType.Sticker)
		{
			return this.GetStickerItemDataList(partId);
		}
		if (this.CurrentOutlookType == EOutlookType.Decoration)
		{
			return this.GetDecorationItemDataList(partId);
		}
		return new List<MotorcycleDiyStickerDecoItemData>();
	}

	// Token: 0x06011021 RID: 69665 RVA: 0x004AAB7C File Offset: 0x004A8D7C
	private List<MotorcycleDiyStickerDecoItemData> GetStickerItemDataList(int partId)
	{
		List<MotorcycleDiyStickerDecoItemData> list = new List<MotorcycleDiyStickerDecoItemData>();
		list.Add(new MotorcycleDiyStickerDecoItemData
		{
			Part = partId,
			ItemId = 0,
			IsSticker = true
		});
		int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerId(partId));
		if (num != null && num.Value > 0)
		{
			MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num.Value);
			list.Add(new MotorcycleDiyStickerDecoItemData
			{
				Part = partId,
				ItemId = num.Value,
				QualityId = ((motorStickerConfig != null) ? motorStickerConfig.Value.QualityId : 0),
				SortIndex = ((motorStickerConfig != null) ? motorStickerConfig.Value.SortIndex : 0),
				IsSticker = true
			});
		}
		foreach (int num2 in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseStickerIdsInRegion())
		{
			MotorSticker? motorStickerConfig2 = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num2);
			if (motorStickerConfig2 != null && motorStickerConfig2.Value.PartId == partId)
			{
				EOutLookState stickerState = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(num2);
				if (stickerState != EOutLookState.IsHide && stickerState != EOutLookState.IsEquipped)
				{
					list.Add(new MotorcycleDiyStickerDecoItemData
					{
						Part = partId,
						ItemId = num2,
						QualityId = motorStickerConfig2.Value.QualityId,
						SortIndex = motorStickerConfig2.Value.SortIndex,
						IsSticker = true
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06011022 RID: 69666 RVA: 0x004AAD48 File Offset: 0x004A8F48
	private List<MotorcycleDiyStickerDecoItemData> GetDecorationItemDataList(int partId)
	{
		List<MotorcycleDiyStickerDecoItemData> list = new List<MotorcycleDiyStickerDecoItemData>();
		list.Add(new MotorcycleDiyStickerDecoItemData
		{
			Part = partId,
			ItemId = 0,
			IsSticker = false
		});
		int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationId(partId));
		if (num != null && num.Value > 0)
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num.Value);
			list.Add(new MotorcycleDiyStickerDecoItemData
			{
				Part = partId,
				ItemId = num.Value,
				QualityId = ((motorDecorationConfig != null) ? motorDecorationConfig.Value.QualityId : 0),
				SortIndex = ((motorDecorationConfig != null) ? motorDecorationConfig.Value.SortIndex : 0),
				IsSticker = false
			});
		}
		foreach (int num2 in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseDecorationsIdsInRegion())
		{
			MotorDecorations? motorDecorationConfig2 = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num2);
			if (motorDecorationConfig2 != null && motorDecorationConfig2.Value.PartId == partId)
			{
				EOutLookState decorationState = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(num2);
				if (decorationState != EOutLookState.IsHide && decorationState != EOutLookState.IsEquipped)
				{
					list.Add(new MotorcycleDiyStickerDecoItemData
					{
						Part = partId,
						ItemId = num2,
						QualityId = motorDecorationConfig2.Value.QualityId,
						SortIndex = motorDecorationConfig2.Value.SortIndex,
						IsSticker = false
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06011023 RID: 69667 RVA: 0x004AAF14 File Offset: 0x004A9114
	private int SortItemFunc(MotorcycleDiyStickerDecoItemData dataA, MotorcycleDiyStickerDecoItemData dataB)
	{
		EOutLookState itemState = ModelBase<MotorcycleDiyModel>.Instance.GetItemState(this.CurrentOutlookType, dataA.ItemId);
		EOutLookState itemState2 = ModelBase<MotorcycleDiyModel>.Instance.GetItemState(this.CurrentOutlookType, dataB.ItemId);
		if (itemState != itemState2)
		{
			return itemState - itemState2;
		}
		int num = (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(dataA.ItemId) > false) ? 1 : 0;
		int num2 = (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(dataB.ItemId) > false) ? 1 : 0;
		if (num != num2)
		{
			return num2 - num;
		}
		int qualityId = dataA.QualityId;
		int qualityId2 = dataB.QualityId;
		if (qualityId != qualityId2)
		{
			return qualityId2 - qualityId;
		}
		int sortIndex = dataA.SortIndex;
		return dataB.SortIndex - sortIndex;
	}

	// Token: 0x06011024 RID: 69668 RVA: 0x004AAFB4 File Offset: 0x004A91B4
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(this.CurrentOutlookType, new int?(partId));
			List<MotorcycleDiyStickerDecoItemData> dataList = this.GetItemDataList(partId);
			dataList.Sort(new Comparison<MotorcycleDiyStickerDecoItemData>(this.SortItemFunc));
			this.OverviewScrollView.RefreshByData(dataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, dataList);
			}, false);
			this.CachedDataList = dataList;
			return;
		}
		this.OverviewScrollView.RefreshByData(this.CachedDataList, true, null, false);
	}

	// Token: 0x06011025 RID: 69669 RVA: 0x004AB05C File Offset: 0x004A925C
	private void AutoSelectGridByDataList(int partId, List<MotorcycleDiyStickerDecoItemData> dataList)
	{
		int gridIndex = 0;
		int selectItemId = 0;
		int selectedItemId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedItemId(this.CurrentOutlookType, new int?(partId));
		if (selectedItemId != 0)
		{
			selectItemId = selectedItemId;
		}
		else
		{
			selectItemId = ModelBase<MotorcycleDiyModel>.Instance.GetEquippedItemId(this.CurrentOutlookType, partId);
		}
		int num = dataList.IndexOf((MotorcycleDiyStickerDecoItemData data) => data.ItemId == selectItemId);
		if (num >= 0)
		{
			gridIndex = num;
		}
		if (!this.OverviewScrollView.IsGridDisplaying(gridIndex))
		{
			this.OverviewScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.OverviewScrollView.DeselectCurrentGridProxy(false);
		this.OverviewScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06011026 RID: 69670 RVA: 0x004AB100 File Offset: 0x004A9300
	private void OnClickOverView(int itemId, UUIExtendToggle toggle, UUIItem newItem)
	{
		EOutLookState itemState = ModelBase<MotorcycleDiyModel>.Instance.GetItemState(this.CurrentOutlookType, itemId);
		if (itemState == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = ModelBase<MotorcycleDiyModel>.Instance.GetBanTips(this.CurrentOutlookType, itemId);
			if (banTips != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("MotorDIYWarning01", new object[]
				{
					banTips.Value.Item1,
					banTips.Value.Item2
				});
			}
			return;
		}
		if (this.CurrentSelectToggle != null)
		{
			this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		bool flag;
		bool flag2;
		if (this.CurrentOutlookType != EOutlookType.Sticker)
		{
			if (this.CurrentOutlookType == EOutlookType.Decoration)
			{
				ModelBase<MotorcycleDiyModel>.Instance.SetSelectDecorationInfo(this.CurrentSelectPart, itemId);
				flag = ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultDecoration(this.CurrentSelectPart);
				flag2 = (itemId == 0 && !flag);
				if (itemState == EOutLookState.CanEquipped || flag2)
				{
					List<int> selectedDecorationIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationIdList(true);
					ControllerBase<MotorcycleDiyController>.Instance.EquipMotorDecorationRequest(selectedDecorationIdList, delegate
					{
						this.RefreshScrollViewByData(this.CurrentSelectPart, false);
					});
					return;
				}
				this.RefreshScrollViewByData(this.CurrentSelectPart, false);
			}
			return;
		}
		ModelBase<MotorcycleDiyModel>.Instance.SetSelectStickerInfo(this.CurrentSelectPart, itemId);
		flag = ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultSticker(this.CurrentSelectPart);
		flag2 = (itemId == 0 && !flag);
		if (itemState == EOutLookState.CanEquipped || flag2)
		{
			List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(true);
			ControllerBase<MotorcycleDiyController>.Instance.EquipMotorStickerRequest(selectedStickerIdList, delegate
			{
				this.RefreshScrollViewByData(this.CurrentSelectPart, false);
			});
			return;
		}
		this.RefreshScrollViewByData(this.CurrentSelectPart, false);
	}

	// Token: 0x06011027 RID: 69671 RVA: 0x004AB293 File Offset: 0x004A9493
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x040085D4 RID: 34260
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040085D5 RID: 34261
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyPartTabItem> PartTabComponent;

	// Token: 0x040085D6 RID: 34262
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyStickerDecoItem, MotorcycleDiyStickerDecoItemData> OverviewScrollView;

	// Token: 0x040085D7 RID: 34263
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x040085D8 RID: 34264
	private List<MotorcycleDiyStickerDecoItemData> CachedDataList = new List<MotorcycleDiyStickerDecoItemData>();

	// Token: 0x040085D9 RID: 34265
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040085DA RID: 34266
	private int CurrentSelectPart;

	// Token: 0x040085DB RID: 34267
	private EOutlookType CurrentOutlookType;

	// Token: 0x020085FE RID: 34302
	[NullableContext(0)]
	private class EMotorDiyOverviewComponent
	{
		// Token: 0x0402D53F RID: 185663
		public const int CaptionItem = 0;

		// Token: 0x0402D540 RID: 185664
		public const int TabScrollView = 1;

		// Token: 0x0402D541 RID: 185665
		public const int TabContent = 2;

		// Token: 0x0402D542 RID: 185666
		public const int TabItem = 3;

		// Token: 0x0402D543 RID: 185667
		public const int OverviewScrollView = 4;

		// Token: 0x0402D544 RID: 185668
		public const int OverviewItem = 5;
	}
}
