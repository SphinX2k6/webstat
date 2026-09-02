using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Guide.StepInfo;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001E2E RID: 7726
[NullableContext(1)]
[Nullable(0)]
public class GuideFocusView : GuideBaseView
{
	// Token: 0x0600E47E RID: 58494 RVA: 0x003DA103 File Offset: 0x003D8303
	public GuideFocusView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E47F RID: 58495 RVA: 0x003DA12E File Offset: 0x003D832E
	protected override void OnBeforeGuideBaseViewCreate()
	{
		this.Config = new GuideFocusNew?((GuideFocusNew)this.GuideStepInfo.ViewData.ViewConf);
		this.BindInputAfterSequence();
	}

	// Token: 0x0600E480 RID: 58496 RVA: 0x003DA158 File Offset: 0x003D8358
	protected override void OnGuideBaseViewStart()
	{
		base.GetRootItem().SetAlpha(0f);
		this.FindAttachmentTime = 4000f;
		if (this.Config.Value.ContentDirection == EGuideFocusTextDir.Down)
		{
			this.StartSequenceName = "StartManualUp";
		}
		else if (this.Config.Value.ContentDirection == EGuideFocusTextDir.Up)
		{
			this.StartSequenceName = "StartManualDown";
		}
		else if (this.Config.Value.ContentDirection == EGuideFocusTextDir.Left)
		{
			this.StartSequenceName = "StartManualRight";
		}
		else if (this.Config.Value.ContentDirection == EGuideFocusTextDir.Right)
		{
			this.StartSequenceName = "StartManualLeft";
		}
		if (this.StartSequenceName != null)
		{
			this.UiViewSequence.AddSequenceFinishEvent(this.StartSequenceName, new Action<string>(this.OnStartSequenceEnd), false);
		}
		if (this.Config != null && this.Config.GetValueOrDefault().HideWhenOtherPopViewOccur)
		{
			UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop);
			if (topView != null)
			{
				string viewName = this.Config.Value.ViewName;
				UiViewInfo viewInfo = topView.ViewInfo;
				EUiViewName? euiViewName = (viewInfo != null) ? new EUiViewName?(viewInfo.Name) : null;
				if (viewName != ((euiViewName != null) ? euiViewName.GetValueOrDefault() : null))
				{
					UiViewInfo viewInfo2 = topView.ViewInfo;
					this.OccurredOtherPopupViewName = ((viewInfo2 != null) ? new EUiViewName?(viewInfo2.Name) : null);
				}
			}
			Singleton<EventSystem>.Instance.Add<EUiViewName, UiViewBase>(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnOtherPopupViewDone));
			Singleton<EventSystem>.Instance.Add<EUiViewName, int>(EEventName.CloseView, new Action<EUiViewName, int>(this.OnOtherPopupViewClose));
		}
	}

	// Token: 0x0600E481 RID: 58497 RVA: 0x003DA348 File Offset: 0x003D8548
	protected override void OnGuideBaseViewAddEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnSkillButtonIndexRefresh, new Action(this.CheckSkillItem));
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
	}

	// Token: 0x0600E482 RID: 58498 RVA: 0x003DA382 File Offset: 0x003D8582
	protected override void OnGuideBaseViewRemoveEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnSkillButtonIndexRefresh, new Action(this.CheckSkillItem));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPreparePhotoScreenShot, new Action<bool>(this.OnPreparePhotoScreenShot));
	}

	// Token: 0x0600E483 RID: 58499 RVA: 0x003DA3BC File Offset: 0x003D85BC
	protected override void OnGuideViewAfterShow()
	{
		this.RootItem.SetRaycastTarget(false);
		this.CheckAttachedItemVisible();
		this.BindInputAfterSequence();
		Singleton<InputManager>.Instance.SetShowCursor(this.Config.Value.ShowMouse, true);
	}

	// Token: 0x0600E484 RID: 58500 RVA: 0x003DA400 File Offset: 0x003D8600
	protected override void OnGuideBaseViewAfterHide()
	{
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
		string[] inputEnums = this.Config.Value.InputEnums();
		base.UnbindInput(this.Config.Value.InputEnums(), inputEnums);
		Singleton<EventSystem>.Instance.Emit(EEventName.RefreshCursor);
	}

	// Token: 0x0600E485 RID: 58501 RVA: 0x003DA45C File Offset: 0x003D865C
	protected override void OnGuideBaseViewDestroy()
	{
		if (this.FocusItem != null)
		{
			this.FocusItem.Destroy(null);
			this.FocusItem = null;
		}
		if (this.Config != null && this.Config.GetValueOrDefault().HideWhenOtherPopViewOccur)
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnViewDone, new Action<EUiViewName, UiViewBase>(this.OnOtherPopupViewDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.CloseView, new Action<EUiViewName, int>(this.OnOtherPopupViewClose));
		}
	}

	// Token: 0x170011CB RID: 4555
	// (get) Token: 0x0600E486 RID: 58502 RVA: 0x003DA4D8 File Offset: 0x003D86D8
	private bool IsSkillButtonGuide
	{
		get
		{
			return this.Config.Value.ViewName == EUiViewName.BattleView && this.Config.Value.ExtraParam() != null && this.Config.Value.ExtraParam().Length != 0 && this.Config.Value.ExtraParam()[0] == "Skill";
		}
	}

	// Token: 0x0600E487 RID: 58503 RVA: 0x003DA558 File Offset: 0x003D8758
	private void CheckSkillItem()
	{
		if (this.IsSkillButtonGuide)
		{
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.BattleView);
			UUIItem[] array = (viewByName != null) ? viewByName.GetGuideUiItemAndUiItemForShowEx(this.Config.Value.ExtraParam()) : null;
			if (array != null)
			{
				UUIItem uuiitem = array[0];
				GuideStepInfo guideStepInfo = this.GuideStepInfo;
				object obj;
				if (guideStepInfo == null)
				{
					obj = null;
				}
				else
				{
					GuideStepViewData viewData = guideStepInfo.ViewData;
					obj = ((viewData != null) ? viewData.GetAttachedUiItem() : null);
				}
				if (uuiitem == obj)
				{
					return;
				}
			}
			this.GuideStepInfo.SwitchState(EGuideStepState.Break);
		}
	}

	// Token: 0x0600E488 RID: 58504 RVA: 0x003DA5D0 File Offset: 0x003D87D0
	protected override void OnGuideBaseViewTick(float delta)
	{
		this.CheckAttachedItemVisible();
		if (base.IsShow && this.Config.Value.ShowMouse)
		{
			Singleton<InputManager>.Instance.SetShowCursor(true, true);
		}
		GuideFocusItem focusItem = this.FocusItem;
		if (focusItem != null)
		{
			focusItem.OnTick(delta);
		}
		this.ShowInner();
		if (this.IsAttachViewReady && !this.IsAttachItemsReady)
		{
			this.FindAttachmentTime -= delta;
			if (this.FindAttachmentTime < 0f)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Guide;
				ELogAuthor author = ELogAuthor.JT;
				string message = "[Guide][引导界面打开后5秒后目标没有显示出来,触发保底]";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("步骤Id", this.GuideStepInfo.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				base.CloseMe(null);
			}
		}
	}

	// Token: 0x0600E489 RID: 58505 RVA: 0x003DA68C File Offset: 0x003D888C
	protected override void OnDurationChange(float remainDuration)
	{
		GuideFocusItem focusItem = this.FocusItem;
		if (focusItem == null)
		{
			return;
		}
		focusItem.OnDurationChange(remainDuration);
	}

	// Token: 0x0600E48A RID: 58506 RVA: 0x003DA6A0 File Offset: 0x003D88A0
	private bool GetAttachedItemVisible()
	{
		this.IsAttachViewReady = false;
		UiPanelBase attachedView = this.GuideStepInfo.ViewData.GetAttachedView();
		if (attachedView == null)
		{
			return false;
		}
		if (attachedView.GetRootActor() == null)
		{
			return false;
		}
		if (!attachedView.IsUiActiveInHierarchy())
		{
			return false;
		}
		if (!((this.Config != null && this.Config.GetValueOrDefault().CheckShowByIsShowOrShowing) ? attachedView.IsShowOrShowing : attachedView.IsShow))
		{
			return false;
		}
		if (base.HasConflictView())
		{
			return false;
		}
		if (this.HasBlockingPopup())
		{
			return false;
		}
		if (!base.CheckTickCondition())
		{
			return false;
		}
		if (this.OccurredOtherPopupViewName != null)
		{
			return false;
		}
		this.IsAttachViewReady = true;
		if (!this.GuideStepInfo.ViewData.IsMultiAttach)
		{
			UUIItem attachedUiItemForShow = this.GuideStepInfo.ViewData.GetAttachedUiItemForShow();
			return ObjectUtils.IsValid(attachedUiItemForShow) && attachedUiItemForShow.IsUIActiveInHierarchy();
		}
		List<UUIItem> multiAttachItems = this.GuideStepInfo.ViewData.GetMultiAttachItems();
		if (multiAttachItems == null || multiAttachItems.Count == 0)
		{
			return false;
		}
		foreach (UUIItem uuiitem in multiAttachItems)
		{
			if (!ObjectUtils.IsValid(uuiitem) || !uuiitem.IsUIActiveInHierarchy())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600E48B RID: 58507 RVA: 0x003DA7F4 File Offset: 0x003D89F4
	private bool HasBlockingPopup()
	{
		if (this.Config == null)
		{
			return true;
		}
		UiViewBase topView = Singleton<UiModel>.Instance.GetTopView(ELayerType.Pop);
		return topView != null && topView.ViewInfo.Name != this.Config.Value.ViewName && !this.guidePopupIgnoreView.Contains(topView.ViewInfo.Name);
	}

	// Token: 0x0600E48C RID: 58508 RVA: 0x003DA868 File Offset: 0x003D8A68
	private void CheckAttachedItemVisible()
	{
		bool attachedItemVisible = this.GetAttachedItemVisible();
		this.SetActive(attachedItemVisible);
		if (this.IsAttachItemsReady == attachedItemVisible)
		{
			return;
		}
		this.IsAttachItemsReady = attachedItemVisible;
		if (attachedItemVisible)
		{
			base.GetRootItem().SetAlpha(0f);
			this.InitFocusItem();
		}
	}

	// Token: 0x0600E48D RID: 58509 RVA: 0x003DA8B0 File Offset: 0x003D8AB0
	private void OnStartSequenceEnd(string _)
	{
		this.UiViewSequence.PlaySequence("AutoLoopManual", false, null);
	}

	// Token: 0x0600E48E RID: 58510 RVA: 0x003DA8D8 File Offset: 0x003D8AD8
	private void InitFocusItem()
	{
		UUIItem attachedUiItem = this.GuideStepInfo.ViewData.GetAttachedUiItem();
		if (attachedUiItem == null || !attachedUiItem.IsValid())
		{
			return;
		}
		UUIItem attachedUiItemForShow = this.GuideStepInfo.ViewData.GetAttachedUiItemForShow();
		this.FocusItem = this.CreateFocusItem(attachedUiItem, attachedUiItemForShow);
	}

	// Token: 0x0600E48F RID: 58511 RVA: 0x003DA928 File Offset: 0x003D8B28
	private void ShowInner()
	{
		if (!base.GetActive())
		{
			return;
		}
		if (!this.ReadyToShow)
		{
			return;
		}
		this.ReadyToShow = false;
		base.GetRootItem().SetAlpha(1f);
		if (this.StartSequenceName != null)
		{
			this.UiViewSequence.PlaySequence(this.StartSequenceName, false, null);
			return;
		}
		this.OnStartSequenceEnd("");
	}

	// Token: 0x0600E490 RID: 58512 RVA: 0x003DA990 File Offset: 0x003D8B90
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600E491 RID: 58513 RVA: 0x003DA9D8 File Offset: 0x003D8BD8
	[NullableContext(2)]
	public GuideStepInfo GetGuideStepInfo()
	{
		return this.GuideStepInfo;
	}

	// Token: 0x0600E492 RID: 58514 RVA: 0x003DA9E0 File Offset: 0x003D8BE0
	public GuideFocusNew? GetFocusViewConf()
	{
		return this.Config;
	}

	// Token: 0x0600E493 RID: 58515 RVA: 0x003DA9E8 File Offset: 0x003D8BE8
	public void BindInputAfterSequence()
	{
		List<string> list = new List<string>(this.Config.Value.InputEnumsIter());
		base.BindInput(list, list, new TInputHandle<float>(this.ProcessInput));
	}

	// Token: 0x0600E494 RID: 58516 RVA: 0x003DAA24 File Offset: 0x003D8C24
	private void ProcessInput([Nullable(2)] string name, float value, InputIdentification _)
	{
		if (this.RootItem != null && !this.RootItem.bIsUIActive)
		{
			return;
		}
		if (name != null)
		{
			this.CombineInputMap[name] = value;
			if (!base.IsAllCombineInputPass())
			{
				return;
			}
		}
		string[] inputEnums = this.Config.Value.InputEnums();
		base.UnbindInput(this.Config.Value.InputEnums(), inputEnums);
		base.DoCloseByFinished();
	}

	// Token: 0x0600E495 RID: 58517 RVA: 0x003DAA94 File Offset: 0x003D8C94
	protected override void OnGuideViewCloseWhenFinish()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null && uiViewSequence.HasSequenceNameInPlaying("Start"))
		{
			this.UiViewSequence.StopPrevSequence(false, true);
		}
		GuideFocusItem focusItem = this.FocusItem;
		if (focusItem == null)
		{
			return;
		}
		focusItem.OnBaseViewCloseWhenFinish();
	}

	// Token: 0x0600E496 RID: 58518 RVA: 0x003DAACC File Offset: 0x003D8CCC
	private GuideFocusItem CreateFocusItem(UUIItem attachedItem, UUIItem attachedItemForShow)
	{
		UUIItem item = base.GetItem(0);
		item.SetActive(false, false);
		GuideFocusItem guideFocusItem = new GuideFocusItem(attachedItem, attachedItemForShow, this);
		guideFocusItem.Init(item);
		return guideFocusItem;
	}

	// Token: 0x0600E497 RID: 58519 RVA: 0x003DAAF8 File Offset: 0x003D8CF8
	private void OnOtherPopupViewDone(EUiViewName viewName, UiViewBase view)
	{
		UiViewInfo viewInfo = view.ViewInfo;
		if (viewInfo == null || viewInfo.GetContainerLayerType() != ELayerType.Pop)
		{
			return;
		}
		if (((this.Config != null) ? this.Config.GetValueOrDefault().ViewName : null) == viewName)
		{
			return;
		}
		this.OccurredOtherPopupViewName = new EUiViewName?(viewName);
	}

	// Token: 0x0600E498 RID: 58520 RVA: 0x003DAB5C File Offset: 0x003D8D5C
	private void OnOtherPopupViewClose(EUiViewName viewName, int viewId)
	{
		if (this.OccurredOtherPopupViewName == viewName)
		{
			this.OccurredOtherPopupViewName = null;
		}
	}

	// Token: 0x0600E499 RID: 58521 RVA: 0x003DAB99 File Offset: 0x003D8D99
	private void OnPreparePhotoScreenShot(bool bShow)
	{
		UUIItem rootItem = base.GetRootItem();
		if (rootItem == null)
		{
			return;
		}
		rootItem.SetUIActive(bShow);
	}

	// Token: 0x04006DE7 RID: 28135
	private readonly HashSet<EUiViewName> guidePopupIgnoreView = new HashSet<EUiViewName>
	{
		EUiViewName.FightPhotoFocusView
	};

	// Token: 0x04006DE8 RID: 28136
	public GuideFocusNew? Config;

	// Token: 0x04006DE9 RID: 28137
	public bool IsAttachItemsReady;

	// Token: 0x04006DEA RID: 28138
	private bool IsAttachViewReady;

	// Token: 0x04006DEB RID: 28139
	public bool ReadyToShow;

	// Token: 0x04006DEC RID: 28140
	private float FindAttachmentTime = 4000f;

	// Token: 0x04006DED RID: 28141
	[Nullable(2)]
	private GuideFocusItem FocusItem;

	// Token: 0x04006DEE RID: 28142
	[Nullable(2)]
	private string StartSequenceName;

	// Token: 0x04006DEF RID: 28143
	private EUiViewName? OccurredOtherPopupViewName;

	// Token: 0x02008193 RID: 33171
	[NullableContext(0)]
	private enum EGuideFocusView
	{
		// Token: 0x0402BFEB RID: 180203
		FocusItem
	}
}
