using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020026EB RID: 9963
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class RacingBetsController : ActivityControllerBase<RacingBetsController>
{
	// Token: 0x06013ABF RID: 80575 RVA: 0x0057C597 File Offset: 0x0057A797
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06013AC0 RID: 80576 RVA: 0x0057C599 File Offset: 0x0057A799
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_RaceHorseGuide";
	}

	// Token: 0x06013AC1 RID: 80577 RVA: 0x0057C5A0 File Offset: 0x0057A7A0
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new RacingBetsActivityView();
	}

	// Token: 0x06013AC2 RID: 80578 RVA: 0x0057C5A8 File Offset: 0x0057A7A8
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		RacingBetsSeasonData racingBetsSeasonData = new RacingBetsSeasonData();
		ModelBase<RacingBetsModel>.Instance.SetRacingBetsSeasonData(racingBetsSeasonData);
		return racingBetsSeasonData;
	}

	// Token: 0x06013AC3 RID: 80579 RVA: 0x0057C5C7 File Offset: 0x0057A7C7
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x06013AC4 RID: 80580 RVA: 0x0057C5CA File Offset: 0x0057A7CA
	protected override bool OnInit()
	{
		this.IsShowDangoFrameTipView = false;
		return true;
	}

	// Token: 0x06013AC5 RID: 80581 RVA: 0x0057C5D4 File Offset: 0x0057A7D4
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataInit));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.HandleRacingBetsFrameViewShow));
		Singleton<EventSystem>.Instance.Add(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveDungeon));
	}

	// Token: 0x06013AC6 RID: 80582 RVA: 0x0057C654 File Offset: 0x0057A854
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataInit));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDoneAndCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.HandleRacingBetsFrameViewShow));
		Singleton<EventSystem>.Instance.Remove(EEventName.LeaveInstanceDungeon, new Action(this.OnLeaveDungeon));
	}

	// Token: 0x06013AC7 RID: 80583 RVA: 0x0057C6D4 File Offset: 0x0057A8D4
	protected override bool OnClear()
	{
		this.IsShowDangoFrameTipView = false;
		if (this.RefreshOddsTimeTimers != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.RefreshOddsTimeTimers);
			this.RefreshOddsTimeTimers = null;
		}
		if (this.LegMatchStateChangeTimer != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.LegMatchStateChangeTimer);
			this.LegMatchStateChangeTimer = null;
		}
		return true;
	}

	// Token: 0x06013AC8 RID: 80584 RVA: 0x0057C729 File Offset: 0x0057A929
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsDangoActivityOpenTips, null, null);
	}

	// Token: 0x06013AC9 RID: 80585 RVA: 0x0057C73C File Offset: 0x0057A93C
	private void WorldDoneAndCloseLoading()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			return;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instanceId) : null;
		if (instanceDungeon == null || instanceDungeon.Value.InstSubType != 31)
		{
			return;
		}
		int consoleVariableIntValue = UKismetSystemLibrary.GetConsoleVariableIntValue("r.RayTracing.Shadows");
		int consoleVariableIntValue2 = UKismetSystemLibrary.GetConsoleVariableIntValue("r.NGX.DLSS.Enable");
		ModelBase<RacingBetsModel>.Instance.SetVisionValue(consoleVariableIntValue, consoleVariableIntValue2);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.RayTracing.Shadows 0", null);
		UKismetSystemLibrary.ExecuteConsoleCommand(GlobalData.World, "r.NGX.DLSS.Enable 0", null);
	}

	// Token: 0x06013ACA RID: 80586 RVA: 0x0057C7E0 File Offset: 0x0057A9E0
	private void HandleRacingBetsFrameViewShow()
	{
		if (!ControllerBase<GameModeController>.Instance.IsInInstance())
		{
			if (this.IsShowDangoFrameTipView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RacingBetsDangoFrameTipView, null);
				this.IsShowDangoFrameTipView = false;
			}
			return;
		}
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instanceId) : null;
		if (instanceDungeon == null || instanceDungeon.Value.InstSubType != 31)
		{
			if (this.IsShowDangoFrameTipView)
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.RacingBetsDangoFrameTipView, null);
				this.IsShowDangoFrameTipView = false;
			}
			return;
		}
		BP_DiceOL_C bp_DiceOL_C = UKuroCollectActorComponent.GetActorWithTag(FNameUtil.GetDynamicFName("DiceBp").Value, ECollectActorType.UI) as BP_DiceOL_C;
		if (bp_DiceOL_C != null)
		{
			bp_DiceOL_C.SetActorHiddenInGame(true);
		}
		if (!this.IsShowDangoFrameTipView)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsDangoFrameTipView, null, null);
			this.IsShowDangoFrameTipView = true;
		}
	}

	// Token: 0x06013ACB RID: 80587 RVA: 0x0057C8C8 File Offset: 0x0057AAC8
	private void OnLeaveDungeon()
	{
		if (ModelBase<RacingBetsModel>.Instance.CheckInRacingBetsDungeon())
		{
			int rayTracingShadowsValue = ModelBase<RacingBetsModel>.Instance.RayTracingShadowsValue;
			int dlssValue = ModelBase<RacingBetsModel>.Instance.DlssValue;
			UObject world = GlobalData.World;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(21, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.RayTracing.Shadows ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(rayTracingShadowsValue);
			UKismetSystemLibrary.ExecuteConsoleCommand(world, defaultInterpolatedStringHandler.ToStringAndClear(), null);
			UObject world2 = GlobalData.World;
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(18, 1);
			defaultInterpolatedStringHandler.AppendLiteral("r.NGX.DLSS.Enable ");
			defaultInterpolatedStringHandler.AppendFormatted<int>(dlssValue);
			UKismetSystemLibrary.ExecuteConsoleCommand(world2, defaultInterpolatedStringHandler.ToStringAndClear(), null);
		}
	}

	// Token: 0x06013ACC RID: 80588 RVA: 0x0057C957 File Offset: 0x0057AB57
	private void OnRacingBetsDataInit(RacingBetsSeasonData seasonData)
	{
		this.TryRegisterNextDangoOddsUpdateRequest(seasonData);
		this.TryRegisterLegMatchStateChange(seasonData);
	}

	// Token: 0x06013ACD RID: 80589 RVA: 0x0057C968 File Offset: 0x0057AB68
	public void TryRegisterNextDangoOddsUpdateRequest(RacingBetsSeasonData seasonData)
	{
		RacingBetsLegMatchData curLegMatchData = seasonData.GetCurLegMatchData();
		if (curLegMatchData == null)
		{
			return;
		}
		double num = curLegMatchData.NextOddsRateRefreshTime - Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (num < 0.0)
		{
			return;
		}
		if (this.RefreshOddsTimeTimers != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.RefreshOddsTimeTimers);
			this.RefreshOddsTimeTimers = null;
		}
		this.RefreshOddsTimeTimers = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.RacingBetsUpdateOddsRequest), (float)num, null, null, false, 1f);
	}

	// Token: 0x06013ACE RID: 80590 RVA: 0x0057C9E8 File Offset: 0x0057ABE8
	public void TryRegisterLegMatchStateChange(RacingBetsSeasonData seasonData)
	{
		if (seasonData == null)
		{
			return;
		}
		RacingBetsLegMatchData curLegMatchData = seasonData.GetCurLegMatchData();
		if (curLegMatchData == null)
		{
			return;
		}
		double num = Singleton<TimeUtil>.Instance.SetTimeMillisecond(curLegMatchData.GetLegRemindTime());
		if (num <= 0.0)
		{
			return;
		}
		if (this.LegMatchStateChangeTimer != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.LegMatchStateChangeTimer);
			this.LegMatchStateChangeTimer = null;
		}
		this.LegMatchStateChangeTimer = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.OnLegMatchStateChange), (float)num, null, null, false, 1f);
	}

	// Token: 0x06013ACF RID: 80591 RVA: 0x0057CA68 File Offset: 0x0057AC68
	public void TryStartRacingBetsGaming(int legMatchId)
	{
		if (ControllerBase<ConfirmBoxController>.Instance.CheckIsConfirmBoxOpen())
		{
			return;
		}
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		RacingBetsLegMatchData racingBetsLegMatchData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsLegMatchData(legMatchId);
		if (racingBetsLegMatchData == null || racingBetsSeasonData == null)
		{
			return;
		}
		ERacingBetsLegMatchState legMatchState = racingBetsLegMatchData.GetLegMatchState();
		if (ModelBase<RacingBetsModel>.Instance.GetIsFromActivityOpenDungeon() && legMatchState == ERacingBetsLegMatchState.MatchPeriod)
		{
			this.RacingBetMatchActionRequest(racingBetsSeasonData.Id, racingBetsLegMatchData.Id);
			LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RacingBetsWatchGameRecord, racingBetsLegMatchData.Id);
		}
	}

	// Token: 0x06013AD0 RID: 80592 RVA: 0x0057CADC File Offset: 0x0057ACDC
	private void OnLegMatchStateChange(float _)
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return;
		}
		this.TryRegisterLegMatchStateChange(racingBetsSeasonData);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, racingBetsSeasonData.Id);
	}

	// Token: 0x06013AD1 RID: 80593 RVA: 0x0057CB18 File Offset: 0x0057AD18
	public bool TryOpenRacingBetsLegMatchResultView()
	{
		RacingBetLegMatchResultNotify legMatchResultData = ModelBase<RacingBetsModel>.Instance.GetLegMatchResultData();
		if (legMatchResultData == null)
		{
			return false;
		}
		if (legMatchResultData.BetDangoRank == 1)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsSuccessTip, legMatchResultData, null);
		}
		else
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsFailTip, legMatchResultData, null);
		}
		ModelBase<RacingBetsModel>.Instance.SetLegMatchResultData(null);
		return true;
	}

	// Token: 0x06013AD2 RID: 80594 RVA: 0x0057CB70 File Offset: 0x0057AD70
	public void TryLeaveRacingBetsDungeon()
	{
		if (!ModelBase<RacingBetsModel>.Instance.CheckInRacingBetsDungeon())
		{
			return;
		}
		if (ModelBase<RacingBetsModel>.Instance.IsDungeonPlaying)
		{
			ModelBase<RacingBetsModel>.Instance.LeaveDungeonOnEnd = true;
			ModelBase<RacingBetsModel>.Instance.RacingBetsAbortDungeon();
			return;
		}
		ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
	}

	// Token: 0x06013AD3 RID: 80595 RVA: 0x0057CBBC File Offset: 0x0057ADBC
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<RacingBetsPlayerInfoUpdateNotify>(ENotifyMessageId.RacingBetsPlayerInfoUpdateNotify, new Action<RacingBetsPlayerInfoUpdateNotify, Net.CallbackStatus>(this.OnRacingBetsPlayerInfoUpdateNotify));
		Singleton<Net>.Instance.Register<RacingBetsTaskNotify>(ENotifyMessageId.RacingBetsTaskNotify, new Action<RacingBetsTaskNotify, Net.CallbackStatus>(this.OnRacingBetsTaskNotify));
		Singleton<Net>.Instance.Register<RacingBetLegMatchResultNotify>(ENotifyMessageId.RacingBetLegMatchResultNotify, new Action<RacingBetLegMatchResultNotify, Net.CallbackStatus>(this.OnRacingBetLegMatchResultNotify));
		Singleton<Net>.Instance.Register<RacingBetLegMatchSettleNotify>(ENotifyMessageId.RacingBetLegMatchSettleNotify, new Action<RacingBetLegMatchSettleNotify, Net.CallbackStatus>(this.OnRacingBetLegMatchSettleNotify));
	}

	// Token: 0x06013AD4 RID: 80596 RVA: 0x0057CC3C File Offset: 0x0057AE3C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RacingBetsPlayerInfoUpdateNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RacingBetsTaskNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RacingBetLegMatchResultNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.RacingBetLegMatchSettleNotify);
	}

	// Token: 0x06013AD5 RID: 80597 RVA: 0x0057CC8C File Offset: 0x0057AE8C
	public void RacingBetsGearRequest(int activityId, RacingBetsLegMatchData legMatchData, int dangoId, int gearId, int costCount)
	{
		RacingBetsGearRequest racingBetsGearRequest = Aki.Protocol.RacingBetsGearRequest.Create();
		racingBetsGearRequest.ActivityId = activityId;
		racingBetsGearRequest.LegMatchId = legMatchData.Id;
		racingBetsGearRequest.DangoId = dangoId;
		racingBetsGearRequest.GearId = gearId;
		racingBetsGearRequest.Cash = costCount;
		racingBetsGearRequest.OddsVersion = legMatchData.OddsVersion;
		Singleton<Net>.Instance.Call<RacingBetsGearResponse>(ERequestMessageId.RacingBetsGearRequest, racingBetsGearRequest, delegate(RacingBetsGearResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16831, null, true, true);
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_BetPage_BetSuccess", Array.Empty<object>());
			ModelBase<RacingBetsModel>.Instance.OnPlayerInfoUpdate(response.PlayerInfo);
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnRacingBetsBettingInfoUpdate, dangoId, true);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06013AD6 RID: 80598 RVA: 0x0057CD10 File Offset: 0x0057AF10
	public void RacingBetsGearRefundRequest(int activityId, RacingBetsLegMatchData legMatchData, int dangoId)
	{
		RacingBetsGearRefundRequest racingBetsGearRefundRequest = Aki.Protocol.RacingBetsGearRefundRequest.Create();
		racingBetsGearRefundRequest.ActivityId = activityId;
		racingBetsGearRefundRequest.LegMatchId = legMatchData.Id;
		racingBetsGearRefundRequest.DangoId = dangoId;
		Singleton<Net>.Instance.Call<RacingBetsGearRefundResponse>(ERequestMessageId.RacingBetsGearRefundRequest, racingBetsGearRefundRequest, delegate(RacingBetsGearRefundResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 24912, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.OnPlayerInfoUpdate(response.PlayerInfo);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_BetPage_CancelSuccess", Array.Empty<object>());
			Singleton<EventSystem>.Instance.Emit<int, bool>(EEventName.OnRacingBetsBettingInfoUpdate, dangoId, false);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06013AD7 RID: 80599 RVA: 0x0057CD78 File Offset: 0x0057AF78
	[NullableContext(2)]
	public void RacingBetsRankRequest(int activityId, Action callback = null)
	{
		RacingBetsRankRequest racingBetsRankRequest = Aki.Protocol.RacingBetsRankRequest.Create();
		racingBetsRankRequest.ActivityId = activityId;
		Singleton<Net>.Instance.Call<RacingBetsRankResponse>(ERequestMessageId.RacingBetsRankRequest, racingBetsRankRequest, delegate(RacingBetsRankResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode == Aki.Protocol.ErrorCode.RacingBetsBulletNotFundOpenRankCurTime)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_RankPage_EmptyInfo", Array.Empty<object>());
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29152, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.RacingBetsRankRefresh(response);
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x06013AD8 RID: 80600 RVA: 0x0057CDBC File Offset: 0x0057AFBC
	public void RacingBetsTaskRewardRequest(int taskId)
	{
		RacingBetsTaskRewardRequest racingBetsTaskRewardRequest = Aki.Protocol.RacingBetsTaskRewardRequest.Create();
		racingBetsTaskRewardRequest.TaskId = taskId;
		Singleton<Net>.Instance.Call<RacingBetsTaskRewardResponse>(ERequestMessageId.RacingBetsTaskRewardRequest, racingBetsTaskRewardRequest, delegate(RacingBetsTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 16766, null, true, true);
			}
			int id = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().Id;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, id);
		}, 0);
	}

	// Token: 0x06013AD9 RID: 80601 RVA: 0x0057CE08 File Offset: 0x0057B008
	public void RacingBetsUpdateOddsRequest(float _)
	{
		RacingBetsUpdateOddsRequest racingBetsUpdateOddsRequest = Aki.Protocol.RacingBetsUpdateOddsRequest.Create();
		RacingBetsSeasonData seasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		RacingBetsLegMatchData curLegMatchData = seasonData.GetCurLegMatchData();
		racingBetsUpdateOddsRequest.ActivityId = seasonData.Id;
		racingBetsUpdateOddsRequest.LegMatchId = curLegMatchData.Id;
		Singleton<Net>.Instance.Call<RacingBetsUpdateOddsResponse>(ERequestMessageId.RacingBetsUpdateOddsRequest, racingBetsUpdateOddsRequest, delegate(RacingBetsUpdateOddsResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15450, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.OnRacingBetsOddsUpdate(response);
			this.TryRegisterNextDangoOddsUpdateRequest(seasonData);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsDangoOddsUpdate);
		}, 0);
	}

	// Token: 0x06013ADA RID: 80602 RVA: 0x0057CE7E File Offset: 0x0057B07E
	private void OnRacingBetsPlayerInfoUpdateNotify(RacingBetsPlayerInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<RacingBetsModel>.Instance.OnPlayerInfoUpdate(message.PlayerInfo);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsPlayerInfoUpdate);
	}

	// Token: 0x06013ADB RID: 80603 RVA: 0x0057CEA0 File Offset: 0x0057B0A0
	private void OnRacingBetsTaskNotify(RacingBetsTaskNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<RacingBetsModel>.Instance.OnRacingBetsTaskNotify(message);
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsRewardRefresh);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, racingBetsSeasonData.Id);
	}

	// Token: 0x06013ADC RID: 80604 RVA: 0x0057CEED File Offset: 0x0057B0ED
	private void OnRacingBetLegMatchResultNotify(RacingBetLegMatchResultNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<RacingBetsModel>.Instance.OnRacingBetsMatchResultNotify(message);
	}

	// Token: 0x06013ADD RID: 80605 RVA: 0x0057CEFA File Offset: 0x0057B0FA
	private void OnRacingBetLegMatchSettleNotify(RacingBetLegMatchSettleNotify message, [Nullable(2)] Net.CallbackStatus status)
	{
		ModelBase<RacingBetsModel>.Instance.RefreshLegMatchResult(message.Result);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnRacingBetsLegMatchEnd, message.Result.LegMatchId);
	}

	// Token: 0x06013ADE RID: 80606 RVA: 0x0057CF28 File Offset: 0x0057B128
	public void RacingBetMatchActionRequest(int activityId, int legMatchId)
	{
		RacingBetMatchActionRequest racingBetMatchActionRequest = Aki.Protocol.RacingBetMatchActionRequest.Create();
		racingBetMatchActionRequest.ActivityId = activityId;
		racingBetMatchActionRequest.LegMatchId = legMatchId;
		Singleton<Net>.Instance.Call<RacingBetMatchActionResponse>(ERequestMessageId.RacingBetMatchActionRequest, racingBetMatchActionRequest, delegate(RacingBetMatchActionResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28142, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.RacingBetsMatchStart(legMatchId, response);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityId);
		}, 0);
	}

	// Token: 0x06013ADF RID: 80607 RVA: 0x0057CF84 File Offset: 0x0057B184
	[NullableContext(0)]
	public UniTask<bool> RacingBetsMatchRoundActionRequestAsync(int activityId, int legMatchId, int roundId)
	{
		RacingBetsController.<RacingBetsMatchRoundActionRequestAsync>d__35 <RacingBetsMatchRoundActionRequestAsync>d__;
		<RacingBetsMatchRoundActionRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<RacingBetsMatchRoundActionRequestAsync>d__.activityId = activityId;
		<RacingBetsMatchRoundActionRequestAsync>d__.legMatchId = legMatchId;
		<RacingBetsMatchRoundActionRequestAsync>d__.roundId = roundId;
		<RacingBetsMatchRoundActionRequestAsync>d__.<>1__state = -1;
		<RacingBetsMatchRoundActionRequestAsync>d__.<>t__builder.Start<RacingBetsController.<RacingBetsMatchRoundActionRequestAsync>d__35>(ref <RacingBetsMatchRoundActionRequestAsync>d__);
		return <RacingBetsMatchRoundActionRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013AE0 RID: 80608 RVA: 0x0057CFD8 File Offset: 0x0057B1D8
	public void RacingBetsMatchInfoRequest(int activityId, int legMatchId)
	{
		RacingBetMatchInfoRequest racingBetMatchInfoRequest = RacingBetMatchInfoRequest.Create();
		racingBetMatchInfoRequest.ActivityId = activityId;
		racingBetMatchInfoRequest.LegMatchId = legMatchId;
		Singleton<Net>.Instance.Call<RacingBetMatchInfoResponse>(ERequestMessageId.RacingBetMatchInfoRequest, racingBetMatchInfoRequest, delegate(RacingBetMatchInfoResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 19148, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.RacingBetsMatchPreview(legMatchId, response);
		}, 0);
	}

	// Token: 0x06013AE1 RID: 80609 RVA: 0x0057D028 File Offset: 0x0057B228
	public void RacingBetsRepeatedTaskRewardRequest(List<int> taskId)
	{
		RacingBetsRepeatedTaskRewardRequest racingBetsRepeatedTaskRewardRequest = Aki.Protocol.RacingBetsRepeatedTaskRewardRequest.Create();
		racingBetsRepeatedTaskRewardRequest.TaskId.AddRange(taskId);
		Singleton<Net>.Instance.Call<RacingBetsRepeatedTaskRewardResponse>(ERequestMessageId.RacingBetsRepeatedTaskRewardRequest, racingBetsRepeatedTaskRewardRequest, delegate(RacingBetsRepeatedTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18482, null, true, true);
			}
			int id = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData().Id;
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, id);
		}, 0);
	}

	// Token: 0x06013AE2 RID: 80610 RVA: 0x0057D078 File Offset: 0x0057B278
	public void RacingBetsCloseSettleMenuRequest(int legMatchId)
	{
		RacingBetsCloseSettleMenuRequest racingBetsCloseSettleMenuRequest = Aki.Protocol.RacingBetsCloseSettleMenuRequest.Create();
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		racingBetsCloseSettleMenuRequest.ActivityId = racingBetsSeasonData.Id;
		racingBetsCloseSettleMenuRequest.LegMatchId = legMatchId;
		Singleton<Net>.Instance.Call<RacingBetsCloseSettleMenuResponse>(ERequestMessageId.RacingBetsCloseSettleMenuRequest, racingBetsCloseSettleMenuRequest, delegate(RacingBetsCloseSettleMenuResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28553, null, true, true);
				return;
			}
			ModelBase<RacingBetsModel>.Instance.OnRacingBetsCloseSettleMenu(legMatchId);
		}, 0);
	}

	// Token: 0x06013AE3 RID: 80611 RVA: 0x0057D0D8 File Offset: 0x0057B2D8
	public UniTask RacingBetsMatchInfoRequestAsync(int activityId)
	{
		RacingBetsController.<RacingBetsMatchInfoRequestAsync>d__39 <RacingBetsMatchInfoRequestAsync>d__;
		<RacingBetsMatchInfoRequestAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RacingBetsMatchInfoRequestAsync>d__.activityId = activityId;
		<RacingBetsMatchInfoRequestAsync>d__.<>1__state = -1;
		<RacingBetsMatchInfoRequestAsync>d__.<>t__builder.Start<RacingBetsController.<RacingBetsMatchInfoRequestAsync>d__39>(ref <RacingBetsMatchInfoRequestAsync>d__);
		return <RacingBetsMatchInfoRequestAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013AE4 RID: 80612 RVA: 0x0057D11C File Offset: 0x0057B31C
	public void RacingBetsBulletScreenRequest(int bulletScreenId)
	{
		RacingBetsBulletScreenRequest racingBetsBulletScreenRequest = Aki.Protocol.RacingBetsBulletScreenRequest.Create();
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		racingBetsBulletScreenRequest.ActivityId = racingBetsSeasonData.Id;
		racingBetsBulletScreenRequest.LegMatchId = ModelBase<RacingBetsModel>.Instance.DungeonMatchId;
		racingBetsBulletScreenRequest.BulletScreenId = bulletScreenId;
		racingBetsBulletScreenRequest.ActionIndex = ModelBase<RacingBetsModel>.Instance.GetCommandActionIndex();
		Singleton<Net>.Instance.Call<RacingBetsBulletScreenResponse>(ERequestMessageId.RacingBetsBulletScreenRequest, racingBetsBulletScreenRequest, delegate(RacingBetsBulletScreenResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20913, null, true, true);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<IReadOnlyList<int>, bool>(EEventName.OnRacingBetsPushBulletScreen, new List<int>
			{
				bulletScreenId
			}, true);
		}, 0);
	}

	// Token: 0x040098FC RID: 39164
	private bool IsShowDangoFrameTipView;

	// Token: 0x040098FD RID: 39165
	[Nullable(2)]
	private TimerHandle RefreshOddsTimeTimers;

	// Token: 0x040098FE RID: 39166
	[Nullable(2)]
	private TimerHandle LegMatchStateChangeTimer;
}
