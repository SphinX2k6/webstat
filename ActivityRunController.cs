using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001585 RID: 5509
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityRunController : ActivityControllerBase<ActivityRunController>
{
	// Token: 0x06009AC6 RID: 39622 RVA: 0x00288A88 File Offset: 0x00286C88
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRunView);
	}

	// Token: 0x06009AC7 RID: 39623 RVA: 0x00288A99 File Offset: 0x00286C99
	protected override void OnOpenView(ActivityBaseData data)
	{
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRunView, data, null);
	}

	// Token: 0x06009AC8 RID: 39624 RVA: 0x00288AAC File Offset: 0x00286CAC
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_Running";
	}

	// Token: 0x06009AC9 RID: 39625 RVA: 0x00288AB3 File Offset: 0x00286CB3
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewRun();
	}

	// Token: 0x06009ACA RID: 39626 RVA: 0x00288ABA File Offset: 0x00286CBA
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityRun();
	}

	// Token: 0x06009ACB RID: 39627 RVA: 0x00288AC1 File Offset: 0x00286CC1
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
	}

	// Token: 0x06009ACC RID: 39628 RVA: 0x00288ADF File Offset: 0x00286CDF
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
	}

	// Token: 0x06009ACD RID: 39629 RVA: 0x00288AFD File Offset: 0x00286CFD
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<ParkourChallengeOpenNotify>(ENotifyMessageId.ParkourChallengeOpenNotify, new Action<ParkourChallengeOpenNotify, Net.CallbackStatus>(this.OnParkourChallengeOpenNotify));
		Singleton<Net>.Instance.Register<ParkourChallengeEndNotify>(ENotifyMessageId.ParkourChallengeEndNotify, new Action<ParkourChallengeEndNotify, Net.CallbackStatus>(this.OnParkourChallengeEndNotify));
	}

	// Token: 0x06009ACE RID: 39630 RVA: 0x00288B37 File Offset: 0x00286D37
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ParkourChallengeOpenNotify);
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.ParkourChallengeEndNotify);
	}

	// Token: 0x06009ACF RID: 39631 RVA: 0x00288B5C File Offset: 0x00286D5C
	public void SelectDefaultChallengeId(ActivityBaseData baseData)
	{
		int defaultOpenUiChallengeIndex = ModelBase<ActivityRunModel>.Instance.GetDefaultOpenUiChallengeIndex(baseData);
		ModelBase<ActivityRunModel>.Instance.SetStartViewSelectIndex(defaultOpenUiChallengeIndex);
	}

	// Token: 0x06009AD0 RID: 39632 RVA: 0x00288B80 File Offset: 0x00286D80
	private void RequestChallengeInfo()
	{
		ParkourChallengeRequest message = ParkourChallengeRequest.Create();
		Singleton<Net>.Instance.Call<ParkourChallengeResponse>(ERequestMessageId.ParkourChallengeRequest, message, delegate(ParkourChallengeResponse response, Net.CallbackStatus _)
		{
			ModelBase<ActivityRunModel>.Instance.OnReceiveMessageData(response);
		}, 0);
	}

	// Token: 0x06009AD1 RID: 39633 RVA: 0x00288BC4 File Offset: 0x00286DC4
	public void RequestTakeChallengeReward(int challengeId, int scoreIndex)
	{
		ParkourChallengeTakeRequest parkourChallengeTakeRequest = ParkourChallengeTakeRequest.Create();
		parkourChallengeTakeRequest.ChallengeId = challengeId;
		parkourChallengeTakeRequest.ScoreIndex = scoreIndex;
		Singleton<Net>.Instance.Call<ParkourChallengeTakeResponse>(ERequestMessageId.ParkourChallengeTakeRequest, parkourChallengeTakeRequest, delegate(ParkourChallengeTakeResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 23646, null, true, true);
				return;
			}
			ModelBase<ActivityRunModel>.Instance.OnGetChallengeReward(challengeId, scoreIndex);
		}, 0);
	}

	// Token: 0x06009AD2 RID: 39634 RVA: 0x00288C20 File Offset: 0x00286E20
	private void OnParkourChallengeOpenNotify(ParkourChallengeOpenNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		ModelBase<ActivityRunModel>.Instance.OnReceiveChallengeOpenNotify(message);
	}

	// Token: 0x06009AD3 RID: 39635 RVA: 0x00288C30 File Offset: 0x00286E30
	private void OnParkourChallengeEndNotify(ParkourChallengeEndNotify message, [Nullable(2)] Net.CallbackStatus _)
	{
		if (!message.IsComplete)
		{
			RunEndData runEndData = new RunEndData();
			runEndData.Phrase(message);
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRunFailView, runEndData, null);
			return;
		}
		ActivityRunData activityRunData = ModelBase<ActivityRunModel>.Instance.GetActivityRunData(message.ChallengeId);
		if (activityRunData == null)
		{
			return;
		}
		int miniTime = activityRunData.GetMiniTime();
		int maxScore = activityRunData.GetMaxScore();
		activityRunData.OnChallengeEnd(message);
		int miniTime2 = activityRunData.GetMiniTime();
		int maxScore2 = activityRunData.GetMaxScore();
		bool ifNewRecord = false;
		if (miniTime2 < miniTime || maxScore < maxScore2 || miniTime == 0)
		{
			ifNewRecord = true;
		}
		RunEndData runEndData2 = new RunEndData();
		runEndData2.Phrase(message);
		runEndData2.SetIfNewRecord(ifNewRecord);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityRunSuccessView, runEndData2, null);
	}

	// Token: 0x06009AD4 RID: 39636 RVA: 0x00288CDC File Offset: 0x00286EDC
	public void RequestTransToParkourChallenge(int challengeId)
	{
		ParkourChallengeTransRequest parkourChallengeTransRequest = ParkourChallengeTransRequest.Create();
		parkourChallengeTransRequest.ChallengeId = challengeId;
		Singleton<Net>.Instance.Call<ParkourChallengeTransResponse>(ERequestMessageId.ParkourChallengeTransRequest, parkourChallengeTransRequest, delegate(ParkourChallengeTransResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18039, null, true, true);
				return;
			}
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityRunSuccessView, null);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.ActivityRunFailView, null);
		}, 0);
	}

	// Token: 0x06009AD5 RID: 39637 RVA: 0x00288D26 File Offset: 0x00286F26
	private void OnReceiveActivityData(int type, IReadOnlyList<int> activityIds)
	{
		if (type == 0)
		{
			this.RequestChallengeInfo();
		}
	}
}
