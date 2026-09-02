using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022F8 RID: 8952
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyEditStickerTabView : UiTabViewBase, IMotorcycleDiyEditTabViewRegister, IMotorcycleDiyTabViewRegister
{
	// Token: 0x17001506 RID: 5382
	// (get) Token: 0x06010F31 RID: 69425 RVA: 0x004A49A8 File Offset: 0x004A2BA8
	// (set) Token: 0x06010F32 RID: 69426 RVA: 0x004A49B0 File Offset: 0x004A2BB0
	public Action<int> OnTabCameraClick { get; set; }

	// Token: 0x17001507 RID: 5383
	// (get) Token: 0x06010F33 RID: 69427 RVA: 0x004A49B9 File Offset: 0x004A2BB9
	// (set) Token: 0x06010F34 RID: 69428 RVA: 0x004A49C1 File Offset: 0x004A2BC1
	public Action<EOutlookType, int, int> OnSelectItemClick { get; set; }

	// Token: 0x17001508 RID: 5384
	// (get) Token: 0x06010F35 RID: 69429 RVA: 0x004A49CA File Offset: 0x004A2BCA
	// (set) Token: 0x06010F36 RID: 69430 RVA: 0x004A49D2 File Offset: 0x004A2BD2
	public Func<MotorcycleDiyPresetData> GetLocalPresetData { get; set; }

	// Token: 0x17001509 RID: 5385
	// (get) Token: 0x06010F37 RID: 69431 RVA: 0x004A49DB File Offset: 0x004A2BDB
	// (set) Token: 0x06010F38 RID: 69432 RVA: 0x004A49E3 File Offset: 0x004A2BE3
	public Action<EOutlookType, bool> OnEditPresetChanged { get; set; }

	// Token: 0x06010F39 RID: 69433 RVA: 0x004A49EC File Offset: 0x004A2BEC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 16;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(14, new Action(this.OnBtnOverviewClick));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06010F3A RID: 69434 RVA: 0x004A4C6C File Offset: 0x004A2E6C
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyEditStickerTabView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyEditStickerTabView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010F3B RID: 69435 RVA: 0x004A4CB0 File Offset: 0x004A2EB0
	protected override void OnBeforeShow()
	{
		this.CurrentSelectStickerPart = (this.ExtraParams as int?).GetValueOrDefault();
		int index = (this.CurrentSelectStickerPart > 0) ? (this.CurrentSelectStickerPart - 1) : 0;
		this.PartTabComponent.SelectToggleByIndex(index, true, true);
	}

	// Token: 0x06010F3C RID: 69436 RVA: 0x004A4CFE File Offset: 0x004A2EFE
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnStickerInfoUpdate));
	}

	// Token: 0x06010F3D RID: 69437 RVA: 0x004A4D1C File Offset: 0x004A2F1C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnStickerInfoUpdate));
	}

	// Token: 0x06010F3E RID: 69438 RVA: 0x004A4D3A File Offset: 0x004A2F3A
	[NullableContext(1)]
	private MotorcycleDiyEditPartTabItem InitStickerTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyEditPartTabItem();
	}

	// Token: 0x06010F3F RID: 69439 RVA: 0x004A4D44 File Offset: 0x004A2F44
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		this.CurrentSelectStickerPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
		Action<int> onTabCameraClick = this.OnTabCameraClick;
		if (onTabCameraClick == null)
		{
			return;
		}
		onTabCameraClick(this.CurrentSelectStickerPart);
	}

	// Token: 0x06010F40 RID: 69440 RVA: 0x004A4D8D File Offset: 0x004A2F8D
	[NullableContext(1)]
	private MotorcycleDiyEditStickerDecoItem CreateStickerItem()
	{
		return new MotorcycleDiyEditStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickSticker)
		};
	}

	// Token: 0x06010F41 RID: 69441 RVA: 0x004A4DA6 File Offset: 0x004A2FA6
	public void RefreshItemScrollView()
	{
		if (this.StickerScrollView != null)
		{
			this.RefreshScrollViewByData(this.CurrentSelectStickerPart, true);
		}
	}

	// Token: 0x06010F42 RID: 69442 RVA: 0x004A4DC0 File Offset: 0x004A2FC0
	private void RefreshStickerPreviewRedDots()
	{
		Func<MotorcycleDiyPresetData> getLocalPresetData = this.GetLocalPresetData;
		MotorcycleDiyPresetData motorcycleDiyPresetData = (getLocalPresetData != null) ? getLocalPresetData() : null;
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		Dictionary<int, MotorcycleDiyEditPartTabItem> tabItemMap = this.PartTabComponent.GetTabItemMap();
		bool arg = false;
		foreach (KeyValuePair<int, MotorcycleDiyEditPartTabItem> keyValuePair in tabItemMap)
		{
			int key = keyValuePair.Key;
			MotorcycleDiyEditPartTabItem value = keyValuePair.Value;
			int partId = this.PartTabItemDataList[key].PartId;
			if (motorcycleDiyPresetData == null)
			{
				value.SetPresetRedDotVisible(false);
			}
			else
			{
				int num = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_STICKER_PART, partId);
				int num2 = (num >= 0 && num < motorcycleDiyPresetData.StickerIds.Length) ? motorcycleDiyPresetData.StickerIds[num] : 0;
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

	// Token: 0x06010F43 RID: 69443 RVA: 0x004A4EC8 File Offset: 0x004A30C8
	[NullableContext(1)]
	private List<MotorcycleDiyEditStickerDecoItemData> GetStickerItemDataList(int partId)
	{
		List<MotorcycleDiyEditStickerDecoItemData> list = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorcycleDiyEditStickerDecoItemData item = new MotorcycleDiyEditStickerDecoItemData
		{
			Part = partId,
			ItemId = 0,
			IsSticker = true
		};
		list.Add(item);
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

	// Token: 0x06010F44 RID: 69444 RVA: 0x004A4FDC File Offset: 0x004A31DC
	[NullableContext(1)]
	private int SortStickerItemFunc(MotorcycleDiyEditStickerDecoItemData dataA, MotorcycleDiyEditStickerDecoItemData dataB)
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

	// Token: 0x06010F45 RID: 69445 RVA: 0x004A503C File Offset: 0x004A323C
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			List<MotorcycleDiyEditStickerDecoItemData> stickerDataList = this.GetStickerItemDataList(partId);
			stickerDataList.Sort(new Comparison<MotorcycleDiyEditStickerDecoItemData>(this.SortStickerItemFunc));
			this.StickerScrollView.RefreshByData(stickerDataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, stickerDataList);
			}, false);
			this.CachedStickerDataList = stickerDataList;
			return;
		}
		this.StickerScrollView.RefreshByData(this.CachedStickerDataList, true, null, false);
	}

	// Token: 0x06010F46 RID: 69446 RVA: 0x004A50CC File Offset: 0x004A32CC
	[NullableContext(1)]
	private void AutoSelectGridByDataList(int stickerPart, List<MotorcycleDiyEditStickerDecoItemData> stickerDataList)
	{
		int gridIndex = 0;
		int selectStickerId = 0;
		int selectedStickerId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerId(stickerPart);
		if (selectedStickerId != 0)
		{
			selectStickerId = selectedStickerId;
		}
		MotorcycleDiyEditStickerDecoItemData motorcycleDiyEditStickerDecoItemData = stickerDataList.Find((MotorcycleDiyEditStickerDecoItemData data) => data.ItemId == selectStickerId);
		if (motorcycleDiyEditStickerDecoItemData != null)
		{
			gridIndex = stickerDataList.IndexOf(motorcycleDiyEditStickerDecoItemData);
		}
		if (!this.StickerScrollView.IsGridDisplaying(gridIndex))
		{
			this.StickerScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.StickerScrollView.DeselectCurrentGridProxy(false);
		this.StickerScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010F47 RID: 69447 RVA: 0x004A5150 File Offset: 0x004A3350
	private void OnStickerInfoUpdate()
	{
		this.RefreshScrollViewByData(this.CurrentSelectStickerPart, false);
	}

	// Token: 0x06010F48 RID: 69448 RVA: 0x004A5160 File Offset: 0x004A3360
	[NullableContext(1)]
	private void OnClickSticker(int stickerId, UUIExtendToggle toggle, UUIItem newItem)
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		if (instance.GetStickerState(stickerId) == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = instance.GetBanTips(EOutlookType.Sticker, stickerId);
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
		if (stickerId == 0)
		{
			Singleton<MotorcycleUiModelUtil>.Instance.SetEmptySticker(this.CurrentSelectStickerPart);
		}
		else
		{
			Singleton<MotorcycleUiModelUtil>.Instance.AddMaterialByStickerId(stickerId);
		}
		instance.SetSelectStickerInfo(this.CurrentSelectStickerPart, stickerId);
		this.RefreshStickerPreviewRedDots();
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Sticker, this.CurrentSelectStickerPart, stickerId);
		}
		this.RefreshScrollViewByData(this.CurrentSelectStickerPart, false);
		UUIItem item = base.GetItem(7);
		UUIItem item2 = base.GetItem(10);
		UUIItem item3 = base.GetItem(12);
		ULGUIBehaviour button = base.GetButton(9);
		UUIText text = base.GetText(6);
		UUIText text2 = base.GetText(8);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		if (stickerId <= 0)
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("MotorEmptyStickerName");
			string stringConfig2 = ConfigCommonParamById.GetStringConfig("MotorEmptyStickerType");
			text2.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, stringConfig2, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, stringConfig, Array.Empty<object>());
			return;
		}
		MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(stickerId);
		if (motorStickerConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, motorStickerConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, motorStickerConfig.Value.Title, Array.Empty<object>());
	}

	// Token: 0x06010F49 RID: 69449 RVA: 0x004A5358 File Offset: 0x004A3558
	private void OnBtnOverviewClick()
	{
		MotorcycleDiyEditOverviewOpenParam motorcycleDiyEditOverviewOpenParam = new MotorcycleDiyEditOverviewOpenParam();
		motorcycleDiyEditOverviewOpenParam.PartId = this.CurrentSelectStickerPart;
		Func<MotorcycleDiyPresetData> getLocalPresetData = this.GetLocalPresetData;
		motorcycleDiyEditOverviewOpenParam.LocalPresetData = ((getLocalPresetData != null) ? getLocalPresetData() : null);
		motorcycleDiyEditOverviewOpenParam.OnEditPresetChanged = new Action<EOutlookType, bool>(this.OnOverviewEditPresetChanged);
		MotorcycleDiyEditOverviewOpenParam param = motorcycleDiyEditOverviewOpenParam;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyEditOverviewView, param, null);
	}

	// Token: 0x06010F4A RID: 69450 RVA: 0x004A53B2 File Offset: 0x004A35B2
	private void OnOverviewEditPresetChanged(EOutlookType outlookType, bool isModified)
	{
		this.RefreshStickerPreviewRedDots();
		Action<EOutlookType, bool> onEditPresetChanged = this.OnEditPresetChanged;
		if (onEditPresetChanged == null)
		{
			return;
		}
		onEditPresetChanged(outlookType, isModified);
	}

	// Token: 0x0400857B RID: 34171
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyEditPartTabItem> PartTabComponent;

	// Token: 0x0400857C RID: 34172
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyEditStickerDecoItem, MotorcycleDiyEditStickerDecoItemData> StickerScrollView;

	// Token: 0x0400857D RID: 34173
	[Nullable(1)]
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x0400857E RID: 34174
	[Nullable(1)]
	private List<MotorcycleDiyEditStickerDecoItemData> CachedStickerDataList = new List<MotorcycleDiyEditStickerDecoItemData>();

	// Token: 0x0400857F RID: 34175
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04008580 RID: 34176
	private int CurrentSelectStickerPart;

	// Token: 0x04008581 RID: 34177
	private MotorcycleDiyEditPresetPanel EditPresetPanel;

	// Token: 0x020085D2 RID: 34258
	[NullableContext(0)]
	private class EMotorStickerTabViewComponent
	{
		// Token: 0x0402D445 RID: 185413
		public const int TabContent = 0;

		// Token: 0x0402D446 RID: 185414
		public const int TabItem = 1;

		// Token: 0x0402D447 RID: 185415
		public const int LoopScrollView = 2;

		// Token: 0x0402D448 RID: 185416
		public const int SVContent = 3;

		// Token: 0x0402D449 RID: 185417
		public const int TogMotoDiyStickerOrDecoTabItem = 4;

		// Token: 0x0402D44A RID: 185418
		public const int RightLayout = 5;

		// Token: 0x0402D44B RID: 185419
		public const int TxtStickerName = 6;

		// Token: 0x0402D44C RID: 185420
		public const int LockItem = 7;

		// Token: 0x0402D44D RID: 185421
		public const int TxtCurEquip = 8;

		// Token: 0x0402D44E RID: 185422
		public const int BtnJump = 9;

		// Token: 0x0402D44F RID: 185423
		public const int TipsItem = 10;

		// Token: 0x0402D450 RID: 185424
		public const int TxtTipsName = 11;

		// Token: 0x0402D451 RID: 185425
		public const int TitleGetItem = 12;

		// Token: 0x0402D452 RID: 185426
		public const int TxtJump = 13;

		// Token: 0x0402D453 RID: 185427
		public const int BtnOverview = 14;

		// Token: 0x0402D454 RID: 185428
		public const int MenuItem = 15;

		// Token: 0x0402D455 RID: 185429
		public const int SmallTitleItem = 16;

		// Token: 0x0402D456 RID: 185430
		public const int NormalPanel = 17;

		// Token: 0x0402D457 RID: 185431
		public const int EditPresetPanel = 18;
	}
}
