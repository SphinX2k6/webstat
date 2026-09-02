using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Dango.DangoLogic;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;
using CSharpScript.Game.Module.UiCameraAnimation.UiCameraContext;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x0200273F RID: 10047
[NullableContext(1)]
[Nullable(0)]
public class RacingBetsMainView : UiTickViewBase, IUiCameraBehavior
{
	// Token: 0x06013D40 RID: 81216 RVA: 0x00585A94 File Offset: 0x00583C94
	public RacingBetsMainView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013D41 RID: 81217 RVA: 0x00585AE4 File Offset: 0x00583CE4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 37;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(22, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(25, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(26, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(27, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(28, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(29, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(30, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(31, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(32, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(33, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(34, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(35, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(36, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 4;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRaycastButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickCloseButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(32, new Action(this.OnClickMatchResultDetailButton));
		num++;
		*span2[num] = new ValueTuple<int, Delegate>(34, new Action(this.OnClickViewPreviousResultButton));
		this.BtnBindInfo = list2;
	}

	// Token: 0x06013D42 RID: 81218 RVA: 0x00586098 File Offset: 0x00584298
	protected override UniTask OnBeforeStartAsync()
	{
		RacingBetsMainView.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<RacingBetsMainView.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06013D43 RID: 81219 RVA: 0x005860DC File Offset: 0x005842DC
	protected override UniTask OnBeforeShowAsyncImplementImplement()
	{
		RacingBetsMainView.<OnBeforeShowAsyncImplementImplement>d__35 <OnBeforeShowAsyncImplementImplement>d__;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
		<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
		<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<RacingBetsMainView.<OnBeforeShowAsyncImplementImplement>d__35>(ref <OnBeforeShowAsyncImplementImplement>d__);
		return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
	}

	// Token: 0x06013D44 RID: 81220 RVA: 0x00586120 File Offset: 0x00584320
	private void ApplyMainViewDisplayRule()
	{
		int curLegMatchDataIndex = this.SeasonData.GetCurLegMatchDataIndex();
		RacingBetsLegMatchData legMatchDataByIndex = this.SeasonData.GetLegMatchDataByIndex(curLegMatchDataIndex);
		int id = this.SeasonData.Id;
		RacingBetsLegMatchData endOfMatchLegMatchData = this.SeasonData.GetEndOfMatchLegMatchData();
		RacingBetsLegMatchData racingBetsLegMatchData = (legMatchDataByIndex.GetLegMatchState() == ERacingBetsLegMatchState.BettingPeriod) ? legMatchDataByIndex : null;
		if (endOfMatchLegMatchData != null && racingBetsLegMatchData != null && endOfMatchLegMatchData.Id != racingBetsLegMatchData.Id)
		{
			if (!ModelBase<RacingBetsModel>.Instance.HasEnteredBettingMainView(id, endOfMatchLegMatchData.Id))
			{
				this.ShowLegMatchData = endOfMatchLegMatchData;
				this.ActualLegMatchData = racingBetsLegMatchData;
				this.IsViewingPreviousResult = true;
				return;
			}
			bool flag;
			if (this.IsViewingPreviousResult)
			{
				RacingBetsLegMatchData showLegMatchData = this.ShowLegMatchData;
				int? num = (showLegMatchData != null) ? new int?(showLegMatchData.Id) : null;
				int id2 = endOfMatchLegMatchData.Id;
				flag = (num.GetValueOrDefault() == id2 & num != null);
			}
			else
			{
				flag = false;
			}
			if (flag)
			{
				this.ShowLegMatchData = endOfMatchLegMatchData;
				this.ActualLegMatchData = racingBetsLegMatchData;
				this.IsViewingPreviousResult = true;
				return;
			}
			this.ShowLegMatchData = racingBetsLegMatchData;
			this.ActualLegMatchData = racingBetsLegMatchData;
			this.IsViewingPreviousResult = false;
			return;
		}
		else
		{
			if (endOfMatchLegMatchData == null)
			{
				this.ShowLegMatchData = legMatchDataByIndex;
				this.ActualLegMatchData = legMatchDataByIndex;
				this.IsViewingPreviousResult = false;
				return;
			}
			RacingBetsLegMatchData nextLegMatchData = this.SeasonData.GetNextLegMatchData(endOfMatchLegMatchData.Id);
			if (nextLegMatchData == null || nextLegMatchData.GetLegMatchState() != ERacingBetsLegMatchState.BettingPeriod)
			{
				this.ShowLegMatchData = endOfMatchLegMatchData;
				this.ActualLegMatchData = (nextLegMatchData ?? legMatchDataByIndex);
				this.IsViewingPreviousResult = false;
				return;
			}
			this.ShowLegMatchData = legMatchDataByIndex;
			this.ActualLegMatchData = legMatchDataByIndex;
			this.IsViewingPreviousResult = false;
			return;
		}
	}

	// Token: 0x06013D45 RID: 81221 RVA: 0x005862A0 File Offset: 0x005844A0
	private UniTask InitComponent()
	{
		RacingBetsMainView.<InitComponent>d__37 <InitComponent>d__;
		<InitComponent>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitComponent>d__.<>4__this = this;
		<InitComponent>d__.<>1__state = -1;
		<InitComponent>d__.<>t__builder.Start<RacingBetsMainView.<InitComponent>d__37>(ref <InitComponent>d__);
		return <InitComponent>d__.<>t__builder.Task;
	}

	// Token: 0x06013D46 RID: 81222 RVA: 0x005862E4 File Offset: 0x005844E4
	private void InitButtonItem()
	{
		this.ActivityInternalRewardButton.BindRedDot(ERedDotName.RedDotRacingBetsActivityInternalReward, 0);
		this.ActivityRewardButton.BindRedDot(ERedDotName.RedDotRacingBetsActivityReward, 0);
		this.HistoryButton.SetRedDotVisible(false);
		this.ReplayButton.SetFunction(new Action(this.OnClickReplayButton));
		this.ReplayChampionButton.SetFunction(new Action(this.OnClickReplayButton));
		this.BetButton.SetFunction(new Action(this.OnClickBetButton));
		this.RankButton.SetFunction(new Action(this.OnClickRankButton));
		this.HistoryButton.SetFunction(new Action(this.OnClickBettingHistoryButton));
		this.ScheduleButton.SetFunction(new Action(this.OnClickScheduleButton));
		this.ActivityInternalRewardButton.SetFunction(new Action(this.OnClickActivityInternalRewardButton));
		this.ActivityRewardButton.SetFunction(new Action(this.OnClickActivityRewardButton));
		this.ToBetButton.SetFunction(new Action(this.OnClickToBetButton));
	}

	// Token: 0x06013D47 RID: 81223 RVA: 0x005863EE File Offset: 0x005845EE
	private RacingBetsLegMatchResultItem ResultItemProxyCreate()
	{
		return new RacingBetsLegMatchResultItem();
	}

	// Token: 0x06013D48 RID: 81224 RVA: 0x005863F5 File Offset: 0x005845F5
	public void PushCameraHandle(EUiViewName viewName, int viewId, bool isBlend)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PushCameraHandle((EUiViewName)"Camera_DangoPreview_Start", new int?(viewId), isBlend);
	}

	// Token: 0x06013D49 RID: 81225 RVA: 0x00586414 File Offset: 0x00584614
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnRacingBetsCloseLoading));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsDangoOddsUpdate, new Action(this.OnRacingBetsDangoOddsUpdate));
		Singleton<EventSystem>.Instance.Add<RacingBetsSeasonData>(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRedDotUpdate, new Action(this.OnRacingBetsRedDotUpdate));
		Singleton<EventSystem>.Instance.Add<UiCameraHandleData>(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06013D4A RID: 81226 RVA: 0x005864AD File Offset: 0x005846AD
	protected override void OnBeforeShow()
	{
		if (ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(this.ShowLegMatchData.Id) && this.CurMatchState == ERacingBetsLegMatchState.EndOfMatch)
		{
			base.PlaySequence("Champion", null, false);
		}
		this.RefreshUi();
	}

	// Token: 0x06013D4B RID: 81227 RVA: 0x005864E4 File Offset: 0x005846E4
	protected override void OnAfterShow()
	{
		this.RefreshDangoOddsInfo();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnRacingBetsViewAfterShow);
		if (ControllerBase<RacingBetsController>.Instance.TryOpenRacingBetsLegMatchResultView())
		{
			return;
		}
		if (this.IsFirstShow)
		{
			return;
		}
		ControllerBase<RacingBetsController>.Instance.TryStartRacingBetsGaming(this.ShowLegMatchData.Id);
		if (this.ActorShowType == ERacingBetsMainViewShowType.SixDango)
		{
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RacingBetsMainSixDango");
			return;
		}
		Singleton<EventSystem>.Instance.Emit<string>(EEventName.OnGuideTriggerEvent, "RacingBetsMainOneDango");
	}

	// Token: 0x06013D4C RID: 81228 RVA: 0x00586568 File Offset: 0x00584768
	private void RefreshUi()
	{
		this.FirstLegMatchItem.RefreshUi(this.ShowLegMatchData);
		this.SecondLegMatchItem.RefreshUi(this.NextLegMatchData);
		this.BroadcastItem.Init(this.ShowLegMatchData);
		this.RefreshCurrencyItem(this.SeasonData);
		this.RefreshResultPanel(this.ShowLegMatchData);
		this.RefreshBetPanel(this.ShowLegMatchData);
		this.RefreshTimePanel(this.ShowLegMatchData);
		this.RefreshAudio(this.ShowLegMatchData);
		this.RefreshButtonShowState(this.ShowLegMatchData);
		this.RefreshButtonRedDot();
	}

	// Token: 0x06013D4D RID: 81229 RVA: 0x005865F8 File Offset: 0x005847F8
	private void RefreshCurrencyItem(RacingBetsSeasonData seasonData)
	{
		this.CommonCurrencyItem.RefreshTemp(seasonData.GetCurrencyItemId(), seasonData.GetCurrencyCount().ToString());
		this.CommonCurrencyItem.SetButtonActive(false);
	}

	// Token: 0x06013D4E RID: 81230 RVA: 0x00586630 File Offset: 0x00584830
	private void RefreshResultPanel(RacingBetsLegMatchData legMatchData)
	{
		bool flag = ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(legMatchData.Id);
		bool flag2 = legMatchData.IsLegMatchFinished();
		base.GetItem(27).SetUIActive(!flag && flag2);
		base.GetItem(28).SetUIActive(flag && flag2);
		base.GetItem(30).SetUIActive(flag && flag2);
		base.GetItem(12).SetUIActive(flag2);
		if (flag2)
		{
			if (flag)
			{
				this.RefreshFinalResultPanel(legMatchData);
				return;
			}
			this.RefreshNormalResultPanel(legMatchData);
		}
	}

	// Token: 0x06013D4F RID: 81231 RVA: 0x005866AC File Offset: 0x005848AC
	private void RefreshNormalResultPanel(RacingBetsLegMatchData legMatchData)
	{
		List<IRacingBetsLegMatchResultData> legMatchResultList = legMatchData.GetLegMatchResultList();
		base.GetText(14).ShowTextNew(legMatchData.Name);
		this.MatchResultLayout.RefreshByData(legMatchResultList, null, false);
		this.ReplayChampionButton.SetActive(false);
		this.ReplayButton.SetActive(true);
	}

	// Token: 0x06013D50 RID: 81232 RVA: 0x005866FC File Offset: 0x005848FC
	private void RefreshFinalResultPanel(RacingBetsLegMatchData legMatchData)
	{
		this.ChampionRewardItem.Refresh(this.SeasonData.GetSeasonConfig().EndReward);
		int championDangoId = legMatchData.GetChampionDangoId();
		DangoData dangoData = Singleton<DangoManager>.Instance.GetDangoData(championDangoId);
		base.GetText(31).ShowTextNew(dangoData.NameKey);
		this.ReplayChampionButton.SetActive(true);
		this.ReplayButton.SetActive(false);
	}

	// Token: 0x06013D51 RID: 81233 RVA: 0x00586768 File Offset: 0x00584968
	private void RefreshBetPanel(RacingBetsLegMatchData legMatchData)
	{
		ERacingBetsLegMatchState curMatchState = this.CurMatchState;
		if (curMatchState != ERacingBetsLegMatchState.BettingPeriod && curMatchState != ERacingBetsLegMatchState.EndOfBetting && curMatchState != ERacingBetsLegMatchState.MatchPeriod)
		{
			base.GetItem(19).SetUIActive(false);
			return;
		}
		base.GetItem(19).SetUIActive(true);
		if (!legMatchData.HasBetting)
		{
			base.GetItem(20).SetUIActive(false);
			base.GetItem(25).SetUIActive(true);
			return;
		}
		base.GetItem(20).SetUIActive(true);
		base.GetItem(25).SetUIActive(false);
		UUIText text = base.GetText(24);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("×");
		defaultInterpolatedStringHandler.AppendFormatted<int>(legMatchData.Odds / 100);
		text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		int currencyItemId = this.SeasonData.GetCurrencyItemId();
		this.BetsCostItem.RefreshUi(currencyItemId, legMatchData.BetGearCash);
		this.BetRewardItem.RefreshUi(currencyItemId, legMatchData.GetOddsRewardCount());
	}

	// Token: 0x06013D52 RID: 81234 RVA: 0x00586850 File Offset: 0x00584A50
	private void RefreshTimePanel(RacingBetsLegMatchData legMatchData)
	{
		ERacingBetsLegMatchState legMatchState = legMatchData.GetLegMatchState();
		UUIText text = base.GetText(3);
		double num = 0.0;
		if (legMatchState == ERacingBetsLegMatchState.EndOfMatch)
		{
			RacingBetsLegMatchData nextLegMatchData = this.NextLegMatchData;
			if (nextLegMatchData != null)
			{
				num = nextLegMatchData.GetLegRemindTime();
			}
		}
		else if (legMatchState != ERacingBetsLegMatchState.MatchPeriod)
		{
			num = legMatchData.GetLegRemindTime();
		}
		if (legMatchState == ERacingBetsLegMatchState.NotOpen)
		{
			text.ShowTextNew("Dango_MainPage_StatusTime_Bet");
		}
		else if (legMatchState == ERacingBetsLegMatchState.BettingPeriod)
		{
			text.ShowTextNew("Dango_MainPage_StatusTime_Bet");
		}
		else if (legMatchState == ERacingBetsLegMatchState.EndOfBetting)
		{
			text.ShowTextNew("Dango_MainPage_StatusTime_Wait");
		}
		else if (legMatchState == ERacingBetsLegMatchState.MatchPeriod)
		{
			text.ShowTextNew("Dango_MainPage_StatusTime_Race");
		}
		else if (legMatchState == ERacingBetsLegMatchState.EndOfMatch || legMatchState == ERacingBetsLegMatchState.End)
		{
			if (ModelBase<RacingBetsModel>.Instance.IsFinalLegMatch(legMatchData.Id))
			{
				text.ShowTextNew("Dango_MainPage_StatusTime_FinalRaceEnd");
			}
			else
			{
				text.ShowTextNew("Dango_MainPage_StatusTime_Settle");
			}
		}
		if (num > 0.0)
		{
			UUIText text2 = base.GetText(4);
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(num);
			text2.SetText(((remainTimeDataFormat != null) ? remainTimeDataFormat.CountDownText : null) ?? "", true);
			text2.SetUIActive(true);
			return;
		}
		base.GetText(4).SetUIActive(false);
	}

	// Token: 0x06013D53 RID: 81235 RVA: 0x00586960 File Offset: 0x00584B60
	private void RefreshAudio(RacingBetsLegMatchData legMatchData)
	{
		if (this.CurMatchState == ERacingBetsLegMatchState.EndOfMatch)
		{
			Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.RaceFinals.ToString(), true);
			return;
		}
		Singleton<AudioSystem>.Instance.SetState("dungeon_2_3_race_music", ERacingBetsAudioState.None.ToString(), true);
	}

	// Token: 0x06013D54 RID: 81236 RVA: 0x005869B8 File Offset: 0x00584BB8
	private void RefreshButtonShowState(RacingBetsLegMatchData legMatchData)
	{
		bool flag = this.CurMatchState == ERacingBetsLegMatchState.BettingPeriod;
		RacingBetsLegMatchData endOfMatchLegMatchData = this.SeasonData.GetEndOfMatchLegMatchData();
		if (this.IsViewingPreviousResult)
		{
			bool active = endOfMatchLegMatchData != null && endOfMatchLegMatchData.Id == this.ShowLegMatchData.Id;
			base.GetButton(34).RootUIComp.Get().SetUIActive(false);
			this.ToBetButton.SetActive(active);
		}
		else
		{
			bool uiactive = flag && endOfMatchLegMatchData != null;
			base.GetButton(34).RootUIComp.Get().SetUIActive(uiactive);
			this.ToBetButton.SetActive(false);
		}
		base.GetButton(0).SetSelfInteractive(flag && !this.IsViewingPreviousResult);
		ERacingBetsLegMatchState legMatchState = this.SeasonData.GetCurLegMatchData().GetLegMatchState();
		base.GetButton(32).RootUIComp.Get().SetUIActive(legMatchState != ERacingBetsLegMatchState.End && legMatchState != ERacingBetsLegMatchState.EndOfMatch && !this.IsViewingPreviousResult);
		this.BetButton.SetActive(legMatchState != ERacingBetsLegMatchState.End && legMatchState != ERacingBetsLegMatchState.EndOfMatch && !this.IsViewingPreviousResult);
	}

	// Token: 0x06013D55 RID: 81237 RVA: 0x00586AD8 File Offset: 0x00584CD8
	private void RefreshButtonRedDot()
	{
		if (this.ShowLegMatchData == null)
		{
			return;
		}
		ERacingBetsLegMatchState legMatchState = this.ShowLegMatchData.GetLegMatchState();
		RacingBetsRedDotState player = LocalStorage.GetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsMatchViewRecord, null);
		this.ScheduleButton.SetRedDotVisible(player != null && !player.HasViewed);
		RacingBetsRedDotState player2 = LocalStorage.GetPlayer<RacingBetsRedDotState>(ELocalStoragePlayerKey.RacingBetsRankViewRecord, null);
		bool flag = this.SeasonData.CheckRankOpen();
		this.RankButton.SetRedDotVisible(player2 != null && !player2.HasViewed && flag);
		int player3 = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsReplayGameRecord, 0);
		bool redDotVisible = legMatchState == ERacingBetsLegMatchState.EndOfMatch && this.ShowLegMatchData.Id > player3;
		this.ReplayButton.SetRedDotVisible(redDotVisible);
		this.ReplayChampionButton.SetRedDotVisible(redDotVisible);
		bool redDotVisible2 = false;
		int betDangoId = this.ShowLegMatchData.BetDangoId;
		if (legMatchState == ERacingBetsLegMatchState.BettingPeriod)
		{
			redDotVisible2 = (betDangoId == 0);
		}
		else if (legMatchState == ERacingBetsLegMatchState.MatchPeriod)
		{
			int player4 = LocalStorage.GetPlayer<int>(ELocalStoragePlayerKey.RacingBetsWatchGameRecord, 0);
			redDotVisible2 = (this.ShowLegMatchData.Id > player4);
		}
		this.BetButton.SetRedDotVisible(redDotVisible2);
		bool redDotVisible3 = this.IsViewingPreviousResult && this.ActualLegMatchData != null && this.ActualLegMatchData.GetLegMatchState() == ERacingBetsLegMatchState.BettingPeriod && this.ActualLegMatchData.BetDangoId == 0;
		this.ToBetButton.SetRedDotVisible(redDotVisible3);
	}

	// Token: 0x06013D56 RID: 81238 RVA: 0x00586C20 File Offset: 0x00584E20
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnRacingBetsCloseLoading));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDangoOddsUpdate, new Action(this.OnRacingBetsDangoOddsUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRedDotUpdate, new Action(this.OnRacingBetsRedDotUpdate));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnActivateUiCameraAnimationHandle, new Action<UiCameraHandleData>(this.OnActivateUiCameraAnimationHandle));
	}

	// Token: 0x06013D57 RID: 81239 RVA: 0x00586CB9 File Offset: 0x00584EB9
	[NullableContext(2)]
	public void PopCameraHandle(EUiViewName viewName, UiViewInfo stackTopInfo, int closeViewId, bool popOrDelete)
	{
		ControllerBase<UiCameraAnimationController>.Instance.PopCameraHandle((EUiViewName)"Camera_DangoPreview_Start", stackTopInfo, closeViewId, popOrDelete);
	}

	// Token: 0x06013D58 RID: 81240 RVA: 0x00586CD3 File Offset: 0x00584ED3
	protected override void OnBeforeHide()
	{
		this.RefreshDangoListOddsVisible(this.BettingDangoActorList, false);
	}

	// Token: 0x06013D59 RID: 81241 RVA: 0x00586CE2 File Offset: 0x00584EE2
	protected override void OnAfterHide()
	{
		if (this.HoverDango != null)
		{
			Singleton<UiModelUtil>.Instance.SelectDangoActor(this.HoverDango, false);
			this.HoverDango = null;
		}
	}

	// Token: 0x06013D5A RID: 81242 RVA: 0x00586D04 File Offset: 0x00584F04
	protected override void OnBeforeDestroy()
	{
		if (this.MatchStateChangeDelayTimer != null)
		{
			TimerSystem.RealTimeInstance.Remove(this.MatchStateChangeDelayTimer);
			this.MatchStateChangeDelayTimer = null;
		}
		this.DestroyDangoActor();
	}

	// Token: 0x06013D5B RID: 81243 RVA: 0x00586D2C File Offset: 0x00584F2C
	private UniTask InitDangoActorList()
	{
		RacingBetsMainView.<InitDangoActorList>d__59 <InitDangoActorList>d__;
		<InitDangoActorList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDangoActorList>d__.<>4__this = this;
		<InitDangoActorList>d__.<>1__state = -1;
		<InitDangoActorList>d__.<>t__builder.Start<RacingBetsMainView.<InitDangoActorList>d__59>(ref <InitDangoActorList>d__);
		return <InitDangoActorList>d__.<>t__builder.Task;
	}

	// Token: 0x06013D5C RID: 81244 RVA: 0x00586D6F File Offset: 0x00584F6F
	private void RefreshDangoOddsInfo()
	{
		if (this.ActorShowType != ERacingBetsMainViewShowType.OneDango)
		{
			this.RefreshDangoActorOdds(this.BettingDangoActorList, this.ShowLegMatchData);
			this.RefreshDangoListOddsVisible(this.BettingDangoActorList, !this.IsViewingPreviousResult);
			return;
		}
		this.RefreshDangoListOddsVisible(this.BettingDangoActorList, false);
	}

	// Token: 0x06013D5D RID: 81245 RVA: 0x00586DB0 File Offset: 0x00584FB0
	private void RefreshDangoActorOdds(List<TsUiSceneDangoActor> dangoActorList, RacingBetsLegMatchData legMatchData)
	{
		bool flag = legMatchData.Type == 2;
		for (int i = 0; i < dangoActorList.Count - 1; i++)
		{
			TsUiSceneDangoActor tsUiSceneDangoActor = dangoActorList[i];
			UiDangoDataComponent uiDangoDataComponent = tsUiSceneDangoActor.Model.CheckGetComponent<UiDangoDataComponent>();
			int dangoId = uiDangoDataComponent.DangoId;
			DangoConfig instance = ConfigBase<DangoConfig>.Instance;
			Dango? dango = (instance != null) ? instance.GetDangoById(dangoId) : null;
			if (dango == null || dango.GetValueOrDefault().Type != 1)
			{
				IRacingBetsDangoActorData dangoActorData = legMatchData.GetDangoActorData(dangoId);
				UiDangoOddsComponent uiDangoOddsComponent = tsUiSceneDangoActor.Model.CheckGetComponent<UiDangoOddsComponent>();
				int rank = flag ? (i + 1) : 0;
				bool isBet = legMatchData.BetDangoId == uiDangoDataComponent.DangoId;
				uiDangoOddsComponent.SetOffset(dangoActorData.DangoOffset);
				uiDangoOddsComponent.Refresh(dangoActorData.Odds / 100, rank, isBet);
			}
		}
	}

	// Token: 0x06013D5E RID: 81246 RVA: 0x00586E8C File Offset: 0x0058508C
	private void RefreshDangoListOddsVisible(List<TsUiSceneDangoActor> dangoActorList, bool visible)
	{
		foreach (TsUiSceneDangoActor tsUiSceneDangoActor in dangoActorList)
		{
			UiDangoDataComponent uiDangoDataComponent = tsUiSceneDangoActor.Model.CheckGetComponent<UiDangoDataComponent>();
			DangoConfig instance = ConfigBase<DangoConfig>.Instance;
			Dango? dango = (instance != null) ? instance.GetDangoById(uiDangoDataComponent.DangoId) : null;
			bool flag = dango != null && dango.GetValueOrDefault().Type == 1;
			tsUiSceneDangoActor.Model.CheckGetComponent<UiDangoOddsComponent>().SetVisible(!flag && visible);
		}
	}

	// Token: 0x06013D5F RID: 81247 RVA: 0x00586F38 File Offset: 0x00585138
	private void DestroyDangoActor()
	{
		this.DestroyBettingDangoActor();
		this.DestroyWinnerDangoActor();
	}

	// Token: 0x06013D60 RID: 81248 RVA: 0x00586F48 File Offset: 0x00585148
	private void DestroyBettingDangoActor()
	{
		if (this.BettingDangoActorList.Count == 0)
		{
			return;
		}
		foreach (TsUiSceneDangoActor dango in this.BettingDangoActorList)
		{
			Singleton<UiSceneManager>.Instance.DestroyDangoActor(dango);
		}
		this.BettingDangoActorList = new List<TsUiSceneDangoActor>();
	}

	// Token: 0x06013D61 RID: 81249 RVA: 0x00586FB8 File Offset: 0x005851B8
	private void DestroyWinnerDangoActor()
	{
		if (this.WinnerDangoActorList.Count == 0)
		{
			return;
		}
		foreach (TsUiSceneDangoActor dango in this.WinnerDangoActorList)
		{
			Singleton<UiSceneManager>.Instance.DestroyDangoActor(dango);
		}
		this.WinnerDangoActorList = new List<TsUiSceneDangoActor>();
	}

	// Token: 0x06013D62 RID: 81250 RVA: 0x00587028 File Offset: 0x00585228
	protected unsafe override void OnTick(float delta)
	{
		this.RefreshTimePanel(this.ShowLegMatchData);
		this.BroadcastItem.OnTick(delta);
		this.CheckHoverDango();
		if (!ModelBase<RacingBetsModel>.Instance.UseGmState)
		{
			if (this.IsViewingPreviousResult)
			{
				RacingBetsLegMatchData endOfMatchLegMatchData = this.SeasonData.GetEndOfMatchLegMatchData();
				if (endOfMatchLegMatchData == null || endOfMatchLegMatchData.Id != this.ShowLegMatchData.Id)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.RacingBets;
					ELogAuthor author = ELogAuthor.LRC;
					string message = "[OnTick] AutoSwitchBack triggered";
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("endOfMatchLegId", (endOfMatchLegMatchData != null) ? endOfMatchLegMatchData.Id : -1);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowLegId", this.ShowLegMatchData.Id);
					instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					this.SwitchBackToBettingMode().Forget();
				}
				return;
			}
			RacingBetsLegMatchData curLegMatchData = this.SeasonData.GetCurLegMatchData();
			if (curLegMatchData == null)
			{
				return;
			}
			if (curLegMatchData.GetLegMatchState() == this.CurMatchState && curLegMatchData.Id == this.ShowLegMatchData.Id)
			{
				return;
			}
			if (this.IsMatchStateChangePending)
			{
				return;
			}
			this.IsMatchStateChangePending = true;
			bool flag = curLegMatchData.Id != this.ShowLegMatchData.Id;
			bool flag2 = this.SeasonData.GetEndOfMatchLegMatchData() != null;
			if (flag && !flag2)
			{
				this.MatchStateChangeDelayTimer = TimerSystem.RealTimeInstance.Delay(new TTimerAction(this.OnMatchStateChangeDelayTimerEnd), 10000f, null, null, true, 1f);
				return;
			}
			this.MatchStateChange().Forget();
		}
	}

	// Token: 0x06013D63 RID: 81251 RVA: 0x005871B4 File Offset: 0x005853B4
	private void CheckHoverDango()
	{
		if (!Singleton<Info>.Instance.IsInKeyBoard())
		{
			return;
		}
		ERacingBetsLegMatchState legMatchState = this.ShowLegMatchData.GetLegMatchState();
		if (!base.IsShowOrShowing || legMatchState != ERacingBetsLegMatchState.BettingPeriod)
		{
			if (this.HoverDango != null)
			{
				Singleton<UiModelUtil>.Instance.SelectDangoActor(this.HoverDango, false);
				this.HoverDango = null;
			}
			return;
		}
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		if (pointerEventDataPosition == null)
		{
			return;
		}
		TsUiSceneDangoActor tsUiSceneDangoActor = Singleton<UiSceneManager>.Instance.RayTraceDangoActor(pointerEventDataPosition.Value);
		if (tsUiSceneDangoActor == this.HoverDango)
		{
			return;
		}
		if (tsUiSceneDangoActor == null)
		{
			if (this.HoverDango != null)
			{
				Singleton<UiModelUtil>.Instance.SelectDangoActor(this.HoverDango, false);
			}
			this.HoverDango = null;
			return;
		}
		if (this.HoverDango != null)
		{
			Singleton<UiModelUtil>.Instance.SelectDangoActor(this.HoverDango, false);
		}
		this.HoverDango = tsUiSceneDangoActor;
		Singleton<UiModelUtil>.Instance.SelectDangoActor(this.HoverDango, true);
	}

	// Token: 0x06013D64 RID: 81252 RVA: 0x0058728E File Offset: 0x0058548E
	private void OnMatchStateChangeDelayTimerEnd(float _)
	{
		this.MatchStateChangeDelayTimer = null;
		this.MatchStateChange().Forget();
	}

	// Token: 0x06013D65 RID: 81253 RVA: 0x005872A4 File Offset: 0x005854A4
	private UniTask MatchStateChange()
	{
		RacingBetsMainView.<MatchStateChange>d__70 <MatchStateChange>d__;
		<MatchStateChange>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<MatchStateChange>d__.<>4__this = this;
		<MatchStateChange>d__.<>1__state = -1;
		<MatchStateChange>d__.<>t__builder.Start<RacingBetsMainView.<MatchStateChange>d__70>(ref <MatchStateChange>d__);
		return <MatchStateChange>d__.<>t__builder.Task;
	}

	// Token: 0x06013D66 RID: 81254 RVA: 0x005872E7 File Offset: 0x005854E7
	private void OnRacingBetsDangoOddsUpdate()
	{
		this.RefreshDangoActorOdds(this.BettingDangoActorList, this.ShowLegMatchData);
	}

	// Token: 0x06013D67 RID: 81255 RVA: 0x005872FB File Offset: 0x005854FB
	private void OnRacingBetsCloseLoading()
	{
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_fx_spl_rsnt_weapon_cam_in");
	}

	// Token: 0x06013D68 RID: 81256 RVA: 0x0058730D File Offset: 0x0058550D
	private void OnActivateUiCameraAnimationHandle(UiCameraHandleData handleData)
	{
		if (handleData.HandleName != this.CameraHandleName)
		{
			return;
		}
		if (!this.IsFirstShow)
		{
			return;
		}
		ControllerBase<RacingBetsController>.Instance.TryStartRacingBetsGaming(this.ShowLegMatchData.Id);
		this.IsFirstShow = false;
	}

	// Token: 0x06013D69 RID: 81257 RVA: 0x00587348 File Offset: 0x00585548
	private void OnRacingBetsRedDotUpdate()
	{
		this.RefreshButtonRedDot();
	}

	// Token: 0x06013D6A RID: 81258 RVA: 0x00587350 File Offset: 0x00585550
	private void OnRacingBetsDataRefresh(RacingBetsSeasonData seasonData)
	{
		if (!base.IsShowOrShowing || seasonData == null || seasonData.Id != this.SeasonData.Id)
		{
			return;
		}
		this.RefreshBySeasonData().Forget();
	}

	// Token: 0x06013D6B RID: 81259 RVA: 0x0058737C File Offset: 0x0058557C
	private UniTask RefreshBySeasonData()
	{
		RacingBetsMainView.<RefreshBySeasonData>d__76 <RefreshBySeasonData>d__;
		<RefreshBySeasonData>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<RefreshBySeasonData>d__.<>4__this = this;
		<RefreshBySeasonData>d__.<>1__state = -1;
		<RefreshBySeasonData>d__.<>t__builder.Start<RacingBetsMainView.<RefreshBySeasonData>d__76>(ref <RefreshBySeasonData>d__);
		return <RefreshBySeasonData>d__.<>t__builder.Task;
	}

	// Token: 0x06013D6C RID: 81260 RVA: 0x005873C0 File Offset: 0x005855C0
	private UniTask SwitchToViewPreviousResult()
	{
		RacingBetsMainView.<SwitchToViewPreviousResult>d__77 <SwitchToViewPreviousResult>d__;
		<SwitchToViewPreviousResult>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SwitchToViewPreviousResult>d__.<>4__this = this;
		<SwitchToViewPreviousResult>d__.<>1__state = -1;
		<SwitchToViewPreviousResult>d__.<>t__builder.Start<RacingBetsMainView.<SwitchToViewPreviousResult>d__77>(ref <SwitchToViewPreviousResult>d__);
		return <SwitchToViewPreviousResult>d__.<>t__builder.Task;
	}

	// Token: 0x06013D6D RID: 81261 RVA: 0x00587404 File Offset: 0x00585604
	private UniTask SwitchBackToBettingMode()
	{
		RacingBetsMainView.<SwitchBackToBettingMode>d__78 <SwitchBackToBettingMode>d__;
		<SwitchBackToBettingMode>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<SwitchBackToBettingMode>d__.<>4__this = this;
		<SwitchBackToBettingMode>d__.<>1__state = -1;
		<SwitchBackToBettingMode>d__.<>t__builder.Start<RacingBetsMainView.<SwitchBackToBettingMode>d__78>(ref <SwitchBackToBettingMode>d__);
		return <SwitchBackToBettingMode>d__.<>t__builder.Task;
	}

	// Token: 0x06013D6E RID: 81262 RVA: 0x00587448 File Offset: 0x00585648
	private void OnClickRaycastButton()
	{
		FVector? pointerEventDataPosition = Singleton<LguiEventSystemManager>.Instance.GetPointerEventDataPosition(0);
		if (pointerEventDataPosition == null)
		{
			return;
		}
		TsUiSceneDangoActor tsUiSceneDangoActor = Singleton<UiSceneManager>.Instance.RayTraceDangoActor(pointerEventDataPosition.Value);
		if (tsUiSceneDangoActor == null)
		{
			return;
		}
		UiModelBase model = tsUiSceneDangoActor.Model;
		UiDangoDataComponent uiDangoDataComponent = (model != null) ? model.CheckGetComponent<UiDangoDataComponent>() : null;
		RacingBetsBettingViewData param = new RacingBetsBettingViewData
		{
			SelectDangoId = uiDangoDataComponent.DangoId,
			LegMatchData = this.ShowLegMatchData,
			DangoActorList = this.BettingDangoActorList
		};
		Singleton<AudioSystem>.Instance.PostEvent("play_ui_tuanzi_saima_click_large");
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsBettingView, param, null);
	}

	// Token: 0x06013D6F RID: 81263 RVA: 0x005874E0 File Offset: 0x005856E0
	private void OnClickCloseButton()
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.RacingBetsExitDungeonBackFightConfirm);
		confirmBoxDataNew.FunctionMap[2] = delegate()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeonRequest(LeaveInstWay.Default).Forget<bool>();
		};
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x06013D70 RID: 81264 RVA: 0x00587530 File Offset: 0x00585730
	private void OnClickActivityRewardButton()
	{
		RacingBetsSeasonData seasonData = this.SeasonData;
		RacingBetsGroupRewardData item = (seasonData != null) ? seasonData.GetGroupRewardData(ERacingBetsRewardType.BetsCount) : null;
		RacingBetsSeasonData seasonData2 = this.SeasonData;
		RacingBetsGroupRewardData item2 = (seasonData2 != null) ? seasonData2.GetGroupRewardData(ERacingBetsRewardType.DailyEarn) : null;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsActivityRewardView, new List<RacingBetsGroupRewardData>
		{
			item,
			item2
		}, null);
	}

	// Token: 0x06013D71 RID: 81265 RVA: 0x00587588 File Offset: 0x00585788
	private void OnClickActivityInternalRewardButton()
	{
		RacingBetsSeasonData seasonData = this.SeasonData;
		RacingBetsGroupRewardData item = (seasonData != null) ? seasonData.GetGroupRewardData(ERacingBetsRewardType.DailyGameEarn) : null;
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsRewardView, new List<RacingBetsGroupRewardData>
		{
			item
		}, null);
	}

	// Token: 0x06013D72 RID: 81266 RVA: 0x005875C5 File Offset: 0x005857C5
	private void OnClickBettingHistoryButton()
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsHistoryView, null, null);
	}

	// Token: 0x06013D73 RID: 81267 RVA: 0x005875D8 File Offset: 0x005857D8
	private void OnClickRankButton()
	{
		ControllerBase<RacingBetsController>.Instance.RacingBetsRankRequest(this.SeasonData.Id, delegate
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsRankView, null, null);
		});
		ModelBase<RacingBetsModel>.Instance.SetViewRedDotState(ELocalStoragePlayerKey.RacingBetsRankViewRecord);
	}

	// Token: 0x06013D74 RID: 81268 RVA: 0x00587628 File Offset: 0x00585828
	private void OnClickScheduleButton()
	{
		ModelBase<RacingBetsModel>.Instance.SetViewRedDotState(ELocalStoragePlayerKey.RacingBetsMatchViewRecord);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsMatchView, null, null);
	}

	// Token: 0x06013D75 RID: 81269 RVA: 0x0058764A File Offset: 0x0058584A
	private void OnClickReplayButton()
	{
		ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(this.SeasonData.Id, this.ShowLegMatchData.Id);
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RacingBetsReplayGameRecord, this.ShowLegMatchData.Id);
	}

	// Token: 0x06013D76 RID: 81270 RVA: 0x00587684 File Offset: 0x00585884
	private void OnClickMatchResultDetailButton()
	{
		int id = this.SeasonData.GetCurLegMatchData().Id;
		ControllerBase<RacingBetsController>.Instance.RacingBetsMatchInfoRequest(this.SeasonData.Id, id);
	}

	// Token: 0x06013D77 RID: 81271 RVA: 0x005876B8 File Offset: 0x005858B8
	private void OnClickBetButton()
	{
		if (this.CurMatchState == ERacingBetsLegMatchState.NotOpen || this.CurMatchState == ERacingBetsLegMatchState.EndOfBetting)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_MainPage_MatchNotStart", Array.Empty<object>());
			return;
		}
		if (this.CurMatchState == ERacingBetsLegMatchState.BettingPeriod)
		{
			this.MarkCurrentOverlapAsEnteredBetting();
			UiModelBase model = this.BettingDangoActorList[0].Model;
			UiDangoDataComponent uiDangoDataComponent = (model != null) ? model.CheckGetComponent<UiDangoDataComponent>() : null;
			RacingBetsBettingViewData param = new RacingBetsBettingViewData
			{
				SelectDangoId = uiDangoDataComponent.DangoId,
				LegMatchData = this.ShowLegMatchData,
				DangoActorList = this.BettingDangoActorList
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.RacingBetsBettingView, param, null);
			return;
		}
		ControllerBase<RacingBetsController>.Instance.RacingBetMatchActionRequest(this.SeasonData.Id, this.ShowLegMatchData.Id);
		LocalStorage.SetPlayer<int>(ELocalStoragePlayerKey.RacingBetsWatchGameRecord, this.ShowLegMatchData.Id);
	}

	// Token: 0x06013D78 RID: 81272 RVA: 0x0058778C File Offset: 0x0058598C
	private unsafe void OnClickViewPreviousResultButton()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RacingBets;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "[OnClickViewPreviousResult]";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsViewingPrev", this.IsViewingPreviousResult);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "ShowLegId";
		RacingBetsLegMatchData showLegMatchData = this.ShowLegMatchData;
		ptr = new ValueTuple<string, object>(item, (showLegMatchData != null) ? showLegMatchData.Id : -1);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		if (!this.IsViewingPreviousResult)
		{
			this.SwitchToViewPreviousResult().Forget();
		}
	}

	// Token: 0x06013D79 RID: 81273 RVA: 0x00587824 File Offset: 0x00585A24
	private unsafe void OnClickToBetButton()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.RacingBets;
		ELogAuthor author = ELogAuthor.LRC;
		string message = "[OnClickToBet] enter";
		<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("IsViewingPrev", this.IsViewingPreviousResult);
		ref ValueTuple<string, object> ptr = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1);
		string item = "ShowLegId";
		RacingBetsLegMatchData showLegMatchData = this.ShowLegMatchData;
		ptr = new ValueTuple<string, object>(item, (showLegMatchData != null) ? showLegMatchData.Id : -1);
		ref ValueTuple<string, object> ptr2 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2);
		string item2 = "ActualLegId";
		RacingBetsLegMatchData actualLegMatchData = this.ActualLegMatchData;
		ptr2 = new ValueTuple<string, object>(item2, (actualLegMatchData != null) ? actualLegMatchData.Id : -1);
		ref ValueTuple<string, object> ptr3 = ref <PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3);
		string item3 = "ActualLegState";
		RacingBetsLegMatchData actualLegMatchData2 = this.ActualLegMatchData;
		ptr3 = new ValueTuple<string, object>(item3, (actualLegMatchData2 != null) ? actualLegMatchData2.GetLegMatchState() : ((ERacingBetsLegMatchState)(-1)));
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
		if (this.IsViewingPreviousResult)
		{
			RacingBetsLegMatchData actualLegMatchData3 = this.ActualLegMatchData;
			ERacingBetsLegMatchState eracingBetsLegMatchState = (actualLegMatchData3 != null) ? actualLegMatchData3.GetLegMatchState() : ((ERacingBetsLegMatchState)(-1));
			int num = (actualLegMatchData3 != null) ? actualLegMatchData3.GetAllDangoActorDataList().Count : 0;
			if (actualLegMatchData3 == null || eracingBetsLegMatchState != ERacingBetsLegMatchState.BettingPeriod || num <= 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.RacingBets;
				ELogAuthor author2 = ELogAuthor.LRC;
				string message2 = "[OnClickToBet] block: data not ready";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("ActualLegState", eracingBetsLegMatchState);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("DangoCount", num);
				instance2.Info(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Dango_MainPage_MatchNotOpen", Array.Empty<object>());
				return;
			}
			Singleton<Log>.Instance.Info(ELogModule.RacingBets, ELogAuthor.LRC, "[OnClickToBet] proceed switch back", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.MarkCurrentOverlapAsEnteredBetting();
			this.SwitchBackToBettingMode().Forget();
		}
	}

	// Token: 0x06013D7A RID: 81274 RVA: 0x005879EC File Offset: 0x00585BEC
	private void MarkCurrentOverlapAsEnteredBetting()
	{
		RacingBetsLegMatchData endOfMatchLegMatchData = this.SeasonData.GetEndOfMatchLegMatchData();
		if (endOfMatchLegMatchData == null)
		{
			return;
		}
		ModelBase<RacingBetsModel>.Instance.MarkBettingMainViewEntered(this.SeasonData.Id, endOfMatchLegMatchData.Id);
	}

	// Token: 0x04009A3D RID: 39485
	private bool IsFirstShow = true;

	// Token: 0x04009A3E RID: 39486
	private string CameraHandleName = "";

	// Token: 0x04009A3F RID: 39487
	private ERacingBetsMainViewShowType ActorShowType = ERacingBetsMainViewShowType.SixDango;

	// Token: 0x04009A40 RID: 39488
	private ERacingBetsLegMatchState CurMatchState;

	// Token: 0x04009A41 RID: 39489
	private RacingBetsSeasonData SeasonData;

	// Token: 0x04009A42 RID: 39490
	private RacingBetsLegMatchData ShowLegMatchData;

	// Token: 0x04009A43 RID: 39491
	[Nullable(2)]
	private RacingBetsLegMatchData NextLegMatchData;

	// Token: 0x04009A44 RID: 39492
	private bool IsViewingPreviousResult;

	// Token: 0x04009A45 RID: 39493
	private RacingBetsLegMatchData ActualLegMatchData;

	// Token: 0x04009A46 RID: 39494
	private bool IsMatchStateChangePending;

	// Token: 0x04009A47 RID: 39495
	[Nullable(2)]
	private TimerHandle MatchStateChangeDelayTimer;

	// Token: 0x04009A48 RID: 39496
	private RacingBetsLegMatchTabItem FirstLegMatchItem;

	// Token: 0x04009A49 RID: 39497
	private RacingBetsLegMatchTabItem SecondLegMatchItem;

	// Token: 0x04009A4A RID: 39498
	private CommonCurrencyItem CommonCurrencyItem;

	// Token: 0x04009A4B RID: 39499
	private RacingBetsCostItem BetsCostItem;

	// Token: 0x04009A4C RID: 39500
	private RacingBetsCostItem BetRewardItem;

	// Token: 0x04009A4D RID: 39501
	private RacingBetsChampionRewardItem ChampionRewardItem;

	// Token: 0x04009A4E RID: 39502
	private RacingBetsDangoBroadcastItem BroadcastItem;

	// Token: 0x04009A4F RID: 39503
	private GenericLayout<RacingBetsLegMatchResultItem, IRacingBetsLegMatchResultData> MatchResultLayout;

	// Token: 0x04009A50 RID: 39504
	private List<TsUiSceneDangoActor> BettingDangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x04009A51 RID: 39505
	private List<IRacingBetsDangoActorData> BettingDangoActorDataList = new List<IRacingBetsDangoActorData>();

	// Token: 0x04009A52 RID: 39506
	private List<TsUiSceneDangoActor> WinnerDangoActorList = new List<TsUiSceneDangoActor>();

	// Token: 0x04009A53 RID: 39507
	private RacingBetsButtonItem ReplayButton;

	// Token: 0x04009A54 RID: 39508
	private RacingBetsButtonItem ReplayChampionButton;

	// Token: 0x04009A55 RID: 39509
	private RacingBetsButtonItem BetButton;

	// Token: 0x04009A56 RID: 39510
	private RacingBetsButtonItem RankButton;

	// Token: 0x04009A57 RID: 39511
	private RacingBetsButtonItem HistoryButton;

	// Token: 0x04009A58 RID: 39512
	private RacingBetsButtonItem ScheduleButton;

	// Token: 0x04009A59 RID: 39513
	private RacingBetsButtonItem ActivityInternalRewardButton;

	// Token: 0x04009A5A RID: 39514
	private RacingBetsButtonItem ActivityRewardButton;

	// Token: 0x04009A5B RID: 39515
	private RacingBetsButtonItem ToBetButton;

	// Token: 0x04009A5C RID: 39516
	[Nullable(2)]
	private TsUiSceneDangoActor HoverDango;

	// Token: 0x02008AF9 RID: 35577
	[NullableContext(0)]
	private class EComponent
	{
		// Token: 0x0402EDE2 RID: 191970
		public const int RaycastButton = 0;

		// Token: 0x0402EDE3 RID: 191971
		public const int CloseButton = 1;

		// Token: 0x0402EDE4 RID: 191972
		public const int CurrencyItem = 2;

		// Token: 0x0402EDE5 RID: 191973
		public const int TimeDescText = 3;

		// Token: 0x0402EDE6 RID: 191974
		public const int RemainTimeText = 4;

		// Token: 0x0402EDE7 RID: 191975
		public const int ActivityInternalRewardButton = 5;

		// Token: 0x0402EDE8 RID: 191976
		public const int ActivityRewardButton = 6;

		// Token: 0x0402EDE9 RID: 191977
		public const int BettingHistoryButton = 7;

		// Token: 0x0402EDEA RID: 191978
		public const int RankButton = 8;

		// Token: 0x0402EDEB RID: 191979
		public const int FirstLegMatchItem = 9;

		// Token: 0x0402EDEC RID: 191980
		public const int SecondLegMatchItem = 10;

		// Token: 0x0402EDED RID: 191981
		public const int ScheduleButton = 11;

		// Token: 0x0402EDEE RID: 191982
		public const int ResultPanel = 12;

		// Token: 0x0402EDEF RID: 191983
		public const int TimeText = 13;

		// Token: 0x0402EDF0 RID: 191984
		public const int ResultTitle = 14;

		// Token: 0x0402EDF1 RID: 191985
		public const int ResultLayout = 15;

		// Token: 0x0402EDF2 RID: 191986
		public const int ReplayButton = 16;

		// Token: 0x0402EDF3 RID: 191987
		public const int BroadcastItem = 17;

		// Token: 0x0402EDF4 RID: 191988
		public const int TipsText = 18;

		// Token: 0x0402EDF5 RID: 191989
		public const int BetPanel = 19;

		// Token: 0x0402EDF6 RID: 191990
		public const int BetInfoItem = 20;

		// Token: 0x0402EDF7 RID: 191991
		public const int BetDangoNameText = 21;

		// Token: 0x0402EDF8 RID: 191992
		public const int DangoTexture = 22;

		// Token: 0x0402EDF9 RID: 191993
		public const int BetCostItem = 23;

		// Token: 0x0402EDFA RID: 191994
		public const int BetOddsText = 24;

		// Token: 0x0402EDFB RID: 191995
		public const int BetEmptyItem = 25;

		// Token: 0x0402EDFC RID: 191996
		public const int BetButton = 26;

		// Token: 0x0402EDFD RID: 191997
		public const int NormalResultPanel = 27;

		// Token: 0x0402EDFE RID: 191998
		public const int ChampionResultPanel = 28;

		// Token: 0x0402EDFF RID: 191999
		public const int ChampionRewardItem = 29;

		// Token: 0x0402EE00 RID: 192000
		public const int ChampionDetailPanel = 30;

		// Token: 0x0402EE01 RID: 192001
		public const int ChampionDangoName = 31;

		// Token: 0x0402EE02 RID: 192002
		public const int MatchResultDetailButton = 32;

		// Token: 0x0402EE03 RID: 192003
		public const int BetRewardItem = 33;

		// Token: 0x0402EE04 RID: 192004
		public const int ViewPreviousResultButton = 34;

		// Token: 0x0402EE05 RID: 192005
		public const int ToBetButton = 35;

		// Token: 0x0402EE06 RID: 192006
		public const int ReplayChampionButton = 36;
	}
}
