using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200180E RID: 6158
[NullableContext(1)]
[Nullable(0)]
public class VisionRecoveryTabView : UiTabViewBase
{
	// Token: 0x0600AF19 RID: 44825 RVA: 0x002EA174 File Offset: 0x002E8374
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIItem)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIText)),
			new ValueTuple<int, Type>(16, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(3, new Action(this.OnClickRecoveryBtn)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickBatchRecoveryBtn))
		};
	}

	// Token: 0x0600AF1A RID: 44826 RVA: 0x002EA348 File Offset: 0x002E8548
	protected override UniTask OnBeforeStartAsync()
	{
		VisionRecoveryTabView.<OnBeforeStartAsync>d__18 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<VisionRecoveryTabView.<OnBeforeStartAsync>d__18>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600AF1B RID: 44827 RVA: 0x002EA38C File Offset: 0x002E858C
	protected override void OnStart()
	{
		ModelBase<CalabashModel>.Instance.DirectionalFusionTargetFetterGroup = 0;
		this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		UiTabSequence tabBehavior = base.GetTabBehavior<UiTabSequence>();
		LevelSequencePlayer levelSequencePlayer = (tabBehavior != null) ? tabBehavior.GetLevelSequencePlayer() : null;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.BindSequenceStartEvent(new TSequenceStartEvent(this.OnTabSequenceStart));
			levelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnTabSequenceFinish), false);
		}
		bool isOpenAim = ModelBase<FunctionModel>.Instance.IsOpen(10100);
		GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> tabLayout = this.TabLayout;
		if (tabLayout != null)
		{
			tabLayout.RefreshByData(new List<EVisionRecoveryTabViewType>
			{
				EVisionRecoveryTabViewType.DirectionalFusion,
				EVisionRecoveryTabViewType.NormalFusion
			}, delegate
			{
				if (!isOpenAim)
				{
					GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> tabLayout3 = this.TabLayout;
					if (tabLayout3 == null)
					{
						return;
					}
					VisionRecoveryTabItem layoutItemByIndex = tabLayout3.GetLayoutItemByIndex(1);
					if (layoutItemByIndex == null)
					{
						return;
					}
					layoutItemByIndex.SelectToggle();
					return;
				}
				else if (ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime > 0)
				{
					GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> tabLayout4 = this.TabLayout;
					if (tabLayout4 == null)
					{
						return;
					}
					VisionRecoveryTabItem layoutItemByIndex2 = tabLayout4.GetLayoutItemByIndex(0);
					if (layoutItemByIndex2 == null)
					{
						return;
					}
					layoutItemByIndex2.SelectToggle();
					return;
				}
				else
				{
					GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> tabLayout5 = this.TabLayout;
					if (tabLayout5 == null)
					{
						return;
					}
					VisionRecoveryTabItem layoutItemByIndex3 = tabLayout5.GetLayoutItemByIndex(1);
					if (layoutItemByIndex3 == null)
					{
						return;
					}
					layoutItemByIndex3.SelectToggle();
					return;
				}
			}, false);
		}
		GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> tabLayout2 = this.TabLayout;
		if (tabLayout2 != null)
		{
			UUIItem rootUiItem = tabLayout2.GetRootUiItem();
			if (rootUiItem != null)
			{
				rootUiItem.SetUIActive(isOpenAim);
			}
		}
		ModelBase<PhantomBattleModel>.Instance.RecordVisionRecoveryRedDot(false);
		ModelBase<PhantomBattleModel>.Instance.RecordVisionRecoveryAimRedDot(false);
	}

	// Token: 0x0600AF1C RID: 44828 RVA: 0x002EA478 File Offset: 0x002E8678
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse>>(EEventName.OnVisionRecoveryResult, new Action<OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse>>(this.OnVisionRecoveryResult));
		Singleton<EventSystem>.Instance.Add<OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>>(EEventName.OnVisionRecoveryBatchResult, new Action<OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>>(this.OnVisionRecoveryBatchResult));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Add(EEventName.SelectDirectionalFusionTarget, new Action(this.SelectDirectionalFusionTarget));
		Singleton<EventSystem>.Instance.Add(EEventName.PhantomDirectRefiningWeeklyReset, new Action(this.PhantomDirectRefiningWeeklyReset));
	}

	// Token: 0x0600AF1D RID: 44829 RVA: 0x002EA511 File Offset: 0x002E8711
	protected override void OnBeforeShow()
	{
		if (this.IsShowRecoveryChoosePanel)
		{
			this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
		}
	}

	// Token: 0x0600AF1E RID: 44830 RVA: 0x002EA52D File Offset: 0x002E872D
	private void InitRecoveryChoosePanel(EVisionRecoveryMode recoveryMode)
	{
		this.HasInitRecoveryChoosePanel = true;
		this.AllVisionItemInfoList = ModelBase<InventoryModel>.Instance.GetUnEquipPhantomItemDataList();
		this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
	}

	// Token: 0x0600AF1F RID: 44831 RVA: 0x002EA558 File Offset: 0x002E8758
	private void InitPreviewReward()
	{
		int value = ConfigCommonParamById.GetIntConfig("VisionRecoveryPreviewRewardDropId").Value;
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dropPackagePreview = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreview(value);
		if (dropPackagePreview != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropPackagePreview)
			{
				InventoryDefine.GetItemData itemData = new InventoryDefine.GetItemData(keyValuePair.Key, 0);
				TItem item = new TItem(itemData, keyValuePair.Value);
				list.Add(item);
			}
		}
		this.RewardLayout.RefreshByData(list, null, false);
		this.BatchRewardLayout.RefreshByData(list, null, false);
	}

	// Token: 0x0600AF20 RID: 44832 RVA: 0x002EA60C File Offset: 0x002E880C
	private void RefreshRecoveryChoosePanel(List<PhantomItemData> itemDataList, List<ISelectedData> selectedDataList)
	{
		CommonItemSelectViewOpenViewData<PhantomItemData> commonItemSelectViewOpenViewData = new CommonItemSelectViewOpenViewData<PhantomItemData>();
		SelectableComponentData selectableComponentData = new SelectableComponentData();
		selectableComponentData.IsSingleSelected = false;
		selectableComponentData.MaxSelectedGridNum = this.BatchMaxNum;
		selectableComponentData.OnlyGold = (this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion);
		selectableComponentData.OnChangeSelectedFunction = new Action<List<ISelectedData>, SelectableExpData>(this.OnChangeSelectedFunction);
		commonItemSelectViewOpenViewData.SelectableComponentType = ESelectableComponentType.VisionRecovery;
		commonItemSelectViewOpenViewData.ItemDataBaseList = itemDataList.ToList<PhantomItemData>();
		commonItemSelectViewOpenViewData.SelectedDataList = selectedDataList;
		commonItemSelectViewOpenViewData.ExpData = null;
		commonItemSelectViewOpenViewData.SelectableComponentData = selectableComponentData;
		commonItemSelectViewOpenViewData.UseWayId = ((this.CurrentShowType == EVisionRecoveryTabViewType.NormalFusion) ? EFilterSortGroupId.VisionRecovery : EFilterSortGroupId.VersionAim);
		commonItemSelectViewOpenViewData.InitSortToggleState = true;
		this.RecoveryChoosePanel.RefreshUi(commonItemSelectViewOpenViewData);
		this.RecoveryChoosePanel.SetAllSelectToggleVisible(true);
	}

	// Token: 0x0600AF21 RID: 44833 RVA: 0x002EA6B4 File Offset: 0x002E88B4
	private void RefreshRecoverySlotPanel(List<ISelectedData> selectedDataList)
	{
		List<PhantomItemData> list = new List<PhantomItemData>();
		foreach (ISelectedData selectedData in selectedDataList)
		{
			PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(selectedData.IncId);
			if (phantomItemData != null)
			{
				list.Add(phantomItemData);
			}
		}
		this.RecoverySlotPanel.RefreshUi(list);
		base.GetItem(14).SetUIActive(this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion);
		int num = ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime;
		UUIText text = base.GetText(2);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, (num > 0) ? "DirectionalFusion_Times" : "DirectionalFusion_Times_Red", new <>z__ReadOnlyArray<object>(new object[]
		{
			num,
			ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax
		}));
	}

	// Token: 0x0600AF22 RID: 44834 RVA: 0x002EA7A4 File Offset: 0x002E89A4
	private void RefreshRecoveryBatchPanel(List<ISelectedData> selectedDataList)
	{
		int count = selectedDataList.Count;
		if (this.CurrentShowType == EVisionRecoveryTabViewType.NormalFusion)
		{
			int num = (int)Math.Floor((double)((float)count / (float)this.SlotMaxNum));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Text_BatchEchoSelect_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				count,
				this.BatchMaxNum
			}));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "Text_BatchEchoSelectNum_Text", new <>z__ReadOnlySingleElementList<object>(num));
		}
		if (this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion)
		{
			int num2 = ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(8), "Text_BatchEchoSelect_Text", new <>z__ReadOnlyArray<object>(new object[]
			{
				count,
				num2 * 5
			}));
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), "DirectionalFusion_Times", new <>z__ReadOnlyArray<object>(new object[]
			{
				num2,
				ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax
			}));
		}
	}

	// Token: 0x0600AF23 RID: 44835 RVA: 0x002EA8C0 File Offset: 0x002E8AC0
	private void ShowRecoveryChoosePanel()
	{
		if (this.IsShowRecoveryChoosePanel)
		{
			return;
		}
		this.IsShowRecoveryChoosePanel = true;
		this.RecoveryChoosePanel.SetActive(true);
		this.UiViewSequence.PlaySequence("SwitchA", false, null);
		this.RecoveryChoosePanel.UiViewSequence.PlaySequence("SwitchA", false, null);
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRefreshCalabashTabShowState, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashEnterInternalView);
	}

	// Token: 0x0600AF24 RID: 44836 RVA: 0x002EA944 File Offset: 0x002E8B44
	private void HideRecoveryChoosePanel()
	{
		if (!this.IsShowRecoveryChoosePanel)
		{
			return;
		}
		this.IsShowRecoveryChoosePanel = false;
		this.UiViewSequence.PlaySequence("SwitchB", false, null);
		this.RecoveryChoosePanel.UiViewSequence.PlaySequence("SwitchB", false, null);
		this.RecoveryChoosePanel.UiViewSequence.AddSequenceFinishEvent("SwitchB", new Action<string>(this.OnRecoveryChoosePanelHideAniFinish), false);
		VisionRecoveryDirectionalFusionItem directionalFusionItem = this.DirectionalFusionItem;
		if (directionalFusionItem != null)
		{
			directionalFusionItem.SetUiActive(false);
		}
		Singleton<EventSystem>.Instance.Emit<bool>(EEventName.OnRefreshCalabashTabShowState, false);
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashQuitInternalView);
	}

	// Token: 0x0600AF25 RID: 44837 RVA: 0x002EA9F0 File Offset: 0x002E8BF0
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionRecoveryResult, new Action<OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse>>(this.OnVisionRecoveryResult));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionRecoveryBatchResult, new Action<OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse>>(this.OnVisionRecoveryBatchResult));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnItemFuncValueChange, new Action<int>(this.OnItemFuncValueChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.SelectDirectionalFusionTarget, new Action(this.SelectDirectionalFusionTarget));
		Singleton<EventSystem>.Instance.Remove(EEventName.PhantomDirectRefiningWeeklyReset, new Action(this.PhantomDirectRefiningWeeklyReset));
	}

	// Token: 0x0600AF26 RID: 44838 RVA: 0x002EAA8C File Offset: 0x002E8C8C
	private void PlayBatchInAnim()
	{
		this.UiViewSequence.StopPrevSequence(false, false);
		base.GetItem(5).SetUIActive(true);
		this.UiViewSequence.PlaySequence("BatchIn", false, null);
		base.GetHorizontalLayout(11).RootUIComp.Get().SetUIActive(false);
	}

	// Token: 0x0600AF27 RID: 44839 RVA: 0x002EAAE8 File Offset: 0x002E8CE8
	private void PlayBatchOutAnim()
	{
		this.UiViewSequence.StopPrevSequence(false, false);
		this.UiViewSequence.PlaySequence("BatchOut", false, null);
		bool uiactive = ModelBase<FunctionModel>.Instance.IsOpen(10100);
		base.GetHorizontalLayout(11).RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x0600AF28 RID: 44840 RVA: 0x002EAB47 File Offset: 0x002E8D47
	private void OnRecoveryChoosePanelHideAniFinish(string _)
	{
		this.RecoveryChoosePanel.SetActive(false);
		this.RecoveryChoosePanel.UiViewSequence.RemoveSequenceFinishEvent("SwitchB", new Action<string>(this.OnRecoveryChoosePanelHideAniFinish));
	}

	// Token: 0x0600AF29 RID: 44841 RVA: 0x002EAB78 File Offset: 0x002E8D78
	private void OnTabSequenceStart(string sequenceName)
	{
		if (sequenceName == "Start".ToString() || sequenceName == "ShowView".ToString() || sequenceName == "Sle".ToString())
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiTabViewName.VisionRecoveryTabView, true);
		}
	}

	// Token: 0x0600AF2A RID: 44842 RVA: 0x002EABD0 File Offset: 0x002E8DD0
	private void OnTabSequenceFinish(string sequenceName)
	{
		if (sequenceName == "Start".ToString() || sequenceName == "ShowView".ToString() || sequenceName == "Sle".ToString())
		{
			Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiTabViewName.VisionRecoveryTabView, false);
			this.ExecuteViewParams();
		}
	}

	// Token: 0x0600AF2B RID: 44843 RVA: 0x002EAC30 File Offset: 0x002E8E30
	private void ExecuteViewParams()
	{
		if (this.ExtraParams == null)
		{
			return;
		}
		EVisionRecoveryMode? evisionRecoveryMode = this.ExtraParams as EVisionRecoveryMode?;
		if (evisionRecoveryMode == null)
		{
			return;
		}
		EVisionRecoveryMode value = evisionRecoveryMode.Value;
		if (value != EVisionRecoveryMode.Batch)
		{
			if (value == EVisionRecoveryMode.DirectionalFusion)
			{
				this.OnClickDirectionalFusionModelBtn();
			}
		}
		else
		{
			this.OnClickRecoveryModelBtn();
		}
		this.ExtraParams = null;
	}

	// Token: 0x0600AF2C RID: 44844 RVA: 0x002EAC86 File Offset: 0x002E8E86
	[NullableContext(2)]
	private void OnClickSlotCallBack(bool isAddVision, PhantomItemData data)
	{
	}

	// Token: 0x0600AF2D RID: 44845 RVA: 0x002EAC88 File Offset: 0x002E8E88
	private void BatchQuickAddVisionItem()
	{
		if (!this.HasInitRecoveryChoosePanel)
		{
			this.RefreshFilterVisionItemInfoList();
		}
		foreach (PhantomItemData phantomItemData in this.FilterVisionItemInfoList)
		{
			if (this.SelectedVisionList.Count >= this.BatchMaxNum)
			{
				break;
			}
			PhantomBattleData phantomBattleData = ModelBase<PhantomBattleModel>.Instance.GetPhantomBattleData(phantomItemData.GetUniqueId());
			if (phantomBattleData != null && phantomBattleData.GetVisionIfCanRecovery(this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion))
			{
				ISelectedData selectedData = null;
				foreach (ISelectedData selectedData2 in this.SelectedVisionList)
				{
					if (selectedData2.IncId == phantomBattleData.GetIncrId())
					{
						selectedData = selectedData2;
						break;
					}
				}
				if (selectedData == null)
				{
					selectedData = SelectablePropDataUtil.GetSelectablePropData(phantomItemData);
					selectedData.SelectedCount = 1;
					this.SelectedVisionList.Add(selectedData);
				}
			}
		}
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
	}

	// Token: 0x0600AF2E RID: 44846 RVA: 0x002EADB4 File Offset: 0x002E8FB4
	private void RefreshFilterVisionItemInfoList()
	{
		this.FilterVisionItemInfoList = ModelBase<InventoryModel>.Instance.GetUnEquipPhantomItemDataList();
		int sortId = ConfigBase<SortConfig>.Instance.GetSortId(EFilterSortGroupId.VisionRecovery);
		Sort? sortConfig = ConfigBase<SortConfig>.Instance.GetSortConfig(sortId);
		SortResultData sortResultData = new SortResultData();
		sortResultData.SetConfigId(sortConfig.Value.Id);
		sortResultData.SetIsAscending(true);
		int ruleId = sortConfig.Value.BaseSortList()[0];
		string sortRuleName = ConfigBase<SortConfig>.Instance.GetSortRuleName(ruleId, (ESortDataType)sortConfig.Value.DataId);
		sortResultData.SetSelectBaseSort(new SortViewBaseSort(ruleId, sortRuleName));
		ModelBase<SortModel>.Instance.SortDataList<PhantomItemData>(this.FilterVisionItemInfoList, sortConfig.Value.Id, sortResultData, Array.Empty<object>());
	}

	// Token: 0x0600AF2F RID: 44847 RVA: 0x002EAE71 File Offset: 0x002E9071
	private void RemoveAllVisionItem()
	{
		if (this.SelectedVisionList.Count <= 0)
		{
			return;
		}
		this.SelectedVisionList = new List<ISelectedData>();
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
	}

	// Token: 0x0600AF30 RID: 44848 RVA: 0x002EAEAB File Offset: 0x002E90AB
	public void RemoveAllVisionItemOutside()
	{
		this.AllVisionItemInfoList = ModelBase<InventoryModel>.Instance.GetUnEquipPhantomItemDataList();
		this.RemoveAllVisionItem();
	}

	// Token: 0x0600AF31 RID: 44849 RVA: 0x002EAEC4 File Offset: 0x002E90C4
	private void OnClickRecoveryBtn()
	{
		if (!this.IsShowRecoveryChoosePanel)
		{
			EVisionRecoveryTabViewType currentShowType = this.CurrentShowType;
			if (currentShowType == EVisionRecoveryTabViewType.NormalFusion)
			{
				this.OnClickRecoveryModelBtn();
				return;
			}
			if (currentShowType != EVisionRecoveryTabViewType.DirectionalFusion)
			{
				return;
			}
			this.OnClickDirectionalFusionModelBtn();
			return;
		}
		else
		{
			if (this.SelectedVisionList.Count < this.SlotMaxNum)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Text_EchoLack_Text", Array.Empty<object>());
				return;
			}
			EVisionRecoveryTabViewType currentShowType = this.CurrentShowType;
			if (currentShowType == EVisionRecoveryTabViewType.NormalFusion)
			{
				this.VisionRecovery(delegate
				{
					ControllerBase<CalabashController>.Instance.RequestPhantomRefiningRequest(this.SelectedVisionList.ToArray());
				});
				return;
			}
			if (currentShowType != EVisionRecoveryTabViewType.DirectionalFusion)
			{
				return;
			}
			this.VisionRecovery(delegate
			{
				ControllerBase<CalabashController>.Instance.PhantomBatchDirectRefiningRequest(this.SelectedVisionList.ToArray());
			});
			return;
		}
	}

	// Token: 0x0600AF32 RID: 44850 RVA: 0x002EAF54 File Offset: 0x002E9154
	private void VisionRecovery(Action refineRequest)
	{
		Action action = delegate()
		{
			bool flag4 = false;
			foreach (ISelectedData selectedData2 in this.SelectedVisionList)
			{
				if (selectedData2.IncId > 0 && ModelBase<VisionEquipGroupModel>.Instance.CheckVisionListIfInGroup(new List<int>
				{
					selectedData2.IncId
				}))
				{
					flag4 = true;
					break;
				}
			}
			if (flag4)
			{
				ConfirmBoxDataNew confirmBoxDataNew2 = new ConfirmBoxDataNew(EConfirmBoxConfigId.DestroyVisionInGroup);
				confirmBoxDataNew2.FunctionMap.Add(2, refineRequest);
				ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew2);
				return;
			}
			refineRequest();
		};
		if (ModelBase<CalabashModel>.Instance.HideVisionRecoveryConfirmBox)
		{
			action();
			return;
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (ISelectedData selectedData in this.SelectedVisionList)
		{
			PhantomBattleData phantomItemDataByUniqueId = ControllerBase<PhantomBattleController>.Instance.GetPhantomItemDataByUniqueId(selectedData.IncId);
			if (phantomItemDataByUniqueId != null)
			{
				if (!flag && ModelBase<PhantomBattleModel>.Instance.IsVisionHighQuality(phantomItemDataByUniqueId))
				{
					flag = true;
				}
				if (!flag2 && ModelBase<PhantomBattleModel>.Instance.IsVisionHighLevel(phantomItemDataByUniqueId))
				{
					flag2 = true;
				}
				if (!flag3 && ModelBase<PhantomBattleModel>.Instance.IsVisionHighRare(phantomItemDataByUniqueId))
				{
					flag3 = true;
				}
			}
		}
		EConfirmBoxConfigId? econfirmBoxConfigId = null;
		List<string> list = new List<string>();
		if (flag)
		{
			string textById = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighQuality");
			if (textById != null)
			{
				list.Add(textById);
			}
		}
		if (flag2)
		{
			string textById2 = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighLevel");
			if (textById2 != null)
			{
				list.Add(textById2);
			}
		}
		if (flag3)
		{
			string textById3 = ConfigBase<TextConfig>.Instance.GetTextById("VisionHighRare");
			if (textById3 != null)
			{
				list.Add(textById3);
			}
		}
		switch (list.Count)
		{
		case 1:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips1);
			break;
		case 2:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips2);
			break;
		case 3:
			econfirmBoxConfigId = new EConfirmBoxConfigId?(EConfirmBoxConfigId.VisionLevelUpTips3);
			break;
		}
		if (econfirmBoxConfigId != null)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(econfirmBoxConfigId.Value);
			confirmBoxDataNew.SetTextArgs(list.ToArray());
			confirmBoxDataNew.FunctionMap.Add(2, action);
			confirmBoxDataNew.HasToggle = true;
			confirmBoxDataNew.ToggleText = ConfigMultiTextLang.GetLocalTextNew("Text_ItemRecycleConfirmToggle_text", null);
			confirmBoxDataNew.SetToggleFunction(new Action<bool>(this.OnClickedNotShowConfirm));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		action();
	}

	// Token: 0x0600AF33 RID: 44851 RVA: 0x002EB150 File Offset: 0x002E9350
	private void OnClickedNotShowConfirm(bool isSelectedOn)
	{
		ModelBase<CalabashModel>.Instance.HideVisionRecoveryConfirmBox = isSelectedOn;
	}

	// Token: 0x0600AF34 RID: 44852 RVA: 0x002EB160 File Offset: 0x002E9360
	private void OnClickRecoveryModelBtn()
	{
		this.VisionRecoveryMode = EVisionRecoveryMode.Batch;
		this.SelectedVisionList = new List<ISelectedData>();
		if (!this.HasInitRecoveryChoosePanel)
		{
			this.InitRecoveryChoosePanel(this.VisionRecoveryMode);
		}
		else
		{
			this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
		}
		this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		this.PlayBatchInAnim();
		this.ShowRecoveryChoosePanel();
		this.RefreshRewardItemTag();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "VisionRecoveryTabView_Btn_RandomModel", Array.Empty<object>());
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "VisionRecoveryBatchStart");
	}

	// Token: 0x0600AF35 RID: 44853 RVA: 0x002EB204 File Offset: 0x002E9404
	private void OnClickDirectionalFusionModelBtn()
	{
		if (ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime <= 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomRecycle_Tips02", Array.Empty<object>());
			return;
		}
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.VisionDirectionalFusionSelectTargetView))
		{
			return;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionDirectionalFusionSelectTargetView, null, null);
	}

	// Token: 0x0600AF36 RID: 44854 RVA: 0x002EB264 File Offset: 0x002E9464
	private void OnEnterDirectionalFusionModel()
	{
		this.VisionRecoveryMode = EVisionRecoveryMode.DirectionalFusion;
		this.SelectedVisionList = new List<ISelectedData>();
		if (!this.HasInitRecoveryChoosePanel)
		{
			this.InitRecoveryChoosePanel(this.VisionRecoveryMode);
		}
		else
		{
			this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
		}
		this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		this.PlayBatchInAnim();
		this.ShowRecoveryChoosePanel();
		VisionRecoveryDirectionalFusionItem directionalFusionItem = this.DirectionalFusionItem;
		if (directionalFusionItem != null)
		{
			directionalFusionItem.SetUiActive(true);
		}
		VisionRecoveryDirectionalFusionItem directionalFusionItem2 = this.DirectionalFusionItem;
		if (directionalFusionItem2 != null)
		{
			directionalFusionItem2.RefreshItem();
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(16), "VisionRecoveryTabView_Btn_AimModel", Array.Empty<object>());
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "VisionRecoveryBatchStart");
	}

	// Token: 0x0600AF37 RID: 44855 RVA: 0x002EB324 File Offset: 0x002E9524
	private void OnClickBatchRecoveryBtn()
	{
		if (!this.IsShowRecoveryChoosePanel)
		{
			EVisionRecoveryTabViewType currentShowType = this.CurrentShowType;
			if (currentShowType == EVisionRecoveryTabViewType.NormalFusion)
			{
				this.OnClickRecoveryModelBtn();
				return;
			}
			if (currentShowType != EVisionRecoveryTabViewType.DirectionalFusion)
			{
				return;
			}
			this.OnClickDirectionalFusionModelBtn();
			return;
		}
		else
		{
			if (this.SelectedVisionList.Count < this.SlotMaxNum)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("Text_BatchEchoLack", Array.Empty<object>());
				return;
			}
			EVisionRecoveryTabViewType currentShowType = this.CurrentShowType;
			if (currentShowType == EVisionRecoveryTabViewType.NormalFusion)
			{
				this.VisionRecovery(delegate
				{
					ControllerBase<CalabashController>.Instance.RequestBatchRefiningRequest(this.SelectedVisionList.ToArray());
				});
				return;
			}
			if (currentShowType != EVisionRecoveryTabViewType.DirectionalFusion)
			{
				return;
			}
			this.VisionRecovery(delegate
			{
				ControllerBase<CalabashController>.Instance.PhantomBatchDirectRefiningRequest(this.SelectedVisionList.ToArray());
			});
			return;
		}
	}

	// Token: 0x0600AF38 RID: 44856 RVA: 0x002EB3B2 File Offset: 0x002E95B2
	private CommonItemSmallItemGrid OnRewardLayoutUpdate()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600AF39 RID: 44857 RVA: 0x002EB3B9 File Offset: 0x002E95B9
	private VisionRecoveryTabItem OnInitTabItem()
	{
		return new VisionRecoveryTabItem
		{
			OnClickToggleCallBack = new Action<EVisionRecoveryTabViewType, UUIExtendToggle>(this.OnClickTabItemCallBack)
		};
	}

	// Token: 0x0600AF3A RID: 44858 RVA: 0x002EB3D4 File Offset: 0x002E95D4
	private void OnClickTabItemCallBack(EVisionRecoveryTabViewType type, UUIExtendToggle toggle)
	{
		UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
		if (currentSelectToggle != null)
		{
			currentSelectToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
		}
		this.CurrentSelectToggle = toggle;
		this.CurrentShowType = type;
		this.SelectedVisionList = new List<ISelectedData>();
		if (type == EVisionRecoveryTabViewType.NormalFusion)
		{
			this.BatchMaxNum = ConfigBase<CalabashConfig>.Instance.GetVisionBatchRecoveryMaxCount();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "VisionRecoveryTabView_Out_Btn_RandomModel", Array.Empty<object>());
			base.GetItem(14).SetUIActive(false);
		}
		else
		{
			int num = ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime;
			this.BatchMaxNum = num * this.SlotMaxNum;
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(15), "VisionRecoveryTabView_Out_Btn_AimModel", Array.Empty<object>());
			base.GetItem(14).SetUIActive(true);
		}
		this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		this.RefreshRewardItemTag();
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Change", false, null);
	}

	// Token: 0x0600AF3B RID: 44859 RVA: 0x002EB4D0 File Offset: 0x002E96D0
	private void RefreshRewardItemTag()
	{
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in (((rewardLayout != null) ? rewardLayout.GetLayoutItemList() : null) ?? new List<CommonItemSmallItemGrid>()))
		{
			commonItemSmallItemGrid.SetDirectionalFusionComponent(new int?((this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion) ? -1 : 0));
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> batchRewardLayout = this.BatchRewardLayout;
		foreach (CommonItemSmallItemGrid commonItemSmallItemGrid2 in (((batchRewardLayout != null) ? batchRewardLayout.GetLayoutItemList() : null) ?? new List<CommonItemSmallItemGrid>()))
		{
			commonItemSmallItemGrid2.SetDirectionalFusionComponent(new int?((this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion) ? ModelBase<CalabashModel>.Instance.DirectionalFusionTargetFetterGroup : 0));
		}
	}

	// Token: 0x0600AF3C RID: 44860 RVA: 0x002EB5B8 File Offset: 0x002E97B8
	private void OnChangeSelectedFunction(List<ISelectedData> selectedDataList, SelectableExpData _)
	{
		this.SelectedVisionList = selectedDataList;
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
	}

	// Token: 0x0600AF3D RID: 44861 RVA: 0x002EB5D0 File Offset: 0x002E97D0
	private void OnRecoveryChoosePanelClose()
	{
		this.SelectedVisionList = new List<ISelectedData>();
		this.RefreshRecoveryChoosePanel(this.AllVisionItemInfoList, this.SelectedVisionList);
		this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		this.PlayBatchOutAnim();
		this.HideRecoveryChoosePanel();
	}

	// Token: 0x0600AF3E RID: 44862 RVA: 0x002EB61E File Offset: 0x002E981E
	private void OnVisionRecoveryResult([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<PhantomBatchDirectRefiningResponse, PhantomRefiningResponse> response)
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashQuitInternalView);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRecoveryResultView, response, delegate(bool _2, int _3)
		{
			this.AllVisionItemInfoList = ModelBase<InventoryModel>.Instance.GetUnEquipPhantomItemDataList();
			this.RemoveAllVisionItem();
			this.RefreshRecoverySlotPanel(this.SelectedVisionList);
			this.PlayBatchOutAnim();
			this.HideRecoveryChoosePanel();
		});
	}

	// Token: 0x0600AF3F RID: 44863 RVA: 0x002EB654 File Offset: 0x002E9854
	private void OnVisionRecoveryBatchResult([Nullable(new byte[]
	{
		0,
		1,
		1
	})] OneOf<PhantomBatchDirectRefiningResponse, PhantomBatchRefiningResponse> response)
	{
		if (this.CurrentShowType == EVisionRecoveryTabViewType.DirectionalFusion)
		{
			int num = ModelBase<CalabashModel>.Instance.DirectionalFusionTimeMax - ModelBase<CalabashModel>.Instance.DirectionalFusionTime;
			this.BatchMaxNum = num * this.SlotMaxNum;
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.VisionRecoveryBatchResultView, response, delegate(bool _2, int _3)
		{
			this.AllVisionItemInfoList = ModelBase<InventoryModel>.Instance.GetUnEquipPhantomItemDataList();
			this.RemoveAllVisionItem();
			this.RefreshRecoverySlotPanel(this.SelectedVisionList);
		});
	}

	// Token: 0x0600AF40 RID: 44864 RVA: 0x002EB6B0 File Offset: 0x002E98B0
	private void OnItemFuncValueChange(int uniqueId)
	{
		PhantomItemData phantomItemData = ModelBase<InventoryModel>.Instance.GetPhantomItemData(uniqueId);
		if (phantomItemData == null)
		{
			return;
		}
		int num = this.SelectedVisionList.FindIndex((ISelectedData value) => value.IncId == uniqueId);
		if (num >= 0 && phantomItemData.GetIsLock())
		{
			this.SelectedVisionList.RemoveAt(num);
			this.RefreshRecoveryBatchPanel(this.SelectedVisionList);
		}
		int num2 = this.FilterVisionItemInfoList.FindIndex((PhantomItemData visionData) => visionData.GetUniqueId() == uniqueId);
		if (num2 >= 0)
		{
			this.RecoveryChoosePanel.UpdatePartByIndex(num2);
		}
	}

	// Token: 0x0600AF41 RID: 44865 RVA: 0x002EB743 File Offset: 0x002E9943
	private void SelectDirectionalFusionTarget()
	{
		VisionRecoveryDirectionalFusionItem directionalFusionItem = this.DirectionalFusionItem;
		if (directionalFusionItem != null)
		{
			directionalFusionItem.RefreshItem();
		}
		this.RefreshRewardItemTag();
		this.OnEnterDirectionalFusionModel();
	}

	// Token: 0x0600AF42 RID: 44866 RVA: 0x002EB762 File Offset: 0x002E9962
	private void PhantomDirectRefiningWeeklyReset()
	{
		Singleton<UiManager>.Instance.CloseView(EUiViewName.CalabashRootView, null);
	}

	// Token: 0x0600AF43 RID: 44867 RVA: 0x002EB774 File Offset: 0x002E9974
	private void OnVisionChooseSortRefresh(List<PhantomItemData> list)
	{
		if (list != null)
		{
			this.FilterVisionItemInfoList = list;
		}
	}

	// Token: 0x0600AF44 RID: 44868 RVA: 0x002EB780 File Offset: 0x002E9980
	private void OnClickSelectAllToggle(EToggleState state)
	{
		if (state == EToggleState.ETT_UnChecked)
		{
			this.RemoveAllVisionItem();
			return;
		}
		this.BatchQuickAddVisionItem();
	}

	// Token: 0x0600AF45 RID: 44869 RVA: 0x002EB794 File Offset: 0x002E9994
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (!(configParams[0] == "Filter"))
		{
			return null;
		}
		UUIItem filterToggleItem = this.RecoveryChoosePanel.GetFilterToggleItem();
		if (filterToggleItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			filterToggleItem,
			filterToggleItem
		};
	}

	// Token: 0x0400530E RID: 21262
	private List<ISelectedData> SelectedVisionList = new List<ISelectedData>();

	// Token: 0x0400530F RID: 21263
	private List<PhantomItemData> AllVisionItemInfoList = new List<PhantomItemData>();

	// Token: 0x04005310 RID: 21264
	private List<PhantomItemData> FilterVisionItemInfoList = new List<PhantomItemData>();

	// Token: 0x04005311 RID: 21265
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private VisionRecoveryChoosePanel<PhantomItemData> RecoveryChoosePanel;

	// Token: 0x04005312 RID: 21266
	[Nullable(2)]
	private VisionRecoverySlotPanel RecoverySlotPanel;

	// Token: 0x04005313 RID: 21267
	[Nullable(2)]
	private VisionRecoveryDirectionalFusionItem DirectionalFusionItem;

	// Token: 0x04005314 RID: 21268
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<VisionRecoveryTabItem, EVisionRecoveryTabViewType> TabLayout;

	// Token: 0x04005315 RID: 21269
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x04005316 RID: 21270
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> BatchRewardLayout;

	// Token: 0x04005317 RID: 21271
	private bool IsShowRecoveryChoosePanel;

	// Token: 0x04005318 RID: 21272
	private bool HasInitRecoveryChoosePanel;

	// Token: 0x04005319 RID: 21273
	private EVisionRecoveryMode VisionRecoveryMode = EVisionRecoveryMode.Batch;

	// Token: 0x0400531A RID: 21274
	private readonly int SlotMaxNum = 5;

	// Token: 0x0400531B RID: 21275
	private int BatchMaxNum;

	// Token: 0x0400531C RID: 21276
	private EVisionRecoveryTabViewType CurrentShowType;

	// Token: 0x0400531D RID: 21277
	[Nullable(2)]
	private UUIExtendToggle CurrentSelectToggle;

	// Token: 0x02007B8A RID: 31626
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402A39D RID: 172957
		RecoverySlotPanel,
		// Token: 0x0402A39E RID: 172958
		RecoveryChoosePanelRoot,
		// Token: 0x0402A39F RID: 172959
		RecoveryCountText,
		// Token: 0x0402A3A0 RID: 172960
		RecoveryBtn,
		// Token: 0x0402A3A1 RID: 172961
		RewardLayout,
		// Token: 0x0402A3A2 RID: 172962
		NormalRecoveryRoot,
		// Token: 0x0402A3A3 RID: 172963
		BatchRecoveryRoot,
		// Token: 0x0402A3A4 RID: 172964
		BatchRewardLayout,
		// Token: 0x0402A3A5 RID: 172965
		BatchMaterialText,
		// Token: 0x0402A3A6 RID: 172966
		BatchCountText,
		// Token: 0x0402A3A7 RID: 172967
		BatchRecoveryBtn,
		// Token: 0x0402A3A8 RID: 172968
		TabLayout,
		// Token: 0x0402A3A9 RID: 172969
		TabItem,
		// Token: 0x0402A3AA RID: 172970
		DirectionalItem,
		// Token: 0x0402A3AB RID: 172971
		RecoveryCountTextItem,
		// Token: 0x0402A3AC RID: 172972
		IntoBtnText,
		// Token: 0x0402A3AD RID: 172973
		BatchRecoveryBtnText
	}
}
