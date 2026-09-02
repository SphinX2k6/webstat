using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.SkipInterface;
using Google.Protobuf.Collections;

// Token: 0x02001502 RID: 5378
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressData : ActivityBaseData
{
	// Token: 0x17000CFA RID: 3322
	// (get) Token: 0x060096BE RID: 38590 RVA: 0x0027758E File Offset: 0x0027578E
	public int PrevBpExp
	{
		get
		{
			return this.PrevBpExpInternal;
		}
	}

	// Token: 0x060096BF RID: 38591 RVA: 0x00277598 File Offset: 0x00275798
	protected override void PhraseEx(ActivityData data)
	{
		this.RegressRawData = data.RegressData;
		if (this.RegressRawData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回流活动-ActivityRegressData.PhraseEx()->";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("协议下发的活动数据没有回流活动相关的, data:", this.RegressRawData);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		if (this.RegressRawData.SignRewards == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.ActivityRegress;
			ELogAuthor author2 = ELogAuthor.LRX;
			string message2 = "回流活动-ActivityRegressData.PhraseEx()->";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("协议下发的回流活动数据没有签到数据, data:", this.RegressRawData.SignRewards);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		if (this.RegressRawData.ActivityTasks == null)
		{
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.ActivityRegress;
			ELogAuthor author3 = ELogAuthor.LRX;
			string message3 = "回流活动-ActivityRegressData.PhraseEx()->";
			ValueTuple<string, object> valueTuple3 = new ValueTuple<string, object>("协议下发的回流活动数据没有任务数据, data:", this.RegressRawData.ActivityTasks);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple3));
		}
		if (this.RegressRawData.ScoreRewards == null)
		{
			Log instance4 = Singleton<Log>.Instance;
			ELogModule module4 = ELogModule.ActivityRegress;
			ELogAuthor author4 = ELogAuthor.LRX;
			string message4 = "回流活动-ActivityRegressData.PhraseEx()->";
			ValueTuple<string, object> valueTuple4 = new ValueTuple<string, object>("协议下发的回流活动数据没有已经领取的积分奖励, data:", this.RegressRawData.ScoreRewards);
			instance4.Warn(module4, author4, message4, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple4));
		}
		this.DisposableReward = this.RegressRawData.DisposableReward;
		this.CurrentUseTrialRole = this.RegressRawData.CurUseTrialRoleId;
		this.ParseTrialRoles(this.RegressRawData.RoleInfo);
		ModelBase<TrialRoleModel>.Instance.SetCurUseTrialRole(this.CurrentUseTrialRole, this.RegressRawData.CurUseRoleInfo);
		this.EndOpenTimeInternal = this.RegressRawData.EndTime;
		this.EndShowTimeInternal = this.EndOpenTimeInternal;
		if (this.EndOpenTimeInternal == 0L)
		{
			base.ForceClose();
		}
		this.ActivityRecallDailyTaskRefreshTime = this.RegressRawData.NextRefreshTime;
		this.ActivityInternalTaskMap.Clear();
		foreach (ActivityTask activityTask in this.RegressRawData.ActivityTasks)
		{
			this.ActivityInternalTaskMap[activityTask.Id] = activityTask;
		}
		this.RefreshScoreRewardNeedScoreList();
		this.RefreshRegressTaskMapping();
		this.RefreshPrevBpExp();
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, ModelBase<ActivityRegressModel>.Instance.ActivityId);
	}

	// Token: 0x060096C0 RID: 38592 RVA: 0x002777D8 File Offset: 0x002759D8
	private void ParseTrialRoles(RepeatedField<NewTrialRoleInfo> roleList)
	{
		List<ITrialRoleCreateData> list = new List<ITrialRoleCreateData>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (NewTrialRoleInfo newTrialRoleInfo in roleList)
		{
			list.Add(new TrialRoleCreateData
			{
				TrialRoleId = newTrialRoleInfo.TrialRoleId,
				IsUnlocked = true
			});
			TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
			int? num = (instance != null) ? instance.GetTrialRoleGroupId(newTrialRoleInfo.TrialRoleId) : null;
			if (num != null)
			{
				hashSet.Add(num.Value);
			}
		}
		TrialRoleConfig instance2 = ConfigBase<TrialRoleConfig>.Instance;
		Dictionary<int, List<TrialRoleInfo>> dictionary = (instance2 != null) ? instance2.GetTrialRoleAllConfigByType(ETrialRoleType.ReturnSupportTrial) : null;
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, List<TrialRoleInfo>> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				List<TrialRoleInfo> value = keyValuePair.Value;
				if (!hashSet.Contains(key) && value.Count > 0)
				{
					list.Add(new TrialRoleCreateData
					{
						TrialRoleId = value[0].Id,
						IsUnlocked = false
					});
				}
			}
		}
		ModelBase<TrialRoleModel>.Instance.AddTrialRoles(list);
	}

	// Token: 0x060096C1 RID: 38593 RVA: 0x00277928 File Offset: 0x00275B28
	public EActivityRecallState GetActivityState()
	{
		if (!base.IsUnLock())
		{
			return EActivityRecallState.UnOpen;
		}
		if (this.RegressRawData == null || this.RegressRawData.EndTime == 0L)
		{
			return EActivityRecallState.UnOpen;
		}
		if (this.CheckIfInOpenTime())
		{
			return EActivityRecallState.Opening;
		}
		return EActivityRecallState.UnOpen;
	}

	// Token: 0x17000CFB RID: 3323
	// (get) Token: 0x060096C2 RID: 38594 RVA: 0x00277956 File Offset: 0x00275B56
	// (set) Token: 0x060096C3 RID: 38595 RVA: 0x0027796D File Offset: 0x00275B6D
	public ERegressGrade Grade
	{
		get
		{
			if (this.RegressRawData != null)
			{
				return (ERegressGrade)this.RegressRawData.GradeId;
			}
			return ERegressGrade.None;
		}
		set
		{
			if (this.RegressRawData != null)
			{
				this.RegressRawData.GradeId = (int)value;
			}
		}
	}

	// Token: 0x060096C4 RID: 38596 RVA: 0x00277983 File Offset: 0x00275B83
	public override bool CheckIfInOpenTime()
	{
		return base.CheckIfInTimeInterval(base.BeginOpenTime, base.EndOpenTime);
	}

	// Token: 0x060096C5 RID: 38597 RVA: 0x00277998 File Offset: 0x00275B98
	public double GetActivityOpenTimeLeft()
	{
		long endOpenTime = base.EndOpenTime;
		return Math.Max(0.0, (double)endOpenTime - Singleton<TimeUtil>.Instance.GetServerTime());
	}

	// Token: 0x060096C6 RID: 38598 RVA: 0x002779C7 File Offset: 0x00275BC7
	public bool IsActivityOpen()
	{
		return this.GetActivityState() == EActivityRecallState.Opening;
	}

	// Token: 0x060096C7 RID: 38599 RVA: 0x002779D4 File Offset: 0x00275BD4
	public ERegressRewardState GetSignRewardState(int day)
	{
		ActivityTask signRewardRawData = this.GetSignRewardRawData(day);
		if (signRewardRawData == null)
		{
			return ERegressRewardState.UnReach;
		}
		switch (signRewardRawData.Status)
		{
		case ActivityTaskState.ActivityTaskRunning:
			return ERegressRewardState.UnReach;
		case ActivityTaskState.ActivityTaskFinish:
			return ERegressRewardState.Reached;
		case ActivityTaskState.ActivityTaskTaken:
			return ERegressRewardState.Claim;
		default:
			return ERegressRewardState.UnReach;
		}
	}

	// Token: 0x060096C8 RID: 38600 RVA: 0x00277A10 File Offset: 0x00275C10
	public bool HasSignRewardCanClaimed()
	{
		if (this.RegressRawData == null)
		{
			return false;
		}
		using (IEnumerator<ActivityTask> enumerator = this.RegressRawData.SignRewards.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060096C9 RID: 38601 RVA: 0x00277A74 File Offset: 0x00275C74
	[NullableContext(2)]
	private ActivityTask GetSignRewardRawData(int day)
	{
		if (this.RegressRawData == null)
		{
			return null;
		}
		RepeatedField<ActivityTask> signRewards = this.RegressRawData.SignRewards;
		if (day - 1 < 0 || day - 1 >= signRewards.Count)
		{
			return null;
		}
		return signRewards[day - 1];
	}

	// Token: 0x060096CA RID: 38602 RVA: 0x00277AB4 File Offset: 0x00275CB4
	public bool CheckHaveTaskRewardCanGet()
	{
		if (this.GetRegressTaskProgressFloat01() >= 1.0)
		{
			return false;
		}
		if (this.RegressRawData == null)
		{
			return false;
		}
		using (IEnumerator<ActivityTask> enumerator = this.RegressRawData.ActivityTasks.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060096CB RID: 38603 RVA: 0x00277B2C File Offset: 0x00275D2C
	public int GetSignRewardEntityId(int day)
	{
		ActivityTask signRewardRawData = this.GetSignRewardRawData(day);
		if (signRewardRawData == null)
		{
			return 0;
		}
		return signRewardRawData.Id;
	}

	// Token: 0x060096CC RID: 38604 RVA: 0x00277B4C File Offset: 0x00275D4C
	[NullableContext(2)]
	private ActivityTask GetRawTaskData(int taskId)
	{
		ActivityTask result;
		if (!this.ActivityInternalTaskMap.TryGetValue(taskId, out result))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[回流活动]ActivityRegressData.GetRawTaskData->";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("获取回流任务数据失败, 服务器没下发该任务数据 taskId:", taskId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return result;
	}

	// Token: 0x060096CD RID: 38605 RVA: 0x00277B9B File Offset: 0x00275D9B
	public bool IsRegressTaskScoreOverExp()
	{
		return this.GetRegressTaskProgressFloat01() >= 1.0;
	}

	// Token: 0x060096CE RID: 38606 RVA: 0x00277BB4 File Offset: 0x00275DB4
	[NullableContext(0)]
	public ValueTuple<int, int> GetTaskProgressTuple(int taskId)
	{
		ActivityTask rawTaskData = this.GetRawTaskData(taskId);
		if (rawTaskData == null)
		{
			return new ValueTuple<int, int>(0, 0);
		}
		int item = rawTaskData.Current;
		int target = rawTaskData.Target;
		return new ValueTuple<int, int>(item, target);
	}

	// Token: 0x060096CF RID: 38607 RVA: 0x00277BEC File Offset: 0x00275DEC
	public ERegressRewardState GetTaskRewardState(int taskId)
	{
		ActivityTask rawTaskData = this.GetRawTaskData(taskId);
		if (rawTaskData == null)
		{
			return ERegressRewardState.UnReach;
		}
		switch (rawTaskData.Status)
		{
		case ActivityTaskState.ActivityTaskRunning:
			return ERegressRewardState.UnReach;
		case ActivityTaskState.ActivityTaskFinish:
			return ERegressRewardState.Reached;
		case ActivityTaskState.ActivityTaskTaken:
			return ERegressRewardState.Claim;
		default:
			return ERegressRewardState.UnReach;
		}
	}

	// Token: 0x060096D0 RID: 38608 RVA: 0x00277C28 File Offset: 0x00275E28
	public string GetNextRefreshTime()
	{
		long activityRecallDailyTaskRefreshTime = this.ActivityRecallDailyTaskRefreshTime;
		if (activityRecallDailyTaskRefreshTime == 0L)
		{
			return "";
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)activityRecallDailyTaskRefreshTime - serverTime, Singleton<TimeUtil>.Instance.TimeDeviation);
		CommonDefine.ETimeType value = (num >= 3600.0) ? CommonDefine.ETimeType.Hour : CommonDefine.ETimeType.Minute;
		CommonDefine.ETimeType value2 = (num >= 3600.0) ? CommonDefine.ETimeType.Minute : CommonDefine.ETimeType.Second;
		return Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(value), new CommonDefine.ETimeType?(value2)).CountDownText ?? "";
	}

	// Token: 0x060096D1 RID: 38609 RVA: 0x00277CB0 File Offset: 0x00275EB0
	public override bool GetExDataRedPointShowState()
	{
		return this.IsActivityOpen() && (this.HasSignRewardCanClaimed() || this.CheckRegressScoreRewardReached() || this.CheckShowQuestionnaireRedDot() || this.CheckShopRedDot() || this.CheckTrialRoleRedDot() || this.CheckDisposableRewardRedDot() || this.HasReachableConstantTask() || this.CheckRegressRewardBtnReached());
	}

	// Token: 0x060096D2 RID: 38610 RVA: 0x00277D07 File Offset: 0x00275F07
	public int GetBossDoubleDropCount()
	{
		RegressData regressRawData = this.RegressRawData;
		if (regressRawData == null)
		{
			return 0;
		}
		return regressRawData.BossDoubleCount;
	}

	// Token: 0x060096D3 RID: 38611 RVA: 0x00277D1A File Offset: 0x00275F1A
	public int GetWeekDoubleDropCount()
	{
		RegressData regressRawData = this.RegressRawData;
		if (regressRawData == null)
		{
			return 0;
		}
		return regressRawData.WeekDoubleCount;
	}

	// Token: 0x060096D4 RID: 38612 RVA: 0x00277D30 File Offset: 0x00275F30
	public ERegressRewardState GetQuestionnaireRewardState(int id)
	{
		if (this.RegressRawData == null)
		{
			return ERegressRewardState.UnReach;
		}
		RepeatedField<QuestionTask> question = this.RegressRawData.Question;
		QuestionTask questionTask = null;
		foreach (QuestionTask questionTask2 in question)
		{
			if (questionTask2.Id == id)
			{
				questionTask = questionTask2;
				break;
			}
		}
		if (questionTask == null)
		{
			return ERegressRewardState.UnReach;
		}
		switch (questionTask.Status)
		{
		case ActivityTaskState.ActivityTaskRunning:
			return ERegressRewardState.UnReach;
		case ActivityTaskState.ActivityTaskFinish:
			return ERegressRewardState.Reached;
		case ActivityTaskState.ActivityTaskTaken:
			return ERegressRewardState.Claim;
		default:
			return ERegressRewardState.UnReach;
		}
	}

	// Token: 0x060096D5 RID: 38613 RVA: 0x00277DBC File Offset: 0x00275FBC
	public bool CheckShowQuestionnaireRedDot()
	{
		if (!this.IsActivityOpen())
		{
			return false;
		}
		foreach (ERegressQuestionnaireType type in this.CheckQuestionnaireTypes)
		{
			RegressInvestigation? regressQuestionnaireConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestionnaireConfig(type);
			if (regressQuestionnaireConfig != null && this.IsQuestionnaireUnlock(type) && this.GetQuestionnaireRewardState(regressQuestionnaireConfig.Value.Id) == ERegressRewardState.Reached)
			{
				return true;
			}
		}
		return this.CheckQuestionnaireFirstRedDot() || this.CheckSecondQuestionnaireFirstRedDot();
	}

	// Token: 0x060096D6 RID: 38614 RVA: 0x00277E60 File Offset: 0x00276060
	public bool CheckQuestionnaireFirstRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressQuestionnaireRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096D7 RID: 38615 RVA: 0x00277E78 File Offset: 0x00276078
	public bool CheckSecondQuestionnaireFirstRedDot()
	{
		if (!this.IsActivityOpen())
		{
			return false;
		}
		bool flag = this.IsQuestionnaireUnlock(ERegressQuestionnaireType.Type2);
		return !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressSecondQuestionnaireRedDotCheckedInPeriod, false) && flag;
	}

	// Token: 0x060096D8 RID: 38616 RVA: 0x00277EA4 File Offset: 0x002760A4
	public bool CheckDisposableRewardRedDot()
	{
		return !this.DisposableReward;
	}

	// Token: 0x060096D9 RID: 38617 RVA: 0x00277EAF File Offset: 0x002760AF
	public void ResetQuestionnaireRedDot()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressQuestionnaireRedDotCheckedInPeriod, false);
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressSecondQuestionnaireRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096DA RID: 38618 RVA: 0x00277EC4 File Offset: 0x002760C4
	public void SetQuestionnaireRedDotChecked()
	{
		if (this.CheckQuestionnaireFirstRedDot())
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressQuestionnaireRedDotCheckedInPeriod, true);
		}
		if (this.CheckSecondQuestionnaireFirstRedDot())
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressSecondQuestionnaireRedDotCheckedInPeriod, true);
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060096DB RID: 38619 RVA: 0x00277F19 File Offset: 0x00276119
	public bool CheckShopRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressShopRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096DC RID: 38620 RVA: 0x00277F30 File Offset: 0x00276130
	public bool CheckTrialRoleRedDot()
	{
		return this.IsActivityOpen() && (this.CheckNewUnLockRole() || this.IsTrialRoleUpgradeRedPoint());
	}

	// Token: 0x060096DD RID: 38621 RVA: 0x00277F4C File Offset: 0x0027614C
	public bool CheckNewUnLockRole()
	{
		return !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressTrialRoleRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096DE RID: 38622 RVA: 0x00277F5C File Offset: 0x0027615C
	public bool IsTrialRoleUpgradeRedPoint()
	{
		using (List<TrialRoleGroupData>.Enumerator enumerator = this.GetTrialRoleList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanUpgrade())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060096DF RID: 38623 RVA: 0x00277FB8 File Offset: 0x002761B8
	public List<TrialRoleGroupData> GetTrialRoleList()
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataListByType(ETrialRoleType.ReturnSupportTrial);
	}

	// Token: 0x060096E0 RID: 38624 RVA: 0x00277FC5 File Offset: 0x002761C5
	public bool CheckDoubleDropRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressDoubleDropRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096E1 RID: 38625 RVA: 0x00277FDC File Offset: 0x002761DC
	public bool CheckRecommendRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressRecommendRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096E2 RID: 38626 RVA: 0x00277FF3 File Offset: 0x002761F3
	public bool CheckAdventureRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressAdventureRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096E3 RID: 38627 RVA: 0x0027800A File Offset: 0x0027620A
	public void ResetShopRemindRedDot()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressShopRedDotCheckedInPeriod, false);
	}

	// Token: 0x060096E4 RID: 38628 RVA: 0x00278015 File Offset: 0x00276215
	public void SetShopRedDotChecked()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressShopRedDotCheckedInPeriod, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060096E5 RID: 38629 RVA: 0x00278046 File Offset: 0x00276246
	public void SetTrialRoleRedDotChecked(bool value)
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressTrialRoleRedDotCheckedInPeriod, value);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060096E6 RID: 38630 RVA: 0x00278077 File Offset: 0x00276277
	public void SetDoubleDropRedDotChecked()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressDoubleDropRedDotCheckedInPeriod, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x060096E7 RID: 38631 RVA: 0x00278092 File Offset: 0x00276292
	public void SetRecommendRedDotChecked()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressRecommendRedDotCheckedInPeriod, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x060096E8 RID: 38632 RVA: 0x002780AD File Offset: 0x002762AD
	public void SetAdventureRedDotChecked()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressAdventureRedDotCheckedInPeriod, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
	}

	// Token: 0x060096E9 RID: 38633 RVA: 0x002780C8 File Offset: 0x002762C8
	[NullableContext(0)]
	public ValueTuple<int, int> GetShopIdAndTabIndex()
	{
		AccessPath? accessPathConfig = ConfigBase<SkipInterfaceConfig>.Instance.GetAccessPathConfig(859201);
		string text = (accessPathConfig != null) ? accessPathConfig.GetValueOrDefault().Val1 : null;
		string text2 = (accessPathConfig != null) ? accessPathConfig.GetValueOrDefault().Val2 : null;
		int item = (!string.IsNullOrEmpty(text)) ? int.Parse(text) : 0;
		int item2 = (!string.IsNullOrEmpty(text2)) ? int.Parse(text2) : 0;
		return new ValueTuple<int, int>(item, item2);
	}

	// Token: 0x060096EA RID: 38634 RVA: 0x00278148 File Offset: 0x00276348
	public bool IsQuestionnaireUnlock(ERegressQuestionnaireType type)
	{
		if (!this.IsActivityOpen())
		{
			return false;
		}
		if (type == ERegressQuestionnaireType.Type1)
		{
			return true;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("RegressSecondAskSignDay");
		return intConfig != null && this.GetSignRewardState(intConfig.Value) == ERegressRewardState.Claim;
	}

	// Token: 0x060096EB RID: 38635 RVA: 0x0027818C File Offset: 0x0027638C
	public void SetQuestionnaireReached(int id)
	{
		if (this.RegressRawData == null)
		{
			return;
		}
		RepeatedField<QuestionTask> question = this.RegressRawData.Question;
		QuestionTask questionTask = null;
		foreach (QuestionTask questionTask2 in question)
		{
			if (questionTask2.Id == id)
			{
				questionTask = questionTask2;
				break;
			}
		}
		if (questionTask != null && questionTask.Status == ActivityTaskState.ActivityTaskRunning)
		{
			questionTask.Status = ActivityTaskState.ActivityTaskFinish;
		}
	}

	// Token: 0x060096EC RID: 38636 RVA: 0x00278204 File Offset: 0x00276404
	public void RefreshRegressTaskMapping()
	{
		this.RegressTaskMapping.Clear();
		if (this.RegressRawData == null)
		{
			return;
		}
		foreach (ActivityTask activityTask in this.RegressRawData.ActivityTasks)
		{
			int id = activityTask.Id;
			RegressQuest? regressQuestConfig = ConfigBase<ActivityRegressConfig>.Instance.GetRegressQuestConfig(id);
			if (regressQuestConfig != null)
			{
				List<RegressQuest> list;
				if (!this.RegressTaskMapping.TryGetValue((ERegressTaskType)regressQuestConfig.Value.TaskType, out list))
				{
					list = new List<RegressQuest>();
					this.RegressTaskMapping[(ERegressTaskType)regressQuestConfig.Value.TaskType] = list;
				}
				list.Add(regressQuestConfig.Value);
			}
		}
	}

	// Token: 0x060096ED RID: 38637 RVA: 0x002782CC File Offset: 0x002764CC
	[NullableContext(2)]
	public List<RegressQuest> GetRegressTaskListByType(ERegressTaskType taskType)
	{
		List<RegressQuest> result;
		if (this.RegressTaskMapping.TryGetValue(taskType, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x060096EE RID: 38638 RVA: 0x002782EC File Offset: 0x002764EC
	public List<RegressQuest> GetAllRegressTaskList()
	{
		List<RegressQuest> list = new List<RegressQuest>();
		foreach (KeyValuePair<ERegressTaskType, List<RegressQuest>> keyValuePair in this.RegressTaskMapping)
		{
			list.AddRange(keyValuePair.Value);
		}
		return list;
	}

	// Token: 0x060096EF RID: 38639 RVA: 0x0027834C File Offset: 0x0027654C
	public bool HasReachableTask(ERegressTaskType regressTaskType)
	{
		List<RegressQuest> regressTaskListByType = this.GetRegressTaskListByType(regressTaskType);
		if (regressTaskListByType == null)
		{
			return false;
		}
		foreach (RegressQuest regressQuest in regressTaskListByType)
		{
			if (this.GetTaskRewardState(regressQuest.Id) == ERegressRewardState.Reached)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060096F0 RID: 38640 RVA: 0x002783B8 File Offset: 0x002765B8
	public bool HasReachableConstantTask()
	{
		return this.GetRegressTaskProgressFloat01() < 1.0 && (this.HasReachableTask(ERegressTaskType.Constant) || this.HasReachableTask(ERegressTaskType.Daily) || this.HasReachableTask(ERegressTaskType.Once));
	}

	// Token: 0x060096F1 RID: 38641 RVA: 0x002783E8 File Offset: 0x002765E8
	public bool HasReachableCultivateTask()
	{
		return this.HasReachableTask(ERegressTaskType.Cultivate);
	}

	// Token: 0x060096F2 RID: 38642 RVA: 0x002783F4 File Offset: 0x002765F4
	public double GetRegressTaskProgressFloat01()
	{
		ValueTuple<int, int> regressTaskProgressTuple = this.GetRegressTaskProgressTuple();
		int item = regressTaskProgressTuple.Item1;
		int item2 = regressTaskProgressTuple.Item2;
		if (item2 == 0)
		{
			return 0.0;
		}
		return Math.Truncate(Math.Min(1.0, (double)item / (double)item2) * 100.0) / 100.0;
	}

	// Token: 0x060096F3 RID: 38643 RVA: 0x0027844D File Offset: 0x0027664D
	public int GetRegressTaskScore()
	{
		return this.GetRegressTaskProgressTuple().Item1;
	}

	// Token: 0x060096F4 RID: 38644 RVA: 0x0027845C File Offset: 0x0027665C
	private bool IsGetScoreReward(int id)
	{
		if (this.RegressRawData == null)
		{
			return false;
		}
		using (IEnumerator<int> enumerator = this.RegressRawData.ScoreRewards.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == id)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060096F5 RID: 38645 RVA: 0x002784BC File Offset: 0x002766BC
	private bool IsGetPayScoreReward(int id)
	{
		if (this.RegressRawData == null)
		{
			return false;
		}
		using (IEnumerator<int> enumerator = this.RegressRawData.PayScoreRewards.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == id)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060096F6 RID: 38646 RVA: 0x0027851C File Offset: 0x0027671C
	public ERegressRewardState GetRegressTaskScoreRewardState(RegressBonusReward config)
	{
		if (this.IsGetScoreReward(config.Id))
		{
			return ERegressRewardState.Claim;
		}
		if (this.GetRegressTaskScore() >= config.NeedScore)
		{
			return ERegressRewardState.Reached;
		}
		return ERegressRewardState.UnReach;
	}

	// Token: 0x060096F7 RID: 38647 RVA: 0x00278541 File Offset: 0x00276741
	public ERegressRewardState GetRegressTaskPayScoreRewardState(RegressBonusReward config)
	{
		if (this.IsGetPayScoreReward(config.Id))
		{
			return ERegressRewardState.Claim;
		}
		if (this.RegressRawData == null || !this.RegressRawData.PayRewardUnlock)
		{
			return ERegressRewardState.UnReach;
		}
		if (this.GetRegressTaskScore() >= config.NeedScore)
		{
			return ERegressRewardState.Reached;
		}
		return ERegressRewardState.UnReach;
	}

	// Token: 0x060096F8 RID: 38648 RVA: 0x00278580 File Offset: 0x00276780
	public bool CheckRegressScoreRewardReached()
	{
		foreach (RegressBonusReward config in (ConfigBase<ActivityRegressConfig>.Instance.GetRegressBonusRewardConfigList(this.Grade) ?? new List<RegressBonusReward>()))
		{
			int regressTaskScoreRewardState = (int)this.GetRegressTaskScoreRewardState(config);
			ERegressRewardState regressTaskPayScoreRewardState = this.GetRegressTaskPayScoreRewardState(config);
			if (regressTaskScoreRewardState == 1 || regressTaskPayScoreRewardState == ERegressRewardState.Reached)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060096F9 RID: 38649 RVA: 0x002785F8 File Offset: 0x002767F8
	public void SetRegressScoreRewardReached(List<int> ids)
	{
		if (this.RegressRawData == null)
		{
			return;
		}
		foreach (int item in ids)
		{
			this.RegressRawData.ScoreRewards.Add(item);
		}
		if (this.RegressRawData.PayRewardUnlock)
		{
			foreach (int item2 in ids)
			{
				this.RegressRawData.PayScoreRewards.Add(item2);
			}
		}
	}

	// Token: 0x060096FA RID: 38650 RVA: 0x002786B0 File Offset: 0x002768B0
	public bool CheckRegressRewardBtnReached()
	{
		return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 100, 0, 0) == 0;
	}

	// Token: 0x060096FB RID: 38651 RVA: 0x002786CA File Offset: 0x002768CA
	public void SetRegressRewardBtnReached()
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 100, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x060096FC RID: 38652 RVA: 0x00278708 File Offset: 0x00276908
	[NullableContext(0)]
	public ValueTuple<int, int> GetRegressTaskProgressTuple()
	{
		int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(20, 0);
		IEnumerable<RegressBonusReward> enumerable = ConfigBase<ActivityRegressConfig>.Instance.GetRegressBonusRewardConfigList(this.Grade) ?? new List<RegressBonusReward>();
		int num = 0;
		foreach (RegressBonusReward regressBonusReward in enumerable)
		{
			num = Math.Max(regressBonusReward.NeedScore, num);
		}
		return new ValueTuple<int, int>(commonItemCount, num);
	}

	// Token: 0x060096FD RID: 38653 RVA: 0x00278788 File Offset: 0x00276988
	private void RefreshScoreRewardNeedScoreList()
	{
		this.ActivityScoreRewardTotalNeedScoreMap.Clear();
		foreach (RegressBonusReward regressBonusReward in (ConfigBase<ActivityRegressConfig>.Instance.GetRegressBonusRewardConfigList(this.Grade) ?? new List<RegressBonusReward>()))
		{
			this.ActivityScoreRewardTotalNeedScoreMap[regressBonusReward.Id] = regressBonusReward.NeedScore;
		}
	}

	// Token: 0x060096FE RID: 38654 RVA: 0x00278808 File Offset: 0x00276A08
	public int GetTaskSortPriority(int taskId)
	{
		ActivityTask rawTaskData = this.GetRawTaskData(taskId);
		if (rawTaskData == null)
		{
			return 1;
		}
		switch (rawTaskData.Status)
		{
		case ActivityTaskState.ActivityTaskRunning:
			return 1;
		case ActivityTaskState.ActivityTaskFinish:
			return 0;
		case ActivityTaskState.ActivityTaskTaken:
			return 2;
		default:
			return 1;
		}
	}

	// Token: 0x060096FF RID: 38655 RVA: 0x00278844 File Offset: 0x00276A44
	[NullableContext(0)]
	public ValueTuple<int, int> GetRegressTaskRelativeScore(RegressBonusReward config)
	{
		int regressTaskScore = this.GetRegressTaskScore();
		int key = config.Id - 1;
		int num = 0;
		int num2;
		if (this.ActivityScoreRewardTotalNeedScoreMap.TryGetValue(key, out num2))
		{
			num = num2;
		}
		int num3;
		if (!this.ActivityScoreRewardTotalNeedScoreMap.TryGetValue(config.Id, out num3))
		{
			num3 = 0;
		}
		int num4 = num3 - num;
		int item = 0;
		if (regressTaskScore > num)
		{
			if (regressTaskScore < num3)
			{
				item = regressTaskScore - num;
			}
			else
			{
				item = num4;
			}
		}
		return new ValueTuple<int, int>(item, num4);
	}

	// Token: 0x06009700 RID: 38656 RVA: 0x002788B5 File Offset: 0x00276AB5
	public bool IsDoubleDropUnlock(EActivityRegressDoubleDropEntryType type)
	{
		if (type == EActivityRegressDoubleDropEntryType.WorldBoss)
		{
			RegressData regressRawData = this.RegressRawData;
			return regressRawData != null && regressRawData.BossDoubleUnLock;
		}
		if (type == EActivityRegressDoubleDropEntryType.WeeklyDungeon)
		{
			RegressData regressRawData2 = this.RegressRawData;
			return regressRawData2 != null && regressRawData2.WeekDoubleUnLock;
		}
		return false;
	}

	// Token: 0x06009701 RID: 38657 RVA: 0x002788E4 File Offset: 0x00276AE4
	public void ResetDoubleDropFirstRedDot()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressDoubleDropFirstRedDotCheckedInPeriod, false);
	}

	// Token: 0x06009702 RID: 38658 RVA: 0x002788EF File Offset: 0x00276AEF
	public void MarkDoubleDropFirstRedDotShown()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressDoubleDropFirstRedDotCheckedInPeriod, true);
		Singleton<EventSystem>.Instance.Emit(EEventName.RecallActivityInfoUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06009703 RID: 38659 RVA: 0x00278920 File Offset: 0x00276B20
	public bool CheckDoubleDropFirstRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressDoubleDropFirstRedDotCheckedInPeriod, false);
	}

	// Token: 0x06009704 RID: 38660 RVA: 0x00278938 File Offset: 0x00276B38
	public int GetLevelByScore(int score)
	{
		IReadOnlyList<RegressBonusReward> sortedRegressBonusRewardConfigList = this.GetSortedRegressBonusRewardConfigList();
		int num = 0;
		int count = sortedRegressBonusRewardConfigList.Count;
		while (num < count && score >= sortedRegressBonusRewardConfigList[num].NeedScore)
		{
			num++;
		}
		return num;
	}

	// Token: 0x06009705 RID: 38661 RVA: 0x00278974 File Offset: 0x00276B74
	public IRegressLevelProgressData? GetLevelProgressDataByScore(int score)
	{
		IReadOnlyList<RegressBonusReward> sortedRegressBonusRewardConfigList = this.GetSortedRegressBonusRewardConfigList();
		int num = 0;
		int count = sortedRegressBonusRewardConfigList.Count;
		if (count == 0)
		{
			return null;
		}
		while (num < count && score >= sortedRegressBonusRewardConfigList[num].NeedScore)
		{
			num++;
		}
		if (num == count)
		{
			return new IRegressLevelProgressData?(new IRegressLevelProgressData
			{
				Level = num,
				MaxLevel = count,
				CurScore = sortedRegressBonusRewardConfigList[num - 1].NeedScore,
				NeedScore = sortedRegressBonusRewardConfigList[num - 1].NeedScore
			});
		}
		int num2 = (num > 0) ? sortedRegressBonusRewardConfigList[num - 1].NeedScore : 0;
		return new IRegressLevelProgressData?(new IRegressLevelProgressData
		{
			Level = num,
			MaxLevel = count,
			CurScore = score - num2,
			NeedScore = sortedRegressBonusRewardConfigList[num].NeedScore - num2
		});
	}

	// Token: 0x06009706 RID: 38662 RVA: 0x00278A6C File Offset: 0x00276C6C
	public IRegressLevelProgressData GetCurLevelProgressData()
	{
		int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(20, 0);
		IRegressLevelProgressData? levelProgressDataByScore = this.GetLevelProgressDataByScore(commonItemCount);
		if (levelProgressDataByScore == null)
		{
			levelProgressDataByScore = new IRegressLevelProgressData?(new IRegressLevelProgressData
			{
				Level = 0,
				MaxLevel = 0,
				CurScore = 0,
				NeedScore = 0
			});
		}
		return levelProgressDataByScore.Value;
	}

	// Token: 0x06009707 RID: 38663 RVA: 0x00278ACF File Offset: 0x00276CCF
	public bool IsPayRewardUnlock()
	{
		RegressData regressRawData = this.RegressRawData;
		return regressRawData != null && regressRawData.PayRewardUnlock;
	}

	// Token: 0x06009708 RID: 38664 RVA: 0x00278AE2 File Offset: 0x00276CE2
	public int GetMaxLevel()
	{
		return this.GetSortedRegressBonusRewardConfigList().Count;
	}

	// Token: 0x06009709 RID: 38665 RVA: 0x00278AEF File Offset: 0x00276CEF
	public void SetPayRewardUnlock(bool value)
	{
		if (this.RegressRawData != null)
		{
			this.RegressRawData.PayRewardUnlock = value;
		}
	}

	// Token: 0x0600970A RID: 38666 RVA: 0x00278B05 File Offset: 0x00276D05
	public void ResetBpPayButtonRedDot()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressBpPayButtonRedDotCheckedInPeriod, false);
	}

	// Token: 0x0600970B RID: 38667 RVA: 0x00278B10 File Offset: 0x00276D10
	public bool CheckBpPayButtonRedDot()
	{
		return this.IsActivityOpen() && !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressBpPayButtonRedDotCheckedInPeriod, false);
	}

	// Token: 0x0600970C RID: 38668 RVA: 0x00278B27 File Offset: 0x00276D27
	public void SetBpPayButtonRedDotChecked()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressBpPayButtonRedDotCheckedInPeriod, true);
	}

	// Token: 0x0600970D RID: 38669 RVA: 0x00278B32 File Offset: 0x00276D32
	public void RefreshPrevBpExp()
	{
		this.PrevBpExpInternal = ModelBase<InventoryModel>.Instance.GetCommonItemCount(20, 0);
	}

	// Token: 0x0600970E RID: 38670 RVA: 0x00278B48 File Offset: 0x00276D48
	public IReadOnlyList<RegressBonusReward> GetSortedRegressBonusRewardConfigList()
	{
		if (this.SortedRegressBonusRewardConfigList == null || this.SortedRegressBonusRewardConfigList.Count == 0)
		{
			IReadOnlyList<RegressBonusReward> collection = ConfigBase<ActivityRegressConfig>.Instance.GetRegressBonusRewardConfigList(this.Grade) ?? new List<RegressBonusReward>();
			this.SortedRegressBonusRewardConfigList = new List<RegressBonusReward>(collection);
			this.SortedRegressBonusRewardConfigList.Sort((RegressBonusReward a, RegressBonusReward b) => a.NeedScore - b.NeedScore);
		}
		return this.SortedRegressBonusRewardConfigList;
	}

	// Token: 0x040045B2 RID: 17842
	[Nullable(2)]
	private RegressData RegressRawData;

	// Token: 0x040045B3 RID: 17843
	private const int ACTIVITY_REGRESS_REWARD_BTN_CLICK_KEY = 100;

	// Token: 0x040045B4 RID: 17844
	private readonly Dictionary<int, ActivityTask> ActivityInternalTaskMap = new Dictionary<int, ActivityTask>();

	// Token: 0x040045B5 RID: 17845
	private readonly Dictionary<int, int> ActivityScoreRewardTotalNeedScoreMap = new Dictionary<int, int>();

	// Token: 0x040045B6 RID: 17846
	private long ActivityRecallDailyTaskRefreshTime;

	// Token: 0x040045B7 RID: 17847
	public int CurrentUseTrialRole;

	// Token: 0x040045B8 RID: 17848
	public bool DisposableReward;

	// Token: 0x040045B9 RID: 17849
	private int PrevBpExpInternal;

	// Token: 0x040045BA RID: 17850
	[Nullable(2)]
	private List<RegressBonusReward> SortedRegressBonusRewardConfigList;

	// Token: 0x040045BB RID: 17851
	private readonly List<ERegressQuestionnaireType> CheckQuestionnaireTypes = new List<ERegressQuestionnaireType>
	{
		ERegressQuestionnaireType.Type1,
		ERegressQuestionnaireType.Type2
	};

	// Token: 0x040045BC RID: 17852
	private readonly Dictionary<ERegressTaskType, List<RegressQuest>> RegressTaskMapping = new Dictionary<ERegressTaskType, List<RegressQuest>>();
}
