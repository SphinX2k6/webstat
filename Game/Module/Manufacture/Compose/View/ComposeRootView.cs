using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Manufacture.Compose.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Compose.View
{
	// Token: 0x020059CA RID: 22986
	[NullableContext(1)]
	[Nullable(0)]
	public class ComposeRootView : UiViewBase
	{
		// Token: 0x0603A3BE RID: 238526 RVA: 0x00EC1603 File Offset: 0x00EBF803
		public ComposeRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603A3BF RID: 238527 RVA: 0x00EC1630 File Offset: 0x00EBF830
		protected unsafe override void OnRegisterComponent()
		{
			int num = 14;
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
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.ShowComposeLevelView));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A3C0 RID: 238528 RVA: 0x00EC1868 File Offset: 0x00EBFA68
		protected override UniTask OnBeforeStartAsync()
		{
			ComposeRootView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<ComposeRootView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603A3C1 RID: 238529 RVA: 0x00EC18AC File Offset: 0x00EBFAAC
		protected override void OnStart()
		{
			this.FilterComponent = new FilterEntrance<IBaseItemData>(base.GetItem(3), new TUpdateDataListFunction<IBaseItemData>(this.OnFilterSortRefresh));
			this.FilterComponent.SetActive(false);
			this.SortComponent = new SortEntrance<IBaseItemData>(base.GetItem(10), new TUpdateDataListFunction<IBaseItemData>(this.OnFilterSortRefresh));
			this.SortComponent.SetSortToggleState(true);
			this.ComposeItemScrollView = new LoopScrollView<ComposeMediumItemGrid, IBaseItemData>(base.GetLoopScrollViewComponent(2), base.GetLoopScrollViewComponent(2).TemplateGrid, new Func<ComposeMediumItemGrid>(this.OnGridProxyCreate), false);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "ComposeLevelButtonText", Array.Empty<object>());
			this.StartLevelComponent = new StarLevelComponent(base.GetHorizontalLayout(11));
			Singleton<CommonManager>.Instance.SetCurrentSystem(CSharpScript.Game.Module.Manufacture.Common.ESystemType.ComposeSystem);
			ControllerBase<ComposeController>.Instance.RegisterCurrentInteractionEntity();
			this.WaitUiBlendInCameraSequenceFinished = new CustomPromise();
			ModelBase<ComposeModel>.Instance.CurrentInteractCreatureDataLongId = ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId;
			Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
			if (ModelBase<InteractionModel>.Instance.CurrentInteractEntityId == null)
			{
				Singleton<global::Log>.Instance.Info(ELogModule.Compose, ELogAuthor.WZ, "[LevelEventOpenSystem] 打开合成界面时找不到交互对象，直接关闭界面", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.CloseMe(null);
			}
		}

		// Token: 0x0603A3C2 RID: 238530 RVA: 0x00EC19F7 File Offset: 0x00EBFBF7
		protected override void OnBeforeShow()
		{
			this.ShowComposeMainView();
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			childPopView.PopItem.SetMaskResponsibleState(false);
		}

		// Token: 0x0603A3C3 RID: 238531 RVA: 0x00EC1A18 File Offset: 0x00EBFC18
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			ComposeRootView.<OnBeforeShowAsyncImplement>d__23 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<ComposeRootView.<OnBeforeShowAsyncImplement>d__23>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603A3C4 RID: 238532 RVA: 0x00EC1A5B File Offset: 0x00EBFC5B
		protected override void OnAfterShow()
		{
			this.RefreshPopItemVisible();
			this.WaitUiBlendInCameraSequenceFinished = null;
		}

		// Token: 0x0603A3C5 RID: 238533 RVA: 0x00EC1A6C File Offset: 0x00EBFC6C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
			this.MainTypeHorizontal.ClearChildren();
			this.ComposeItemScrollView.ClearGridProxies();
			this.StartLevelComponent.Clear();
			ComposeModel instance = ModelBase<ComposeModel>.Instance;
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.ComposeLevelKey);
			ControllerBase<ComposeController>.Instance.PlayLeaveCompositeAudio();
			ControllerBase<ComposeController>.Instance.ClearCurrentInteractionEntityDisplay();
			instance.ClearComposeRoleItemDataList();
			instance.CurrentComposeRoleId = 0;
			instance.CurrentComposeListType = EComposeListType.ReagentProduction;
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.ComposeReagentProduction);
			this.WaitUiBlendInCameraSequenceFinished = null;
		}

		// Token: 0x0603A3C6 RID: 238534 RVA: 0x00EC1B04 File Offset: 0x00EBFD04
		private void RefreshPopItemVisible()
		{
			CommonPopViewBase popItem = this.ChildPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			if (this.IsEnterSequenceCompleted)
			{
				return;
			}
			bool flag = !Singleton<UiCameraAnimationManager>.Instance.IsPlayingBlendInSequence();
			if (popItem.GetActive() == flag)
			{
				return;
			}
			popItem.SetActive(flag);
		}

		// Token: 0x0603A3C7 RID: 238535 RVA: 0x00EC1B4C File Offset: 0x00EBFD4C
		private void CheckShowTab()
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeMainType;
			List<MainTypeItem> layoutItemList = this.MainTypeHorizontal.GetLayoutItemList();
			bool flag = false;
			EComposeListType currentComposeListType = ModelBase<ComposeModel>.Instance.CurrentComposeListType;
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				MainTypeItem mainTypeItem = layoutItemList[i];
				EComposeListType mainType = mainTypeItem.GetMainType();
				if (this.GetItemListByType(currentComposeListType).Count > 0 || i == layoutItemList.Count - 1)
				{
					mainTypeItem.SetUiActive(true);
					if (currentComposeListType == mainType && !flag)
					{
						this.MainTypeHorizontal.SelectGridProxy(mainTypeItem.GridIndex, false);
						flag = true;
					}
				}
				else
				{
					mainTypeItem.SetUiActive(false);
				}
			}
		}

		// Token: 0x0603A3C8 RID: 238536 RVA: 0x00EC1BEC File Offset: 0x00EBFDEC
		private void ShowComposeMainView()
		{
			this.CheckShowTab();
			this.KeepSelectOnSort = true;
			this.SortComponent.SetResultDataDirty();
			this.SortComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
			this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId);
			this.FilterComponent.SetActive(true);
			this.FilterComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId2 = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
			this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId2);
			this.KeepSelectOnSort = false;
			this.SwitchComposeLevelShow();
			this.OnShowRedDot();
			this.SwitchMainTitleByListType();
			int value = Singleton<CommonManager>.Instance.GetComposeMaxLevel().Value;
			int value2 = Singleton<CommonManager>.Instance.GetCurrentRewardLevel().Value;
			this.StartLevelComponent.ShowLevel(value2, value);
			this.RefreshLimitTime();
		}

		// Token: 0x0603A3C9 RID: 238537 RVA: 0x00EC1CD8 File Offset: 0x00EBFED8
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.GetComposeData, new Action(this.ShowComposeMainView));
			Singleton<EventSystem>.Instance.Add(EEventName.OpenHelpRole, new Action<int>(this.ShowComposeRoleView));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeSuccess, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Add(EEventName.ComposeFail, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBeginPlayCompositeWorkingDisplay, new Action(this.OnBeginPlayCompositeWorkingDisplay));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnSecondTimerRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603A3CA RID: 238538 RVA: 0x00EC1DB4 File Offset: 0x00EBFFB4
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.GetComposeData, new Action(this.ShowComposeMainView));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeSuccess, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Remove(EEventName.ComposeFail, new Action(this.OnCookResponse));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenHelpRole, new Action<int>(this.ShowComposeRoleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBeginPlayCompositeWorkingDisplay, new Action(this.OnBeginPlayCompositeWorkingDisplay));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			if (this.RefreshTimer != null && TimerSystem.Instance.Has(this.RefreshTimer))
			{
				TimerSystem.Instance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603A3CB RID: 238539 RVA: 0x00EC1E98 File Offset: 0x00EC0098
		private void OnSecondTimerRefresh(float delta)
		{
			this.RefreshLimitTime();
			this.ComposeDetailsInfoView.OnSecondTimerRefresh();
			if (this.CheckIsLimitCountRefresh())
			{
				this.<OnSecondTimerRefresh>g__Temp|31_0().Forget();
				return;
			}
			if (this.CheckHasItemTimeOut())
			{
				this.<OnSecondTimerRefresh>g__Temp|31_1().Forget();
			}
		}

		// Token: 0x0603A3CC RID: 238540 RVA: 0x00EC1ED4 File Offset: 0x00EC00D4
		private void RefreshLimitTime()
		{
			string refreshLimitTime = ModelBase<ComposeModel>.Instance.GetRefreshLimitTime();
			if (refreshLimitTime != null)
			{
				base.GetItem(12).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "RefreshTime", new <>z__ReadOnlySingleElementList<object>(refreshLimitTime));
				return;
			}
			base.GetItem(12).SetUIActive(false);
		}

		// Token: 0x0603A3CD RID: 238541 RVA: 0x00EC1F29 File Offset: 0x00EC0129
		private bool CheckIsLimitCountRefresh()
		{
			return ModelBase<ComposeModel>.Instance.GetRefreshLimitTimeValue() <= 0.0;
		}

		// Token: 0x0603A3CE RID: 238542 RVA: 0x00EC1F44 File Offset: 0x00EC0144
		private bool CheckHasItemTimeOut()
		{
			List<IBaseItemData> itemList = this.GetItemList();
			if (itemList == null)
			{
				return false;
			}
			foreach (IBaseItemData baseItemData in itemList)
			{
				if (baseItemData.ExistEndTime > 0.0 && !Singleton<TimeUtil>.Instance.IsInTimeSpan(baseItemData.ExistStartTime, baseItemData.ExistEndTime))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603A3CF RID: 238543 RVA: 0x00EC1FC8 File Offset: 0x00EC01C8
		private void OnBeginPlayCompositeWorkingDisplay()
		{
			this.<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0().Forget();
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, true);
		}

		// Token: 0x0603A3D0 RID: 238544 RVA: 0x00EC1FE8 File Offset: 0x00EC01E8
		private void OnExecuteUiCameraSequenceEvent(string sequenceEventName)
		{
			if (sequenceEventName != "OnBlackScreen")
			{
				return;
			}
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PlayLevelSequenceByName("BlackScreenShow", false);
			}
			if (this.WaitUiBlendInCameraSequenceFinished != null && this.WaitUiBlendInCameraSequenceFinished.IsPending)
			{
				this.WaitUiBlendInCameraSequenceFinished.SetResult();
			}
			ControllerBase<ComposeController>.Instance.PlayCompositeEnterDisplay(new Action(this.OnPlayEnterDisplayFinished));
			this.IsEnterSequenceCompleted = true;
		}

		// Token: 0x0603A3D1 RID: 238545 RVA: 0x00EC2057 File Offset: 0x00EC0257
		private void OnPlayEnterDisplayFinished()
		{
			if (!Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ComposeCarryOnView))
			{
				return;
			}
			ControllerBase<ComposeController>.Instance.PlayCompositeLoopDisplay();
		}

		// Token: 0x0603A3D2 RID: 238546 RVA: 0x00EC2078 File Offset: 0x00EC0278
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.CompositeRewardView)
			{
				return;
			}
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.SetActive(true);
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 != null)
			{
				childPopView2.PlayLevelSequenceByName("Start", false);
			}
			Singleton<EventSystem>.Instance.Emit<bool>(EEventName.HangPlotViewHud, false);
			PlayFlow composeSuccessFlow = ModelBase<ComposeModel>.Instance.ComposeSuccessFlow;
			ControllerBase<ComposeController>.Instance.PlayCompositeFlow(composeSuccessFlow);
		}

		// Token: 0x0603A3D3 RID: 238547 RVA: 0x00EC20E8 File Offset: 0x00EC02E8
		private void SetSelectedComposeItem(bool isNeedScroll = false)
		{
			int num = 0;
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				num = this.SelectedReagentProductionIndex;
				this.ComposeDetailsInfoView.RefreshTips(this.ReagentProductionDataList[num]);
				break;
			case EComposeListType.Structure:
				num = this.SelectedStructureIndex;
				this.ComposeDetailsInfoView.RefreshTips(this.StructureDataList[num]);
				break;
			case EComposeListType.Purification:
				num = this.SelectedPurificationIndex;
				this.ComposeDetailsInfoView.RefreshTips(this.PurificationDataList[num]);
				break;
			}
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			if (isNeedScroll)
			{
				this.ComposeItemScrollView.ScrollToGridIndex(num, true);
			}
			this.ComposeItemScrollView.SelectGridProxy(num, false);
		}

		// Token: 0x0603A3D4 RID: 238548 RVA: 0x00EC219F File Offset: 0x00EC039F
		private ComposeMediumItemGrid OnGridProxyCreate()
		{
			ComposeMediumItemGrid composeMediumItemGrid = new ComposeMediumItemGrid();
			composeMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnComposeItemClick));
			return composeMediumItemGrid;
		}

		// Token: 0x0603A3D5 RID: 238549 RVA: 0x00EC21B8 File Offset: 0x00EC03B8
		private void OnComposeItemClick(MediumItemGridExtendCallback callbackParameter)
		{
			IBaseItemData baseItemData = callbackParameter.Data as IBaseItemData;
			int gridIndex = 0;
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			switch (baseItemData.MainType)
			{
			case EComposeListType.ReagentProduction:
			{
				IReagentProductionData item = baseItemData as IReagentProductionData;
				this.SelectedReagentProductionIndex = this.ReagentProductionDataList.IndexOf(item);
				gridIndex = this.SelectedReagentProductionIndex;
				break;
			}
			case EComposeListType.Structure:
			{
				IStructureData item2 = baseItemData as IStructureData;
				this.SelectedStructureIndex = this.StructureDataList.IndexOf(item2);
				gridIndex = this.SelectedStructureIndex;
				break;
			}
			case EComposeListType.Purification:
			{
				IPurificationData item3 = baseItemData as IPurificationData;
				this.SelectedPurificationIndex = this.PurificationDataList.IndexOf(item3);
				gridIndex = this.SelectedPurificationIndex;
				break;
			}
			}
			if (!this.ComposeItemScrollView.IsGridDisplaying(gridIndex))
			{
				return;
			}
			if (baseItemData.IsNew)
			{
				ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.ComposeLevelKey, baseItemData.ConfigId);
				baseItemData.IsNew = false;
			}
			this.ComposeItemScrollView.SelectGridProxy(gridIndex, false);
			this.ComposeItemScrollView.RefreshGridProxy(gridIndex);
			this.ComposeDetailsInfoView.RefreshTips(baseItemData);
		}

		// Token: 0x0603A3D6 RID: 238550 RVA: 0x00EC22BA File Offset: 0x00EC04BA
		private MainTypeItem InitMainTypeItem()
		{
			MainTypeItem mainTypeItem = new MainTypeItem();
			mainTypeItem.SetMainTypeCallback(new Action<int>(this.OnSwitchCallback));
			return mainTypeItem;
		}

		// Token: 0x0603A3D7 RID: 238551 RVA: 0x00EC22D4 File Offset: 0x00EC04D4
		private void OnSwitchCallback(int mainType)
		{
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == (EComposeListType)mainType)
			{
				return;
			}
			switch (mainType)
			{
			case 1:
				ModelBase<ComposeModel>.Instance.CurrentComposeListType = EComposeListType.ReagentProduction;
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchComposeType);
				this.SwitchComposeLevelShow();
				this.SwitchComposeItemScroll();
				this.SwitchMainTitleByListType();
				return;
			case 2:
				ModelBase<ComposeModel>.Instance.CurrentComposeListType = EComposeListType.Structure;
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchComposeType);
				this.SwitchComposeLevelShow();
				this.SwitchComposeItemScroll();
				this.SwitchMainTitleByListType();
				return;
			case 3:
				ModelBase<ComposeModel>.Instance.CurrentComposeListType = EComposeListType.Purification;
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchComposeType);
				this.SwitchComposeLevelShow();
				this.SwitchComposeItemScroll();
				this.SwitchMainTitleByListType();
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A3D8 RID: 238552 RVA: 0x00EC238D File Offset: 0x00EC058D
		private void SwitchComposeLevelShow()
		{
			(base.GetButton(5).GetOwner() as AUIBaseActor).GetUIItem().SetUIActive(ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.ReagentProduction);
			this.SetComposeLevelSprite();
		}

		// Token: 0x0603A3D9 RID: 238553 RVA: 0x00EC23C0 File Offset: 0x00EC05C0
		private void SetComposeLevelSprite()
		{
			if (ModelBase<ComposeModel>.Instance.CurrentComposeListType == EComposeListType.ReagentProduction)
			{
				string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_ReagentProductionLevel");
				this.SetSpriteByPath(resourcePath, base.GetSprite(6), false, null, null);
			}
		}

		// Token: 0x0603A3DA RID: 238554 RVA: 0x00EC2404 File Offset: 0x00EC0604
		private void SwitchComposeItemScroll()
		{
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
			{
				this.FilterComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId);
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.ReagentList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId2 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.ReagentList);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId2);
				return;
			}
			case EComposeListType.Structure:
			{
				this.FilterComponent.UpdateData(EFilterSortGroupId.StructureList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId3 = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.StructureList);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId3);
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.StructureList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId4 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.StructureList);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId4);
				return;
			}
			case EComposeListType.Purification:
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.PurificationList, this.GetItemList(), Array.Empty<object>());
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A3DB RID: 238555 RVA: 0x00EC2538 File Offset: 0x00EC0738
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IBaseItemData> GetItemListByType(EComposeListType type)
		{
			List<IBaseItemData> result;
			switch (type)
			{
			case EComposeListType.ReagentProduction:
			{
				List<IReagentProductionData> reagentProductionDataList = ModelBase<ComposeModel>.Instance.GetReagentProductionDataList();
				List<IBaseItemData> list;
				if (reagentProductionDataList == null)
				{
					list = null;
				}
				else
				{
					list = reagentProductionDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IReagentProductionData v) => v);
				}
				result = list;
				break;
			}
			case EComposeListType.Structure:
			{
				List<IStructureData> structureDataList = ModelBase<ComposeModel>.Instance.GetStructureDataList();
				List<IBaseItemData> list2;
				if (structureDataList == null)
				{
					list2 = null;
				}
				else
				{
					list2 = structureDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IStructureData v) => v);
				}
				result = list2;
				break;
			}
			case EComposeListType.Purification:
			{
				List<IPurificationData> purificationDataList = ModelBase<ComposeModel>.Instance.GetPurificationDataList();
				List<IBaseItemData> list3;
				if (purificationDataList == null)
				{
					list3 = null;
				}
				else
				{
					list3 = purificationDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IPurificationData v) => v);
				}
				result = list3;
				break;
			}
			default:
				return null;
			}
			return result;
		}

		// Token: 0x0603A3DC RID: 238556 RVA: 0x00EC260B File Offset: 0x00EC080B
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		private List<IBaseItemData> GetItemList()
		{
			return this.GetItemListByType(ModelBase<ComposeModel>.Instance.CurrentComposeListType);
		}

		// Token: 0x0603A3DD RID: 238557 RVA: 0x00EC2620 File Offset: 0x00EC0820
		private void OnFilterSortRefresh(List<IBaseItemData> list, bool arg1, EFilterSortType arg2)
		{
			List<IBaseItemData> list2 = list.ConvertAll<IBaseItemData>(([Nullable(1)] IBaseItemData v) => v).FindAll((IBaseItemData value) => value.ExistStartTime <= 0.0 || Singleton<TimeUtil>.Instance.IsInTimeSpan(value.ExistStartTime, value.ExistEndTime));
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				this.SelectedReagentProductionIndex = ((!this.KeepSelectOnSort) ? 0 : this.SelectedReagentProductionIndex);
				this.ReagentProductionDataList = list2.ConvertAll<IReagentProductionData>(([Nullable(1)] IBaseItemData v) => v as IReagentProductionData);
				break;
			case EComposeListType.Structure:
				this.SelectedStructureIndex = ((!this.KeepSelectOnSort) ? 0 : this.SelectedStructureIndex);
				this.StructureDataList = list2.ConvertAll<IStructureData>(([Nullable(1)] IBaseItemData v) => v as IStructureData);
				break;
			case EComposeListType.Purification:
				this.SelectedPurificationIndex = ((!this.KeepSelectOnSort) ? 0 : this.SelectedPurificationIndex);
				this.PurificationDataList = list2.ConvertAll<IPurificationData>(([Nullable(1)] IBaseItemData v) => v as IPurificationData);
				break;
			}
			this.ComposeItemScrollView.DeselectCurrentGridProxy(false);
			this.RefreshItemScrollView();
			if (list2.Count == 0)
			{
				base.GetItem(8).SetUIActive(true);
				this.ComposeDetailsInfoView.SetActive(false);
				return;
			}
			base.GetItem(8).SetUIActive(false);
			this.ComposeDetailsInfoView.SetActive(true);
			this.SetSelectedComposeItem(!this.KeepSelectOnSort);
		}

		// Token: 0x0603A3DE RID: 238558 RVA: 0x00EC27C4 File Offset: 0x00EC09C4
		private void OnCookResponse()
		{
			this.KeepSelectOnSort = true;
			this.SwitchComposeItemScroll();
			this.KeepSelectOnSort = false;
		}

		// Token: 0x0603A3DF RID: 238559 RVA: 0x00EC27DC File Offset: 0x00EC09DC
		private void RefreshItemScrollView()
		{
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
				this.ComposeItemScrollView.RefreshByData(this.ReagentProductionDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IReagentProductionData v) => v), false, null, false);
				return;
			case EComposeListType.Structure:
				this.ComposeItemScrollView.RefreshByData(this.StructureDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IStructureData v) => v), false, null, false);
				return;
			case EComposeListType.Purification:
				this.ComposeItemScrollView.RefreshByData(this.PurificationDataList.ConvertAll<IBaseItemData>(([Nullable(1)] IPurificationData v) => v), false, null, false);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603A3E0 RID: 238560 RVA: 0x00EC28B3 File Offset: 0x00EC0AB3
		private void OnShowRedDot()
		{
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.ComposeReagentProduction, base.GetItem(7), null, 0);
		}

		// Token: 0x0603A3E1 RID: 238561 RVA: 0x00EC28CA File Offset: 0x00EC0ACA
		private void ShowComposeLevelView()
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeLevelType;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ComposeLevelView, null, null);
		}

		// Token: 0x0603A3E2 RID: 238562 RVA: 0x00EC28E8 File Offset: 0x00EC0AE8
		private void ShowComposeRoleView(int id)
		{
			ModelBase<ComposeModel>.Instance.CurrentComposeViewType = EComposeViewType.ComposeRoleType;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ManufactureHelpRoleView, id, null);
		}

		// Token: 0x0603A3E3 RID: 238563 RVA: 0x00EC290C File Offset: 0x00EC0B0C
		private void SwitchMainTitleByListType()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				childPopView.PopItem.SetTitleVisible(true);
			}
			switch (ModelBase<ComposeModel>.Instance.CurrentComposeListType)
			{
			case EComposeListType.ReagentProduction:
			{
				IUiPopFrameInterface childPopView2 = this.ChildPopView;
				if (childPopView2 == null)
				{
					return;
				}
				childPopView2.PopItem.SetTitleText(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ReagentProduction") ?? "");
				return;
			}
			case EComposeListType.Structure:
			{
				IUiPopFrameInterface childPopView3 = this.ChildPopView;
				if (childPopView3 == null)
				{
					return;
				}
				childPopView3.PopItem.SetTitleText(ConfigBase<TextConfig>.Instance.GetTextContentIdById("Structure") ?? "");
				return;
			}
			case EComposeListType.Purification:
			{
				IUiPopFrameInterface childPopView4 = this.ChildPopView;
				if (childPopView4 == null)
				{
					return;
				}
				childPopView4.PopItem.SetTitleText(ConfigBase<TextConfig>.Instance.GetTextContentIdById("Purification") ?? "");
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603A3E4 RID: 238564 RVA: 0x00EC29DC File Offset: 0x00EC0BDC
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			LoopScrollView<ComposeMediumItemGrid, IBaseItemData> composeItemScrollView = this.ComposeItemScrollView;
			if (composeItemScrollView == null || !composeItemScrollView.DataInited)
			{
				return null;
			}
			int displayIndex = int.Parse(configParams[0]);
			UUIItem gridByDisplayIndex = this.ComposeItemScrollView.GetGridByDisplayIndex(displayIndex);
			if (gridByDisplayIndex != null)
			{
				return new UUIItem[]
				{
					gridByDisplayIndex,
					gridByDisplayIndex
				};
			}
			global::Log instance = Singleton<global::Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.JT;
			string message = "合成界面聚焦引导的额外参数配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603A3E5 RID: 238565 RVA: 0x00EC2A54 File Offset: 0x00EC0C54
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|31_0()
		{
			ComposeRootView.<<OnSecondTimerRefresh>g__Temp|31_0>d <<OnSecondTimerRefresh>g__Temp|31_0>d;
			<<OnSecondTimerRefresh>g__Temp|31_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|31_0>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|31_0>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|31_0>d.<>t__builder.Start<ComposeRootView.<<OnSecondTimerRefresh>g__Temp|31_0>d>(ref <<OnSecondTimerRefresh>g__Temp|31_0>d);
			return <<OnSecondTimerRefresh>g__Temp|31_0>d.<>t__builder.Task;
		}

		// Token: 0x0603A3E6 RID: 238566 RVA: 0x00EC2A98 File Offset: 0x00EC0C98
		[CompilerGenerated]
		private UniTask <OnSecondTimerRefresh>g__Temp|31_1()
		{
			ComposeRootView.<<OnSecondTimerRefresh>g__Temp|31_1>d <<OnSecondTimerRefresh>g__Temp|31_1>d;
			<<OnSecondTimerRefresh>g__Temp|31_1>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSecondTimerRefresh>g__Temp|31_1>d.<>4__this = this;
			<<OnSecondTimerRefresh>g__Temp|31_1>d.<>1__state = -1;
			<<OnSecondTimerRefresh>g__Temp|31_1>d.<>t__builder.Start<ComposeRootView.<<OnSecondTimerRefresh>g__Temp|31_1>d>(ref <<OnSecondTimerRefresh>g__Temp|31_1>d);
			return <<OnSecondTimerRefresh>g__Temp|31_1>d.<>t__builder.Task;
		}

		// Token: 0x0603A3E7 RID: 238567 RVA: 0x00EC2ADC File Offset: 0x00EC0CDC
		[CompilerGenerated]
		private UniTask <OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0()
		{
			ComposeRootView.<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d <<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d;
			<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d.<>4__this = this;
			<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d.<>1__state = -1;
			<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d.<>t__builder.Start<ComposeRootView.<<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d>(ref <<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d);
			return <<OnBeginPlayCompositeWorkingDisplay>g__Temp|35_0>d.<>t__builder.Task;
		}

		// Token: 0x0402101E RID: 135198
		private const int TIMERGAP = 1000;

		// Token: 0x0402101F RID: 135199
		private int SelectedReagentProductionIndex;

		// Token: 0x04021020 RID: 135200
		private int SelectedStructureIndex;

		// Token: 0x04021021 RID: 135201
		private int SelectedPurificationIndex;

		// Token: 0x04021022 RID: 135202
		[Nullable(2)]
		private ComposeIngredientsView ComposeDetailsInfoView;

		// Token: 0x04021023 RID: 135203
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MainTypeItem, EComposeListType> MainTypeHorizontal;

		// Token: 0x04021024 RID: 135204
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<ComposeMediumItemGrid, IBaseItemData> ComposeItemScrollView;

		// Token: 0x04021025 RID: 135205
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterEntrance<IBaseItemData> FilterComponent;

		// Token: 0x04021026 RID: 135206
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private SortEntrance<IBaseItemData> SortComponent;

		// Token: 0x04021027 RID: 135207
		private List<IReagentProductionData> ReagentProductionDataList = new List<IReagentProductionData>();

		// Token: 0x04021028 RID: 135208
		private List<IStructureData> StructureDataList = new List<IStructureData>();

		// Token: 0x04021029 RID: 135209
		private List<IPurificationData> PurificationDataList = new List<IPurificationData>();

		// Token: 0x0402102A RID: 135210
		[Nullable(2)]
		private StarLevelComponent StartLevelComponent;

		// Token: 0x0402102B RID: 135211
		private bool KeepSelectOnSort;

		// Token: 0x0402102C RID: 135212
		private bool IsEnterSequenceCompleted;

		// Token: 0x0402102D RID: 135213
		[Nullable(2)]
		private CustomPromise WaitUiBlendInCameraSequenceFinished;

		// Token: 0x0402102E RID: 135214
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x0200B99A RID: 47514
		[NullableContext(0)]
		private class EComposeRootDefine
		{
			// Token: 0x04039592 RID: 234898
			public const int ComposeListTypeHorizontalLayout = 0;

			// Token: 0x04039593 RID: 234899
			public const int ComposeListTypeHorizontalLayoutItem = 1;

			// Token: 0x04039594 RID: 234900
			public const int ItemLoopScroll = 2;

			// Token: 0x04039595 RID: 234901
			public const int FilterItem = 3;

			// Token: 0x04039596 RID: 234902
			public const int IngredientDetail = 4;

			// Token: 0x04039597 RID: 234903
			public const int ComposeLevelButton = 5;

			// Token: 0x04039598 RID: 234904
			public const int ComposeLevelSprite = 6;

			// Token: 0x04039599 RID: 234905
			public const int RedDotItem = 7;

			// Token: 0x0403959A RID: 234906
			public const int NoItem = 8;

			// Token: 0x0403959B RID: 234907
			public const int TxtConfirm = 9;

			// Token: 0x0403959C RID: 234908
			public const int SortItem = 10;

			// Token: 0x0403959D RID: 234909
			public const int PnlStar = 11;

			// Token: 0x0403959E RID: 234910
			public const int PnlTime = 12;

			// Token: 0x0403959F RID: 234911
			public const int TxtTime = 13;
		}
	}
}
