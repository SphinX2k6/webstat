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

// Token: 0x020022F6 RID: 8950
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyEditDecorationTabView : UiTabViewBase, IMotorcycleDiyEditTabViewRegister, IMotorcycleDiyTabViewRegister
{
	// Token: 0x170014FE RID: 5374
	// (get) Token: 0x06010F01 RID: 69377 RVA: 0x004A3812 File Offset: 0x004A1A12
	// (set) Token: 0x06010F02 RID: 69378 RVA: 0x004A381A File Offset: 0x004A1A1A
	public Action<int> OnTabCameraClick { get; set; }

	// Token: 0x170014FF RID: 5375
	// (get) Token: 0x06010F03 RID: 69379 RVA: 0x004A3823 File Offset: 0x004A1A23
	// (set) Token: 0x06010F04 RID: 69380 RVA: 0x004A382B File Offset: 0x004A1A2B
	public Action<EOutlookType, int, int> OnSelectItemClick { get; set; }

	// Token: 0x17001500 RID: 5376
	// (get) Token: 0x06010F05 RID: 69381 RVA: 0x004A3834 File Offset: 0x004A1A34
	// (set) Token: 0x06010F06 RID: 69382 RVA: 0x004A383C File Offset: 0x004A1A3C
	public Func<MotorcycleDiyPresetData> GetLocalPresetData { get; set; }

	// Token: 0x17001501 RID: 5377
	// (get) Token: 0x06010F07 RID: 69383 RVA: 0x004A3845 File Offset: 0x004A1A45
	// (set) Token: 0x06010F08 RID: 69384 RVA: 0x004A384D File Offset: 0x004A1A4D
	public Action<EOutlookType, bool> OnEditPresetChanged { get; set; }

	// Token: 0x06010F09 RID: 69385 RVA: 0x004A3858 File Offset: 0x004A1A58
	protected unsafe override void OnRegisterComponent()
	{
		int num = 18;
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
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06010F0A RID: 69386 RVA: 0x004A3ADC File Offset: 0x004A1CDC
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyEditDecorationTabView.<OnBeforeStartAsync>d__25 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyEditDecorationTabView.<OnBeforeStartAsync>d__25>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010F0B RID: 69387 RVA: 0x004A3B20 File Offset: 0x004A1D20
	protected override void OnBeforeShow()
	{
		this.CurrentSelectDecorationPart = (this.ExtraParams as int?).GetValueOrDefault();
		int index = (this.CurrentSelectDecorationPart > 0) ? (this.CurrentSelectDecorationPart - 1) : 0;
		this.PartTabComponent.SelectToggleByIndex(index, true, true);
	}

	// Token: 0x06010F0C RID: 69388 RVA: 0x004A3B6E File Offset: 0x004A1D6E
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnDecorationInfoUpdate));
	}

	// Token: 0x06010F0D RID: 69389 RVA: 0x004A3B8C File Offset: 0x004A1D8C
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnDecorationInfoUpdate));
	}

	// Token: 0x06010F0E RID: 69390 RVA: 0x004A3BAA File Offset: 0x004A1DAA
	[NullableContext(1)]
	private MotorcycleDiyEditPartTabItem InitDecorationTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyEditPartTabItem();
	}

	// Token: 0x06010F0F RID: 69391 RVA: 0x004A3BB4 File Offset: 0x004A1DB4
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		this.CurrentSelectDecorationPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
		Action<int> onTabCameraClick = this.OnTabCameraClick;
		if (onTabCameraClick == null)
		{
			return;
		}
		onTabCameraClick(this.CurrentSelectDecorationPart);
	}

	// Token: 0x06010F10 RID: 69392 RVA: 0x004A3BFD File Offset: 0x004A1DFD
	[NullableContext(1)]
	private MotorcycleDiyEditStickerDecoItem CreateDecorationItem()
	{
		return new MotorcycleDiyEditStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickDecoration)
		};
	}

	// Token: 0x06010F11 RID: 69393 RVA: 0x004A3C16 File Offset: 0x004A1E16
	public void RefreshItemScrollView()
	{
		if (this.DecorationScrollView != null)
		{
			this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, true);
		}
	}

	// Token: 0x06010F12 RID: 69394 RVA: 0x004A3C30 File Offset: 0x004A1E30
	private void RefreshDecorationPreviewRedDots()
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
				int num = Array.IndexOf<int>(MotorcycleDiyDefine.MOTORCYCLE_DIY_DECORATION_PART, partId);
				int num2 = (num >= 0 && num < motorcycleDiyPresetData.DecorateIds.Length) ? motorcycleDiyPresetData.DecorateIds[num] : 0;
				bool flag = instance.GetSelectedDecorationId(partId) != num2;
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
		onEditPresetChanged(EOutlookType.Decoration, arg);
	}

	// Token: 0x06010F13 RID: 69395 RVA: 0x004A3D38 File Offset: 0x004A1F38
	[NullableContext(1)]
	private List<MotorcycleDiyEditStickerDecoItemData> GetDecorationItemDataList(int partId)
	{
		List<MotorcycleDiyEditStickerDecoItemData> list = new List<MotorcycleDiyEditStickerDecoItemData>();
		MotorcycleDiyEditStickerDecoItemData item = new MotorcycleDiyEditStickerDecoItemData
		{
			Part = partId,
			ItemId = 0,
			IsSticker = false
		};
		list.Add(item);
		foreach (int num in ModelBase<MotorcycleDiyModel>.Instance.GetCanUseDecorationsIdsInRegion())
		{
			MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num);
			if (motorDecorationConfig != null && motorDecorationConfig.Value.PartId == partId)
			{
				int decorationState = (int)ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(num);
				bool flag = ModelBase<MotorcycleDiyModel>.Instance.HasDecoration(num);
				if (decorationState != 0 && flag)
				{
					list.Add(new MotorcycleDiyEditStickerDecoItemData
					{
						Part = partId,
						ItemId = num,
						QualityId = motorDecorationConfig.Value.QualityId,
						SortIndex = motorDecorationConfig.Value.SortIndex,
						IsSticker = false
					});
				}
			}
		}
		return list;
	}

	// Token: 0x06010F14 RID: 69396 RVA: 0x004A3E4C File Offset: 0x004A204C
	[NullableContext(1)]
	private int SortDecorationItemFunc(MotorcycleDiyEditStickerDecoItemData dataA, MotorcycleDiyEditStickerDecoItemData dataB)
	{
		EOutLookState decorationState = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(dataA.ItemId);
		EOutLookState decorationState2 = ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(dataB.ItemId);
		if (decorationState != decorationState2)
		{
			return decorationState - decorationState2;
		}
		if (dataA.QualityId != dataB.QualityId)
		{
			return dataB.QualityId - dataA.QualityId;
		}
		return dataB.SortIndex - dataA.SortIndex;
	}

	// Token: 0x06010F15 RID: 69397 RVA: 0x004A3EAC File Offset: 0x004A20AC
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			List<MotorcycleDiyEditStickerDecoItemData> decorationDataList = this.GetDecorationItemDataList(partId);
			decorationDataList.Sort(new Comparison<MotorcycleDiyEditStickerDecoItemData>(this.SortDecorationItemFunc));
			this.CachedDecorationDataList = decorationDataList;
			this.DecorationScrollView.RefreshByData(decorationDataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, decorationDataList);
			}, false);
			return;
		}
		this.DecorationScrollView.RefreshByData(this.CachedDecorationDataList, true, null, false);
	}

	// Token: 0x06010F16 RID: 69398 RVA: 0x004A3F3C File Offset: 0x004A213C
	[NullableContext(1)]
	private void AutoSelectGridByDataList(int decorationPart, List<MotorcycleDiyEditStickerDecoItemData> decorationDataList)
	{
		int gridIndex = 0;
		int selectDecorationId = 0;
		int selectedDecorationId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationId(decorationPart);
		if (selectedDecorationId != 0)
		{
			selectDecorationId = selectedDecorationId;
		}
		MotorcycleDiyEditStickerDecoItemData motorcycleDiyEditStickerDecoItemData = decorationDataList.Find((MotorcycleDiyEditStickerDecoItemData data) => data.ItemId == selectDecorationId);
		if (motorcycleDiyEditStickerDecoItemData != null)
		{
			gridIndex = decorationDataList.IndexOf(motorcycleDiyEditStickerDecoItemData);
		}
		if (!this.DecorationScrollView.IsGridDisplaying(gridIndex))
		{
			this.DecorationScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.DecorationScrollView.DeselectCurrentGridProxy(false);
		this.DecorationScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010F17 RID: 69399 RVA: 0x004A3FC0 File Offset: 0x004A21C0
	private void OnDecorationInfoUpdate()
	{
		this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, false);
	}

	// Token: 0x06010F18 RID: 69400 RVA: 0x004A3FD0 File Offset: 0x004A21D0
	[NullableContext(1)]
	private void OnClickDecoration(int decorationId, UUIExtendToggle toggle, UUIItem newItem)
	{
		MotorcycleDiyModel instance = ModelBase<MotorcycleDiyModel>.Instance;
		if (instance.GetDecorationState(decorationId) == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = instance.GetBanTips(EOutlookType.Decoration, decorationId);
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
		if (decorationId == 0)
		{
			Singleton<MotorcycleUiModelUtil>.Instance.SetEmptyDecoration(this.CurrentSelectDecorationPart);
		}
		else
		{
			Singleton<MotorcycleUiModelUtil>.Instance.AddDecoration(decorationId, null);
		}
		instance.SetSelectDecorationInfo(this.CurrentSelectDecorationPart, decorationId);
		this.RefreshDecorationPreviewRedDots();
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Decoration, this.CurrentSelectDecorationPart, decorationId);
		}
		this.RefreshScrollViewByData(this.CurrentSelectDecorationPart, false);
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
		if (decorationId <= 0)
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("MotorEmptyDecorationName");
			text2.SetUIActive(false);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, stringConfig, Array.Empty<object>());
			return;
		}
		text2.SetUIActive(true);
		MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(decorationId);
		if (motorDecorationConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, motorDecorationConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, motorDecorationConfig.Value.Title, Array.Empty<object>());
	}

	// Token: 0x04008568 RID: 34152
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyEditPartTabItem> PartTabComponent;

	// Token: 0x04008569 RID: 34153
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyEditStickerDecoItem, MotorcycleDiyEditStickerDecoItemData> DecorationScrollView;

	// Token: 0x0400856A RID: 34154
	[Nullable(1)]
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x0400856B RID: 34155
	[Nullable(1)]
	private List<MotorcycleDiyEditStickerDecoItemData> CachedDecorationDataList = new List<MotorcycleDiyEditStickerDecoItemData>();

	// Token: 0x0400856C RID: 34156
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x0400856D RID: 34157
	private int CurrentSelectDecorationPart;

	// Token: 0x0400856E RID: 34158
	private MotorcycleDiyEditPresetPanel EditPresetPanel;

	// Token: 0x020085CA RID: 34250
	[NullableContext(0)]
	private class EMotorDecorationTabViewComponent
	{
		// Token: 0x0402D415 RID: 185365
		public const int TabContent = 0;

		// Token: 0x0402D416 RID: 185366
		public const int TabItem = 1;

		// Token: 0x0402D417 RID: 185367
		public const int LoopScrollView = 2;

		// Token: 0x0402D418 RID: 185368
		public const int SVContent = 3;

		// Token: 0x0402D419 RID: 185369
		public const int TogMotoDiyStickerOrDecoTabItem = 4;

		// Token: 0x0402D41A RID: 185370
		public const int RightLayout = 5;

		// Token: 0x0402D41B RID: 185371
		public const int TxtDecorationName = 6;

		// Token: 0x0402D41C RID: 185372
		public const int LockItem = 7;

		// Token: 0x0402D41D RID: 185373
		public const int TxtCurEquip = 8;

		// Token: 0x0402D41E RID: 185374
		public const int BtnJump = 9;

		// Token: 0x0402D41F RID: 185375
		public const int TipsItem = 10;

		// Token: 0x0402D420 RID: 185376
		public const int TxtTipsName = 11;

		// Token: 0x0402D421 RID: 185377
		public const int TitleGetItem = 12;

		// Token: 0x0402D422 RID: 185378
		public const int TxtJump = 13;

		// Token: 0x0402D423 RID: 185379
		public const int BtnOverview = 14;

		// Token: 0x0402D424 RID: 185380
		public const int MenuItem = 15;

		// Token: 0x0402D425 RID: 185381
		public const int SmallTitleItem = 16;

		// Token: 0x0402D426 RID: 185382
		public const int NormalPanel = 17;

		// Token: 0x0402D427 RID: 185383
		public const int EditPresetPanel = 18;
	}
}
