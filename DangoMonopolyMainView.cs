using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020012F5 RID: 4853
[NullableContext(2)]
[Nullable(0)]
public class DangoMonopolyMainView : DangoMonopolyViewBase
{
	// Token: 0x17000B17 RID: 2839
	// (get) Token: 0x06008388 RID: 33672 RVA: 0x0022BAA8 File Offset: 0x00229CA8
	public new DangoMonopolyMainViewParam OpenParam
	{
		get
		{
			return this.OpenParam as DangoMonopolyMainViewParam;
		}
	}

	// Token: 0x06008389 RID: 33673 RVA: 0x0022BAB5 File Offset: 0x00229CB5
	[NullableContext(1)]
	public DangoMonopolyMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600838A RID: 33674 RVA: 0x0022BAC0 File Offset: 0x00229CC0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(9, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(10, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUIText)),
			new ValueTuple<int, Type>(23, typeof(UUIExtendToggle))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickBtnSpeed)),
			new ValueTuple<int, Delegate>(8, new Action(this.OnClickBtnRoundRecord)),
			new ValueTuple<int, Delegate>(9, new Action(this.OnClickBtnDiceTask)),
			new ValueTuple<int, Delegate>(10, new Action(this.OnClickBtnUseDice)),
			new ValueTuple<int, Delegate>(23, new Action<EToggleState>(this.OnClickAngleOfView))
		};
	}

	// Token: 0x0600838B RID: 33675 RVA: 0x0022BD7D File Offset: 0x00229F7D
	private void InitDataParam()
	{
	}

	// Token: 0x0600838C RID: 33676 RVA: 0x0022BD80 File Offset: 0x00229F80
	protected override UniTask OnBeforeStartAsync()
	{
		DangoMonopolyMainView.<OnBeforeStartAsync>d__20 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<DangoMonopolyMainView.<OnBeforeStartAsync>d__20>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600838D RID: 33677 RVA: 0x0022BDC4 File Offset: 0x00229FC4
	protected override void OnStart()
	{
		if (this.ActivityData == null)
		{
			this.ActivityHide();
			return;
		}
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		this.UpdateAngleOfViewBtnState();
		Singleton<EventSystem>.Instance.Emit(EEventName.DangoMonopolyViewStart);
		this.CheckShowProcess().Forget();
		Singleton<EventSystem>.Instance.Add(EEventName.DangoMonopolyMoveStart, new Action(this.EventDangoMonopolyMoveStart));
	}

	// Token: 0x0600838E RID: 33678 RVA: 0x0022BE30 File Offset: 0x0022A030
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.DangoMonopolyBoardRewardUpdate, new Action(this.EventDangoMonopolyBoardRewardUpdate));
		Singleton<EventSystem>.Instance.Add(EEventName.OnCloseRewardView, new Action(this.EventOnCloseRewardView));
		Singleton<EventSystem>.Instance.Add(EEventName.DangoMonopolyStartShowProcess, new Action(this.EventDangoMonopolyStartShowProcess));
		Singleton<EventSystem>.Instance.Add(EEventName.DangoMonopolyEndShowProcess, new Action(this.EventDangoMonopolyEndShowProcess));
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.DangoMonopolyTask, base.GetItem(19), null, 0);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.DangoMonopolyDiceNum, base.GetItem(20), new Action<bool, int>(this.UpdateDiceUseState), 0);
	}

	// Token: 0x0600838F RID: 33679 RVA: 0x0022BEEC File Offset: 0x0022A0EC
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyBoardRewardUpdate, new Action(this.EventDangoMonopolyBoardRewardUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCloseRewardView, new Action(this.EventOnCloseRewardView));
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyStartShowProcess, new Action(this.EventDangoMonopolyStartShowProcess));
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyEndShowProcess, new Action(this.EventDangoMonopolyEndShowProcess));
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.DangoMonopolyTask);
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.DangoMonopolyDiceNum);
	}

	// Token: 0x06008390 RID: 33680 RVA: 0x0022BF88 File Offset: 0x0022A188
	protected override void OnBeforeShow()
	{
		if (!base.UpdateActivityData())
		{
			this.ActivityHide();
			return;
		}
		this.PopupCaption.SetCurrencyItemList(new int[]
		{
			this.ActivityData.DiceItemId
		}).Forget();
		this.UpdateShowBoardData(this.ActivityData.CurrentBoardData);
		this.UpdateData();
		int num = 500;
		this.RefreshTimerHandle = TimerSystem.RealTimeInstance.Forever(new TTimerAction(this.OnTimerRefresh), (float)num, 1f, null, null, true);
	}

	// Token: 0x06008391 RID: 33681 RVA: 0x0022C00B File Offset: 0x0022A20B
	public void OnTimerRefresh(float _)
	{
		this.CheckBoardUnlockTime();
	}

	// Token: 0x06008392 RID: 33682 RVA: 0x0022C013 File Offset: 0x0022A213
	public void CheckBoardUnlockTime()
	{
		if (this.ActivityData.IsRunningBoardLock() != this.IsBoardLock)
		{
			this.UpdateData();
		}
		this.UpdateBoardRemainTime();
	}

	// Token: 0x06008393 RID: 33683 RVA: 0x0022C034 File Offset: 0x0022A234
	public bool CheckActivityClose()
	{
		if (!this.ActivityData.CheckIfClose())
		{
			return false;
		}
		ControllerBase<ActivityController>.Instance.ShowActivityRefreshAndBackToBattleView();
		return true;
	}

	// Token: 0x06008394 RID: 33684 RVA: 0x0022C050 File Offset: 0x0022A250
	public void ClearTimer()
	{
		if (this.RefreshTimerHandle != null && TimerSystem.RealTimeInstance.Has(this.RefreshTimerHandle))
		{
			TimerSystem.RealTimeInstance.Remove(this.RefreshTimerHandle);
			this.RefreshTimerHandle = null;
		}
	}

	// Token: 0x06008395 RID: 33685 RVA: 0x0022C084 File Offset: 0x0022A284
	protected override void OnBeforeHide()
	{
		this.ClearTimer();
		this.SetBattleFloatVisible(false).Forget();
	}

	// Token: 0x06008396 RID: 33686 RVA: 0x0022C098 File Offset: 0x0022A298
	protected override void OnAfterShow()
	{
		this.SetBattleFloatVisible(true).Forget();
	}

	// Token: 0x06008397 RID: 33687 RVA: 0x0022C0A8 File Offset: 0x0022A2A8
	public UniTask SetBattleFloatVisible(bool visible)
	{
		DangoMonopolyMainView.<SetBattleFloatVisible>d__31 <SetBattleFloatVisible>d__;
		<SetBattleFloatVisible>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SetBattleFloatVisible>d__.<>4__this = this;
		<SetBattleFloatVisible>d__.visible = visible;
		<SetBattleFloatVisible>d__.<>1__state = -1;
		<SetBattleFloatVisible>d__.<>t__builder.Start<DangoMonopolyMainView.<SetBattleFloatVisible>d__31>(ref <SetBattleFloatVisible>d__);
		return <SetBattleFloatVisible>d__.<>t__builder.Task;
	}

	// Token: 0x06008398 RID: 33688 RVA: 0x0022C0F4 File Offset: 0x0022A2F4
	public UniTask CheckShowProcess()
	{
		DangoMonopolyMainView.<CheckShowProcess>d__32 <CheckShowProcess>d__;
		<CheckShowProcess>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckShowProcess>d__.<>4__this = this;
		<CheckShowProcess>d__.<>1__state = -1;
		<CheckShowProcess>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckShowProcess>d__32>(ref <CheckShowProcess>d__);
		return <CheckShowProcess>d__.<>t__builder.Task;
	}

	// Token: 0x06008399 RID: 33689 RVA: 0x0022C138 File Offset: 0x0022A338
	public UniTask CheckUpdateDangoPosition()
	{
		DangoMonopolyMainView.<CheckUpdateDangoPosition>d__33 <CheckUpdateDangoPosition>d__;
		<CheckUpdateDangoPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckUpdateDangoPosition>d__.<>4__this = this;
		<CheckUpdateDangoPosition>d__.<>1__state = -1;
		<CheckUpdateDangoPosition>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckUpdateDangoPosition>d__33>(ref <CheckUpdateDangoPosition>d__);
		return <CheckUpdateDangoPosition>d__.<>t__builder.Task;
	}

	// Token: 0x0600839A RID: 33690 RVA: 0x0022C17C File Offset: 0x0022A37C
	public UniTask CheckShowInfo()
	{
		DangoMonopolyMainView.<CheckShowInfo>d__34 <CheckShowInfo>d__;
		<CheckShowInfo>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckShowInfo>d__.<>4__this = this;
		<CheckShowInfo>d__.<>1__state = -1;
		<CheckShowInfo>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckShowInfo>d__34>(ref <CheckShowInfo>d__);
		return <CheckShowInfo>d__.<>t__builder.Task;
	}

	// Token: 0x0600839B RID: 33691 RVA: 0x0022C1C0 File Offset: 0x0022A3C0
	public UniTask CheckWelcome(bool dangoPosShow = false)
	{
		DangoMonopolyMainView.<CheckWelcome>d__35 <CheckWelcome>d__;
		<CheckWelcome>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckWelcome>d__.<>4__this = this;
		<CheckWelcome>d__.dangoPosShow = dangoPosShow;
		<CheckWelcome>d__.<>1__state = -1;
		<CheckWelcome>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckWelcome>d__35>(ref <CheckWelcome>d__);
		return <CheckWelcome>d__.<>t__builder.Task;
	}

	// Token: 0x0600839C RID: 33692 RVA: 0x0022C20C File Offset: 0x0022A40C
	private void ActivityHide()
	{
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(false);
		}
		UUIButtonComponent button2 = base.GetButton(8);
		if (button2 != null)
		{
			button2.RootUIComp.Get().SetUIActive(false);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(23);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(false);
		}
		UUIItem item = base.GetItem(17);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(18);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x0600839D RID: 33693 RVA: 0x0022C2A1 File Offset: 0x0022A4A1
	public void UpdateShowBoardData(DangoMonopolyBoardData boardData)
	{
		this.ShowBoardData = (boardData ?? this.ActivityData.BoardList[0]);
	}

	// Token: 0x0600839E RID: 33694 RVA: 0x0022C2C0 File Offset: 0x0022A4C0
	protected override void OnBeforeDestroy()
	{
		this.ClearTimer();
		DangoMonopolyRoundRewardItem endRoundReward = this.EndRoundReward;
		if (endRoundReward != null)
		{
			endRoundReward.Destroy(null);
		}
		DangoMonopolyPosition dangoPosition = this.DangoPosition;
		if (dangoPosition != null)
		{
			dangoPosition.Destroy(null);
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData != null)
		{
			activityData.GameplayExit();
		}
		Singleton<UiLayer>.Instance.SetShowMaskLayer(EUiViewName.DangoMonopolyMainView.ToString(), false);
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
		Singleton<EventSystem>.Instance.Remove(EEventName.DangoMonopolyMoveStart, new Action(this.EventDangoMonopolyMoveStart));
		Singleton<EventSystem>.Instance.Emit(EEventName.LeaveInstanceDungeonConfirm);
		Singleton<EventSystem>.Instance.Emit(EEventName.LeaveInstanceExternalConfirm);
	}

	// Token: 0x0600839F RID: 33695 RVA: 0x0022C370 File Offset: 0x0022A570
	private void CloseCallBack()
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData != null && activityData.IsDangoMoveProcess)
		{
			return;
		}
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BattleViewLeaveInstance);
		confirmBoxDataNew.IsEscViewTriggerCallBack = false;
		confirmBoxDataNew.FunctionMap.Add(1, delegate
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.LeaveInstanceExternalCancel);
		});
		confirmBoxDataNew.FunctionMap.Add(2, delegate
		{
			base.CloseMe(null);
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060083A0 RID: 33696 RVA: 0x0022C3EF File Offset: 0x0022A5EF
	private void HelpCallback()
	{
		ControllerBase<HelpController>.Instance.OpenHelpById(290);
	}

	// Token: 0x060083A1 RID: 33697 RVA: 0x0022C400 File Offset: 0x0022A600
	private void OnClickBtnSpeed()
	{
		this.ActivityData.SetActivitySpeed(null);
		this.UpdateSpeed();
	}

	// Token: 0x060083A2 RID: 33698 RVA: 0x0022C427 File Offset: 0x0022A627
	private void OnClickBtnRoundRecord()
	{
		this.ActivityData.OpenViewDangoMonopolyTransition(delegate
		{
			DangoMonopolyMainView.<<OnClickBtnRoundRecord>b__42_0>d <<OnClickBtnRoundRecord>b__42_0>d;
			<<OnClickBtnRoundRecord>b__42_0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnClickBtnRoundRecord>b__42_0>d.<>4__this = this;
			<<OnClickBtnRoundRecord>b__42_0>d.<>1__state = -1;
			<<OnClickBtnRoundRecord>b__42_0>d.<>t__builder.Start<DangoMonopolyMainView.<<OnClickBtnRoundRecord>b__42_0>d>(ref <<OnClickBtnRoundRecord>b__42_0>d);
			return <<OnClickBtnRoundRecord>b__42_0>d.<>t__builder.Task;
		});
	}

	// Token: 0x060083A3 RID: 33699 RVA: 0x0022C440 File Offset: 0x0022A640
	public void UpdateBtnRoundRecord()
	{
		bool uiactive = this.ActivityData.GetFinishedRoundNum() > 0;
		UUIButtonComponent button = base.GetButton(8);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(uiactive);
	}

	// Token: 0x060083A4 RID: 33700 RVA: 0x0022C47B File Offset: 0x0022A67B
	private void OnClickBtnDiceTask()
	{
		if (this.CheckActivityClose())
		{
			return;
		}
		this.ActivityData.OpenViewDiceTask();
	}

	// Token: 0x060083A5 RID: 33701 RVA: 0x0022C494 File Offset: 0x0022A694
	private void OnClickBtnUseDice()
	{
		if (this.CheckActivityClose())
		{
			return;
		}
		ActivityDangoMonopolyData activityData = this.ActivityData;
		if (activityData != null && activityData.IsExistGridReward())
		{
			return;
		}
		if (this.ActivityData.RequestUseDice())
		{
			return;
		}
		if (this.ActivityData.IsRunningBoardLock())
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("DangoMonopoly_title_17", Array.Empty<object>());
			return;
		}
		this.OnClickBtnDiceTask();
	}

	// Token: 0x060083A6 RID: 33702 RVA: 0x0022C4F5 File Offset: 0x0022A6F5
	[NullableContext(1)]
	private DangoMonopolyBuffStateItem CreateBuffItem()
	{
		return new DangoMonopolyBuffStateItem();
	}

	// Token: 0x060083A7 RID: 33703 RVA: 0x0022C4FC File Offset: 0x0022A6FC
	public void UpdateData()
	{
		ActivityDangoMonopolyData activityData = this.ActivityData;
		DangoMonopolyBoardData showBoardData = this.ShowBoardData;
		int value = (showBoardData != null) ? showBoardData.GetPosition() : 1;
		int totalRoundNum = activityData.GetTotalRoundNum();
		int finishedRoundNum = activityData.GetFinishedRoundNum();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(totalRoundNum);
		string newText = defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		string newText2 = defaultInterpolatedStringHandler.ToStringAndClear();
		UUIText text = base.GetText(3);
		if (text != null)
		{
			text.SetText(newText2, true);
		}
		UUIText text2 = base.GetText(12);
		if (text2 != null)
		{
			text2.SetText(finishedRoundNum.ToString(), true);
		}
		UUIText text3 = base.GetText(4);
		if (text3 != null)
		{
			text3.SetText(newText, true);
		}
		UUIText text4 = base.GetText(13);
		if (text4 != null)
		{
			text4.SetText(newText, true);
		}
		List<IDangoMonopolyRoundBuffData> buffItemData = this.GetBuffItemData();
		GenericLayout<DangoMonopolyBuffStateItem, IDangoMonopolyRoundBuffData> buffLayoutView = this.BuffLayoutView;
		if (buffLayoutView != null)
		{
			buffLayoutView.RefreshByData(buffItemData.ToList<IDangoMonopolyRoundBuffData>(), null, true);
		}
		this.UpdateReward(false);
		this.UpdateProgress();
		this.UpdateSpeed();
		this.UpdateBtnRoundRecord();
		this.UpdateDiceUseState(false, 0);
		this.UpdateBoardLockTips();
		DangoMonopolyBoardData showBoardData2 = this.ShowBoardData;
		if (showBoardData2 == null)
		{
			return;
		}
		showBoardData2.LogInfo();
	}

	// Token: 0x060083A8 RID: 33704 RVA: 0x0022C620 File Offset: 0x0022A820
	[NullableContext(1)]
	public List<IDangoMonopolyRoundBuffData> GetBuffItemData()
	{
		DangoMonopolyBoardData showBoardData = this.ShowBoardData;
		return ((showBoardData != null) ? showBoardData.GetDangoBuffShowList() : null) ?? new List<IDangoMonopolyRoundBuffData>();
	}

	// Token: 0x060083A9 RID: 33705 RVA: 0x0022C640 File Offset: 0x0022A840
	public void UpdateBoardLockTips()
	{
		this.IsBoardLock = this.ActivityData.IsRunningBoardLock();
		UUIItem item = base.GetItem(21);
		bool flag = this.ActivityData.IsFinishAllRound();
		if (item != null)
		{
			item.SetUIActive(flag);
		}
		UUIButtonComponent button = base.GetButton(9);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(!flag);
		}
		if (!flag)
		{
			if (item != null)
			{
				item.SetUIActive(this.IsBoardLock);
			}
			this.UpdateBoardRemainTime();
			return;
		}
		UUIText text = base.GetText(22);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew("DangoMonopoly_title_18");
	}

	// Token: 0x060083AA RID: 33706 RVA: 0x0022C6D1 File Offset: 0x0022A8D1
	public void UpdateBoardRemainTime()
	{
		if (!this.IsBoardLock)
		{
			return;
		}
		UUIText text = base.GetText(22);
		if (text == null)
		{
			return;
		}
		text.SetText(this.ActivityData.GetBoardRemainTimeStr(), true);
	}

	// Token: 0x060083AB RID: 33707 RVA: 0x0022C6FC File Offset: 0x0022A8FC
	public void UpdateDiceUseState(bool _1, int _2)
	{
		UUIItem sprite = base.GetSprite(11);
		bool uiactive = !this.ActivityData.IsCanUseDice();
		sprite.SetUIActive(uiactive);
		DangoMonopolyBoardData showBoardData = this.ShowBoardData;
		bool? flag = (showBoardData != null) ? new bool?(!showBoardData.IsFinish()) : null;
		UUIButtonComponent button = base.GetButton(10);
		if (button == null)
		{
			return;
		}
		button.RootUIComp.Get().SetUIActive(flag.GetValueOrDefault());
	}

	// Token: 0x060083AC RID: 33708 RVA: 0x0022C770 File Offset: 0x0022A970
	public void UpdateReward(bool resetNavigation = false)
	{
		List<DangoMonopolyBoardData> boardList = this.ActivityData.BoardList;
		List<IDangoMonopolyRoundRewardItemData> rewardList = new List<IDangoMonopolyRoundRewardItemData>();
		foreach (DangoMonopolyBoardData dangoMonopolyBoardData in boardList)
		{
			DangoMonopolyRoundRewardItemData item = new DangoMonopolyRoundRewardItemData
			{
				IsReceived = dangoMonopolyBoardData.IsRewarded,
				IsCanReceived = dangoMonopolyBoardData.IsCanReceiveReward(),
				ItemId = dangoMonopolyBoardData.RewardItemId,
				Count = dangoMonopolyBoardData.RewardItemCount,
				BoardId = dangoMonopolyBoardData.Id,
				IsCurrent = dangoMonopolyBoardData.IsRunning(),
				Position = dangoMonopolyBoardData.GetPosition()
			};
			rewardList.Add(item);
		}
		IDangoMonopolyRoundRewardItemData data = rewardList[rewardList.Count - 1];
		rewardList.RemoveAt(rewardList.Count - 1);
		LoopScrollView<DangoMonopolyRoundRewardItem, IDangoMonopolyRoundRewardItemData> rewardLayout = this.RewardLayout;
		if (rewardLayout != null)
		{
			rewardLayout.RefreshByData(rewardList, true, delegate
			{
				this.UpdateRewardPos(rewardList, resetNavigation);
			}, false);
		}
		DangoMonopolyRoundRewardItem endRoundReward = this.EndRoundReward;
		if (endRoundReward == null)
		{
			return;
		}
		endRoundReward.Refresh(data, false, 0);
	}

	// Token: 0x060083AD RID: 33709 RVA: 0x0022C8B4 File Offset: 0x0022AAB4
	[NullableContext(1)]
	public void UpdateRewardPos(List<IDangoMonopolyRoundRewardItemData> rewardList, bool resetNavigation = false)
	{
		int rewardPos = this.GetRewardPos(rewardList);
		LoopScrollView<DangoMonopolyRoundRewardItem, IDangoMonopolyRoundRewardItemData> rewardLayout = this.RewardLayout;
		if (rewardLayout != null)
		{
			rewardLayout.ScrollToGridIndex(rewardPos, true);
		}
		if (!resetNavigation)
		{
			return;
		}
		int gridIndex = Math.Min(rewardPos + 1, rewardList.Count - 1);
		LoopScrollView<DangoMonopolyRoundRewardItem, IDangoMonopolyRoundRewardItemData> rewardLayout2 = this.RewardLayout;
		DangoMonopolyRoundRewardItem dangoMonopolyRoundRewardItem = (rewardLayout2 != null) ? rewardLayout2.UnsafeGetGridProxy(gridIndex, false) : null;
		if (dangoMonopolyRoundRewardItem == null)
		{
			return;
		}
		UUIItem rootItem = dangoMonopolyRoundRewardItem.RewardItem.GetRootItem();
		ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirtyByItem(rootItem);
	}

	// Token: 0x060083AE RID: 33710 RVA: 0x0022C924 File Offset: 0x0022AB24
	[NullableContext(1)]
	public int GetRewardPos(List<IDangoMonopolyRoundRewardItemData> rewardList)
	{
		int num = -1;
		for (int i = 0; i < rewardList.Count; i++)
		{
			if (rewardList[i].IsCanReceived)
			{
				num = i;
				break;
			}
		}
		if (num >= 0)
		{
			return Math.Max(0, num - 1);
		}
		int num2 = -1;
		for (int j = 0; j < rewardList.Count; j++)
		{
			if (rewardList[j].IsCurrent)
			{
				num2 = j;
				break;
			}
		}
		return Math.Max(0, num2 - 1);
	}

	// Token: 0x060083AF RID: 33711 RVA: 0x0022C992 File Offset: 0x0022AB92
	[NullableContext(1)]
	private DangoMonopolyRoundRewardItem CreateRewardItemGrid()
	{
		return new DangoMonopolyRoundRewardItem
		{
			ClickCallBack = new Action<IDangoMonopolyRoundRewardItemData>(this.OnClickReward)
		};
	}

	// Token: 0x060083B0 RID: 33712 RVA: 0x0022C9AB File Offset: 0x0022ABAB
	public void UpdateProgress()
	{
	}

	// Token: 0x060083B1 RID: 33713 RVA: 0x0022C9AD File Offset: 0x0022ABAD
	[NullableContext(1)]
	private void OnClickReward(IDangoMonopolyRoundRewardItemData data)
	{
		if (this.CheckActivityClose())
		{
			return;
		}
		if (data.IsCanReceived)
		{
			this.ActivityData.RequestReceiveBoard(data.BoardId, true);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(data.ItemId, true, null);
	}

	// Token: 0x060083B2 RID: 33714 RVA: 0x0022C9E8 File Offset: 0x0022ABE8
	public void UpdateSpeed()
	{
		string speedStr = this.ActivityData.GetSpeedStr();
		UUIText text = base.GetText(2);
		if (text == null)
		{
			return;
		}
		text.SetText(speedStr, true);
	}

	// Token: 0x060083B3 RID: 33715 RVA: 0x0022CA14 File Offset: 0x0022AC14
	public void SetMoveDangoUiState(bool visible)
	{
		UUIItem item = base.GetItem(18);
		if (item != null)
		{
			item.SetUIActive(visible);
		}
		UUIButtonComponent button = base.GetButton(8);
		if (button != null)
		{
			button.RootUIComp.Get().SetUIActive(visible);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(23);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(visible);
		}
		DangoMonopolyMainCaption popupCaption = this.PopupCaption;
		if (popupCaption != null)
		{
			popupCaption.SetBtnCloseVisible(visible);
		}
		DangoMonopolyMainCaption popupCaption2 = this.PopupCaption;
		if (popupCaption2 != null)
		{
			popupCaption2.SetBtnHelpVisible(visible);
		}
		DangoMonopolyMainCaption popupCaption3 = this.PopupCaption;
		if (popupCaption3 == null)
		{
			return;
		}
		popupCaption3.SetCurrencyVisible(visible);
	}

	// Token: 0x060083B4 RID: 33716 RVA: 0x0022CAAB File Offset: 0x0022ACAB
	private void EventDangoMonopolyMoveStart()
	{
		this.UpdateSpeed();
		this.UpdateDiceUseState(false, 0);
		this.ResetAngleOfView();
		this.SetMoveDangoUiState(false);
		this.MoveDangoOneStepAsync(true).Forget();
	}

	// Token: 0x060083B5 RID: 33717 RVA: 0x0022CAD4 File Offset: 0x0022ACD4
	public UniTask MoveDangoOneStepAsync(bool isFirst = false)
	{
		DangoMonopolyMainView.<MoveDangoOneStepAsync>d__61 <MoveDangoOneStepAsync>d__;
		<MoveDangoOneStepAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MoveDangoOneStepAsync>d__.<>4__this = this;
		<MoveDangoOneStepAsync>d__.isFirst = isFirst;
		<MoveDangoOneStepAsync>d__.<>1__state = -1;
		<MoveDangoOneStepAsync>d__.<>t__builder.Start<DangoMonopolyMainView.<MoveDangoOneStepAsync>d__61>(ref <MoveDangoOneStepAsync>d__);
		return <MoveDangoOneStepAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060083B6 RID: 33718 RVA: 0x0022CB20 File Offset: 0x0022AD20
	public UniTask CheckTriggerBuffAsync()
	{
		DangoMonopolyMainView.<CheckTriggerBuffAsync>d__62 <CheckTriggerBuffAsync>d__;
		<CheckTriggerBuffAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckTriggerBuffAsync>d__.<>4__this = this;
		<CheckTriggerBuffAsync>d__.<>1__state = -1;
		<CheckTriggerBuffAsync>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckTriggerBuffAsync>d__62>(ref <CheckTriggerBuffAsync>d__);
		return <CheckTriggerBuffAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060083B7 RID: 33719 RVA: 0x0022CB63 File Offset: 0x0022AD63
	public void CheckBuffIsWhenMoveFire(int id)
	{
		if (this.ActivityData.BuffIsWhenMoveFire(id))
		{
			this.ActivityData.OpenViewDangoTips(id, 0);
			DangoMonopolyBoardData showBoardData = this.ShowBoardData;
			if (showBoardData == null)
			{
				return;
			}
			showBoardData.AddRecordTriggerBuff(id);
		}
	}

	// Token: 0x060083B8 RID: 33720 RVA: 0x0022CB94 File Offset: 0x0022AD94
	[NullableContext(1)]
	public UniTask CheckGridIsActiveDouble(DangoMonopolyGridData gridData)
	{
		DangoMonopolyMainView.<CheckGridIsActiveDouble>d__64 <CheckGridIsActiveDouble>d__;
		<CheckGridIsActiveDouble>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckGridIsActiveDouble>d__.<>4__this = this;
		<CheckGridIsActiveDouble>d__.gridData = gridData;
		<CheckGridIsActiveDouble>d__.<>1__state = -1;
		<CheckGridIsActiveDouble>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckGridIsActiveDouble>d__64>(ref <CheckGridIsActiveDouble>d__);
		return <CheckGridIsActiveDouble>d__.<>t__builder.Task;
	}

	// Token: 0x060083B9 RID: 33721 RVA: 0x0022CBE0 File Offset: 0x0022ADE0
	public UniTask DangoMonopolyMoveEnd()
	{
		DangoMonopolyMainView.<DangoMonopolyMoveEnd>d__65 <DangoMonopolyMoveEnd>d__;
		<DangoMonopolyMoveEnd>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<DangoMonopolyMoveEnd>d__.<>4__this = this;
		<DangoMonopolyMoveEnd>d__.<>1__state = -1;
		<DangoMonopolyMoveEnd>d__.<>t__builder.Start<DangoMonopolyMainView.<DangoMonopolyMoveEnd>d__65>(ref <DangoMonopolyMoveEnd>d__);
		return <DangoMonopolyMoveEnd>d__.<>t__builder.Task;
	}

	// Token: 0x060083BA RID: 33722 RVA: 0x0022CC24 File Offset: 0x0022AE24
	public UniTask CheckEnterNextRound()
	{
		DangoMonopolyMainView.<CheckEnterNextRound>d__66 <CheckEnterNextRound>d__;
		<CheckEnterNextRound>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<CheckEnterNextRound>d__.<>4__this = this;
		<CheckEnterNextRound>d__.<>1__state = -1;
		<CheckEnterNextRound>d__.<>t__builder.Start<DangoMonopolyMainView.<CheckEnterNextRound>d__66>(ref <CheckEnterNextRound>d__);
		return <CheckEnterNextRound>d__.<>t__builder.Task;
	}

	// Token: 0x060083BB RID: 33723 RVA: 0x0022CC67 File Offset: 0x0022AE67
	private void EventDangoMonopolyBoardRewardUpdate()
	{
		this.UpdateReward(true);
	}

	// Token: 0x060083BC RID: 33724 RVA: 0x0022CC70 File Offset: 0x0022AE70
	public UniTask AwaitRewardShowClose()
	{
		DangoMonopolyMainView.<AwaitRewardShowClose>d__68 <AwaitRewardShowClose>d__;
		<AwaitRewardShowClose>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<AwaitRewardShowClose>d__.<>4__this = this;
		<AwaitRewardShowClose>d__.<>1__state = -1;
		<AwaitRewardShowClose>d__.<>t__builder.Start<DangoMonopolyMainView.<AwaitRewardShowClose>d__68>(ref <AwaitRewardShowClose>d__);
		return <AwaitRewardShowClose>d__.<>t__builder.Task;
	}

	// Token: 0x060083BD RID: 33725 RVA: 0x0022CCB3 File Offset: 0x0022AEB3
	private void EventOnCloseRewardView()
	{
		CustomPromise rewardViewClosePromise = this.RewardViewClosePromise;
		if (rewardViewClosePromise == null)
		{
			return;
		}
		rewardViewClosePromise.SetResult();
	}

	// Token: 0x060083BE RID: 33726 RVA: 0x0022CCC8 File Offset: 0x0022AEC8
	public UniTask UpdateDangoPosition(bool show = true)
	{
		DangoMonopolyMainView.<UpdateDangoPosition>d__70 <UpdateDangoPosition>d__;
		<UpdateDangoPosition>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateDangoPosition>d__.<>4__this = this;
		<UpdateDangoPosition>d__.show = show;
		<UpdateDangoPosition>d__.<>1__state = -1;
		<UpdateDangoPosition>d__.<>t__builder.Start<DangoMonopolyMainView.<UpdateDangoPosition>d__70>(ref <UpdateDangoPosition>d__);
		return <UpdateDangoPosition>d__.<>t__builder.Task;
	}

	// Token: 0x060083BF RID: 33727 RVA: 0x0022CD14 File Offset: 0x0022AF14
	public FVector2D GetDangoCursorPosition()
	{
		int runningGridId = this.ActivityData.GetRunningGridId();
		DangoMonopolyGridInfoPanel dangoMonopolyGridInfoPanel;
		if (this.ActivityData.BoardGridUiInfoMap.TryGetValue(runningGridId, out dangoMonopolyGridInfoPanel))
		{
			return dangoMonopolyGridInfoPanel.GetCursorPosition();
		}
		long mainRoleDangoEntityId = this.ActivityData.MainRoleDangoEntityId;
		EntityHandle entity = ModelBase<CreatureModel>.Instance.GetEntity(mainRoleDangoEntityId);
		if (entity != null && entity.Valid && entity.IsInit && entity.Entity != null)
		{
			BaseActorComponent component = entity.Entity.GetComponent<BaseActorComponent>();
			if (((component != null) ? component.SkeletalMesh : null) != null)
			{
				float num = component.SkeletalMesh.Bounds.BoxExtent.Z * 2f;
				return Singleton<UiModelUtil>.Instance.GetActorLguiPos(component.Owner, global::Vector.Create(0.0, 0.0, (double)num));
			}
		}
		return new FVector2D();
	}

	// Token: 0x060083C0 RID: 33728 RVA: 0x0022CDE8 File Offset: 0x0022AFE8
	private void EventDangoMonopolyStartShowProcess()
	{
		DangoMonopolyPosition dangoPosition = this.DangoPosition;
		if (dangoPosition == null)
		{
			return;
		}
		dangoPosition.SetActive(false);
	}

	// Token: 0x060083C1 RID: 33729 RVA: 0x0022CDFB File Offset: 0x0022AFFB
	private void EventDangoMonopolyEndShowProcess()
	{
		this.UpdateDangoPosition(true).Forget();
	}

	// Token: 0x060083C2 RID: 33730 RVA: 0x0022CE09 File Offset: 0x0022B009
	private void OnClickAngleOfView(EToggleState toggleState)
	{
		this.UpdateAngleOfView().Forget();
	}

	// Token: 0x060083C3 RID: 33731 RVA: 0x0022CE18 File Offset: 0x0022B018
	public UniTask UpdateAngleOfView()
	{
		DangoMonopolyMainView.<UpdateAngleOfView>d__75 <UpdateAngleOfView>d__;
		<UpdateAngleOfView>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<UpdateAngleOfView>d__.<>4__this = this;
		<UpdateAngleOfView>d__.<>1__state = -1;
		<UpdateAngleOfView>d__.<>t__builder.Start<DangoMonopolyMainView.<UpdateAngleOfView>d__75>(ref <UpdateAngleOfView>d__);
		return <UpdateAngleOfView>d__.<>t__builder.Task;
	}

	// Token: 0x060083C4 RID: 33732 RVA: 0x0022CE5C File Offset: 0x0022B05C
	public void UpdateAngleOfViewBtnState()
	{
		EToggleState state = this.IsOverView ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		UUIExtendToggle extendToggle = base.GetExtendToggle(23);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleStateForce(state, false, false, false);
	}

	// Token: 0x060083C5 RID: 33733 RVA: 0x0022CE8C File Offset: 0x0022B08C
	public void ResetAngleOfView()
	{
		if (!this.IsOverView)
		{
			return;
		}
		this.IsOverView = false;
		this.UpdateAngleOfViewBtnState();
	}

	// Token: 0x04003E81 RID: 16001
	private DangoMonopolyMainCaption PopupCaption;

	// Token: 0x04003E82 RID: 16002
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoMonopolyBuffStateItem, IDangoMonopolyRoundBuffData> BuffLayoutView;

	// Token: 0x04003E83 RID: 16003
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private LoopScrollView<DangoMonopolyRoundRewardItem, IDangoMonopolyRoundRewardItemData> RewardLayout;

	// Token: 0x04003E84 RID: 16004
	private DangoMonopolyRoundRewardItem EndRoundReward;

	// Token: 0x04003E85 RID: 16005
	public DangoMonopolyBoardData ShowBoardData;

	// Token: 0x04003E86 RID: 16006
	public bool IsCheckShow;

	// Token: 0x04003E87 RID: 16007
	public const int WaitTimeActiveClose = 500;

	// Token: 0x04003E88 RID: 16008
	public CustomPromise RewardViewClosePromise;

	// Token: 0x04003E89 RID: 16009
	public CustomPromise ResultClosePromise;

	// Token: 0x04003E8A RID: 16010
	public CustomPromise ResultShowPromise;

	// Token: 0x04003E8B RID: 16011
	public TimerHandle RefreshTimerHandle;

	// Token: 0x04003E8C RID: 16012
	public bool IsBoardLock;

	// Token: 0x04003E8D RID: 16013
	public DangoMonopolyPosition DangoPosition;

	// Token: 0x04003E8E RID: 16014
	public bool IsOverView;

	// Token: 0x02007678 RID: 30328
	[NullableContext(0)]
	private enum EChildType
	{
		// Token: 0x04028D26 RID: 167206
		ItemCaption,
		// Token: 0x04028D27 RID: 167207
		BtnSpeed,
		// Token: 0x04028D28 RID: 167208
		TxtSpeedTitle,
		// Token: 0x04028D29 RID: 167209
		TxtCurrentRound,
		// Token: 0x04028D2A RID: 167210
		TxtTotalRound,
		// Token: 0x04028D2B RID: 167211
		VLayoutProperty,
		// Token: 0x04028D2C RID: 167212
		ItemProperty,
		// Token: 0x04028D2D RID: 167213
		ItemAllBoardFinish,
		// Token: 0x04028D2E RID: 167214
		BtnRoundRecord,
		// Token: 0x04028D2F RID: 167215
		BtnDiceTask,
		// Token: 0x04028D30 RID: 167216
		BtnUseDice,
		// Token: 0x04028D31 RID: 167217
		SpriteDiceMask,
		// Token: 0x04028D32 RID: 167218
		TxtFinishedRound,
		// Token: 0x04028D33 RID: 167219
		TxtTotalRound2,
		// Token: 0x04028D34 RID: 167220
		LoopViewRoundReward,
		// Token: 0x04028D35 RID: 167221
		ItemRoundReward,
		// Token: 0x04028D36 RID: 167222
		ItemFinalReward,
		// Token: 0x04028D37 RID: 167223
		ItemLeftTopRoot,
		// Token: 0x04028D38 RID: 167224
		ItemBottomRoot,
		// Token: 0x04028D39 RID: 167225
		ItemDiceTaskRedDot,
		// Token: 0x04028D3A RID: 167226
		ItemRollDiceRedDot,
		// Token: 0x04028D3B RID: 167227
		ItemBoardLockTipsRoot,
		// Token: 0x04028D3C RID: 167228
		TxtBoardLockTips,
		// Token: 0x04028D3D RID: 167229
		ToggleAngleOfView
	}
}
