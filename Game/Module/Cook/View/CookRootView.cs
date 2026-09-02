using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.FilterSort.Sort.SortEntrance;
using CSharpScript.Game.Module.Interaction;
using CSharpScript.Game.Module.Manufacture.Common;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E23 RID: 24099
	[NullableContext(1)]
	[Nullable(0)]
	public class CookRootView : UiViewBase
	{
		// Token: 0x0603CA23 RID: 248355 RVA: 0x00F65CC5 File Offset: 0x00F63EC5
		public CookRootView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CA24 RID: 248356 RVA: 0x00F65CE4 File Offset: 0x00F63EE4
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
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action(this.OnShowCookLevelView));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CA25 RID: 248357 RVA: 0x00F65F1C File Offset: 0x00F6411C
		protected override UniTask OnBeforeStartAsync()
		{
			CookRootView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CookRootView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CA26 RID: 248358 RVA: 0x00F65F60 File Offset: 0x00F64160
		protected override void OnStart()
		{
			this.CookItemScrollView = new LoopScrollView<CookMediumItemGrid, ICookItemData>(base.GetLoopScrollViewComponent(2), base.GetLoopScrollViewComponent(2).TemplateGrid, new Func<CookMediumItemGrid>(this.OnGridProxyCreate), false);
			this.FilterComponent = new FilterEntrance<ICookItemData>(base.GetItem(3), new TUpdateDataListFunction<ICookItemData>(this.OnFilterRefresh));
			this.SortComponent = new SortEntrance<ICookItemData>(base.GetItem(10), new TUpdateDataListFunction<ICookItemData>(this.OnSortRefresh));
			this.SortComponent.SetSortToggleState(true);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(9), "CookLevelButtonText", Array.Empty<object>());
			this.StartLevelComponent = new StarLevelComponent(base.GetHorizontalLayout(11));
			if (ModelBase<InteractionModel>.Instance.CurrentInteractEntityId == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Cook, ELogAuthor.WZ, "[LevelEventOpenSystem] 打开烹饪界面时找不到交互对象，直接关闭界面", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.CloseMe(null);
			}
			this.WaitUiBlendInCameraSequenceFinished = new CustomPromise();
			CookModel instance = ModelBase<CookModel>.Instance;
			instance.CurrentInteractCreatureDataLongId = new long?(ModelBase<InteractionModel>.Instance.InteractCreatureDataLongId.Value);
			instance.CurrentCookListType = ECookListType.Cooking;
			this.ShowCookMainView();
			ControllerBase<CookController>.Instance.TryRequestChangeEntityStateByEvent(ECookMechanismState.EnterUi, this);
			Singleton<EventSystem>.Instance.Add(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
			Singleton<EventSystem>.Instance.Add(EEventName.CloseCookRole, new Action(this.CloseCookRole));
		}

		// Token: 0x0603CA27 RID: 248359 RVA: 0x00F660D0 File Offset: 0x00F642D0
		protected override void OnBeforeShow()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			popItem.SetMaskResponsibleState(false);
		}

		// Token: 0x0603CA28 RID: 248360 RVA: 0x00F660F0 File Offset: 0x00F642F0
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			CookRootView.<OnBeforeShowAsyncImplement>d__20 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<CookRootView.<OnBeforeShowAsyncImplement>d__20>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603CA29 RID: 248361 RVA: 0x00F66133 File Offset: 0x00F64333
		protected override void OnAfterShow()
		{
			this.RefreshPopItemVisible();
			this.WaitUiBlendInCameraSequenceFinished = null;
		}

		// Token: 0x0603CA2A RID: 248362 RVA: 0x00F66144 File Offset: 0x00F64344
		private void RefreshPopItemVisible()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			CommonPopViewBase commonPopViewBase = (childPopView != null) ? childPopView.PopItem : null;
			if (commonPopViewBase == null)
			{
				return;
			}
			if (this.IsEnterSequenceCompleted)
			{
				return;
			}
			bool flag = !Singleton<UiCameraAnimationManager>.Instance.IsPlayingBlendInSequence();
			if (commonPopViewBase.GetActive() == flag)
			{
				return;
			}
			commonPopViewBase.SetActive(flag);
		}

		// Token: 0x0603CA2B RID: 248363 RVA: 0x00F66190 File Offset: 0x00F64390
		protected override void OnAfterPlayStartSequence()
		{
			int selectedCookingIndex = this.SelectedCookingIndex;
			this.CookItemScrollView.DeselectCurrentGridProxy(false);
			this.CookItemScrollView.ScrollToGridIndex(selectedCookingIndex, true);
			this.CookItemScrollView.SelectGridProxy(selectedCookingIndex, false);
		}

		// Token: 0x0603CA2C RID: 248364 RVA: 0x00F661CC File Offset: 0x00F643CC
		private void CheckShowTab()
		{
			ModelBase<CookModel>.Instance.CurrentCookViewType = ECookDataType.CookMain;
			List<MainTypeItem> layoutItemList = this.MainTypeVertical.GetLayoutItemList();
			bool flag = false;
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				MainTypeItem mainTypeItem = layoutItemList[i];
				if (this.GetItemListByType(mainTypeItem.GetMainType()).Count > 0 || i == layoutItemList.Count - 1)
				{
					mainTypeItem.SetUiActive(true);
					if (!flag)
					{
						this.MainTypeVertical.SelectGridProxy(mainTypeItem.GridIndex, false);
						ModelBase<CookModel>.Instance.CurrentCookListType = mainTypeItem.GetMainType();
						flag = true;
					}
				}
				else
				{
					mainTypeItem.SetUiActive(false);
				}
			}
		}

		// Token: 0x0603CA2D RID: 248365 RVA: 0x00F66264 File Offset: 0x00F64464
		private void ShowCookMainView()
		{
			this.CheckShowTab();
			this.SetCookLevelSprite();
			this.FilterComponent.UpdateData(EFilterSortGroupId.CookList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookList);
			this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId);
			this.SortComponent.SetResultDataDirty();
			this.SortComponent.UpdateData(EFilterSortGroupId.CookList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId2 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookList);
			this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId2);
			this.OnShowRedDot();
			int cookerMaxLevel = ModelBase<CookModel>.Instance.GetCookerMaxLevel();
			int cookingLevel = ModelBase<CookModel>.Instance.GetCookerInfo().CookingLevel;
			this.StartLevelComponent.ShowLevel(cookingLevel, cookerMaxLevel);
			this.RefreshLimitTime();
		}

		// Token: 0x0603CA2E RID: 248366 RVA: 0x00F66320 File Offset: 0x00F64520
		private void OnShowCookRoleView(int id)
		{
			this.ShowCookRoleView(id);
		}

		// Token: 0x0603CA2F RID: 248367 RVA: 0x00F66329 File Offset: 0x00F64529
		private void ShowCookRoleView(int id)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CookRoleView, id, null);
		}

		// Token: 0x0603CA30 RID: 248368 RVA: 0x00F66341 File Offset: 0x00F64541
		private void OnShowCookLevelView()
		{
			this.ShowCookLevelView();
		}

		// Token: 0x0603CA31 RID: 248369 RVA: 0x00F66349 File Offset: 0x00F64549
		private void ShowCookLevelView()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.CookLevelView, null, null);
		}

		// Token: 0x0603CA32 RID: 248370 RVA: 0x00F6635C File Offset: 0x00F6455C
		protected override void OnAfterHide()
		{
			ModelBase<NewFlagModel>.Instance.SaveNewFlagConfig(ELocalStoragePlayerKey.CookerLevelKey);
		}

		// Token: 0x0603CA33 RID: 248371 RVA: 0x00F6636C File Offset: 0x00F6456C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.UpdateFormula, new Action(this.UpdateCookItemScroll));
			Singleton<EventSystem>.Instance.Add(EEventName.CookSuccess, new Action(this.OnCookSuccess));
			Singleton<EventSystem>.Instance.Add(EEventName.CookFail, new Action(this.OnCookFail));
			Singleton<EventSystem>.Instance.Add(EEventName.MachiningSuccess, new Action(this.OnMachiningSuccess));
			Singleton<EventSystem>.Instance.Add(EEventName.MachiningStudyFail, new Action(this.OnMachiningStudyFail));
			Singleton<EventSystem>.Instance.Add(EEventName.GetCookData, new Action(this.ShowCookMainView));
			Singleton<EventSystem>.Instance.Add(EEventName.OpenCookRole, new Action<int>(this.OnShowCookRoleView));
			Singleton<EventSystem>.Instance.Add(EEventName.OpenCookLevel, new Action(this.OnShowCookLevelView));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBeginPlayCookSuccessDisplay, new Action(this.OnBeginPlayCookSuccessDisplay));
			Singleton<EventSystem>.Instance.Add(EEventName.OnBeginPlayCookFailDisplay, new Action(this.OnBeginPlayCookFailDisplay));
			Singleton<EventSystem>.Instance.Add(EEventName.OnPlayCookSuccessDisplayFinished, new Action(this.OnPlayCookSuccessDisplayFinished));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			ControllerBase<InputDistributeController>.Instance.BindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnSkipSequenceForAction));
			ControllerBase<InputDistributeController>.Instance.BindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnSkipSequenceForTouch));
			this.RefreshTimer = TimerSystem.Instance.Forever(new TTimerAction(this.OnSecondTimerRefresh), 1000f, 1f, null, null, true);
		}

		// Token: 0x0603CA34 RID: 248372 RVA: 0x00F66524 File Offset: 0x00F64724
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFormula, new Action(this.UpdateCookItemScroll));
			Singleton<EventSystem>.Instance.Remove(EEventName.CookSuccess, new Action(this.OnCookSuccess));
			Singleton<EventSystem>.Instance.Remove(EEventName.CookFail, new Action(this.OnCookFail));
			Singleton<EventSystem>.Instance.Remove(EEventName.MachiningSuccess, new Action(this.OnMachiningSuccess));
			Singleton<EventSystem>.Instance.Remove(EEventName.MachiningStudyFail, new Action(this.OnMachiningStudyFail));
			Singleton<EventSystem>.Instance.Remove(EEventName.GetCookData, new Action(this.ShowCookMainView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenCookRole, new Action<int>(this.OnShowCookRoleView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OpenCookLevel, new Action(this.OnShowCookLevelView));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBeginPlayCookSuccessDisplay, new Action(this.OnBeginPlayCookSuccessDisplay));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnBeginPlayCookFailDisplay, new Action(this.OnBeginPlayCookFailDisplay));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPlayCookSuccessDisplayFinished, new Action(this.OnPlayCookSuccessDisplayFinished));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnCloseView));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("UI左键点击", new TInputHandle<InputDistributeDefine.EActionType>(this.OnSkipSequenceForAction));
			ControllerBase<InputDistributeController>.Instance.UnBindTouch(0, new TInputHandle<InputDistributeDefine.ITouchData>(this.OnSkipSequenceForTouch));
			if (this.RefreshTimer != null && TimerSystem.Instance.Has(this.RefreshTimer))
			{
				TimerSystem.Instance.Remove(this.RefreshTimer);
				this.RefreshTimer = null;
			}
		}

		// Token: 0x0603CA35 RID: 248373 RVA: 0x00F666E2 File Offset: 0x00F648E2
		private MainTypeItem InitMainTypeItem()
		{
			MainTypeItem mainTypeItem = new MainTypeItem();
			mainTypeItem.SetMainTypeCallback(new Action<int>(this.OnSwitchCallback));
			return mainTypeItem;
		}

		// Token: 0x0603CA36 RID: 248374 RVA: 0x00F666FC File Offset: 0x00F648FC
		private void OnSecondTimerRefresh(float _)
		{
			this.RefreshLimitTime();
			CookingIngredientsView cookTipsView = this.CookTipsView;
			if (cookTipsView != null)
			{
				cookTipsView.OnSecondTimerRefresh();
			}
			if (this.CheckIsLimitCountRefresh() || this.CheckHasItemTimeoutStateChanged())
			{
				ControllerBase<CookController>.Instance.SendCookingDataRequestAsync().ContinueWith(delegate(bool result)
				{
					if (result)
					{
						this.UpdateCookItemScroll();
					}
				});
				return;
			}
			if (this.CheckHasItemTimeOut())
			{
				ControllerBase<CookController>.Instance.SendCookingDataRequestAsync().ContinueWith(delegate(bool result)
				{
					if (result)
					{
						this.FilterComponent.UpdateData(EFilterSortGroupId.CookList, this.GetItemList(), Array.Empty<object>());
						int uniqueIdByGroupId = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookList);
						this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId);
					}
				});
			}
		}

		// Token: 0x0603CA37 RID: 248375 RVA: 0x00F66774 File Offset: 0x00F64974
		private void RefreshLimitTime()
		{
			string refreshLimitTime = ModelBase<CookModel>.Instance.GetRefreshLimitTime();
			if (refreshLimitTime != null)
			{
				base.GetItem(12).SetUIActive(true);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), "RefreshTime", new <>z__ReadOnlySingleElementList<object>(refreshLimitTime));
				return;
			}
			base.GetItem(12).SetUIActive(false);
		}

		// Token: 0x0603CA38 RID: 248376 RVA: 0x00F667C9 File Offset: 0x00F649C9
		private bool CheckIsLimitCountRefresh()
		{
			return ModelBase<CookModel>.Instance.GetRefreshLimitTimeValue() <= 0.0;
		}

		// Token: 0x0603CA39 RID: 248377 RVA: 0x00F667E3 File Offset: 0x00F649E3
		private bool CheckHasItemTimeoutStateChanged()
		{
			return ModelBase<CookModel>.Instance.CheckHasItemTimeoutStateChangedCore();
		}

		// Token: 0x0603CA3A RID: 248378 RVA: 0x00F667F0 File Offset: 0x00F649F0
		private bool CheckHasItemTimeOut()
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				List<ICookItemData> itemList = this.GetItemList();
				for (int i = 0; i < itemList.Count; i++)
				{
					ICookingData cookingData = (ICookingData)itemList[i];
					if (cookingData.ExistEndTime > 0.0 && !Singleton<TimeUtil>.Instance.IsInTimeSpan(cookingData.ExistStartTime, cookingData.ExistEndTime))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603CA3B RID: 248379 RVA: 0x00F6685A File Offset: 0x00F64A5A
		private CookMediumItemGrid OnGridProxyCreate()
		{
			CookMediumItemGrid cookMediumItemGrid = new CookMediumItemGrid();
			cookMediumItemGrid.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnCookItemClick));
			return cookMediumItemGrid;
		}

		// Token: 0x0603CA3C RID: 248380 RVA: 0x00F66874 File Offset: 0x00F64A74
		private void SetCookLevelSprite()
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_CookLevel");
			this.SetSpriteByPath(resourcePath, base.GetSprite(6), false, null, null);
		}

		// Token: 0x0603CA3D RID: 248381 RVA: 0x00F668AC File Offset: 0x00F64AAC
		private void OnShowRedDot()
		{
			UUIItem item = base.GetItem(7);
			ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.CookerLevel, item, null, 0);
		}

		// Token: 0x0603CA3E RID: 248382 RVA: 0x00F668D0 File Offset: 0x00F64AD0
		public void DisableRedDot()
		{
			ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.CookerLevel);
		}

		// Token: 0x0603CA3F RID: 248383 RVA: 0x00F668E0 File Offset: 0x00F64AE0
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
			this.IsEnterSequenceCompleted = true;
		}

		// Token: 0x0603CA40 RID: 248384 RVA: 0x00F66939 File Offset: 0x00F64B39
		private void OnFilterRefresh(List<ICookItemData> list, bool isOutSideChange, EFilterSortType t)
		{
			this.CookItemScrollView.DeselectCurrentGridProxy(false);
			this.SelectedCookingIndex = 0;
			this.OnFilterSortRefresh(list);
		}

		// Token: 0x0603CA41 RID: 248385 RVA: 0x00F66955 File Offset: 0x00F64B55
		private void OnSortRefresh(List<ICookItemData> list, bool isOutSideChange, EFilterSortType t)
		{
			this.OnFilterSortRefresh(list);
		}

		// Token: 0x0603CA42 RID: 248386 RVA: 0x00F66960 File Offset: 0x00F64B60
		private void OnFilterSortRefresh(List<ICookItemData> list)
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				this.CookItemDataList = new List<ICookingData>();
				using (List<ICookItemData>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ICookItemData cookItemData = enumerator.Current;
						ICookingData cookingData = cookItemData as ICookingData;
						if (cookingData != null && (cookingData.IsUnLock || cookingData.ExistEndTime <= 0.0 || Singleton<TimeUtil>.Instance.IsInTimeSpan(cookingData.ExistStartTime, cookingData.ExistEndTime)))
						{
							this.CookItemDataList.Add(cookingData);
						}
					}
					goto IL_ED;
				}
			}
			this.MachiningDataList = new List<IMachiningData>();
			foreach (ICookItemData cookItemData2 in list)
			{
				IMachiningData machiningData = cookItemData2 as IMachiningData;
				if (machiningData != null)
				{
					this.MachiningDataList.Add(machiningData);
				}
			}
			IL_ED:
			this.RefreshItemScrollView(delegate
			{
				if (list.Count > 0)
				{
					this.SetSelectedCookItem(true);
				}
			});
			if (list.Count == 0)
			{
				base.GetItem(8).SetUIActive(true);
				this.CookTipsView.SetUiActive(false);
				return;
			}
			base.GetItem(8).SetUIActive(false);
			this.CookTipsView.SetUiActive(true);
		}

		// Token: 0x0603CA43 RID: 248387 RVA: 0x00F66AC8 File Offset: 0x00F64CC8
		private void UpdateCookItemScroll()
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				this.FilterComponent.UpdateData(EFilterSortGroupId.CookList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookList);
				this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId);
				this.SortComponent.SetResultDataDirty();
				this.SortComponent.UpdateData(EFilterSortGroupId.CookList, this.GetItemList(), Array.Empty<object>());
				int uniqueIdByGroupId2 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookList);
				this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId2);
				return;
			}
			this.FilterComponent.UpdateData(EFilterSortGroupId.CookMachiningList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId3 = this.FilterComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookMachiningList);
			this.SortComponent.SetFilterUniqueId(uniqueIdByGroupId3);
			this.SortComponent.SetResultDataDirty();
			this.SortComponent.UpdateData(EFilterSortGroupId.CookMachiningList, this.GetItemList(), Array.Empty<object>());
			int uniqueIdByGroupId4 = this.SortComponent.GetUniqueIdByGroupId(EFilterSortGroupId.CookMachiningList);
			this.FilterComponent.SetSortUniqueId(uniqueIdByGroupId4);
		}

		// Token: 0x0603CA44 RID: 248388 RVA: 0x00F66BC0 File Offset: 0x00F64DC0
		private void OnCookSuccess()
		{
			this.UpdateTipsViewWithSavedData(true);
		}

		// Token: 0x0603CA45 RID: 248389 RVA: 0x00F66BC9 File Offset: 0x00F64DC9
		private void OnCookFail()
		{
			this.UpdateTipsViewWithSavedData(true);
		}

		// Token: 0x0603CA46 RID: 248390 RVA: 0x00F66BD2 File Offset: 0x00F64DD2
		private void OnMachiningSuccess()
		{
			this.UpdateTipsViewWithSavedData(true);
		}

		// Token: 0x0603CA47 RID: 248391 RVA: 0x00F66BDB File Offset: 0x00F64DDB
		private void OnMachiningStudyFail()
		{
			this.UpdateTipsViewWithSavedData(true);
		}

		// Token: 0x0603CA48 RID: 248392 RVA: 0x00F66BE4 File Offset: 0x00F64DE4
		private void UpdateTipsViewWithSavedData(bool isNeedScroll = true)
		{
			this.RefreshItemScrollView(delegate
			{
				this.SetSelectedCookItem(isNeedScroll);
			});
			this.CookTipsView.RefreshTipsWithSavedData();
		}

		// Token: 0x0603CA49 RID: 248393 RVA: 0x00F66C24 File Offset: 0x00F64E24
		private void SwitchMainTitleByListType()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				CommonPopViewBase popItem = childPopView.PopItem;
				if (popItem != null)
				{
					popItem.SetTitleVisible(true);
				}
			}
			ECookListType currentCookListType = ModelBase<CookModel>.Instance.CurrentCookListType;
			if (currentCookListType != ECookListType.Cooking)
			{
				if (currentCookListType != ECookListType.Machining)
				{
					return;
				}
				IUiPopFrameInterface childPopView2 = this.ChildPopView;
				if (childPopView2 == null)
				{
					return;
				}
				CommonPopViewBase popItem2 = childPopView2.PopItem;
				if (popItem2 == null)
				{
					return;
				}
				popItem2.SetTitleText(ConfigBase<TextConfig>.Instance.GetTextContentIdById("MakingAccessory") ?? "");
				return;
			}
			else
			{
				IUiPopFrameInterface childPopView3 = this.ChildPopView;
				if (childPopView3 == null)
				{
					return;
				}
				CommonPopViewBase popItem3 = childPopView3.PopItem;
				if (popItem3 == null)
				{
					return;
				}
				popItem3.SetTitleText(ConfigBase<TextConfig>.Instance.GetTextContentIdById("MakingDishes") ?? "");
				return;
			}
		}

		// Token: 0x0603CA4A RID: 248394 RVA: 0x00F66CC8 File Offset: 0x00F64EC8
		private List<ICookItemData> GetItemListByType(ECookListType type)
		{
			if (type == ECookListType.Cooking)
			{
				return ModelBase<CookModel>.Instance.GetCookingDataList().ConvertAll<ICookItemData>(([Nullable(1)] ICookingData v) => v);
			}
			return ModelBase<CookModel>.Instance.GetMachiningDataList().ConvertAll<ICookItemData>(([Nullable(1)] IMachiningData v) => v);
		}

		// Token: 0x0603CA4B RID: 248395 RVA: 0x00F66D35 File Offset: 0x00F64F35
		private List<ICookItemData> GetItemList()
		{
			return this.GetItemListByType(ModelBase<CookModel>.Instance.CurrentCookListType);
		}

		// Token: 0x0603CA4C RID: 248396 RVA: 0x00F66D48 File Offset: 0x00F64F48
		private void RefreshItemScrollView(Action refreshDoneCallback)
		{
			this.CookItemScrollView.DeselectCurrentGridProxy(false);
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				this.CookItemScrollView.RefreshByData(this.CookItemDataList.ConvertAll<ICookItemData>(([Nullable(1)] ICookingData v) => v), false, refreshDoneCallback, false);
				return;
			}
			this.CookItemScrollView.RefreshByData(this.MachiningDataList.ConvertAll<ICookItemData>(([Nullable(1)] IMachiningData v) => v), false, refreshDoneCallback, false);
		}

		// Token: 0x0603CA4D RID: 248397 RVA: 0x00F66DE0 File Offset: 0x00F64FE0
		private void SetSelectedCookItem(bool isNeedScroll = false)
		{
			CookRootView.<>c__DisplayClass58_0 CS$<>8__locals1 = new CookRootView.<>c__DisplayClass58_0();
			CS$<>8__locals1.<>4__this = this;
			CS$<>8__locals1.index = 0;
			if (ModelBase<CookModel>.Instance.CurrentCookListType == ECookListType.Cooking)
			{
				CS$<>8__locals1.index = this.SelectedCookingIndex;
				this.CookTipsView.RefreshTips(this.CookItemDataList[CS$<>8__locals1.index]);
			}
			else
			{
				CS$<>8__locals1.index = this.SelectedMachiningIndex;
				this.CookTipsView.RefreshTips(this.MachiningDataList[CS$<>8__locals1.index]);
			}
			this.CookItemScrollView.DeselectCurrentGridProxy(false);
			if (isNeedScroll)
			{
				CS$<>8__locals1.<SetSelectedCookItem>g__Temp|0().Forget();
			}
			this.CookItemScrollView.SelectGridProxy(CS$<>8__locals1.index, false);
		}

		// Token: 0x0603CA4E RID: 248398 RVA: 0x00F66E8C File Offset: 0x00F6508C
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnExecuteUiCameraSequenceEvent, new Action<string>(this.OnExecuteUiCameraSequenceEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseCookRole, new Action(this.CloseCookRole));
			ControllerBase<CookController>.Instance.TryRequestChangeEntityStateByEvent(ECookMechanismState.CloseUi, this);
			ControllerBase<CookController>.Instance.ClearCookDisplay();
			this.DisableRedDot();
			if (this.CookItemScrollView != null)
			{
				this.CookItemScrollView.ClearGridProxies();
				this.CookItemScrollView = null;
			}
			if (this.FilterComponent != null)
			{
				this.FilterComponent.Destroy(null);
				this.FilterComponent = null;
			}
			if (this.SortComponent != null)
			{
				this.SortComponent.Destroy(null);
			}
			if (this.MainTypeVertical != null)
			{
				this.MainTypeVertical.ClearChildren();
				this.MainTypeVertical = null;
			}
			this.StartLevelComponent.Clear();
			CookModel instance = ModelBase<CookModel>.Instance;
			instance.CurrentCookRoleId = null;
			instance.ClearCookRoleItemDataList();
			this.WaitUiBlendInCameraSequenceFinished = null;
		}

		// Token: 0x0603CA4F RID: 248399 RVA: 0x00F66F7F File Offset: 0x00F6517F
		private void OnBeginPlayCookSuccessDisplay()
		{
			this.<OnBeginPlayCookSuccessDisplay>g__Temp|60_0().Forget();
		}

		// Token: 0x0603CA50 RID: 248400 RVA: 0x00F66F8C File Offset: 0x00F6518C
		private void OnBeginPlayCookFailDisplay()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			popItem.SetUiActive(false);
		}

		// Token: 0x0603CA51 RID: 248401 RVA: 0x00F66FA9 File Offset: 0x00F651A9
		private void OnPlayCookSuccessDisplayFinished()
		{
			ControllerBase<CookController>.Instance.TryRequestChangeEntityStateByEvent(ECookMechanismState.CookDone, this);
		}

		// Token: 0x0603CA52 RID: 248402 RVA: 0x00F66FBC File Offset: 0x00F651BC
		private void OnCloseView(EUiViewName viewName, int viewId)
		{
			if (viewName != EUiViewName.CompositeRewardView)
			{
				return;
			}
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView != null)
			{
				CommonPopViewBase popItem = childPopView.PopItem;
				if (popItem != null)
				{
					popItem.SetActive(true);
				}
			}
			IUiPopFrameInterface childPopView2 = this.ChildPopView;
			if (childPopView2 == null)
			{
				return;
			}
			childPopView2.PlayLevelSequenceByName("Start", false);
		}

		// Token: 0x0603CA53 RID: 248403 RVA: 0x00F6700A File Offset: 0x00F6520A
		private void CloseCookRole()
		{
			this.CookTipsView.RefreshCooking();
		}

		// Token: 0x0603CA54 RID: 248404 RVA: 0x00F67017 File Offset: 0x00F65217
		private void OnSkipSequence()
		{
			if (ControllerBase<CookController>.Instance.IsPlayingSuccessDisplay)
			{
				ControllerBase<CookController>.Instance.SkipCookSuccessDisplay();
				return;
			}
			if (ControllerBase<CookController>.Instance.IsPlayingFailDisplay)
			{
				ControllerBase<CookController>.Instance.SkipCookFailDisplay();
			}
		}

		// Token: 0x0603CA55 RID: 248405 RVA: 0x00F67046 File Offset: 0x00F65246
		private void OnSkipSequenceForAction(string arg1, InputDistributeDefine.EActionType arg2, InputIdentification arg3)
		{
			this.OnSkipSequence();
		}

		// Token: 0x0603CA56 RID: 248406 RVA: 0x00F6704E File Offset: 0x00F6524E
		private void OnSkipSequenceForTouch(string arg1, InputDistributeDefine.ITouchData arg2, InputIdentification arg3)
		{
			this.OnSkipSequence();
		}

		// Token: 0x0603CA57 RID: 248407 RVA: 0x00F67058 File Offset: 0x00F65258
		private void OnSwitchCallback(int mainType)
		{
			if (ModelBase<CookModel>.Instance.CurrentCookListType == (ECookListType)mainType)
			{
				return;
			}
			if (mainType == 0)
			{
				ModelBase<CookModel>.Instance.CurrentCookListType = ECookListType.Cooking;
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchCookType);
				base.GetItem(3).SetUIActive(true);
				this.IsSwitchType = true;
				this.UpdateCookItemScroll();
			}
			else
			{
				ModelBase<CookModel>.Instance.CurrentCookListType = ECookListType.Machining;
				Singleton<EventSystem>.Instance.Emit(EEventName.SwitchCookType);
				this.IsSwitchType = true;
				base.GetItem(3).SetUIActive(false);
				this.UpdateCookItemScroll();
			}
			this.SwitchMainTitleByListType();
			this.IsSwitchType = false;
		}

		// Token: 0x0603CA58 RID: 248408 RVA: 0x00F670F0 File Offset: 0x00F652F0
		private void OnCookItemClick(MediumItemGridExtendCallback callbackParameter)
		{
			ICookItemData cookItemData = callbackParameter.Data as ICookItemData;
			this.CookItemScrollView.DeselectCurrentGridProxy(false);
			int gridIndex;
			if (cookItemData.MainType == ECookListType.Cooking)
			{
				ICookingData cookingData = cookItemData as ICookingData;
				this.SelectedCookingIndex = this.CookItemDataList.IndexOf(cookingData);
				gridIndex = this.SelectedCookingIndex;
				this.CookTipsView.RefreshTips(cookingData);
			}
			else
			{
				IMachiningData machiningData = cookItemData as IMachiningData;
				this.SelectedMachiningIndex = this.MachiningDataList.IndexOf(machiningData);
				gridIndex = this.SelectedMachiningIndex;
				this.CookTipsView.RefreshTips(machiningData);
			}
			if (!this.CookItemScrollView.IsGridDisplaying(gridIndex))
			{
				return;
			}
			if (cookItemData.IsNew && !this.IsSwitchType)
			{
				ModelBase<NewFlagModel>.Instance.RemoveNewFlag(ELocalStoragePlayerKey.CookerLevelKey, cookItemData.ItemId);
				cookItemData.IsNew = false;
			}
			this.CookItemScrollView.SelectGridProxy(gridIndex, false);
			this.CookItemScrollView.RefreshGridProxy(gridIndex);
			this.SwitchMainTitleByListType();
			this.IsSwitchType = false;
		}

		// Token: 0x0603CA59 RID: 248409 RVA: 0x00F671D8 File Offset: 0x00F653D8
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			UUIItem guideUiItem = base.GetGuideUiItem(configParams[0]);
			if (guideUiItem != null)
			{
				return new UUIItem[]
				{
					guideUiItem,
					guideUiItem
				};
			}
			int num = int.Parse(configParams[0]);
			LoopScrollView<CookMediumItemGrid, ICookItemData> cookItemScrollView = this.CookItemScrollView;
			if (cookItemScrollView == null || !cookItemScrollView.DataInited)
			{
				return null;
			}
			if (num != 0)
			{
				UUIItem gridAndScrollToByJudge = this.CookItemScrollView.GetGridAndScrollToByJudge(num, delegate(object tempItemId, ICookItemData picked)
				{
					if (picked.MainType != ECookListType.Cooking)
					{
						return false;
					}
					ICookingData cookingData = (ICookingData)picked;
					return cookingData.SubType == ESubCookDataType.CookMenu && (int)tempItemId == cookingData.DataId;
				}, true);
				if (gridAndScrollToByJudge != null)
				{
					return new UUIItem[]
					{
						gridAndScrollToByJudge,
						gridAndScrollToByJudge
					};
				}
			}
			else
			{
				UUIItem gridByDisplayIndex = this.CookItemScrollView.GetGridByDisplayIndex(0);
				if (gridByDisplayIndex != null)
				{
					return new UUIItem[]
					{
						gridByDisplayIndex,
						gridByDisplayIndex
					};
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Guide;
			ELogAuthor author = ELogAuthor.TL;
			string message = "烹饪界面聚焦引导的额外参数配置错误";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("configParams", configParams);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}

		// Token: 0x0603CA5C RID: 248412 RVA: 0x00F67304 File Offset: 0x00F65504
		[CompilerGenerated]
		private UniTask <OnBeginPlayCookSuccessDisplay>g__Temp|60_0()
		{
			CookRootView.<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d <<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d;
			<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d.<>4__this = this;
			<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d.<>1__state = -1;
			<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d.<>t__builder.Start<CookRootView.<<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d>(ref <<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d);
			return <<OnBeginPlayCookSuccessDisplay>g__Temp|60_0>d.<>t__builder.Task;
		}

		// Token: 0x04022108 RID: 139528
		public const int TIMERGAP = 1000;

		// Token: 0x04022109 RID: 139529
		private int SelectedCookingIndex;

		// Token: 0x0402210A RID: 139530
		private int SelectedMachiningIndex;

		// Token: 0x0402210B RID: 139531
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<MainTypeItem, ECookListType> MainTypeVertical;

		// Token: 0x0402210C RID: 139532
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<CookMediumItemGrid, ICookItemData> CookItemScrollView;

		// Token: 0x0402210D RID: 139533
		private List<ICookingData> CookItemDataList = new List<ICookingData>();

		// Token: 0x0402210E RID: 139534
		private List<IMachiningData> MachiningDataList = new List<IMachiningData>();

		// Token: 0x0402210F RID: 139535
		[Nullable(2)]
		private CookingIngredientsView CookTipsView;

		// Token: 0x04022110 RID: 139536
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private FilterEntrance<ICookItemData> FilterComponent;

		// Token: 0x04022111 RID: 139537
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private SortEntrance<ICookItemData> SortComponent;

		// Token: 0x04022112 RID: 139538
		private bool IsSwitchType;

		// Token: 0x04022113 RID: 139539
		[Nullable(2)]
		private StarLevelComponent StartLevelComponent;

		// Token: 0x04022114 RID: 139540
		[Nullable(2)]
		private CustomPromise WaitUiBlendInCameraSequenceFinished;

		// Token: 0x04022115 RID: 139541
		private bool IsEnterSequenceCompleted;

		// Token: 0x04022116 RID: 139542
		[Nullable(2)]
		private TimerHandle RefreshTimer;

		// Token: 0x0200BE57 RID: 48727
		[NullableContext(0)]
		public enum ECookMainDefine
		{
			// Token: 0x0403A9A1 RID: 240033
			CookListTypeHorizontalLayout,
			// Token: 0x0403A9A2 RID: 240034
			CookListTypeHorizontalLayoutItem,
			// Token: 0x0403A9A3 RID: 240035
			ItemLoopScroll,
			// Token: 0x0403A9A4 RID: 240036
			FilterItem,
			// Token: 0x0403A9A5 RID: 240037
			IngredientDetail,
			// Token: 0x0403A9A6 RID: 240038
			CookLevelExtendToggle,
			// Token: 0x0403A9A7 RID: 240039
			CookLevelSprite,
			// Token: 0x0403A9A8 RID: 240040
			RedDotItem,
			// Token: 0x0403A9A9 RID: 240041
			NoItem,
			// Token: 0x0403A9AA RID: 240042
			TxtConfirm,
			// Token: 0x0403A9AB RID: 240043
			SortItem,
			// Token: 0x0403A9AC RID: 240044
			PnlStar,
			// Token: 0x0403A9AD RID: 240045
			PnlTime,
			// Token: 0x0403A9AE RID: 240046
			TxtTime
		}
	}
}
