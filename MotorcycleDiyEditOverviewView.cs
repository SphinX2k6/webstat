using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022FE RID: 8958
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyEditOverviewView : UiViewBase
{
	// Token: 0x06010F9F RID: 69535 RVA: 0x004A78A5 File Offset: 0x004A5AA5
	public MotorcycleDiyEditOverviewView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06010FA0 RID: 69536 RVA: 0x004A78C4 File Offset: 0x004A5AC4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010FA1 RID: 69537 RVA: 0x004A7970 File Offset: 0x004A5B70
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyEditOverviewView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyEditOverviewView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010FA2 RID: 69538 RVA: 0x004A79B4 File Offset: 0x004A5BB4
	protected override void OnBeforeShow()
	{
		int index = this.CurrentSelectPart - 1;
		TabComponent<MotorcycleDiyPartTabItem> partTabComponent = this.PartTabComponent;
		if (partTabComponent == null)
		{
			return;
		}
		partTabComponent.SelectToggleByIndex(index, false, true);
	}

	// Token: 0x06010FA3 RID: 69539 RVA: 0x004A79DD File Offset: 0x004A5BDD
	private MotorcycleDiyPartTabItem InitPartTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyPartTabItem();
	}

	// Token: 0x06010FA4 RID: 69540 RVA: 0x004A79E4 File Offset: 0x004A5BE4
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		this.CurrentSelectPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
	}

	// Token: 0x06010FA5 RID: 69541 RVA: 0x004A7A17 File Offset: 0x004A5C17
	private MotorcycleDiyEditStickerDecoItem CreateOverviewItem()
	{
		return new MotorcycleDiyEditStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickOverView)
		};
	}

	// Token: 0x06010FA6 RID: 69542 RVA: 0x004A7A30 File Offset: 0x004A5C30
	private List<MotorcycleDiyEditStickerDecoItemData> GetItemDataList(int partId)
	{
		return this.GetStickerItemDataList(partId);
	}

	// Token: 0x06010FA7 RID: 69543 RVA: 0x004A7A3C File Offset: 0x004A5C3C
	private List<MotorcycleDiyEditStickerDecoItemData> GetStickerItemDataList(int partId)
	{
		List<MotorcycleDiyEditStickerDecoItemData> list = new List<MotorcycleDiyEditStickerDecoItemData>
		{
			new MotorcycleDiyEditStickerDecoItemData
			{
				Part = partId,
				ItemId = 0,
				IsSticker = true
			}
		};
		foreach (int num in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseStickerIdsInRegion())
		{
			MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
			if (motorStickerConfig != null && motorStickerConfig.Value.PartId == partId)
			{
				int stickerState = (int)ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(num);
				bool flag = ModelBase<MotorcycleDiyModel>.Instance.HasSticker(num);
				if (stickerState != 0 && flag)
				{
					list.Add(new MotorcycleDiyEditStickerDecoItemData
					{
						Part = partId,
						ItemId = num,
						QualityId = motorStickerConfig.Value.QualityId,
						SortIndex = motorStickerConfig.Value.SortIndex,
						IsSticker = true
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06010FA8 RID: 69544 RVA: 0x004A7B50 File Offset: 0x004A5D50
	private int SortItemFunc(MotorcycleDiyEditStickerDecoItemData dataA, MotorcycleDiyEditStickerDecoItemData dataB)
	{
		EOutLookState stickerState = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(dataA.ItemId);
		EOutLookState stickerState2 = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(dataB.ItemId);
		if (stickerState != stickerState2)
		{
			return stickerState - stickerState2;
		}
		if (dataA.QualityId != dataB.QualityId)
		{
			return dataB.QualityId - dataA.QualityId;
		}
		return dataB.SortIndex - dataA.SortIndex;
	}

	// Token: 0x06010FA9 RID: 69545 RVA: 0x004A7BB0 File Offset: 0x004A5DB0
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (this.OverviewScrollView == null)
		{
			return;
		}
		if (isNeedRefresh)
		{
			List<MotorcycleDiyEditStickerDecoItemData> dataList = this.GetItemDataList(partId);
			dataList.Sort(new Comparison<MotorcycleDiyEditStickerDecoItemData>(this.SortItemFunc));
			this.CachedDataList = dataList;
			this.OverviewScrollView.RefreshByData(dataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, dataList);
			}, false);
			return;
		}
		this.OverviewScrollView.RefreshByData(this.CachedDataList, true, null, false);
	}

	// Token: 0x06010FAA RID: 69546 RVA: 0x004A7C48 File Offset: 0x004A5E48
	private void AutoSelectGridByDataList(int partId, List<MotorcycleDiyEditStickerDecoItemData> dataList)
	{
		if (this.OverviewScrollView == null)
		{
			return;
		}
		int gridIndex = 0;
		int selectItemId = 0;
		int selectedStickerId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerId(partId);
		if (selectedStickerId != 0)
		{
			selectItemId = selectedStickerId;
		}
		MotorcycleDiyEditStickerDecoItemData motorcycleDiyEditStickerDecoItemData = dataList.FirstOrDefault((MotorcycleDiyEditStickerDecoItemData data) => data.ItemId == selectItemId);
		if (motorcycleDiyEditStickerDecoItemData != null)
		{
			gridIndex = dataList.IndexOf(motorcycleDiyEditStickerDecoItemData);
		}
		if (!this.OverviewScrollView.IsGridDisplaying(gridIndex))
		{
			this.OverviewScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.OverviewScrollView.DeselectCurrentGridProxy(false);
		this.OverviewScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010FAB RID: 69547 RVA: 0x004A7CD8 File Offset: 0x004A5ED8
	private void RefreshStickerEditRedDots()
	{
		MotorcycleDiyPresetData localPresetData = this.LocalPresetData;
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		Dictionary<int, MotorcycleDiyPartTabItem> tabItemMap = this.PartTabComponent.GetTabItemMap();
		bool arg = false;
		foreach (KeyValuePair<int, MotorcycleDiyPartTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			MotorcycleDiyPartTabItem value = keyValuePair.Value;
			int partId = this.PartTabItemDataList[key].PartId;
			if (localPresetData == null)
			{
				value.SetPresetRedDotVisible(false);
			}
			else
			{
				int num = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART, partId);
				int num2 = (num >= 0 && num < localPresetData.StickerIds.Length) ? localPresetData.StickerIds[num] : 0;
				bool flag = instance.GetSelectedStickerId(partId) != num2;
				value.SetPresetRedDotVisible(flag);
				if (flag)
				{
					arg = true;
				}
			}
		}
		Action<EOutlookType, bool> onEditPresetChanged = this.OnEditPresetChanged;
		if (onEditPresetChanged == null)
		{
			return;
		}
		onEditPresetChanged(EOutlookType.Sticker, arg);
	}

	// Token: 0x06010FAC RID: 69548 RVA: 0x004A7DD4 File Offset: 0x004A5FD4
	private void OnClickOverView(int itemId, UUIExtendToggle toggle, UUIItem newItem)
	{
		if (ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(itemId) == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = ModelBase<MotorcycleDiyModel>.Instance.GetBanTips(EOutlookType.Sticker, itemId);
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
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentSelectToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
		ModelBase<MotorcycleDiyModel>.Instance.SetSelectStickerInfo(this.CurrentSelectPart, itemId);
		this.RefreshStickerEditRedDots();
		this.RefreshScrollViewByData(this.CurrentSelectPart, false);
	}

	// Token: 0x06010FAD RID: 69549 RVA: 0x004A7E95 File Offset: 0x004A6095
	private void OnBackButtonClick()
	{
		base.CloseMe(null);
	}

	// Token: 0x0400859F RID: 34207
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x040085A0 RID: 34208
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyPartTabItem> PartTabComponent;

	// Token: 0x040085A1 RID: 34209
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyEditStickerDecoItem, MotorcycleDiyEditStickerDecoItemData> OverviewScrollView;

	// Token: 0x040085A2 RID: 34210
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x040085A3 RID: 34211
	private List<MotorcycleDiyEditStickerDecoItemData> CachedDataList = new List<MotorcycleDiyEditStickerDecoItemData>();

	// Token: 0x040085A4 RID: 34212
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x040085A5 RID: 34213
	private int CurrentSelectPart;

	// Token: 0x040085A6 RID: 34214
	[Nullable(2)]
	private MotorcycleDiyPresetData LocalPresetData;

	// Token: 0x040085A7 RID: 34215
	[Nullable(2)]
	private Action<EOutlookType, bool> OnEditPresetChanged;

	// Token: 0x020085E6 RID: 34278
	[NullableContext(0)]
	private class EMotorDiyOverviewComponent
	{
		// Token: 0x0402D4B8 RID: 185528
		public const int CaptionItem = 0;

		// Token: 0x0402D4B9 RID: 185529
		public const int TabScrollView = 1;

		// Token: 0x0402D4BA RID: 185530
		public const int TabContent = 2;

		// Token: 0x0402D4BB RID: 185531
		public const int TabItem = 3;

		// Token: 0x0402D4BC RID: 185532
		public const int OverviewScrollView = 4;

		// Token: 0x0402D4BD RID: 185533
		public const int OverviewItem = 5;
	}
}
