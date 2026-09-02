using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02001452 RID: 5202
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Controller(0)]
public class ActivityNewcomerJourneyController : ActivityControllerBase<ActivityNewcomerJourneyController>
{
	// Token: 0x060090E9 RID: 37097 RVA: 0x00261D07 File Offset: 0x0025FF07
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
	}

	// Token: 0x060090EA RID: 37098 RVA: 0x00261D41 File Offset: 0x0025FF41
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WorldDone, new Action(this.OnWorldDone));
		Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, new Action<int, IReadOnlyList<int>>(this.OnReceiveActivityData));
	}

	// Token: 0x060090EB RID: 37099 RVA: 0x00261D7B File Offset: 0x0025FF7B
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<NewbieAdventureTaskUpdateNotify>(ENotifyMessageId.NewbieAdventureTaskUpdateNotify, new Action<NewbieAdventureTaskUpdateNotify, Net.CallbackStatus>(this.OnNewbieAdventureTaskUpdateNotify));
	}

	// Token: 0x060090EC RID: 37100 RVA: 0x00261D9C File Offset: 0x0025FF9C
	private void OnReceiveActivityData(int type, IReadOnlyList<int> activityIds)
	{
		if (!this.PendingSplashAfterActivitySync)
		{
			return;
		}
		if (type != 2)
		{
			return;
		}
		if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			this.PendingSplashAfterActivitySync = false;
			return;
		}
		ActivitySevenDaySignData activitySevenDaySignData = this.TryGetSignInActivityData();
		if (activitySevenDaySignData == null)
		{
			return;
		}
		this.TryPushNewcomerSplash(activitySevenDaySignData, false);
	}

	// Token: 0x060090ED RID: 37101 RVA: 0x00261DE0 File Offset: 0x0025FFE0
	private void OnWorldDone()
	{
		if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
		{
			return;
		}
		ActivitySevenDaySignData activitySevenDaySignData = this.TryGetSignInActivityData();
		if (activitySevenDaySignData == null)
		{
			this.PendingSplashAfterActivitySync = true;
			return;
		}
		this.TryPushNewcomerSplash(activitySevenDaySignData, false);
	}

	// Token: 0x060090EE RID: 37102 RVA: 0x00261E14 File Offset: 0x00260014
	[NullableContext(2)]
	public ActivitySevenDaySignData TryGetSignInActivityData()
	{
		int type = 2;
		List<ActivityBaseData> activitiesByType = ModelBase<ActivityModel>.Instance.GetActivitiesByType(type);
		if (activitiesByType == null || activitiesByType.Count <= 0)
		{
			return null;
		}
		ActivitySevenDaySignData activitySevenDaySignData = null;
		foreach (ActivityBaseData activityBaseData in activitiesByType)
		{
			ActivitySevenDaySignData activitySevenDaySignData2 = activityBaseData as ActivitySevenDaySignData;
			if (activitySevenDaySignData2 != null)
			{
				ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(activitySevenDaySignData2.Id);
				if (activitySignById != null && activitySignById.Value.Type == 3)
				{
					activitySevenDaySignData = activitySevenDaySignData2;
					break;
				}
			}
		}
		if (activitySevenDaySignData == null)
		{
			return null;
		}
		if (!activitySevenDaySignData.CheckIfInOpenTime())
		{
			return null;
		}
		return activitySevenDaySignData;
	}

	// Token: 0x060090EF RID: 37103 RVA: 0x00261EC8 File Offset: 0x002600C8
	private void TryPushNewcomerSplash(ActivitySevenDaySignData data, bool isInstantly = false)
	{
		int activityId = data.Id;
		if (this.HasShowedSplash(activityId))
		{
			return;
		}
		SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.NewcomerActivity, ESplashScreenType.Config, delegate()
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.NewcomerSplashView, activityId, null);
			this.SaveShowSplash(activityId);
		});
		ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
	}

	// Token: 0x060090F0 RID: 37104 RVA: 0x00261F1E File Offset: 0x0026011E
	public bool HasShowedSplash(int activityId)
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(activityId, 0, 1, 0, 0) == 1;
	}

	// Token: 0x060090F1 RID: 37105 RVA: 0x00261F32 File Offset: 0x00260132
	public void SaveShowSplash(int activityId)
	{
		if (!this.HasShowedSplash(activityId))
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(activityId, 1, 0, 0, 1);
		}
	}

	// Token: 0x060090F2 RID: 37106 RVA: 0x00261F4C File Offset: 0x0026014C
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.NewbieAdventureTaskUpdateNotify);
	}

	// Token: 0x060090F3 RID: 37107 RVA: 0x00261F5E File Offset: 0x0026015E
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x060090F4 RID: 37108 RVA: 0x00261F60 File Offset: 0x00260160
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		return "UiItem_NewcomerExperienceMain";
	}

	// Token: 0x060090F5 RID: 37109 RVA: 0x00261F67 File Offset: 0x00260167
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		return new ActivitySubViewNewcomerJourney();
	}

	// Token: 0x060090F6 RID: 37110 RVA: 0x00261F6E File Offset: 0x0026016E
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		this.ActivityId = data.Id;
		return new ActivityNewcomerJourneyData();
	}

	// Token: 0x060090F7 RID: 37111 RVA: 0x00261F81 File Offset: 0x00260181
	public ActivityNewcomerJourneyData GetNewcomerJourneyData()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as ActivityNewcomerJourneyData;
	}

	// Token: 0x060090F8 RID: 37112 RVA: 0x00261F98 File Offset: 0x00260198
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		return false;
	}

	// Token: 0x060090F9 RID: 37113 RVA: 0x00261F9C File Offset: 0x0026019C
	private void OnNewbieAdventureTaskUpdateNotify(NewbieAdventureTaskUpdateNotify notify, [Nullable(2)] Net.CallbackStatus _)
	{
		(ModelBase<ActivityModel>.Instance.GetActivityById(notify.ActivityId) as ActivityNewcomerJourneyData).UpdateChapterData(notify.Chapter.ToList<NewbieAdventureV2ChapterPb>());
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, notify.ActivityId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, notify.ActivityId);
	}

	// Token: 0x060090FA RID: 37114 RVA: 0x00261FFC File Offset: 0x002601FC
	public void GetTaskReward(int activityId, List<int> taskIds)
	{
		NewbieAdventureTaskRewardRequest newbieAdventureTaskRewardRequest = NewbieAdventureTaskRewardRequest.Create();
		newbieAdventureTaskRewardRequest.ActivityId = activityId;
		newbieAdventureTaskRewardRequest.TaskIds.AddRange(taskIds);
		Singleton<Net>.Instance.Call<NewbieAdventureTaskRewardResponse>(ERequestMessageId.NewbieAdventureTaskRewardRequest, newbieAdventureTaskRewardRequest, delegate(NewbieAdventureTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 29242, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060090FB RID: 37115 RVA: 0x00262054 File Offset: 0x00260254
	public void GetChapterReward(int activityId, int chapterId)
	{
		NewbieAdventureChapterDropRequest newbieAdventureChapterDropRequest = NewbieAdventureChapterDropRequest.Create();
		newbieAdventureChapterDropRequest.ActivityId = activityId;
		newbieAdventureChapterDropRequest.ChapterId = chapterId;
		Singleton<Net>.Instance.Call<NewbieAdventureChapterDropResponse>(ERequestMessageId.NewbieAdventureChapterDropRequest, newbieAdventureChapterDropRequest, delegate(NewbieAdventureChapterDropResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 28542, null, true, true);
			}
		}, 0);
	}

	// Token: 0x060090FC RID: 37116 RVA: 0x002620A8 File Offset: 0x002602A8
	public void GetSelectRole(int activityId, int chapterId, int roleId)
	{
		NewbieAdventureRoleRewardRequest newbieAdventureRoleRewardRequest = NewbieAdventureRoleRewardRequest.Create();
		newbieAdventureRoleRewardRequest.ActivityId = activityId;
		newbieAdventureRoleRewardRequest.ChapterId = chapterId;
		newbieAdventureRoleRewardRequest.RoleId = roleId;
		Singleton<Net>.Instance.Call<NewbieAdventureRoleRewardResponse>(ERequestMessageId.NewbieAdventureRoleRewardRequest, newbieAdventureRoleRewardRequest, delegate(NewbieAdventureRoleRewardResponse response, Net.CallbackStatus _)
		{
			if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 18483, null, true, true);
			}
		}, 0);
	}

	// Token: 0x04004335 RID: 17205
	private const int NEWCOMER_SPLASH_CACHE_KEY = 1;

	// Token: 0x04004336 RID: 17206
	private bool PendingSplashAfterActivitySync;

	// Token: 0x04004337 RID: 17207
	private int ActivityId;
}
