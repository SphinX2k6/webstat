using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002380 RID: 9088
public class BattlePassBackgroundPanel : UiPanelBase
{
	// Token: 0x060116AD RID: 71341 RVA: 0x004CCCE4 File Offset: 0x004CAEE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISliderComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 2;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickReceiveBtn));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(8, new Action(this.OnClickBuyPassBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x060116AE RID: 71342 RVA: 0x004CCF20 File Offset: 0x004CB120
	private void OnClickBuyLevelBtn(int _)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BattlePassBuyLevelView, null, null);
		OnBattlePassOperationLogEvent onBattlePassOperationLogEvent = new OnBattlePassOperationLogEvent();
		onBattlePassOperationLogEvent.i_operation_type = 0;
		ControllerBase<LogReportController>.Instance.LogReport(onBattlePassOperationLogEvent);
	}

	// Token: 0x060116AF RID: 71343 RVA: 0x004CCF58 File Offset: 0x004CB158
	private void OnClickBuyPassBtn()
	{
		BattlePassBackgroundPanelParam battlePassBackgroundPanelParam = (BattlePassBackgroundPanelParam)this.OpenParam;
		ModelBase<BattlePassModel>.Instance.PayButtonRedDotState = false;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.BattlePassPayView, battlePassBackgroundPanelParam.WeaponObservers, null);
		OnBattlePassOperationLogEvent onBattlePassOperationLogEvent = new OnBattlePassOperationLogEvent();
		onBattlePassOperationLogEvent.i_operation_type = 1;
		ControllerBase<LogReportController>.Instance.LogReport(onBattlePassOperationLogEvent);
	}

	// Token: 0x060116B0 RID: 71344 RVA: 0x004CCFAA File Offset: 0x004CB1AA
	private void OnClickReceiveBtn()
	{
		if (this.IsRewardPanel)
		{
			ControllerBase<BattlePassController>.Instance.RequestTakeAllRewardResponse();
			return;
		}
		ControllerBase<BattlePassController>.Instance.TryRequestTaskList(ModelBase<BattlePassModel>.Instance.GetAllFinishedTask());
	}

	// Token: 0x060116B1 RID: 71345 RVA: 0x004CCFD4 File Offset: 0x004CB1D4
	protected override UniTask OnCreateAsync()
	{
		BattlePassBackgroundPanel.<OnCreateAsync>d__10 <OnCreateAsync>d__;
		<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnCreateAsync>d__.<>4__this = this;
		<OnCreateAsync>d__.<>1__state = -1;
		<OnCreateAsync>d__.<>t__builder.Start<BattlePassBackgroundPanel.<OnCreateAsync>d__10>(ref <OnCreateAsync>d__);
		return <OnCreateAsync>d__.<>t__builder.Task;
	}

	// Token: 0x060116B2 RID: 71346 RVA: 0x004CD018 File Offset: 0x004CB218
	private UniTask LoadRedSprite()
	{
		BattlePassBackgroundPanel.<LoadRedSprite>d__11 <LoadRedSprite>d__;
		<LoadRedSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadRedSprite>d__.<>4__this = this;
		<LoadRedSprite>d__.<>1__state = -1;
		<LoadRedSprite>d__.<>t__builder.Start<BattlePassBackgroundPanel.<LoadRedSprite>d__11>(ref <LoadRedSprite>d__);
		return <LoadRedSprite>d__.<>t__builder.Task;
	}

	// Token: 0x060116B3 RID: 71347 RVA: 0x004CD05C File Offset: 0x004CB25C
	private UniTask LoadGreenSprite()
	{
		BattlePassBackgroundPanel.<LoadGreenSprite>d__12 <LoadGreenSprite>d__;
		<LoadGreenSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<LoadGreenSprite>d__.<>4__this = this;
		<LoadGreenSprite>d__.<>1__state = -1;
		<LoadGreenSprite>d__.<>t__builder.Start<BattlePassBackgroundPanel.<LoadGreenSprite>d__12>(ref <LoadGreenSprite>d__);
		return <LoadGreenSprite>d__.<>t__builder.Task;
	}

	// Token: 0x060116B4 RID: 71348 RVA: 0x004CD0A0 File Offset: 0x004CB2A0
	protected void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<int?>(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetBattlePassRewardEvent));
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(this.RefreshButton));
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveBattlePassDataEvent, new Action(this.RefreshMainView));
		Singleton<EventSystem>.Instance.Add(EEventName.NotifyBattlePassToBuyEvent, new Action(this.OnClickBuyPassBtn));
	}

	// Token: 0x060116B5 RID: 71349 RVA: 0x004CD120 File Offset: 0x004CB320
	protected void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.GetBattlePassRewardEvent, new Action<int?>(this.OnGetBattlePassRewardEvent));
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateBattlePassTaskEvent, new Action(this.RefreshButton));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveBattlePassDataEvent, new Action(this.RefreshMainView));
		Singleton<EventSystem>.Instance.Remove(EEventName.NotifyBattlePassToBuyEvent, new Action(this.OnClickBuyPassBtn));
	}

	// Token: 0x060116B6 RID: 71350 RVA: 0x004CD1A0 File Offset: 0x004CB3A0
	protected override void OnStart()
	{
		this.BuyLevelBtn = new ButtonItem(base.GetItem(6));
		this.BuyLevelBtn.SetFunction(new Action<int>(this.OnClickBuyLevelBtn));
		BattlePassBackgroundPanelParam battlePassBackgroundPanelParam = (BattlePassBackgroundPanelParam)this.OpenParam;
		this.IsRewardPanel = battlePassBackgroundPanelParam.IsRewardPanel;
		this.RefreshMainView();
		this.AddEventListener();
	}

	// Token: 0x060116B7 RID: 71351 RVA: 0x004CD1FA File Offset: 0x004CB3FA
	protected override void OnBeforeShow()
	{
		base.GetItem(10).SetUIActive(false);
		base.GetItem(11).SetUIActive(false);
		ControllerBase<RedDotController>.Instance.BindRedDot(ERedDotName.BattlePassPayButton, base.GetItem(12), null, 0);
	}

	// Token: 0x060116B8 RID: 71352 RVA: 0x004CD231 File Offset: 0x004CB431
	protected override void OnBeforeHide()
	{
		ControllerBase<RedDotController>.Instance.UnBindRedDot(ERedDotName.BattlePassPayButton);
	}

	// Token: 0x060116B9 RID: 71353 RVA: 0x004CD242 File Offset: 0x004CB442
	protected override void OnAfterShow()
	{
		base.AddChild(this.BuyLevelBtn);
	}

	// Token: 0x060116BA RID: 71354 RVA: 0x004CD250 File Offset: 0x004CB450
	private void OnGetBattlePassRewardEvent(int? _)
	{
		this.RefreshButton();
	}

	// Token: 0x060116BB RID: 71355 RVA: 0x004CD258 File Offset: 0x004CB458
	private void RefreshButton()
	{
		if (this.IsRewardPanel)
		{
			base.GetButton(7).RootUIComp.Get().SetUIActive(ModelBase<BattlePassModel>.Instance.CheckHasRewardWaitTake());
			return;
		}
		base.GetButton(7).RootUIComp.Get().SetUIActive(ModelBase<BattlePassModel>.Instance.CheckHasTaskWaitTake());
	}

	// Token: 0x060116BC RID: 71356 RVA: 0x004CD2B4 File Offset: 0x004CB4B4
	private void RefreshMainView()
	{
		int battlePassLevel = ModelBase<BattlePassModel>.Instance.BattlePassLevel;
		int maxLevel = ModelBase<BattlePassModel>.Instance.GetMaxLevel();
		base.GetText(1).SetText(battlePassLevel.ToString(), true);
		base.GetSprite(3).SetSprite((maxLevel == battlePassLevel) ? this.RedSprite : this.GreenSprite, true);
		this.BuyLevelBtn.SetEnableClick(maxLevel > battlePassLevel);
		this.BuyLevelBtn.SetLocalTextNew((maxLevel > battlePassLevel) ? "Text_BattlePassLevelBuy_Text" : "Text_BattlePassLevelBuyMax_Text", Array.Empty<object>());
		UUIItem item = base.GetItem((maxLevel == battlePassLevel) ? 11 : 10);
		item.SetUIActive(false);
		item.SetUIActive(true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(5), "Text_BattlePassWeekExp_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			ModelBase<BattlePassModel>.Instance.WeekExp,
			ModelBase<BattlePassModel>.Instance.GetMaxWeekExp()
		}));
		base.GetText(5).SetUIActive(maxLevel > battlePassLevel);
		int maxLevelExp = ModelBase<BattlePassModel>.Instance.GetMaxLevelExp();
		int num = (battlePassLevel != maxLevel) ? ModelBase<BattlePassModel>.Instance.LevelExp : maxLevelExp;
		base.GetText(4).SetText(num.ToString() + "/" + maxLevelExp.ToString(), true);
		base.GetSlider(2).SetValue((float)num / (float)maxLevelExp, true);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(9), ModelBase<BattlePassModel>.Instance.GetPassPayBtnKey(), Array.Empty<object>());
		this.RefreshButton();
	}

	// Token: 0x060116BD RID: 71357 RVA: 0x004CD426 File Offset: 0x004CB626
	protected override void OnBeforeDestroy()
	{
		this.BuyLevelBtn = null;
		this.RemoveEventListener();
		this.RedSprite = null;
		this.GreenSprite = null;
	}

	// Token: 0x040088B9 RID: 35001
	[Nullable(2)]
	private ButtonItem BuyLevelBtn;

	// Token: 0x040088BA RID: 35002
	private bool IsRewardPanel;

	// Token: 0x040088BB RID: 35003
	[Nullable(2)]
	private ULGUISpriteData_BaseObject RedSprite;

	// Token: 0x040088BC RID: 35004
	[Nullable(2)]
	private ULGUISpriteData_BaseObject GreenSprite;

	// Token: 0x02008698 RID: 34456
	private enum EReportOperation
	{
		// Token: 0x0402D86C RID: 186476
		BuyLevelBtn,
		// Token: 0x0402D86D RID: 186477
		BuyPassBtn
	}

	// Token: 0x02008699 RID: 34457
	private enum EComponents
	{
		// Token: 0x0402D86F RID: 186479
		Panel,
		// Token: 0x0402D870 RID: 186480
		TxtLevel,
		// Token: 0x0402D871 RID: 186481
		ExpSlider,
		// Token: 0x0402D872 RID: 186482
		PicFull,
		// Token: 0x0402D873 RID: 186483
		TxtExp,
		// Token: 0x0402D874 RID: 186484
		TxtLimit,
		// Token: 0x0402D875 RID: 186485
		BtnBuyLevel,
		// Token: 0x0402D876 RID: 186486
		BtnReceive,
		// Token: 0x0402D877 RID: 186487
		BtnBuyPass,
		// Token: 0x0402D878 RID: 186488
		TxtBtnBuyPass,
		// Token: 0x0402D879 RID: 186489
		EffectGreen,
		// Token: 0x0402D87A RID: 186490
		EffectRed,
		// Token: 0x0402D87B RID: 186491
		PayButtonRedDotItem
	}
}
