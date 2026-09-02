using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;

// Token: 0x0200139B RID: 5019
[NullableContext(1)]
[Nullable(0)]
public class ActivityMoonChasingData : ActivityBaseData
{
	// Token: 0x06008A20 RID: 35360 RVA: 0x00245C6C File Offset: 0x00243E6C
	protected override void PhraseEx(ActivityData data)
	{
		this.LimitTimeRewardOn = false;
		this.PermanentTargetOn = false;
		this.ActivityFlowState = EMoonChasingActivityFlow.Activity;
		TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(base.Id);
		if (activityMoonChasingConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[ActivityMoonChasing] 活动配置不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", base.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		TrackMoonActivity value = activityMoonChasingConfig.Value;
		this.LimitTimeRewardOn = value.ActivityReward;
		this.PermanentTargetOn = value.PermanentTarget;
		this.ActivityFlowState = ((value.ActivityButtonType == 0) ? EMoonChasingActivityFlow.Activity : EMoonChasingActivityFlow.Close);
		this.LimitTimeRewardState.Clear();
		Aki.Protocol.ActivityTaskData trackMoonActivityTaskData = data.TrackMoonActivityTaskData;
		if (trackMoonActivityTaskData == null)
		{
			return;
		}
		foreach (ActivityTask activityTask in trackMoonActivityTaskData.ActivityTasks)
		{
			this.LimitTimeRewardState[activityTask.Id] = TaskStateResolver.TaskState[activityTask.Status];
		}
		if (!this.LimitTimeRewardOn)
		{
			return;
		}
		this.RefreshRewardPopView();
	}

	// Token: 0x06008A21 RID: 35361 RVA: 0x00245D9C File Offset: 0x00243F9C
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06008A22 RID: 35362 RVA: 0x00245D9F File Offset: 0x00243F9F
	public override bool GetExDataRedPointShowState()
	{
		if (this.ActivityFlowState == EMoonChasingActivityFlow.Close)
		{
			return this.IsHasMoonChasingRedDot();
		}
		return this.IsHasLimitTimeReward() || this.IsHasPermanentReward() || this.IsHasHandbookReward() || this.IsHasMoonChasingRedDot();
	}

	// Token: 0x06008A23 RID: 35363 RVA: 0x00245DD4 File Offset: 0x00243FD4
	public bool IsPreStageQuestFinished()
	{
		TrackMoonActivity? activityMoonChasingConfig = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingConfig(base.Id);
		if (activityMoonChasingConfig == null)
		{
			return true;
		}
		int stageQuestId = activityMoonChasingConfig.Value.StageQuestId;
		return stageQuestId == 0 || ModelBase<QuestNewModel>.Instance.CheckQuestFinished(stageQuestId);
	}

	// Token: 0x06008A24 RID: 35364 RVA: 0x00245E20 File Offset: 0x00244020
	public int? GetPreStageQuestId()
	{
		global::Quest firstShowQuestByType = ModelBase<QuestNewModel>.Instance.GetFirstShowQuestByType(1);
		if (firstShowQuestByType != null)
		{
			return new int?(firstShowQuestByType.Id);
		}
		return null;
	}

	// Token: 0x06008A25 RID: 35365 RVA: 0x00245E54 File Offset: 0x00244054
	[NullableContext(2)]
	public unsafe IActivityRewardViewData GetAllRewardData()
	{
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		foreach (KeyValuePair<int, EActivityTaskState> keyValuePair in this.LimitTimeRewardState)
		{
			IActivityRewardData rewardStateInfo = this.GetRewardStateInfo(keyValuePair.Key, keyValuePair.Value);
			if (rewardStateInfo != null)
			{
				list.Add(rewardStateInfo);
			}
		}
		if (list.Count == 0)
		{
			return null;
		}
		list.Sort(new Comparison<IActivityRewardData>(this.SortReward));
		ActivityRewardDataPage activityRewardDataPage = new ActivityRewardDataPage
		{
			DataList = list
		};
		ActivityRewardViewData activityRewardViewData = new ActivityRewardViewData();
		int num = 1;
		List<IActivityRewardDataPage> list2 = new List<IActivityRewardDataPage>(num);
		CollectionsMarshal.SetCount<IActivityRewardDataPage>(list2, num);
		Span<IActivityRewardDataPage> span = CollectionsMarshal.AsSpan<IActivityRewardDataPage>(list2);
		int index = 0;
		*span[index] = activityRewardDataPage;
		activityRewardViewData.DataPageList = list2;
		activityRewardViewData.Source = EActivityRewardSource.MoonChasing;
		return activityRewardViewData;
	}

	// Token: 0x06008A26 RID: 35366 RVA: 0x00245F30 File Offset: 0x00244130
	[NullableContext(2)]
	private IActivityRewardData GetRewardStateInfo(int id, EActivityTaskState state)
	{
		TrackMoonActivityReward? activityMoonChasingRewardConfigById = ConfigBase<ActivityMoonChasingConfig>.Instance.GetActivityMoonChasingRewardConfigById(id);
		if (activityMoonChasingRewardConfigById == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "[ActivityMoonChasing] 活动限时奖励配置无配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		TrackMoonActivityReward rewardInfoVal = activityMoonChasingRewardConfigById.Value;
		EActivityRewardState rewardState = EActivityRewardState.Disabled;
		string text = "";
		Action clickFunction = null;
		bool value = false;
		bool value2 = false;
		switch (state)
		{
		case EActivityTaskState.FinishedAndUnclaimed:
			rewardState = EActivityRewardState.Enable;
			text = "Moonfiesta_AwardGet";
			value = true;
			clickFunction = delegate()
			{
				ControllerBase<ActivityMoonChasingController>.Instance.TrackMoonActivityTargetRewardRequest(this.Id, rewardInfoVal.Id);
			};
			break;
		case EActivityTaskState.Active:
			if (rewardInfoVal.TargetFunc != 0)
			{
				int targetFunc = rewardInfoVal.TargetFunc;
				clickFunction = delegate()
				{
					SkipTaskManager.RunByConfigId(targetFunc, null);
				};
				rewardState = EActivityRewardState.Enable;
				text = "Moonfiesta_Skip";
				value2 = true;
			}
			else
			{
				rewardState = EActivityRewardState.Disabled;
				text = "Moonfiesta_Underway";
			}
			break;
		case EActivityTaskState.FinishedAndClaimed:
			rewardState = EActivityRewardState.Claimed;
			break;
		}
		if (!StringUtils.IsEmpty(text))
		{
			text = ConfigMultiTextLang.GetLocalTextNew(text, null);
		}
		return new ActivityRewardData
		{
			Id = new int?(rewardInfoVal.Id),
			NameText = ConfigMultiTextLang.GetLocalTextNew(rewardInfoVal.TargetName, null),
			RewardList = base.GetPreviewReward(new int?(rewardInfoVal.TargetReward)).ToArray(),
			RewardState = rewardState,
			RewardButtonText = text,
			RewardButtonRedDot = new bool?(value),
			ClickFunction = clickFunction,
			ClickFunctionAndCloseSelf = new bool?(value2)
		};
	}

	// Token: 0x06008A27 RID: 35367 RVA: 0x002460BC File Offset: 0x002442BC
	private int SortReward(IActivityRewardData a, IActivityRewardData b)
	{
		EActivityTaskState eactivityTaskState = this.LimitTimeRewardState[a.Id.Value];
		EActivityTaskState eactivityTaskState2 = this.LimitTimeRewardState[b.Id.Value];
		if (eactivityTaskState == eactivityTaskState2)
		{
			return a.Id.Value - b.Id.Value;
		}
		return eactivityTaskState - eactivityTaskState2;
	}

	// Token: 0x06008A28 RID: 35368 RVA: 0x00246122 File Offset: 0x00244322
	public void SetRewardState(int id, EActivityTaskState state)
	{
		if (!this.LimitTimeRewardState.ContainsKey(id))
		{
			return;
		}
		this.LimitTimeRewardState[id] = state;
		this.RefreshRewardPopView();
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06008A29 RID: 35369 RVA: 0x0024615C File Offset: 0x0024435C
	public bool IsHasLimitTimeReward()
	{
		if (!this.LimitTimeRewardOn)
		{
			return false;
		}
		using (Dictionary<int, EActivityTaskState>.ValueCollection.Enumerator enumerator = this.LimitTimeRewardState.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06008A2A RID: 35370 RVA: 0x002461C0 File Offset: 0x002443C0
	private void RefreshRewardPopView()
	{
		if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
		{
			IActivityRewardViewData allRewardData = this.GetAllRewardData();
			if (allRewardData != null)
			{
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, allRewardData);
			}
		}
	}

	// Token: 0x06008A2B RID: 35371 RVA: 0x002461F9 File Offset: 0x002443F9
	private bool IsHasPermanentReward()
	{
		return base.IsUnLock() && base.GetPreGuideQuestFinishState() && (ModelBase<MoonChasingRewardModel>.Instance.GetAllTaskDataRedDotState(true) || ModelBase<MoonChasingRewardModel>.Instance.GetShopRedDotState());
	}

	// Token: 0x06008A2C RID: 35372 RVA: 0x00246226 File Offset: 0x00244426
	private bool IsHasHandbookReward()
	{
		return ModelBase<MoonChasingModel>.Instance.HasHandbookRewardRedDot();
	}

	// Token: 0x06008A2D RID: 35373 RVA: 0x00246234 File Offset: 0x00244434
	public bool IsHasMoonChasingRedDot()
	{
		if (!base.IsUnLock() || !base.GetPreGuideQuestFinishState())
		{
			return false;
		}
		if (this.ActivityFlowState == EMoonChasingActivityFlow.Close)
		{
			return ModelBase<MoonChasingModel>.Instance.CheckMemoryRedDotState();
		}
		if (ModelBase<MoonChasingBuildingModel>.Instance.CheckAllBuildingRedDotState())
		{
			return true;
		}
		MoonChasingModel instance = ModelBase<MoonChasingModel>.Instance;
		return instance != null && instance.CheckQuestRedDotState();
	}

	// Token: 0x040040C0 RID: 16576
	public bool LimitTimeRewardOn;

	// Token: 0x040040C1 RID: 16577
	private readonly Dictionary<int, EActivityTaskState> LimitTimeRewardState = new Dictionary<int, EActivityTaskState>();

	// Token: 0x040040C2 RID: 16578
	public bool PermanentTargetOn;

	// Token: 0x040040C3 RID: 16579
	public EMoonChasingActivityFlow ActivityFlowState;
}
