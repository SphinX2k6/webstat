using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Motorcycle.Model;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020022FB RID: 8955
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyStickerTabView : UiTabViewBase, IMotorcycleDiyTabViewRegister
{
	// Token: 0x1700150E RID: 5390
	// (get) Token: 0x06010F76 RID: 69494 RVA: 0x004A673F File Offset: 0x004A493F
	// (set) Token: 0x06010F77 RID: 69495 RVA: 0x004A6747 File Offset: 0x004A4947
	[Nullable(2)]
	public Action<int> OnTabCameraClick { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700150F RID: 5391
	// (get) Token: 0x06010F78 RID: 69496 RVA: 0x004A6750 File Offset: 0x004A4950
	// (set) Token: 0x06010F79 RID: 69497 RVA: 0x004A6758 File Offset: 0x004A4958
	[Nullable(2)]
	public Action<EOutlookType, int, int> OnSelectItemClick { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x06010F7A RID: 69498 RVA: 0x004A6764 File Offset: 0x004A4964
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(9, new Action(this.OnBtnJumpClick)),
			new ValueTuple<int, Delegate>(14, new Action(this.OnBtnOverviewClick))
		};
	}

	// Token: 0x06010F7B RID: 69499 RVA: 0x004A6924 File Offset: 0x004A4B24
	protected override UniTask OnBeforeStartAsync()
	{
		MotorcycleDiyStickerTabView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<MotorcycleDiyStickerTabView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06010F7C RID: 69500 RVA: 0x004A6968 File Offset: 0x004A4B68
	protected override void OnBeforeShow()
	{
		int index = (this.CurrentSelectStickerPart > 0) ? (this.CurrentSelectStickerPart - 1) : 0;
		this.PartTabComponent.SelectToggleByIndex(index, true, true);
	}

	// Token: 0x06010F7D RID: 69501 RVA: 0x004A6998 File Offset: 0x004A4B98
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MotorDiyInfoUpdate, new Action(this.OnStickerInfoUpdate));
	}

	// Token: 0x06010F7E RID: 69502 RVA: 0x004A69B6 File Offset: 0x004A4BB6
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MotorDiyInfoUpdate, new Action(this.OnStickerInfoUpdate));
	}

	// Token: 0x06010F7F RID: 69503 RVA: 0x004A69D4 File Offset: 0x004A4BD4
	private MotorcycleDiyPartTabItem InitStickerTabItem([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new MotorcycleDiyPartTabItem();
	}

	// Token: 0x06010F80 RID: 69504 RVA: 0x004A69DC File Offset: 0x004A4BDC
	private void ToggleCallBack(int index)
	{
		MotorcycleDiyPartTabItemData motorcycleDiyPartTabItemData = this.PartTabItemDataList[index];
		ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Sticker, new int?(motorcycleDiyPartTabItemData.PartId));
		this.CurrentSelectStickerPart = motorcycleDiyPartTabItemData.PartId;
		this.RefreshScrollViewByData(motorcycleDiyPartTabItemData.PartId, true);
		Action<int> onTabCameraClick = this.OnTabCameraClick;
		if (onTabCameraClick == null)
		{
			return;
		}
		onTabCameraClick(this.CurrentSelectStickerPart);
	}

	// Token: 0x06010F81 RID: 69505 RVA: 0x004A6A3B File Offset: 0x004A4C3B
	private MotorcycleDiyStickerDecoItem CreateStickerItem()
	{
		return new MotorcycleDiyStickerDecoItem
		{
			OnClickToggleBack = new Action<int, UUIExtendToggle, UUIItem>(this.OnClickSticker)
		};
	}

	// Token: 0x06010F82 RID: 69506 RVA: 0x004A6A54 File Offset: 0x004A4C54
	public void RefreshItemScrollView()
	{
		if (this.StickerScrollView != null)
		{
			this.RefreshScrollViewByData(this.CurrentSelectStickerPart, true);
		}
	}

	// Token: 0x06010F83 RID: 69507 RVA: 0x004A6A6C File Offset: 0x004A4C6C
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

	// Token: 0x06010F84 RID: 69508 RVA: 0x004A6C38 File Offset: 0x004A4E38
	private int GetStickerSortPriority(MotorcycleDiyStickerDecoItemData data)
	{
		if (data.ItemId == 0)
		{
			return 0;
		}
		EOutLookState stickerState = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(data.ItemId);
		if (stickerState == EOutLookState.IsEquipped)
		{
			return 1;
		}
		if (ModelBase<MotorcycleDiyModel>.Instance.CheckRedDotInViewOpenCache(data.ItemId))
		{
			return 2;
		}
		if (stickerState == EOutLookState.CanEquipped)
		{
			return 3;
		}
		if (stickerState == EOutLookState.IsLock)
		{
			return 4;
		}
		if (stickerState == EOutLookState.IsBan)
		{
			return 5;
		}
		return 6;
	}

	// Token: 0x06010F85 RID: 69509 RVA: 0x004A6C90 File Offset: 0x004A4E90
	private int SortStickerItemFunc(MotorcycleDiyStickerDecoItemData dataA, MotorcycleDiyStickerDecoItemData dataB)
	{
		int stickerSortPriority = this.GetStickerSortPriority(dataA);
		int stickerSortPriority2 = this.GetStickerSortPriority(dataB);
		if (stickerSortPriority != stickerSortPriority2)
		{
			return stickerSortPriority - stickerSortPriority2;
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

	// Token: 0x06010F86 RID: 69510 RVA: 0x004A6CDC File Offset: 0x004A4EDC
	private void RefreshScrollViewByData(int partId, bool isNeedRefresh)
	{
		if (isNeedRefresh)
		{
			List<MotorcycleDiyStickerDecoItemData> stickerDataList = this.GetStickerItemDataList(partId);
			stickerDataList.Sort(new Comparison<MotorcycleDiyStickerDecoItemData>(this.SortStickerItemFunc));
			this.CachedStickerDataList = stickerDataList;
			this.StickerScrollView.RefreshByData(stickerDataList, true, delegate
			{
				this.AutoSelectGridByDataList(partId, stickerDataList);
			}, false);
			return;
		}
		this.StickerScrollView.RefreshByData(this.CachedStickerDataList, true, null, false);
	}

	// Token: 0x06010F87 RID: 69511 RVA: 0x004A6D6C File Offset: 0x004A4F6C
	private void AutoSelectGridByDataList(int stickerPart, List<MotorcycleDiyStickerDecoItemData> stickerDataList)
	{
		int gridIndex = 0;
		int selectStickerId = 0;
		int selectedStickerId = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerId(stickerPart);
		if (selectedStickerId != 0)
		{
			selectStickerId = selectedStickerId;
		}
		else
		{
			int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerId(stickerPart));
			selectStickerId = ((num != null) ? num.Value : 0);
		}
		MotorcycleDiyStickerDecoItemData motorcycleDiyStickerDecoItemData = stickerDataList.FirstOrDefault((MotorcycleDiyStickerDecoItemData data) => data.ItemId == selectStickerId);
		if (motorcycleDiyStickerDecoItemData != null)
		{
			gridIndex = stickerDataList.IndexOf(motorcycleDiyStickerDecoItemData);
		}
		if (!this.StickerScrollView.IsGridDisplaying(gridIndex))
		{
			this.StickerScrollView.ScrollToGridIndex(gridIndex, false);
		}
		this.StickerScrollView.DeselectCurrentGridProxy(false);
		this.StickerScrollView.SelectGridProxy(gridIndex, false);
	}

	// Token: 0x06010F88 RID: 69512 RVA: 0x004A6E1D File Offset: 0x004A501D
	private void OnStickerInfoUpdate()
	{
		ModelBase<MotorcycleDiyModel>.Instance.CollectRedDotOnViewOpen(EOutlookType.Sticker, new int?(this.CurrentSelectStickerPart));
		this.RefreshScrollViewByData(this.CurrentSelectStickerPart, false);
	}

	// Token: 0x06010F89 RID: 69513 RVA: 0x004A6E44 File Offset: 0x004A5044
	private void OnClickSticker(int stickerId, UUIExtendToggle toggle, UUIItem newItem)
	{
		EOutLookState stickerState = ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(stickerId);
		if (stickerState == EOutLookState.IsBan)
		{
			toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			ValueTuple<string, string>? banTips = ModelBase<MotorcycleDiyModel>.Instance.GetBanTips(EOutlookType.Sticker, stickerId);
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
		this.UiViewSequence.StopSequenceByKey("Switch", false, false);
		this.UiViewSequence.PlaySequencePurely("Switch", false, false);
		if (stickerId == 0)
		{
			Singleton<MotorcycleUiModelUtil>.Instance.SetEmptySticker(this.CurrentSelectStickerPart);
		}
		else
		{
			Singleton<MotorcycleUiModelUtil>.Instance.AddMaterialByStickerId(stickerId);
		}
		bool flag = ModelBase<MotorcycleDiyModel>.Instance.IsEquipDefaultSticker(this.CurrentSelectStickerPart);
		bool flag2 = stickerId == 0 && !flag;
		ModelBase<MotorcycleDiyModel>.Instance.SetSelectStickerInfo(this.CurrentSelectStickerPart, stickerId);
		if (stickerState == EOutLookState.CanEquipped || flag2)
		{
			List<int> selectedStickerIdList = ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerIdList(true);
			ControllerBase<MotorcycleDiyController>.Instance.EquipMotorStickerRequest(selectedStickerIdList, null);
		}
		Action<EOutlookType, int, int> onSelectItemClick = this.OnSelectItemClick;
		if (onSelectItemClick != null)
		{
			onSelectItemClick(EOutlookType.Sticker, this.CurrentSelectStickerPart, stickerId);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.MotorDiyInfoRedDotUpdate);
		this.RefreshScrollViewByData(this.CurrentSelectStickerPart, false);
		UUIItem item = base.GetItem(7);
		UUIItem item2 = base.GetItem(10);
		UUIItem item3 = base.GetItem(12);
		UUIText text = base.GetText(11);
		UUIButtonComponent button = base.GetButton(9);
		UUIText text2 = base.GetText(13);
		UUIText text3 = base.GetText(6);
		UUIText text4 = base.GetText(8);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		item3.SetUIActive(false);
		button.RootUIComp.Get().SetUIActive(false);
		if (stickerId <= 0)
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("MotorEmptyStickerName");
			string stringConfig2 = ConfigCommonParamById.GetStringConfig("MotorEmptyStickerType");
			text4.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, stringConfig2, Array.Empty<object>());
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, stringConfig, Array.Empty<object>());
			return;
		}
		MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(stickerId);
		if (motorStickerConfig == null)
		{
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text4, motorStickerConfig.Value.SubTitle, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text3, motorStickerConfig.Value.Title, Array.Empty<object>());
		base.GetItem(7).SetUIActive(stickerState == EOutLookState.IsLock);
		int[] itemAccessArray = motorStickerConfig.Value.GetItemAccessArray();
		if (itemAccessArray == null || itemAccessArray.Length == 0)
		{
			return;
		}
		int num = itemAccessArray[0];
		if (num == 0)
		{
			return;
		}
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(num);
		if (accessPathConfig == null)
		{
			return;
		}
		this.JumpId = num;
		ESkipName skipName = (ESkipName)accessPathConfig.Value.SkipName;
		button.RootUIComp.Get().SetUIActive(skipName != ESkipName.NoSkip && stickerState == EOutLookState.IsLock);
		item3.SetUIActive(stickerState == EOutLookState.IsLock);
		item2.SetUIActive(skipName == ESkipName.NoSkip && stickerState == EOutLookState.IsLock);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, accessPathConfig.Value.Description, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text2, accessPathConfig.Value.Description, Array.Empty<object>());
	}

	// Token: 0x06010F8A RID: 69514 RVA: 0x004A71B6 File Offset: 0x004A53B6
	private void OnBtnJumpClick()
	{
		if (this.JumpId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.JumpId, null);
	}

	// Token: 0x06010F8B RID: 69515 RVA: 0x004A71D0 File Offset: 0x004A53D0
	private void OnBtnOverviewClick()
	{
		List<object> list = new List<object>();
		list.Add(EOutlookType.Sticker);
		list.Add(this.CurrentSelectStickerPart);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyOverviewView, list, null);
	}

	// Token: 0x04008593 RID: 34195
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<MotorcycleDiyPartTabItem> PartTabComponent;

	// Token: 0x04008594 RID: 34196
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<MotorcycleDiyStickerDecoItem, MotorcycleDiyStickerDecoItemData> StickerScrollView;

	// Token: 0x04008595 RID: 34197
	private readonly List<MotorcycleDiyPartTabItemData> PartTabItemDataList = new List<MotorcycleDiyPartTabItemData>();

	// Token: 0x04008596 RID: 34198
	private List<MotorcycleDiyStickerDecoItemData> CachedStickerDataList = new List<MotorcycleDiyStickerDecoItemData>();

	// Token: 0x04008597 RID: 34199
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x04008598 RID: 34200
	private int CurrentSelectStickerPart;

	// Token: 0x04008599 RID: 34201
	private int JumpId;

	// Token: 0x020085DD RID: 34269
	[NullableContext(0)]
	private class EMotorStickerScrollViewComponent
	{
		// Token: 0x0402D48A RID: 185482
		public const int TabContent = 0;

		// Token: 0x0402D48B RID: 185483
		public const int TabItem = 1;

		// Token: 0x0402D48C RID: 185484
		public const int LoopScrollView = 2;

		// Token: 0x0402D48D RID: 185485
		public const int SVContent = 3;

		// Token: 0x0402D48E RID: 185486
		public const int TogMotoDiyStickerOrDecoTabItem = 4;

		// Token: 0x0402D48F RID: 185487
		public const int RightLayout = 5;

		// Token: 0x0402D490 RID: 185488
		public const int TxtStickerName = 6;

		// Token: 0x0402D491 RID: 185489
		public const int LockItem = 7;

		// Token: 0x0402D492 RID: 185490
		public const int TxtCurEquip = 8;

		// Token: 0x0402D493 RID: 185491
		public const int BtnJump = 9;

		// Token: 0x0402D494 RID: 185492
		public const int TipsItem = 10;

		// Token: 0x0402D495 RID: 185493
		public const int TxtTipsName = 11;

		// Token: 0x0402D496 RID: 185494
		public const int TitleGetItem = 12;

		// Token: 0x0402D497 RID: 185495
		public const int TxtJump = 13;

		// Token: 0x0402D498 RID: 185496
		public const int BtnOverview = 14;

		// Token: 0x0402D499 RID: 185497
		public const int MenuItem = 15;

		// Token: 0x0402D49A RID: 185498
		public const int SmallTitleItem = 16;

		// Token: 0x0402D49B RID: 185499
		public const int NormalPanel = 17;

		// Token: 0x0402D49C RID: 185500
		public const int EditPresetPanel = 18;
	}
}
