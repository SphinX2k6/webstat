using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.InputSetting;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.GameMainView.CommonChildPanel;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001D16 RID: 7446
[NullableContext(1)]
[Nullable(0)]
public abstract class GameMainViewProxy
{
	// Token: 0x17001161 RID: 4449
	// (get) Token: 0x0600DAB0 RID: 55984
	protected abstract EBattleUiCommonChildVisibleReason? BattleUiCommonChildVisibleReason { get; }

	// Token: 0x0600DAB1 RID: 55985 RVA: 0x003ABEAF File Offset: 0x003AA0AF
	public void RegisterView(CommonGameMainView view)
	{
		this.View = view;
	}

	// Token: 0x0600DAB2 RID: 55986 RVA: 0x003ABEB8 File Offset: 0x003AA0B8
	public UniTask BeforeStartAsync()
	{
		GameMainViewProxy.<BeforeStartAsync>d__12 <BeforeStartAsync>d__;
		<BeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<BeforeStartAsync>d__.<>4__this = this;
		<BeforeStartAsync>d__.<>1__state = -1;
		<BeforeStartAsync>d__.<>t__builder.Start<GameMainViewProxy.<BeforeStartAsync>d__12>(ref <BeforeStartAsync>d__);
		return <BeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAB3 RID: 55987 RVA: 0x003ABEFB File Offset: 0x003AA0FB
	public void Start()
	{
		this.SetJoystickPanelHierarchyIndex();
		this.OnStart();
		this.AddEventListenerByStart();
	}

	// Token: 0x0600DAB4 RID: 55988 RVA: 0x003ABF10 File Offset: 0x003AA110
	public void BeforeShow()
	{
		foreach (BattleChildViewPanel battleChildViewPanel in this.ChildPanelMap.Values)
		{
			if (battleChildViewPanel.CheckBattleChildViewPanelShowCondition())
			{
				battleChildViewPanel.ShowBattleChildViewPanel();
			}
		}
		this.OnBeforeShow(!this.IsFirstShow);
		this.IsFirstShow = true;
	}

	// Token: 0x0600DAB5 RID: 55989 RVA: 0x003ABF88 File Offset: 0x003AA188
	public void AfterShow()
	{
		this.ApplyTouchUiEditData();
		this.OnAfterShow();
		this.TryAddBattleUiCommonChildVisibleReason();
		Singleton<EventSystem>.Instance.Emit(EEventName.ActiveBattleView);
		Singleton<EventSystem>.Instance.Emit(EEventName.RedDotStart);
	}

	// Token: 0x0600DAB6 RID: 55990 RVA: 0x003ABFBC File Offset: 0x003AA1BC
	public void BeforeHide()
	{
		this.OnBeforeHide();
		this.HideViewOperation();
		Singleton<EventSystem>.Instance.Emit(EEventName.DisActiveBattleView);
	}

	// Token: 0x0600DAB7 RID: 55991 RVA: 0x003ABFDC File Offset: 0x003AA1DC
	public void AfterHide()
	{
		foreach (BattleChildViewPanel battleChildViewPanel in this.ChildPanelMap.Values)
		{
			battleChildViewPanel.HideBattleChildViewPanel();
		}
		this.OnAfterHide();
		this.TryRemoveBattleUiCommonChildVisibleReason();
	}

	// Token: 0x0600DAB8 RID: 55992 RVA: 0x003AC040 File Offset: 0x003AA240
	private void AddEventListenerByStart()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
		this.OnAddEventListenerByStart();
	}

	// Token: 0x0600DAB9 RID: 55993 RVA: 0x003AC064 File Offset: 0x003AA264
	private void RemoveEventListenerForStart()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRouletteViewVisibleChanged, new Action<bool>(this.OnRouletteViewVisibleChanged));
		this.OnRemoveEventListenerForStart();
	}

	// Token: 0x0600DABA RID: 55994 RVA: 0x003AC088 File Offset: 0x003AA288
	public void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		this.OnAddEventListener();
	}

	// Token: 0x0600DABB RID: 55995 RVA: 0x003AC0AC File Offset: 0x003AA2AC
	public void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.InputControllerChange));
		this.OnRemoveEventListener();
	}

	// Token: 0x0600DABC RID: 55996 RVA: 0x003AC0D0 File Offset: 0x003AA2D0
	public void BeforeDestroy()
	{
		this.RemoveEventListenerForStart();
		this.ResetAllChildViewPanels();
		this.PanelResIdMap.Clear();
		this.OnBeforeDestroy();
	}

	// Token: 0x0600DABD RID: 55997 RVA: 0x003AC0F0 File Offset: 0x003AA2F0
	public void Tick(float delta)
	{
		foreach (BattleChildViewPanel battleChildViewPanel in this.TickPanelList)
		{
			if (battleChildViewPanel.GetVisible())
			{
				battleChildViewPanel.OnTickBattleChildViewPanel(delta);
			}
		}
		this.OnTick(delta);
	}

	// Token: 0x0600DABE RID: 55998 RVA: 0x003AC154 File Offset: 0x003AA354
	public void AfterTick(float delta)
	{
		foreach (BattleChildViewPanel battleChildViewPanel in this.TickPanelList)
		{
			if (battleChildViewPanel.GetVisible())
			{
				battleChildViewPanel.OnAfterTickBattleChildViewPanel(delta);
			}
		}
		this.OnAfterTick(delta);
	}

	// Token: 0x0600DABF RID: 55999 RVA: 0x003AC1B8 File Offset: 0x003AA3B8
	public UniTask PlayHideSequenceAsync()
	{
		GameMainViewProxy.<PlayHideSequenceAsync>d__25 <PlayHideSequenceAsync>d__;
		<PlayHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<PlayHideSequenceAsync>d__.<>4__this = this;
		<PlayHideSequenceAsync>d__.<>1__state = -1;
		<PlayHideSequenceAsync>d__.<>t__builder.Start<GameMainViewProxy.<PlayHideSequenceAsync>d__25>(ref <PlayHideSequenceAsync>d__);
		return <PlayHideSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAC0 RID: 56000 RVA: 0x003AC1FC File Offset: 0x003AA3FC
	private UniTask StartAsyncInner()
	{
		GameMainViewProxy.<StartAsyncInner>d__26 <StartAsyncInner>d__;
		<StartAsyncInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<StartAsyncInner>d__.<>4__this = this;
		<StartAsyncInner>d__.<>1__state = -1;
		<StartAsyncInner>d__.<>t__builder.Start<GameMainViewProxy.<StartAsyncInner>d__26>(ref <StartAsyncInner>d__);
		return <StartAsyncInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAC1 RID: 56001 RVA: 0x003AC23F File Offset: 0x003AA43F
	private void SetJoystickPanelHierarchyIndex()
	{
		if (this.JoystickPanel != null)
		{
			this.JoystickPanel.GetOriginalItem().SetAsFirstHierarchy();
		}
	}

	// Token: 0x0600DAC2 RID: 56002 RVA: 0x003AC25C File Offset: 0x003AA45C
	private UniTask CreateJoystickPanel()
	{
		GameMainViewProxy.<CreateJoystickPanel>d__28 <CreateJoystickPanel>d__;
		<CreateJoystickPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateJoystickPanel>d__.<>4__this = this;
		<CreateJoystickPanel>d__.<>1__state = -1;
		<CreateJoystickPanel>d__.<>t__builder.Start<GameMainViewProxy.<CreateJoystickPanel>d__28>(ref <CreateJoystickPanel>d__);
		return <CreateJoystickPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAC3 RID: 56003 RVA: 0x003AC2A0 File Offset: 0x003AA4A0
	private UniTask CreateJoystickPanelInner()
	{
		GameMainViewProxy.<CreateJoystickPanelInner>d__29 <CreateJoystickPanelInner>d__;
		<CreateJoystickPanelInner>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreateJoystickPanelInner>d__.<>4__this = this;
		<CreateJoystickPanelInner>d__.<>1__state = -1;
		<CreateJoystickPanelInner>d__.<>t__builder.Start<GameMainViewProxy.<CreateJoystickPanelInner>d__29>(ref <CreateJoystickPanelInner>d__);
		return <CreateJoystickPanelInner>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAC4 RID: 56004 RVA: 0x003AC2E4 File Offset: 0x003AA4E4
	private UniTask CreatePositionPanel()
	{
		GameMainViewProxy.<CreatePositionPanel>d__30 <CreatePositionPanel>d__;
		<CreatePositionPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CreatePositionPanel>d__.<>4__this = this;
		<CreatePositionPanel>d__.<>1__state = -1;
		<CreatePositionPanel>d__.<>t__builder.Start<GameMainViewProxy.<CreatePositionPanel>d__30>(ref <CreatePositionPanel>d__);
		return <CreatePositionPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DAC5 RID: 56005 RVA: 0x003AC327 File Offset: 0x003AA527
	private void InputControllerChange(EInputControllerType last, EInputControllerType now)
	{
		this.CreateJoystickPanel().Forget();
		this.OnInputControllerChange();
	}

	// Token: 0x0600DAC6 RID: 56006 RVA: 0x003AC33C File Offset: 0x003AA53C
	private void OnRouletteViewVisibleChanged(bool visible)
	{
		if (Singleton<Info>.Instance.IsInTouch() && this.JoystickPanel != null)
		{
			if (visible)
			{
				this.JoystickPanelOriginalIndex = this.JoystickPanel.GetOriginalItem().GetHierarchyIndex();
				this.JoystickPanel.GetOriginalItem().SetUIParent(this.View.GetRootItem(), false);
			}
			else
			{
				this.JoystickPanel.GetOriginalItem().SetUIParent(this.View.GetContentPanel(), false);
				this.JoystickPanel.GetOriginalItem().SetHierarchyIndex(this.JoystickPanelOriginalIndex);
				this.JoystickPanelOriginalIndex = 0;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.CommonGameMainView;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "轮盘界面显隐，调整摇杆面板层级";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("visible", visible);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.View.SetMaskItemActive(visible);
		this.OnRouletteViewVisibleChangedInner(visible);
	}

	// Token: 0x0600DAC7 RID: 56007 RVA: 0x003AC418 File Offset: 0x003AA618
	private void ResetAllChildViewPanels()
	{
		foreach (BattleChildViewPanel battleChildViewPanel in this.ChildPanelMap.Values)
		{
			if (battleChildViewPanel != null)
			{
				battleChildViewPanel.Reset();
			}
		}
		this.ChildPanelMap.Clear();
		this.TickPanelList.Clear();
	}

	// Token: 0x0600DAC8 RID: 56008 RVA: 0x003AC488 File Offset: 0x003AA688
	private void ApplyTouchUiEditData()
	{
		if (this.TouchUiEditGroup == null)
		{
			return;
		}
		if (!Singleton<Info>.Instance.IsInTouch())
		{
			return;
		}
		foreach (KeyValuePair<string, UiPanelBase> keyValuePair in this.PanelResIdMap)
		{
			TouchUiEditApplyHelper.ApplyCommonTouchUiEditData(this.TouchUiEditGroup.Value, keyValuePair.Value, keyValuePair.Key);
		}
	}

	// Token: 0x0600DAC9 RID: 56009 RVA: 0x003AC510 File Offset: 0x003AA710
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	protected UniTask<T> CreateChildPanel<[Nullable(0)] T>(string resourceId, UUIItem parentItem, Type panelClass, bool bShow = true, bool bTick = false, EBattleUiChild childType = EBattleUiChild.Common) where T : BattleChildViewPanel
	{
		GameMainViewProxy.<CreateChildPanel>d__35<T> <CreateChildPanel>d__;
		<CreateChildPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
		<CreateChildPanel>d__.<>4__this = this;
		<CreateChildPanel>d__.resourceId = resourceId;
		<CreateChildPanel>d__.parentItem = parentItem;
		<CreateChildPanel>d__.panelClass = panelClass;
		<CreateChildPanel>d__.bShow = bShow;
		<CreateChildPanel>d__.bTick = bTick;
		<CreateChildPanel>d__.childType = childType;
		<CreateChildPanel>d__.<>1__state = -1;
		<CreateChildPanel>d__.<>t__builder.Start<GameMainViewProxy.<CreateChildPanel>d__35<T>>(ref <CreateChildPanel>d__);
		return <CreateChildPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600DACA RID: 56010 RVA: 0x003AC586 File Offset: 0x003AA786
	protected virtual UniTask OnBeforeStartAsync()
	{
		return UniTask.CompletedTask;
	}

	// Token: 0x0600DACB RID: 56011 RVA: 0x003AC58D File Offset: 0x003AA78D
	protected virtual void OnStart()
	{
	}

	// Token: 0x0600DACC RID: 56012 RVA: 0x003AC58F File Offset: 0x003AA78F
	protected virtual void OnBeforeShow(bool isFirstShow)
	{
	}

	// Token: 0x0600DACD RID: 56013 RVA: 0x003AC591 File Offset: 0x003AA791
	protected virtual void OnAfterShow()
	{
	}

	// Token: 0x0600DACE RID: 56014 RVA: 0x003AC593 File Offset: 0x003AA793
	protected virtual void OnBeforeHide()
	{
	}

	// Token: 0x0600DACF RID: 56015 RVA: 0x003AC595 File Offset: 0x003AA795
	protected virtual void OnAfterHide()
	{
	}

	// Token: 0x0600DAD0 RID: 56016 RVA: 0x003AC597 File Offset: 0x003AA797
	protected virtual void OnAddEventListenerByStart()
	{
	}

	// Token: 0x0600DAD1 RID: 56017 RVA: 0x003AC599 File Offset: 0x003AA799
	protected virtual void OnRemoveEventListenerForStart()
	{
	}

	// Token: 0x0600DAD2 RID: 56018 RVA: 0x003AC59B File Offset: 0x003AA79B
	protected virtual void OnAddEventListener()
	{
	}

	// Token: 0x0600DAD3 RID: 56019 RVA: 0x003AC59D File Offset: 0x003AA79D
	protected virtual void OnRemoveEventListener()
	{
	}

	// Token: 0x0600DAD4 RID: 56020 RVA: 0x003AC59F File Offset: 0x003AA79F
	protected virtual void OnBeforeDestroy()
	{
	}

	// Token: 0x0600DAD5 RID: 56021 RVA: 0x003AC5A1 File Offset: 0x003AA7A1
	protected virtual void OnTick(float delta)
	{
	}

	// Token: 0x0600DAD6 RID: 56022 RVA: 0x003AC5A3 File Offset: 0x003AA7A3
	protected virtual void OnAfterTick(float delta)
	{
	}

	// Token: 0x0600DAD7 RID: 56023 RVA: 0x003AC5A5 File Offset: 0x003AA7A5
	protected virtual void OnInputControllerChange()
	{
	}

	// Token: 0x0600DAD8 RID: 56024 RVA: 0x003AC5A7 File Offset: 0x003AA7A7
	protected virtual void OnRouletteViewVisibleChangedInner(bool visible)
	{
	}

	// Token: 0x0600DAD9 RID: 56025 RVA: 0x003AC5A9 File Offset: 0x003AA7A9
	protected virtual void HideViewOperation()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.PhantomExploreView))
		{
			Singleton<UiManager>.Instance.CloseView(EUiViewName.PhantomExploreView, null);
		}
	}

	// Token: 0x0600DADA RID: 56026 RVA: 0x003AC5CC File Offset: 0x003AA7CC
	protected virtual bool ShouldCreateJoystickPanel()
	{
		return true;
	}

	// Token: 0x0600DADB RID: 56027 RVA: 0x003AC5D0 File Offset: 0x003AA7D0
	protected virtual UniTask OnPlayingHideSequenceAsync()
	{
		GameMainViewProxy.<OnPlayingHideSequenceAsync>d__53 <OnPlayingHideSequenceAsync>d__;
		<OnPlayingHideSequenceAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnPlayingHideSequenceAsync>d__.<>1__state = -1;
		<OnPlayingHideSequenceAsync>d__.<>t__builder.Start<GameMainViewProxy.<OnPlayingHideSequenceAsync>d__53>(ref <OnPlayingHideSequenceAsync>d__);
		return <OnPlayingHideSequenceAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600DADC RID: 56028 RVA: 0x003AC60C File Offset: 0x003AA80C
	private void TryAddBattleUiCommonChildVisibleReason()
	{
		if (this.BattleUiCommonChildVisibleReason != null)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.AddBattleUiCommonChildVisibleReason(this.BattleUiCommonChildVisibleReason.Value);
		}
	}

	// Token: 0x0600DADD RID: 56029 RVA: 0x003AC648 File Offset: 0x003AA848
	private void TryRemoveBattleUiCommonChildVisibleReason()
	{
		if (this.BattleUiCommonChildVisibleReason != null)
		{
			ModelBase<BattleUiModel>.Instance.ChildViewData.RemoveBattleUiCommonChildVisibleReason(this.BattleUiCommonChildVisibleReason.Value);
		}
	}

	// Token: 0x0600DADE RID: 56030 RVA: 0x003AC684 File Offset: 0x003AA884
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public virtual UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 2)
		{
			return null;
		}
		string key = configParams[0];
		string text = configParams[1];
		UiPanelBase uiPanelBase;
		this.PanelResIdMap.TryGetValue(key, out uiPanelBase);
		if (text == "-1")
		{
			if (uiPanelBase == null)
			{
				return null;
			}
			return uiPanelBase.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			UUIItem uuiitem = (uiPanelBase != null) ? uiPanelBase.GetGuideUiItem(text) : null;
			if (uuiitem == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				uuiitem,
				uuiitem
			};
		}
	}

	// Token: 0x0400686B RID: 26731
	[Nullable(2)]
	protected CommonGameMainView View;

	// Token: 0x0400686C RID: 26732
	protected Dictionary<Type, BattleChildViewPanel> ChildPanelMap = new Dictionary<Type, BattleChildViewPanel>();

	// Token: 0x0400686D RID: 26733
	protected List<BattleChildViewPanel> TickPanelList = new List<BattleChildViewPanel>();

	// Token: 0x0400686E RID: 26734
	[Nullable(2)]
	protected JoystickPanel JoystickPanel;

	// Token: 0x0400686F RID: 26735
	protected int JoystickPanelOriginalIndex;

	// Token: 0x04006870 RID: 26736
	[Nullable(2)]
	protected PositionPanel PositionPanel;

	// Token: 0x04006871 RID: 26737
	protected bool IsFirstShow;

	// Token: 0x04006872 RID: 26738
	protected readonly Dictionary<string, UiPanelBase> PanelResIdMap = new Dictionary<string, UiPanelBase>();

	// Token: 0x04006873 RID: 26739
	protected ECommonTouchUiEditGroup? TouchUiEditGroup;
}
