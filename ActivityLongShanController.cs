using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.GenericPrompt;
using CSharpScript.Game.Ui;

// Token: 0x02001352 RID: 4946
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ActivityLongShanController : ActivityControllerBase<ActivityLongShanController>
{
	// Token: 0x0600874D RID: 34637 RVA: 0x0023A168 File Offset: 0x00238368
	protected override bool OnGetIsOpeningActivityRelativeView()
	{
		foreach (ActivityLongShanData activityLongShanData in (from x in ModelBase<ActivityModel>.Instance.GetActivitiesByType(13)
		select (ActivityLongShanData)x).ToList<ActivityLongShanData>())
		{
			if (!activityLongShanData.CheckIfInShowTime())
			{
				LongShanActivityConfig? config = ConfigLongShanActivityConfigByActivityId.GetConfig(activityLongShanData.Id, true);
				List<EUiViewName> list = new List<EUiViewName>();
				int? num = (config != null) ? new int?(config.GetValueOrDefault().Type) : null;
				if (num == null)
				{
					goto IL_115;
				}
				switch (num.GetValueOrDefault())
				{
				case 2:
					list = new List<EUiViewName>
					{
						EUiViewName.RoleGrowingMainView,
						EUiViewName.RoleGrowingTaskView
					};
					break;
				case 3:
					list = new List<EUiViewName>
					{
						EUiViewName.SevenHillsMainView,
						EUiViewName.SevenHillsStageTaskView
					};
					break;
				case 4:
					list = new List<EUiViewName>
					{
						EUiViewName.Theme26MainView,
						EUiViewName.Theme26StageTaskView
					};
					break;
				default:
					goto IL_115;
				}
				IL_131:
				foreach (EUiViewName viewName in list)
				{
					if (Singleton<UiManager>.Instance.IsViewOpen(viewName))
					{
						return true;
					}
				}
				continue;
				IL_115:
				list = new List<EUiViewName>
				{
					EUiViewName.Theme26MainView,
					EUiViewName.Theme26StageTaskView
				};
				goto IL_131;
			}
		}
		return false;
	}

	// Token: 0x0600874E RID: 34638 RVA: 0x0023A33C File Offset: 0x0023853C
	protected override void OnOpenView(ActivityBaseData data)
	{
	}

	// Token: 0x0600874F RID: 34639 RVA: 0x0023A340 File Offset: 0x00238540
	protected override string OnGetActivityResource(ActivityBaseData data)
	{
		LongShanActivityConfig? config = ConfigLongShanActivityConfigByActivityId.GetConfig(data.Id, true);
		int? num = (config != null) ? new int?(config.GetValueOrDefault().Type) : null;
		if (num != null)
		{
			switch (num.GetValueOrDefault())
			{
			case 1:
				return "UiItem_LongshanMain";
			case 2:
				return "UiItem_ActivityRoleGrowing";
			case 3:
				return "UiItem_QiQiuGuide";
			case 4:
				return "UiItem_ActivityThemeGuide26";
			}
		}
		return this.GetActivityUiConfig(data.Id).SubViewId;
	}

	// Token: 0x06008750 RID: 34640 RVA: 0x0023A3DC File Offset: 0x002385DC
	protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
	{
		LongShanActivityConfig? config = ConfigLongShanActivityConfigByActivityId.GetConfig(data.Id, true);
		int? num = (config != null) ? new int?(config.GetValueOrDefault().Type) : null;
		if (num != null)
		{
			switch (num.GetValueOrDefault())
			{
			case 1:
				return new ActivitySubViewLongShan();
			case 2:
				return new ActivitySubViewRoleGrowing();
			case 3:
				return new ActivitySubViewSevenHills();
			case 4:
				return new ActivitySubViewTheme26();
			}
		}
		return new ActivitySubViewTheme26();
	}

	// Token: 0x06008751 RID: 34641 RVA: 0x0023A468 File Offset: 0x00238668
	protected override ActivityBaseData OnCreateActivityData(ActivityData data)
	{
		return new ActivityLongShanData();
	}

	// Token: 0x06008752 RID: 34642 RVA: 0x0023A470 File Offset: 0x00238670
	public override void OnShowActivityFirstUnlockView(ActivityBaseData data)
	{
		LongShanActivityConfig? config = ConfigLongShanActivityConfigByActivityId.GetConfig(data.Id, true);
		int? num = (config != null) ? new int?(config.GetValueOrDefault().Type) : null;
		if (num != null)
		{
			switch (num.GetValueOrDefault())
			{
			case 1:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.LongShanUnlockView, null, null);
				return;
			case 3:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.ActivityUnlockTipSevenHillsView, null, null);
				return;
			case 4:
				Singleton<UiManager>.Instance.OpenView(EUiViewName.Theme26UnlockTipView, data, null);
				return;
			}
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.Theme26UnlockTipView, data, null);
	}

	// Token: 0x06008753 RID: 34643 RVA: 0x0023A526 File Offset: 0x00238726
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06008754 RID: 34644 RVA: 0x0023A529 File Offset: 0x00238729
	protected override void OnRegisterNetEvent()
	{
		Singleton<Net>.Instance.Register<LongShanStageUpdateNotify>(ENotifyMessageId.LongShanStageUpdateNotify, new Action<LongShanStageUpdateNotify, Net.CallbackStatus>(this.OnStageUpdate));
	}

	// Token: 0x06008755 RID: 34645 RVA: 0x0023A547 File Offset: 0x00238747
	protected override void OnUnRegisterNetEvent()
	{
		Singleton<Net>.Instance.UnRegister(ENotifyMessageId.LongShanStageUpdateNotify);
	}

	// Token: 0x06008756 RID: 34646 RVA: 0x0023A559 File Offset: 0x00238759
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06008757 RID: 34647 RVA: 0x0023A577 File Offset: 0x00238777
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
	}

	// Token: 0x06008758 RID: 34648 RVA: 0x0023A595 File Offset: 0x00238795
	private List<ActivityLongShanData> GetActivityDataList()
	{
		return (from x in ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(13)
		select (ActivityLongShanData)x).ToList<ActivityLongShanData>();
	}

	// Token: 0x06008759 RID: 34649 RVA: 0x0023A5CC File Offset: 0x002387CC
	public LongShanUiConfig GetActivityUiConfig(int activityId)
	{
		return ConfigLongShanUiConfigById.GetConfig(ConfigLongShanActivityConfigByActivityId.GetConfig(activityId, true).Value.Type, true).Value;
	}

	// Token: 0x0600875A RID: 34650 RVA: 0x0023A600 File Offset: 0x00238800
	private void OnStageUpdate(LongShanStageUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
	{
		foreach (ActivityLongShanData activityLongShanData in this.GetActivityDataList())
		{
			activityLongShanData.UpdateStage(notify.Stages.ToArray<LongShanStageInfo>());
		}
	}

	// Token: 0x0600875B RID: 34651 RVA: 0x0023A65C File Offset: 0x0023885C
	public void ShowUnlockTip(int stageId)
	{
		string conditionGroupHintText = LevelGeneralCommons.GetConditionGroupHintText(ConfigLongShanStageById.GetConfig(stageId, true).Value.OpenConditionId);
		ControllerBase<GenericPromptController>.Instance.ShowPromptByItsType<object>(EPromptSubViewType.FloatLinePrompt, new TableTextArgNew(conditionGroupHintText, Array.Empty<object>()), null, null, null, null, null, null, null, false, null);
	}

	// Token: 0x0600875C RID: 34652 RVA: 0x0023A6B8 File Offset: 0x002388B8
	public void TakeTaskReward(int taskId)
	{
		int stageId = ConfigLongShanTaskById.GetConfig(taskId, true).Value.StageId;
		List<ActivityLongShanData> activityDataList = this.GetActivityDataList();
		List<int> list = new List<int>();
		for (int i = 0; i < activityDataList.Count; i++)
		{
			List<int> finishedAndUnclaimedTasksByStageId = activityDataList[i].GetFinishedAndUnclaimedTasksByStageId(stageId);
			if (finishedAndUnclaimedTasksByStageId.Count > 0)
			{
				list.AddRange(finishedAndUnclaimedTasksByStageId);
				break;
			}
		}
		Action<LongShanTaskRewardResponse, Net.CallbackStatus> handle = delegate(LongShanTaskRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Error != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, EResponseMessageId.LongShanTaskRewardResponse, null, true, true);
			}
		};
		LongShanTaskRewardRequest longShanTaskRewardRequest = LongShanTaskRewardRequest.Create();
		longShanTaskRewardRequest.TaskIds.AddRange(list);
		Singleton<Net>.Instance.Call<LongShanTaskRewardResponse>(ERequestMessageId.LongShanTaskRewardRequest, longShanTaskRewardRequest, handle, 0);
	}

	// Token: 0x0600875D RID: 34653 RVA: 0x0023A76C File Offset: 0x0023896C
	public void RequestScoreReward(int activityId, List<int> rewardIds)
	{
		LongShanScoreRewardRequest longShanScoreRewardRequest = LongShanScoreRewardRequest.Create();
		longShanScoreRewardRequest.ActivityId = activityId;
		longShanScoreRewardRequest.Ids.AddRange(rewardIds);
		Singleton<Net>.Instance.Call<LongShanScoreRewardResponse>(ERequestMessageId.LongShanScoreRewardRequest, longShanScoreRewardRequest, delegate(LongShanScoreRewardResponse response, Net.CallbackStatus _)
		{
			if (response == null)
			{
				return;
			}
			if (response.Error != Aki.Protocol.ErrorCode.Success)
			{
				ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 17712, null, true, true);
				return;
			}
			(ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as ActivityLongShanData).UpdateScoreRewardStatus(response.ScoreRewardedIds.ToArray<int>());
		}, 0);
	}

	// Token: 0x0600875E RID: 34654 RVA: 0x0023A7C4 File Offset: 0x002389C4
	private void OnCommonItemCountAnyChange(int configId, int count)
	{
		List<ActivityLongShanData> activityDataList = this.GetActivityDataList();
		if (activityDataList.Count == 0)
		{
			return;
		}
		foreach (ActivityLongShanData activityLongShanData in activityDataList)
		{
			if (activityLongShanData.ScoreItemId == configId)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityLongShanData.Id);
			}
		}
	}
}
