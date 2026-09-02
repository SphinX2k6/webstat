using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020012A9 RID: 4777
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityCorniceMeetingController : ActivityControllerBase<ActivityCorniceMeetingController>
{
	// Token: 0x06008002 RID: 32770 RVA: 0x0021CF9C File Offset: 0x0021B19C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x06008003 RID: 32771 RVA: 0x0021CF9E File Offset: 0x0021B19E
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_AbnormalData";
	}

	// Token: 0x06008004 RID: 32772 RVA: 0x0021CFA5 File Offset: 0x0021B1A5
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<CorniceChallengeEndNotify>(ENotifyMessageId.CorniceChallengeEndNotify, new Action<CorniceChallengeEndNotify, Net.CallbackStatus>(this.OnChallengeEndNotify));
	}

	// Token: 0x06008005 RID: 32773 RVA: 0x0021CFC3 File Offset: 0x0021B1C3
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.CorniceChallengeEndNotify);
	}

	// Token: 0x06008006 RID: 32774 RVA: 0x0021CFD8 File Offset: 0x0021B1D8
	private void OnChallengeEndNotify(CorniceChallengeEndNotify data, [Nullable(2)] Net.CallbackStatus _)
	{
		ActivityCorniceMeetingData currentActivityData = this.GetCurrentActivityData();
		if (currentActivityData == null)
		{
			return;
		}
		ActivityCorniceMeetingLevelEntryData levelEntryData = currentActivityData.GetLevelEntryData(data.LevelPlayId);
		if (levelEntryData == null)
		{
			return;
		}
		if (data.NewScoreRecord)
		{
			levelEntryData.MaxScore = data.Score;
		}
		levelEntryData.CurrentScore = data.Score;
		if (data.NewRemainingTimeRecord)
		{
			levelEntryData.RemainTime = data.RemainingTime;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCorniceMeetingRedDot, data.LevelPlayId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ConfigBase<ActivityCorniceMeetingConfig>.Instance.GetCorniceMeetingChallengeConfig(data.LevelPlayId).Value.ActivityId);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.CorniceMeetingSettleView, data, null);
	}

	// Token: 0x06008007 RID: 32775 RVA: 0x0021D08C File Offset: 0x0021B28C
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewCorniceMeeting();
	}

	// Token: 0x06008008 RID: 32776 RVA: 0x0021D093 File Offset: 0x0021B293
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new ActivityCorniceMeetingData();
	}

	// Token: 0x06008009 RID: 32777 RVA: 0x0021D0A6 File Offset: 0x0021B2A6
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x0600800A RID: 32778 RVA: 0x0021D0A9 File Offset: 0x0021B2A9
	[NullableContext(2)]
	public ActivityCorniceMeetingData GetCurrentActivityData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityCorniceMeetingData;
	}

	// Token: 0x0600800B RID: 32779 RVA: 0x0021D0C0 File Offset: 0x0021B2C0
	public void MultiCorniceMeetingRewardRequest(int activityId, Dictionary<int, List<int>> scoreList, Action callback)
	{
		MulCorniceMeetingRewardRequest mulCorniceMeetingRewardRequest = MulCorniceMeetingRewardRequest.Create();
		mulCorniceMeetingRewardRequest.ActivityId = activityId;
		foreach (KeyValuePair<int, List<int>> keyValuePair in scoreList)
		{
			int key = keyValuePair.Key;
			List<int> value = keyValuePair.Value;
			CorniceMeetingRewardScoreList corniceMeetingRewardScoreList = CorniceMeetingRewardScoreList.Create();
			corniceMeetingRewardScoreList.ScoreIndexes.AddRange(value);
			mulCorniceMeetingRewardRequest.CorniceMeetingRewardScoreLists[key] = corniceMeetingRewardScoreList;
		}
		Singleton<Net>.Instance.Call<MulCorniceMeetingRewardResponse>(ERequestMessageId.MulCorniceMeetingRewardRequest, mulCorniceMeetingRewardRequest, delegate(MulCorniceMeetingRewardResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode != ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 27427, null, true, true);
				return;
			}
			ActivityCorniceMeetingData currentActivityData = this.GetCurrentActivityData();
			foreach (KeyValuePair<int, List<int>> keyValuePair2 in scoreList)
			{
				int key2 = keyValuePair2.Key;
				foreach (int score in keyValuePair2.Value)
				{
					currentActivityData.UpdateRewarded(key2, score);
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCorniceMeetingRedDot, key2);
			}
			Action callback2 = callback;
			if (callback2 == null)
			{
				return;
			}
			callback2();
		}, 0);
	}

	// Token: 0x0600800C RID: 32780 RVA: 0x0021D188 File Offset: 0x0021B388
	public void CorniceMeetingChallengeTransRequest(int levelPlayId)
	{
		CorniceChallengeTransRequest corniceChallengeTransRequest = CorniceChallengeTransRequest.Create();
		corniceChallengeTransRequest.LevelPlayId = levelPlayId;
		Singleton<Net>.Instance.Call<CorniceChallengeTransResponse>(ERequestMessageId.CorniceChallengeTransRequest, corniceChallengeTransRequest, delegate(CorniceChallengeTransResponse response, Net.CallbackStatus _)
		{
			if (response != null && response.ErrorCode != ErrorCode.Success && response.ErrorCode != ErrorCode.ErrPlayerIsTeleportCanNotDoTeleport)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 20494, null, true, true);
			}
		}, 0);
	}

	// Token: 0x04003D27 RID: 15655
	public int ActivityId;
}
