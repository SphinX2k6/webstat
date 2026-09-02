using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Mowing;

// Token: 0x0200172E RID: 5934
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ActivityModel : ModelBase<ActivityModel>
{
	// Token: 0x0600A547 RID: 42311 RVA: 0x002BA970 File Offset: 0x002B8B70
	protected override bool OnInit()
	{
		this.InitActivityLevelFuncMap();
		this.InitLangText();
		Singleton<EventSystem>.Instance.Add<string, string>(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
		return true;
	}

	// Token: 0x0600A548 RID: 42312 RVA: 0x002BA99C File Offset: 0x002B8B9C
	protected override bool OnClear()
	{
		foreach (TimerHandle handle in this.ActivityTimeStampHandleMap.Values)
		{
			TimerSystem.RealTimeInstance.Remove(handle);
		}
		this.ActivityTimeStampHandleMap.Clear();
		this.ActivityTimeStampSet.Clear();
		Singleton<EventSystem>.Instance.Remove(EEventName.TextLanguageChange, new Action<string, string>(this.OnLanguageChange));
		return true;
	}

	// Token: 0x0600A549 RID: 42313 RVA: 0x002BAA2C File Offset: 0x002B8C2C
	public void InitCache()
	{
		this.ActivityCache.InitData();
	}

	// Token: 0x0600A54A RID: 42314 RVA: 0x002BAA3C File Offset: 0x002B8C3C
	private void InitLangText()
	{
		if (StringUtils.IsEmpty(this.ActivityForeverTimeText))
		{
			this.ActivityForeverTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityForeverTip", null);
		}
		if (StringUtils.IsEmpty(this.ActivityCloseText))
		{
			string textContentIdById = ConfigBase<TextConfig>.Instance.GetTextContentIdById("ActiveClose");
			this.ActivityCloseText = ConfigMultiTextLang.GetLocalTextNew(textContentIdById, null);
		}
		if (StringUtils.IsEmpty(this.ActivityCdTimeText))
		{
			this.ActivityCdTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityClosePanelTime", null);
		}
		if (StringUtils.IsEmpty(this.ActivityRemainTimeText))
		{
			this.ActivityRemainTimeText = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
		}
		if (StringUtils.IsEmpty(this.ActivityRemainingTimeReward))
		{
			this.ActivityRemainingTimeReward = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime_Reward_Text", null);
		}
	}

	// Token: 0x0600A54B RID: 42315 RVA: 0x002BAAEB File Offset: 0x002B8CEB
	protected void OnLanguageChange(string s, string s1)
	{
		this.ActivityForeverTimeText = "";
		this.ActivityCloseText = "";
		this.ActivityCdTimeText = "";
		this.ActivityRemainTimeText = "";
		this.ActivityRemainingTimeReward = "";
		this.InitLangText();
	}

	// Token: 0x0600A54C RID: 42316 RVA: 0x002BAB2C File Offset: 0x002B8D2C
	public unsafe void OnReceiveMessageData(ActivityData[] data)
	{
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in this.ActivityMap)
		{
			keyValuePair.Value.ForceClose();
		}
		ActivityData[] array = data;
		int i = 0;
		while (i < array.Length)
		{
			ActivityData activityData = array[i];
			if (ActivityManager.GetActivityController(activityData.Type) != null)
			{
				try
				{
					ActivityBaseData orCreateActivity = this.GetOrCreateActivity(activityData);
					if (orCreateActivity != null)
					{
						orCreateActivity.Phrase(activityData);
					}
					goto IL_12F;
				}
				catch (Exception ex)
				{
					this.OpenActivityErrorConfirmBox(activityData.Id, (int)activityData.Type);
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.YYZ;
					string message = "[Activity]Phrase执行异常";
					Exception error = ex;
					<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", activityData.Id);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex.Message);
					instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					goto IL_12F;
				}
				goto IL_FA;
			}
			goto IL_FA;
			IL_12F:
			i++;
			continue;
			IL_FA:
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Activity;
			ELogAuthor author2 = ELogAuthor.YZY;
			string message2 = "尚未实现活动";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("type", activityData.Type);
			instance2.Warn(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			goto IL_12F;
		}
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (ActivityData activityData2 in data)
		{
			if (!dictionary.ContainsKey((int)activityData2.Type))
			{
				dictionary[(int)activityData2.Type] = new List<int>();
			}
			dictionary[(int)activityData2.Type].Add(activityData2.Id);
		}
		foreach (KeyValuePair<int, List<int>> keyValuePair2 in dictionary)
		{
			Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, keyValuePair2.Key, keyValuePair2.Value);
		}
		this.ActivityCache.OnReceiveActivityData();
		this.RefreshShowingActivities();
		this.RefreshActivityFirstUnlockState();
		Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YYZ, "ActivityRequest 收到活动数据", default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600A54D RID: 42317 RVA: 0x002BAD80 File Offset: 0x002B8F80
	public void OnReceiveActivityRead(int activityId)
	{
		ActivityBaseData activityBaseData;
		if (this.ActivityMap.TryGetValue(activityId, out activityBaseData))
		{
			activityBaseData.SetFirstOpenFalse();
		}
	}

	// Token: 0x0600A54E RID: 42318 RVA: 0x002BADA4 File Offset: 0x002B8FA4
	public unsafe void OnActivityUpdate(ActivityData[] data)
	{
		ActivityData[] array = data;
		int i = 0;
		while (i < array.Length)
		{
			ActivityData activityData = array[i];
			if (ActivityManager.GetActivityController(activityData.Type) != null)
			{
				try
				{
					ActivityBaseData orCreateActivity = this.GetOrCreateActivity(activityData);
					if (orCreateActivity != null)
					{
						orCreateActivity.Phrase(activityData);
					}
					goto IL_132;
				}
				catch (Exception ex)
				{
					this.OpenActivityErrorConfirmBox(activityData.Id, (int)activityData.Type);
					if (ex != null)
					{
						Exception ex2 = ex;
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.Activity;
						ELogAuthor author = ELogAuthor.YYZ;
						string message = "[Activity]Phrase执行异常";
						Exception error = ex2;
						<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("id", activityData.Id);
						*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("error", ex2.Message);
						instance.ErrorWithStack(module, author, message, error, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
					}
					else
					{
						Log instance2 = Singleton<Log>.Instance;
						ELogModule module2 = ELogModule.Activity;
						ELogAuthor author2 = ELogAuthor.YYZ;
						string message2 = "[Activity]Phrase执行异常";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", activityData.Id);
						instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
					goto IL_132;
				}
				goto IL_FD;
			}
			goto IL_FD;
			IL_132:
			i++;
			continue;
			IL_FD:
			Log instance3 = Singleton<Log>.Instance;
			ELogModule module3 = ELogModule.Activity;
			ELogAuthor author3 = ELogAuthor.YZY;
			string message3 = "尚未实现活动";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("type", activityData.Type);
			instance3.Warn(module3, author3, message3, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			goto IL_132;
		}
		Dictionary<int, List<int>> dictionary = new Dictionary<int, List<int>>();
		foreach (ActivityData activityData2 in data)
		{
			if (!dictionary.ContainsKey((int)activityData2.Type))
			{
				dictionary[(int)activityData2.Type] = new List<int>();
			}
			dictionary[(int)activityData2.Type].Add(activityData2.Id);
		}
		foreach (KeyValuePair<int, List<int>> keyValuePair in dictionary)
		{
			Singleton<EventSystem>.Instance.Emit<int, IReadOnlyList<int>>(EEventName.OnReceiveActivityData, keyValuePair.Key, keyValuePair.Value);
		}
		this.RefreshShowingActivities();
		if (ModelBase<GameModeModel>.Instance.WorldDone)
		{
			this.RefreshActivityFirstUnlockState();
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityUpdate);
	}

	// Token: 0x0600A54F RID: 42319 RVA: 0x002BAFE0 File Offset: 0x002B91E0
	public void OnDisableActivity(int[] ids)
	{
		foreach (int key in ids)
		{
			ActivityBaseData activityBaseData;
			if (this.ActivityMap.TryGetValue(key, out activityBaseData))
			{
				activityBaseData.ActivityClose();
				activityBaseData.ForceClose();
			}
		}
		this.RefreshShowingActivities();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityUpdate);
	}

	// Token: 0x0600A550 RID: 42320 RVA: 0x002BB034 File Offset: 0x002B9234
	[return: Nullable(2)]
	private unsafe ActivityBaseData GetOrCreateActivity(ActivityData data)
	{
		ActivityBaseData activityBaseData;
		if (this.ActivityMap.TryGetValue(data.Id, out activityBaseData))
		{
			return activityBaseData;
		}
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		long num = Singleton<MathUtils>.Instance.LongToBigInt(data.BeginShowTime);
		long num2 = Singleton<MathUtils>.Instance.LongToBigInt(data.BeginOpenTime);
		if (serverTime <= (double)num && serverTime <= (double)num2)
		{
			long checkTime = Math.Min(num2, num);
			this.SetActivityTimeCheck(checkTime, data.Id, true);
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Activity;
			ELogAuthor author = ELogAuthor.YYZ;
			string message = "活动待开启";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("Id", data.Id);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ShowTime", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("OpenTime", num2);
			instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return null;
		}
		long val = Singleton<MathUtils>.Instance.LongToBigInt(data.EndShowTime);
		long val2 = Singleton<MathUtils>.Instance.LongToBigInt(data.EndOpenTime);
		long checkTime2 = Math.Max(val, val2);
		this.SetActivityTimeCheck(checkTime2, data.Id, false);
		activityBaseData = ControllerBase<ActivityController>.Instance.CreateActivityData(data);
		this.ActivityMap[data.Id] = activityBaseData;
		this.CurrentActivityIds.Add(data.Id);
		return activityBaseData;
	}

	// Token: 0x0600A551 RID: 42321 RVA: 0x002BB19C File Offset: 0x002B939C
	private void SetActivityTimeCheck(long checkTime, int activityId, bool isOpen)
	{
		if (this.ActivityTimeStampSet.Contains(checkTime))
		{
			return;
		}
		if ((double)checkTime < Singleton<TimeUtil>.Instance.GetServerTime())
		{
			return;
		}
		long num = checkTime * (long)Singleton<TimeUtil>.Instance.InverseMillisecond + 20L;
		string reason = StringUtils.Format("活动开启关闭时间倒计时 [ActivityId:{0}, IsOpen:{1}]", new string[]
		{
			activityId.ToString(),
			isOpen.ToString()
		});
		TimerHandle timerHandle = TimerSystem.RealTimeInstance.EmitOnTime(delegate(float _)
		{
			this.ActivityTimeStampCheck(checkTime);
		}, (double)num, null, reason, true, 1f);
		if (timerHandle == null)
		{
			return;
		}
		this.ActivityTimeStampSet.Add(checkTime);
		this.ActivityTimeStampHandleMap[checkTime] = timerHandle;
	}

	// Token: 0x0600A552 RID: 42322 RVA: 0x002BB26C File Offset: 0x002B946C
	private void ActivityTimeStampCheck(long checkTime)
	{
		Singleton<Log>.Instance.Info(ELogModule.Activity, ELogAuthor.YYZ, "ActivityTimeStampCheck 活动开始结束时间检查", default(ReadOnlySpan<ValueTuple<string, object>>));
		ControllerBase<ActivityController>.Instance.RequestActivityData();
		TimerHandle handle;
		if (this.ActivityTimeStampHandleMap.TryGetValue(checkTime, out handle))
		{
			TimerSystem.RealTimeInstance.Remove(handle);
			this.ActivityTimeStampHandleMap.Remove(checkTime);
		}
		this.ActivityTimeStampSet.Remove(checkTime);
	}

	// Token: 0x0600A553 RID: 42323 RVA: 0x002BB2D9 File Offset: 0x002B94D9
	public bool GetIfFunctionOpen()
	{
		return ModelBase<FunctionModel>.Instance.IsOpen(10053);
	}

	// Token: 0x0600A554 RID: 42324 RVA: 0x002BB2EC File Offset: 0x002B94EC
	private bool ShouldDefaultToNewbieTab()
	{
		ActivitySevenDaySignData newcomerSignInActivityData = this.GetNewcomerSignInActivityData();
		return newcomerSignInActivityData != null && !newcomerSignInActivityData.IsAllSignRewardReceived();
	}

	// Token: 0x0600A555 RID: 42325 RVA: 0x002BB310 File Offset: 0x002B9510
	[NullableContext(2)]
	private ActivitySevenDaySignData GetNewcomerSignInActivityData()
	{
		List<ActivityBaseData> activitiesByType = this.GetActivitiesByType(2);
		if (activitiesByType == null || activitiesByType.Count <= 0)
		{
			return null;
		}
		foreach (ActivityBaseData activityBaseData in activitiesByType)
		{
			ActivitySevenDaySignData activitySevenDaySignData = activityBaseData as ActivitySevenDaySignData;
			if (activitySevenDaySignData != null)
			{
				ActivitySign? activitySignById = ConfigBase<ActivitySevenDaySignConfig>.Instance.GetActivitySignById(activitySevenDaySignData.Id);
				if (activitySignById != null && activitySignById.GetValueOrDefault().Type == 3 && activitySevenDaySignData.CheckIfInOpenTime())
				{
					return activitySevenDaySignData;
				}
			}
		}
		return null;
	}

	// Token: 0x0600A556 RID: 42326 RVA: 0x002BB3B8 File Offset: 0x002B95B8
	private int? FindTabIdByFilterTabType(IActivityCategoryTabData[] tabDataList, int filterTabType)
	{
		Func<ActivityBaseData, bool> <>9__0;
		foreach (IActivityCategoryTabData activityCategoryTabData in tabDataList)
		{
			if (!activityCategoryTabData.IsLineType && activityCategoryTabData.Id != null)
			{
				List<ActivityBaseData> activities = activityCategoryTabData.Activities;
				bool flag;
				if (activities == null)
				{
					flag = false;
				}
				else
				{
					Func<ActivityBaseData, bool> predicate;
					if ((predicate = <>9__0) == null)
					{
						predicate = (<>9__0 = ((ActivityBaseData activity) => activity.LocalConfig != null && activity.LocalConfig.GetValueOrDefault().FilterTabType == filterTabType));
					}
					flag = activities.Any(predicate);
				}
				if (flag)
				{
					return activityCategoryTabData.Id;
				}
			}
		}
		return null;
	}

	// Token: 0x0600A557 RID: 42327 RVA: 0x002BB448 File Offset: 0x002B9648
	public int? GetDefaultOpenTabId(IActivityCategoryTabData[] tabDataList)
	{
		if (tabDataList == null || tabDataList.Length == 0)
		{
			return null;
		}
		int filterTabType = this.ShouldDefaultToNewbieTab() ? 2 : 1;
		int? result = this.FindTabIdByFilterTabType(tabDataList, filterTabType);
		if (result != null)
		{
			return result;
		}
		foreach (IActivityCategoryTabData activityCategoryTabData in tabDataList)
		{
			if (!activityCategoryTabData.IsLineType)
			{
				return activityCategoryTabData.Id;
			}
		}
		return null;
	}

	// Token: 0x0600A558 RID: 42328 RVA: 0x002BB4BB File Offset: 0x002B96BB
	public bool GetIfShowActivity()
	{
		return this.GetIfFunctionOpen();
	}

	// Token: 0x0600A559 RID: 42329 RVA: 0x002BB4C8 File Offset: 0x002B96C8
	public Dictionary<int, ActivityBaseData> GetAllActivityMap()
	{
		return this.ActivityMap;
	}

	// Token: 0x0600A55A RID: 42330 RVA: 0x002BB4D0 File Offset: 0x002B96D0
	[NullableContext(2)]
	public ActivityBaseData GetActivityById(int id)
	{
		ActivityBaseData result;
		if (!this.ActivityMap.TryGetValue(id, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x0600A55B RID: 42331 RVA: 0x002BB4F0 File Offset: 0x002B96F0
	public bool IsActivityOpen(int id)
	{
		ActivityBaseData activityBaseData;
		return this.ActivityMap.TryGetValue(id, out activityBaseData) && activityBaseData.CheckIfInShowTime();
	}

	// Token: 0x0600A55C RID: 42332 RVA: 0x002BB518 File Offset: 0x002B9718
	public List<ActivityBaseData> GetActivitiesByType(int type)
	{
		List<ActivityBaseData> list = new List<ActivityBaseData>();
		foreach (ActivityBaseData activityBaseData in this.ActivityMap.Values)
		{
			ActivityType type2 = activityBaseData.Type;
			if (activityBaseData.Type == (ActivityType)type)
			{
				list.Add(activityBaseData);
			}
		}
		return list;
	}

	// Token: 0x0600A55D RID: 42333 RVA: 0x002BB588 File Offset: 0x002B9788
	public List<ActivityBaseData> GetCurrentActivitiesByType(int type)
	{
		List<ActivityBaseData> list = new List<ActivityBaseData>();
		foreach (ActivityBaseData activityBaseData in this.CurrentShowingActivitiesMap.Values)
		{
			if (activityBaseData.Type == (ActivityType)type)
			{
				list.Add(activityBaseData);
			}
		}
		return list;
	}

	// Token: 0x0600A55E RID: 42334 RVA: 0x002BB5F0 File Offset: 0x002B97F0
	public List<ActivityBaseData> GetCurrentActivitiesByType(ActivityType type)
	{
		List<ActivityBaseData> list = new List<ActivityBaseData>();
		foreach (ActivityBaseData activityBaseData in this.CurrentShowingActivitiesMap.Values)
		{
			if (activityBaseData.Type == type)
			{
				list.Add(activityBaseData);
			}
		}
		return list;
	}

	// Token: 0x0600A55F RID: 42335 RVA: 0x002BB658 File Offset: 0x002B9858
	public List<ActivityBaseData> GetCurrentShowingActivities()
	{
		List<ActivityBaseData> list = new List<ActivityBaseData>(this.CurrentShowingActivitiesMap.Values);
		list = (from data in list
		where !data.IsHiddenByConfig()
		select data).ToList<ActivityBaseData>();
		foreach (ActivityBaseData activityBaseData in list)
		{
			activityBaseData.UpdateImportantBubble();
		}
		ActivityModel.SortActivityList<ActivityBaseData>(list);
		return list;
	}

	// Token: 0x0600A560 RID: 42336 RVA: 0x002BB6E8 File Offset: 0x002B98E8
	public bool IsHasShowingRecommendRecActivity()
	{
		foreach (ActivityBaseData activityBaseData in this.GetCurrentShowingActivities())
		{
			if (activityBaseData.LocalConfig != null && activityBaseData.LocalConfig.Value.IsTabEffectNotice)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600A561 RID: 42337 RVA: 0x002BB760 File Offset: 0x002B9960
	private List<ActivityBaseData> GetDebugFilterActivityDataList()
	{
		List<ActivityBaseData> source = new List<ActivityBaseData>(this.CurrentShowingActivitiesMap.Values);
		if (this.DebugFilterMode)
		{
			source = (from data in source
			where this.DebugFilterShowActivityIds.Contains(data.Id)
			select data).ToList<ActivityBaseData>();
		}
		return (from data in source
		where !data.IsHiddenByConfig()
		select data).ToList<ActivityBaseData>();
	}

	// Token: 0x0600A562 RID: 42338 RVA: 0x002BB7CA File Offset: 0x002B99CA
	public bool HaveShowingActivity()
	{
		return this.GetCurrentShowingActivities().Count > 0;
	}

	// Token: 0x0600A563 RID: 42339 RVA: 0x002BB7DC File Offset: 0x002B99DC
	public bool GetIsActivityShowingByType(int type)
	{
		if (this.CurrentShowingActivitiesMap == null || this.CurrentShowingActivitiesMap.Count == 0)
		{
			return false;
		}
		using (Dictionary<int, ActivityBaseData>.ValueCollection.Enumerator enumerator = this.CurrentShowingActivitiesMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.Type == (ActivityType)type)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0600A564 RID: 42340 RVA: 0x002BB854 File Offset: 0x002B9A54
	public void RefreshShowingActivities()
	{
		this.CurrentRemoveActivities.Clear();
		this.CurrentAddActivities.Clear();
		foreach (KeyValuePair<int, ActivityBaseData> keyValuePair in this.ActivityMap)
		{
			ActivityBaseData value = keyValuePair.Value;
			bool flag = value.CheckIfInShowTime();
			if (this.CurrentShowingActivitiesMap.ContainsKey(value.Id) && !flag)
			{
				this.CurrentRemoveActivities.Add(value.Id);
				this.CurrentShowingActivitiesMap.Remove(value.Id);
			}
			else if (!this.CurrentShowingActivitiesMap.ContainsKey(value.Id) && flag)
			{
				this.CurrentAddActivities.Add(value.Id);
				this.CurrentShowingActivitiesMap[value.Id] = value;
			}
		}
		if (this.CurrentRemoveActivities.Count > 0)
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlySet<int>>(EEventName.OnActivityClose, this.CurrentRemoveActivities);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityUpdate);
		}
		if (this.CurrentAddActivities.Count > 0)
		{
			Singleton<EventSystem>.Instance.Emit<IReadOnlySet<int>>(EEventName.OnActivityOpen, this.CurrentAddActivities);
			Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityUpdate);
		}
	}

	// Token: 0x0600A565 RID: 42341 RVA: 0x002BB9AC File Offset: 0x002B9BAC
	private void RefreshActivityFirstUnlockState()
	{
		foreach (ActivityBaseData activityBaseData in this.GetCurrentShowingActivities())
		{
			int activityCacheData = this.GetActivityCacheData(activityBaseData.Id, 0, -100, 0, 0);
			if (activityBaseData.IsUnLock() && activityCacheData == 0)
			{
				IActivityControllerBase activityController = ActivityManager.GetActivityController(activityBaseData.Type);
				if (activityController != null)
				{
					activityController.OnActivityFirstUnlock(activityBaseData);
				}
				if (activityBaseData.TimeType == EActivityTimeType.TimeLimit && activityController != null)
				{
					activityController.OnShowActivityFirstUnlockView(activityBaseData);
				}
				this.SaveActivityData(activityBaseData.Id, -100, 0, 0, 1);
			}
		}
	}

	// Token: 0x0600A566 RID: 42342 RVA: 0x002BBA50 File Offset: 0x002B9C50
	public void SaveActivityData(int activityId, int key1, int key2, int key3, int value)
	{
		ActivityBaseData activityById = this.GetActivityById(activityId);
		this.ActivityCache.SaveCacheData(activityById, key1, key2, key3, value);
	}

	// Token: 0x0600A567 RID: 42343 RVA: 0x002BBA78 File Offset: 0x002B9C78
	public int GetActivityCacheData(int activityId, int defaultValue, int key1, int key2, int key3)
	{
		ActivityBaseData activityById = this.GetActivityById(activityId);
		return this.ActivityCache.GetCacheData(activityById, defaultValue, key1, key2, key3);
	}

	// Token: 0x0600A568 RID: 42344 RVA: 0x002BBAA0 File Offset: 0x002B9CA0
	public static void SortActivityList<[Nullable(0)] T>(List<T> activityDataList) where T : ActivityBaseData
	{
		foreach (T t in activityDataList)
		{
			t.CacheSortSinkState();
		}
		Comparison<T> comparison;
		if ((comparison = ActivityModel.<SortActivityList>O__48_0<T>.<0>__SortFunc) == null)
		{
			comparison = (ActivityModel.<SortActivityList>O__48_0<T>.<0>__SortFunc = new Comparison<T>(ActivityModel.SortFunc));
		}
		activityDataList.Sort(comparison);
	}

	// Token: 0x0600A569 RID: 42345 RVA: 0x002BBB14 File Offset: 0x002B9D14
	private static int SortFunc(ActivityBaseData a, ActivityBaseData b)
	{
		if (a.SortSinkStateCached != b.SortSinkStateCached)
		{
			if (!a.SortSinkStateCached)
			{
				return -1;
			}
			return 1;
		}
		else if (a.IsShowImportantBubble != b.IsShowImportantBubble)
		{
			if (!a.IsShowImportantBubble)
			{
				return 1;
			}
			return -1;
		}
		else
		{
			if (a.IsShowImportantBubble && b.IsShowImportantBubble)
			{
				long bubbleEndShowTime = a.BubbleEndShowTime;
				long bubbleEndShowTime2 = b.BubbleEndShowTime;
				if (bubbleEndShowTime > 0L && bubbleEndShowTime2 > 0L && bubbleEndShowTime != bubbleEndShowTime2)
				{
					if (bubbleEndShowTime <= bubbleEndShowTime2)
					{
						return -1;
					}
					return 1;
				}
			}
			if (a.Sort != b.Sort)
			{
				return a.Sort - b.Sort;
			}
			if (a.BeginOpenTime == b.BeginOpenTime)
			{
				return a.Id - b.Id;
			}
			if (a.BeginOpenTime <= b.BeginOpenTime)
			{
				return -1;
			}
			return 1;
		}
	}

	// Token: 0x0600A56A RID: 42346 RVA: 0x002BBBD2 File Offset: 0x002B9DD2
	public bool GetActivityRedDotState(int activityId)
	{
		ActivityBaseData activityById = this.GetActivityById(activityId);
		return activityById != null && activityById.RedPointShowState;
	}

	// Token: 0x0600A56B RID: 42347 RVA: 0x002BBBE6 File Offset: 0x002B9DE6
	public int GetActivityPermanentFilterId()
	{
		return this.ActivityPermanentFilterId;
	}

	// Token: 0x0600A56C RID: 42348 RVA: 0x002BBBEE File Offset: 0x002B9DEE
	public void SetActivityPermanentFilterId(int value)
	{
		this.ActivityPermanentFilterId = value;
	}

	// Token: 0x0600A56D RID: 42349 RVA: 0x002BBBF8 File Offset: 0x002B9DF8
	public void SendActivityViewOpenLogData(EActivityViewOpenType openType)
	{
		ActivityViewOpenLogData activityViewOpenLogData = new ActivityViewOpenLogData();
		activityViewOpenLogData.i_open_way = (int)openType;
		ControllerBase<LogReportController>.Instance.LogReport(activityViewOpenLogData);
	}

	// Token: 0x0600A56E RID: 42350 RVA: 0x002BBC20 File Offset: 0x002B9E20
	public void SendActivityTabViewOpenLogData(ActivityBaseData openData)
	{
		ActivityTabViewOpenLogData activityTabViewOpenLogData = new ActivityTabViewOpenLogData();
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double a = (openData.EndOpenTime == 0L) ? 0.0 : ((double)((int)openData.EndOpenTime) - serverTime);
		activityTabViewOpenLogData.i_activity_id = openData.Id;
		activityTabViewOpenLogData.i_activity_type = (int)openData.Type;
		activityTabViewOpenLogData.i_time_left = (int)Math.Round(a);
		activityTabViewOpenLogData.i_unlock = ((openData.IsUnLock() > false) ? 1 : 0);
		if (openData.TimeType == EActivityTimeType.Permanent)
		{
			activityTabViewOpenLogData.i_type = 3;
		}
		else
		{
			Activity? activityConfig = ConfigBase<ActivityConfig>.Instance.GetActivityConfig(openData.Id);
			if (activityConfig != null && activityConfig.GetValueOrDefault().FilterTabType == 1)
			{
				activityTabViewOpenLogData.i_type = 1;
			}
			else if (activityConfig != null && activityConfig.GetValueOrDefault().FilterTabType == 3)
			{
				activityTabViewOpenLogData.i_type = 2;
			}
		}
		if (activityTabViewOpenLogData.i_type == 0)
		{
			Singleton<Log>.Instance.Warn(ELogModule.Activity, ELogAuthor.LZK, "[活动埋点] 活动类型未定义，埋点记录为0. 活动Id: " + openData.Id.ToString(), default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		ControllerBase<LogReportController>.Instance.LogReport(activityTabViewOpenLogData);
	}

	// Token: 0x0600A56F RID: 42351 RVA: 0x002BBD4C File Offset: 0x002B9F4C
	public void SendActivityViewJumpClickLogData(ActivityBaseData openData)
	{
		ActivityViewJumpClickLogData activityViewJumpClickLogData = new ActivityViewJumpClickLogData();
		activityViewJumpClickLogData.i_activity_id = openData.Id;
		activityViewJumpClickLogData.i_activity_type = (int)openData.Type;
		activityViewJumpClickLogData.i_unlock = ((openData.IsUnLock() > false) ? 1 : 0);
		ControllerBase<LogReportController>.Instance.LogReport(activityViewJumpClickLogData);
	}

	// Token: 0x0600A570 RID: 42352 RVA: 0x002BBD94 File Offset: 0x002B9F94
	public void SendActivityLockConditionLogData(ActivityBaseData openData)
	{
		ActivityLockConditionClickLogData activityLockConditionClickLogData = new ActivityLockConditionClickLogData();
		activityLockConditionClickLogData.i_activity_id = openData.Id;
		activityLockConditionClickLogData.i_activity_type = (int)openData.Type;
		ControllerBase<LogReportController>.Instance.LogReport(activityLockConditionClickLogData);
	}

	// Token: 0x0600A571 RID: 42353 RVA: 0x002BBDCC File Offset: 0x002B9FCC
	public void SendActivityFinishSinkLogData(ActivityBaseData activityData)
	{
		ActivityFinishSinkLogData activityFinishSinkLogData = new ActivityFinishSinkLogData();
		activityFinishSinkLogData.i_activity_id = activityData.Id;
		ControllerBase<LogReportController>.Instance.LogReport(activityFinishSinkLogData);
	}

	// Token: 0x0600A572 RID: 42354 RVA: 0x002BBDF8 File Offset: 0x002B9FF8
	public void SendActivityGotoClickLogData(int activityId, int type, int scene)
	{
		ActivityGotoClickLogData activityGotoClickLogData = new ActivityGotoClickLogData();
		activityGotoClickLogData.i_activity_id = activityId;
		activityGotoClickLogData.i_type = type;
		activityGotoClickLogData.i_scene = scene;
		ControllerBase<LogReportController>.Instance.LogReport(activityGotoClickLogData);
	}

	// Token: 0x0600A573 RID: 42355 RVA: 0x002BBE2C File Offset: 0x002BA02C
	private void InitActivityLevelFuncMap()
	{
		IActivityLevelFunc value = new IActivityLevelFunc
		{
			CheckIsActivityLevel = new Func<int, bool>(ControllerBase<ActivityMowingController>.Instance.CheckIsActivityLevel),
			GetLevelRecommendLevel = new Func<int, int, int>(ControllerBase<ActivityMowingController>.Instance.GetRecommendLevel)
		};
		this.ActivityLevelFuncMap[9] = value;
	}

	// Token: 0x0600A574 RID: 42356 RVA: 0x002BBE7C File Offset: 0x002BA07C
	public bool GetActivityLevelUnlockState(int type, int levelId)
	{
		IActivityControllerBase activityController = ActivityManager.GetActivityController(type);
		return activityController == null || activityController.GetActivityLevelUnlockState(levelId);
	}

	// Token: 0x0600A575 RID: 42357 RVA: 0x002BBE9C File Offset: 0x002BA09C
	public int GetActivityLevelRecommendLevel(int instanceId, int worldLevel, int activityType)
	{
		IActivityLevelFunc activityLevelFunc;
		if (this.ActivityLevelFuncMap.TryGetValue(activityType, out activityLevelFunc))
		{
			return activityLevelFunc.GetLevelRecommendLevel(instanceId, worldLevel);
		}
		return 0;
	}

	// Token: 0x0600A576 RID: 42358 RVA: 0x002BBEC8 File Offset: 0x002BA0C8
	[NullableContext(0)]
	public ValueTuple<bool, int> CheckActivityLevelBelongToType(int instanceId)
	{
		foreach (KeyValuePair<int, IActivityLevelFunc> keyValuePair in this.ActivityLevelFuncMap)
		{
			int key = keyValuePair.Key;
			bool flag = keyValuePair.Value.CheckIsActivityLevel(instanceId);
			if (flag)
			{
				return new ValueTuple<bool, int>(flag, key);
			}
		}
		return new ValueTuple<bool, int>(false, 0);
	}

	// Token: 0x0600A577 RID: 42359 RVA: 0x002BBF48 File Offset: 0x002BA148
	public bool GetActivityMapMarkState(int type, int markId)
	{
		IActivityControllerBase activityController = ActivityManager.GetActivityController(type);
		return activityController != null && activityController.GetActivityMapMarkState(markId);
	}

	// Token: 0x0600A578 RID: 42360 RVA: 0x002BBF68 File Offset: 0x002BA168
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, string, long> GetTimeVisibleAndRemainTime(ActivityBaseData activityData, [Nullable(2)] string formationTimeText = null)
	{
		bool flag = activityData.CheckIfInShowTime();
		bool flag2 = activityData.CheckIfInOpenTime();
		if (!flag2 && !flag)
		{
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<TextConfig>.Instance.GetTextContentIdById("ActiveClose"), null);
			return new ValueTuple<bool, string, long>(false, localTextNew, -1L);
		}
		long endOpenTime = activityData.EndOpenTime;
		long endShowTime = activityData.EndShowTime;
		long endLimitTime = activityData.EndLimitTime;
		string text = "";
		bool flag3 = true;
		long num = 0L;
		Activity? localConfig = activityData.LocalConfig;
		int num2 = (localConfig != null) ? localConfig.Value.TimeIsDisplay : 0;
		if (localConfig != null && localConfig.GetValueOrDefault().OpenType == 2)
		{
			bool flag4 = activityData.CheckIfInLimitTime();
			flag3 = (flag && flag4);
			if (flag3)
			{
				if (num2 == 1)
				{
					num = 0L;
					text = this.ActivityForeverTimeText;
				}
				else if (num2 == 0)
				{
					num = endLimitTime;
					text = this.ActivityRemainingTimeReward;
				}
			}
		}
		else if (localConfig != null && localConfig.GetValueOrDefault().OpenType == 1)
		{
			flag3 = (num2 == 1);
			text = this.ActivityForeverTimeText;
		}
		else if (localConfig != null && localConfig.GetValueOrDefault().OpenType == 0)
		{
			if (endOpenTime != 0L && endShowTime != 0L)
			{
				flag3 = true;
				num = (flag2 ? endOpenTime : endShowTime);
				text = (flag2 ? this.ActivityRemainTimeText : this.ActivityCdTimeText);
			}
			if (endOpenTime == 0L && endShowTime != 0L)
			{
				flag3 = true;
				num = endShowTime;
				text = this.ActivityCdTimeText;
			}
			if (endOpenTime == 0L && endShowTime == 0L)
			{
				flag3 = (num2 == 1);
				text = this.ActivityForeverTimeText;
			}
		}
		if (flag3 && num > 0L)
		{
			text = (this.GetRemainTimeText(num, formationTimeText ?? text) ?? "");
		}
		return new ValueTuple<bool, string, long>(flag3, text, num);
	}

	// Token: 0x0600A579 RID: 42361 RVA: 0x002BC12C File Offset: 0x002BA32C
	public string GetRemainTimeText(long endTime, string text)
	{
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		double num = Math.Max((double)endTime - serverTime, 1.0);
		ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> timeTypeData = this.GetTimeTypeData((long)num);
		string text2 = Singleton<TimeUtil>.Instance.GetCountDownDataFormat2(num, new CommonDefine.ETimeType?(timeTypeData.Item1), new CommonDefine.ETimeType?(timeTypeData.Item2)).CountDownText ?? "";
		return StringUtils.Format(text, new string[]
		{
			text2
		});
	}

	// Token: 0x0600A57A RID: 42362 RVA: 0x002BC1A0 File Offset: 0x002BA3A0
	[NullableContext(0)]
	private ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType> GetTimeTypeData(long remainTime)
	{
		if (remainTime > 86400L)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Day, CommonDefine.ETimeType.Hour);
		}
		if (remainTime > 3600L)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Hour, CommonDefine.ETimeType.Minute);
		}
		if (remainTime > 60L)
		{
			return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Minute, CommonDefine.ETimeType.Second);
		}
		return new ValueTuple<CommonDefine.ETimeType, CommonDefine.ETimeType>(CommonDefine.ETimeType.Second, CommonDefine.ETimeType.Second);
	}

	// Token: 0x0600A57B RID: 42363 RVA: 0x002BC1DC File Offset: 0x002BA3DC
	public List<IActivityConditionData> GetActivityConditionData(ActivityBaseData activityData)
	{
		List<IActivityConditionData> list = new List<IActivityConditionData>();
		int conditionGroupId;
		if (activityData.HasPreOpenCondition())
		{
			conditionGroupId = activityData.PreOpenConditionGroupId;
		}
		else
		{
			conditionGroupId = activityData.ConditionGroupId;
		}
		foreach (int conditionId in ConfigBase<ConditionConfig>.Instance.GetGroupConditionIds(conditionGroupId))
		{
			Condition? conditionConfig = ConfigBase<ConditionConfig>.Instance.GetConditionConfig(conditionId);
			int accessType = -1;
			if (conditionConfig.Value.AccessId != 0)
			{
				accessType = ConfigBase<GetWayConfig>.Instance.GetConfigById(conditionConfig.Value.AccessId).Value.SkipName;
			}
			ActivityConditionData item = new ActivityConditionData
			{
				ConditionId = conditionId,
				ConditionTextId = conditionConfig.Value.Description,
				IsFinished = activityData.IsActivityConditionFinished(conditionId),
				AccessId = conditionConfig.Value.AccessId,
				AccessType = accessType
			};
			list.Add(item);
		}
		list.Sort(new Comparison<IActivityConditionData>(this.SortConditionData));
		return list;
	}

	// Token: 0x0600A57C RID: 42364 RVA: 0x002BC2EC File Offset: 0x002BA4EC
	private int SortConditionData(IActivityConditionData a, IActivityConditionData b)
	{
		int num = (a.IsFinished > false) ? 1 : 0;
		int num2 = (b.IsFinished > false) ? 1 : 0;
		if (num != num2)
		{
			return num - num2;
		}
		int[] array = new int[]
		{
			a.AccessType,
			b.AccessType
		};
		int[] array2 = new int[2];
		for (int i = 0; i < array.Length; i++)
		{
			int num3 = 2;
			int num4 = array[i];
			if (num4 != 7)
			{
				if (num4 == 16)
				{
					num3 = 1;
				}
			}
			else
			{
				num3 = 0;
			}
			array2[i] = num3;
		}
		return array2[0] - array2[1];
	}

	// Token: 0x0600A57D RID: 42365 RVA: 0x002BC372 File Offset: 0x002BA572
	public bool CheckBubbleHasClicked(int activityId, EActivityBubbleType bubbleType)
	{
		return this.GetActivityCacheData(activityId, 0, 1011, (int)bubbleType, 0) == 1;
	}

	// Token: 0x0600A57E RID: 42366 RVA: 0x002BC386 File Offset: 0x002BA586
	public void SetBubbleHasClicked(int activityId, EActivityBubbleType bubbleType)
	{
		this.SaveActivityData(activityId, 1011, (int)bubbleType, 0, 1);
	}

	// Token: 0x0600A57F RID: 42367 RVA: 0x002BC397 File Offset: 0x002BA597
	[NullableContext(2)]
	private bool IsInTimeInterval(int[] interval, int numberDay)
	{
		return interval != null && interval.Length >= 1 && numberDay >= interval[0] && numberDay < interval[1];
	}

	// Token: 0x0600A580 RID: 42368 RVA: 0x002BC3B0 File Offset: 0x002BA5B0
	public EActivityBubbleType GetBubbleTypeByTimeInterval(ActivityTimeShow timeShowConfig, int numberDay)
	{
		if (this.IsInTimeInterval(timeShowConfig.WhiteInterval(), numberDay))
		{
			return EActivityBubbleType.Normal;
		}
		if (this.IsInTimeInterval(timeShowConfig.YellowInterval(), numberDay))
		{
			return EActivityBubbleType.Remind;
		}
		if (this.IsInTimeInterval(timeShowConfig.RedInterval(), numberDay))
		{
			return EActivityBubbleType.Important;
		}
		return EActivityBubbleType.None;
	}

	// Token: 0x0600A581 RID: 42369 RVA: 0x002BC3E9 File Offset: 0x002BA5E9
	public void SetForceHideActivityTimeTextFlag(bool bVisible)
	{
		this.ForceHideActivityTimeTextFlag = bVisible;
	}

	// Token: 0x0600A582 RID: 42370 RVA: 0x002BC3F2 File Offset: 0x002BA5F2
	public bool GetForceHideActivityTimeTextFlag()
	{
		return Singleton<Info>.Instance.IsBuildDevelopmentOrDebug && this.ForceHideActivityTimeTextFlag;
	}

	// Token: 0x0600A583 RID: 42371 RVA: 0x002BC408 File Offset: 0x002BA608
	[NullableContext(2)]
	public void SetDebugFilterMode(bool bFilterOn, List<int> filterActivityIdList = null)
	{
		this.DebugFilterMode = bFilterOn;
		if (filterActivityIdList != null)
		{
			this.DebugFilterShowActivityIds = filterActivityIdList;
		}
		foreach (ActivityBaseData activityBaseData in this.CurrentShowingActivitiesMap.Values)
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, activityBaseData.Id);
		}
	}

	// Token: 0x0600A584 RID: 42372 RVA: 0x002BC480 File Offset: 0x002BA680
	public void OpenActivityErrorConfirmBox(int activityId, int type)
	{
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.ErrorCodeTips);
		string text = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("ActivityErrorTips", null) ?? "", new string[]
		{
			activityId.ToString(),
			type.ToString()
		});
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			text
		});
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x0600A585 RID: 42373 RVA: 0x002BC4E5 File Offset: 0x002BA6E5
	public void SetDebugPermanentFilterVisible(bool bFilterOn)
	{
		this.DebugPermanentFilterVisible = bFilterOn;
	}

	// Token: 0x0600A586 RID: 42374 RVA: 0x002BC4EE File Offset: 0x002BA6EE
	public bool GetDebugPermanentFilterVisible()
	{
		return this.DebugPermanentFilterVisible;
	}

	// Token: 0x04004E76 RID: 20086
	private readonly Dictionary<int, ActivityBaseData> ActivityMap = new Dictionary<int, ActivityBaseData>();

	// Token: 0x04004E77 RID: 20087
	private readonly List<int> CurrentActivityIds = new List<int>();

	// Token: 0x04004E78 RID: 20088
	private readonly ActivityCache ActivityCache = new ActivityCache();

	// Token: 0x04004E79 RID: 20089
	private readonly HashSet<long> ActivityTimeStampSet = new HashSet<long>();

	// Token: 0x04004E7A RID: 20090
	private readonly Dictionary<long, TimerHandle> ActivityTimeStampHandleMap = new Dictionary<long, TimerHandle>();

	// Token: 0x04004E7B RID: 20091
	private string ActivityForeverTimeText = "";

	// Token: 0x04004E7C RID: 20092
	private string ActivityCloseText = "";

	// Token: 0x04004E7D RID: 20093
	private string ActivityCdTimeText = "";

	// Token: 0x04004E7E RID: 20094
	private string ActivityRemainTimeText = "";

	// Token: 0x04004E7F RID: 20095
	private string ActivityRemainingTimeReward = "";

	// Token: 0x04004E80 RID: 20096
	private int ActivityPermanentFilterId = 999;

	// Token: 0x04004E81 RID: 20097
	private bool DebugPermanentFilterVisible;

	// Token: 0x04004E82 RID: 20098
	private readonly Dictionary<int, ActivityBaseData> CurrentShowingActivitiesMap = new Dictionary<int, ActivityBaseData>();

	// Token: 0x04004E83 RID: 20099
	private readonly HashSet<int> CurrentRemoveActivities = new HashSet<int>();

	// Token: 0x04004E84 RID: 20100
	private readonly HashSet<int> CurrentAddActivities = new HashSet<int>();

	// Token: 0x04004E85 RID: 20101
	private readonly Dictionary<int, IActivityLevelFunc> ActivityLevelFuncMap = new Dictionary<int, IActivityLevelFunc>();

	// Token: 0x04004E86 RID: 20102
	private bool ForceHideActivityTimeTextFlag;

	// Token: 0x04004E87 RID: 20103
	private bool DebugFilterMode;

	// Token: 0x04004E88 RID: 20104
	private List<int> DebugFilterShowActivityIds = new List<int>();

	// Token: 0x02007A7E RID: 31358
	[CompilerGenerated]
	private static class <SortActivityList>O__48_0<T> where T : ActivityBaseData
	{
		// Token: 0x04029F7F RID: 171903
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public static Comparison<T> <0>__SortFunc;
	}
}
