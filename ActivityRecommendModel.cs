using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x02001152 RID: 4434
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ActivityRecommendModel : ModelBase<ActivityRecommendModel>
{
	// Token: 0x060074D0 RID: 29904 RVA: 0x001EA1BC File Offset: 0x001E83BC
	protected override bool OnInit()
	{
		ActivityRecommendConfig instance = ConfigBase<ActivityRecommendConfig>.Instance;
		this.CurrentGroupId = ((instance != null) ? instance.GetCurrentGroupId() : 0);
		this.LatestBranch = ConfigCommonParamById.GetIntConfig("LatestBranch").GetValueOrDefault();
		this.BranchOneMainLineQuestList = (ConfigCommonParamById.GetIntArrayConfig("BranchOneMainQuest") ?? new List<int>());
		this.BranchTwoMainLineQuestList = (ConfigCommonParamById.GetIntArrayConfig("BranchTwoMainQuest") ?? new List<int>());
		this.BranchThreeMainLineQuestList = (ConfigCommonParamById.GetIntArrayConfig("BranchThreeMainQuest") ?? new List<int>());
		return true;
	}

	// Token: 0x060074D1 RID: 29905 RVA: 0x001EA244 File Offset: 0x001E8444
	protected override bool OnClear()
	{
		this.CurrentGroupId = 0;
		this.LatestBranch = 0;
		this.BranchOneMainLineQuestList = new List<int>();
		this.BranchTwoMainLineQuestList = new List<int>();
		this.BranchThreeMainLineQuestList = new List<int>();
		this.RecommendFallbackMap.Clear();
		return true;
	}

	// Token: 0x060074D2 RID: 29906 RVA: 0x001EA284 File Offset: 0x001E8484
	public void SetRecommendFallback(IReadOnlyList<ActivityRecommendOnePb> list)
	{
		this.RecommendFallbackMap.Clear();
		foreach (ActivityRecommendOnePb activityRecommendOnePb in list)
		{
			int activityId = activityRecommendOnePb.ActivityId;
			if (activityId != 0)
			{
				this.RecommendFallbackMap[activityId] = new ActivityRecommendModel.RecommendFallbackData
				{
					BeginShowTime = activityRecommendOnePb.BeginShowTime,
					BeginOpenTime = activityRecommendOnePb.BeginOpenTime
				};
			}
		}
	}

	// Token: 0x060074D3 RID: 29907 RVA: 0x001EA30C File Offset: 0x001E850C
	public bool IsPeriodActivity(int activityId)
	{
		ActivityModel instance = ModelBase<ActivityModel>.Instance;
		ActivityBaseData activityBaseData = (instance != null) ? instance.GetActivityById(activityId) : null;
		int? num = (activityBaseData != null) ? ((activityBaseData.LocalConfig != null) ? new int?(activityBaseData.LocalConfig.GetValueOrDefault().FilterTabType) : null) : null;
		int valueOrDefault;
		if (num == null)
		{
			ActivityConfig instance2 = ConfigBase<ActivityConfig>.Instance;
			Activity? activity;
			valueOrDefault = ((instance2 != null) ? ((instance2.GetActivityConfig(activityId) != null) ? new int?(activity.GetValueOrDefault().FilterTabType) : null) : null).GetValueOrDefault();
		}
		else
		{
			valueOrDefault = num.GetValueOrDefault();
		}
		return valueOrDefault == 3;
	}

	// Token: 0x060074D4 RID: 29908 RVA: 0x001EA3C8 File Offset: 0x001E85C8
	public long? GetActivityPreOpenTime(int activityId)
	{
		ActivityModel instance = ModelBase<ActivityModel>.Instance;
		if (((instance != null) ? instance.GetActivityById(activityId) : null) != null)
		{
			return null;
		}
		ActivityRecommendModel.RecommendFallbackData recommendFallbackData;
		if (!this.RecommendFallbackMap.TryGetValue(activityId, out recommendFallbackData))
		{
			return null;
		}
		if ((double)recommendFallbackData.BeginShowTime <= Singleton<TimeUtil>.Instance.GetServerTime())
		{
			return null;
		}
		return new long?(recommendFallbackData.BeginOpenTime);
	}

	// Token: 0x060074D5 RID: 29909 RVA: 0x001EA438 File Offset: 0x001E8638
	public List<int> GetRecommendDataList()
	{
		ActivityRecommendConfig instance = ConfigBase<ActivityRecommendConfig>.Instance;
		if (instance == null)
		{
			return new List<int>();
		}
		IEnumerable<ActivityRecommend> recommendListByGroup = instance.GetRecommendListByGroup(this.CurrentGroupId);
		ActivityRecommendModel.RecommendBuckets recommendBuckets = new ActivityRecommendModel.RecommendBuckets();
		foreach (ActivityRecommend recommend in recommendListByGroup)
		{
			this.ClassifyRecommend(recommend, recommendBuckets);
		}
		List<ActivityRecommend> activityCurrentUnFinishedList = recommendBuckets.ActivityCurrentUnFinishedList;
		List<ActivityRecommend> dailyUnFinishedList = recommendBuckets.DailyUnFinishedList;
		List<ActivityRecommend> weeklyUnFinishedList = recommendBuckets.WeeklyUnFinishedList;
		List<ActivityRecommend> periodUnFinishedList = recommendBuckets.PeriodUnFinishedList;
		List<ActivityRecommend> activityCurrentFinishedList = recommendBuckets.ActivityCurrentFinishedList;
		List<ActivityRecommend> dailyFinishedList = recommendBuckets.DailyFinishedList;
		List<ActivityRecommend> weeklyFinishedList = recommendBuckets.WeeklyFinishedList;
		List<ActivityRecommend> periodFinishedList = recommendBuckets.PeriodFinishedList;
		List<ActivityRecommendModel.PreOpenItem> preOpenList = recommendBuckets.PreOpenList;
		activityCurrentUnFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		dailyUnFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		weeklyUnFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		periodUnFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		activityCurrentFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		dailyFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		weeklyFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		periodFinishedList.Sort((ActivityRecommend a, ActivityRecommend b) => a.Sort - b.Sort);
		preOpenList.Sort(delegate(ActivityRecommendModel.PreOpenItem a, ActivityRecommendModel.PreOpenItem b)
		{
			if (a.PreOpenTime != b.PreOpenTime)
			{
				return a.PreOpenTime.CompareTo(b.PreOpenTime);
			}
			return a.Sort - b.Sort;
		});
		List<int> list = new List<int>();
		foreach (ActivityRecommend activityRecommend in activityCurrentUnFinishedList)
		{
			list.Add(activityRecommend.Id);
		}
		foreach (ActivityRecommend activityRecommend2 in dailyUnFinishedList)
		{
			list.Add(activityRecommend2.Id);
		}
		foreach (ActivityRecommend activityRecommend3 in weeklyUnFinishedList)
		{
			list.Add(activityRecommend3.Id);
		}
		foreach (ActivityRecommend activityRecommend4 in periodUnFinishedList)
		{
			list.Add(activityRecommend4.Id);
		}
		List<ActivityRecommend> list2 = new List<ActivityRecommend>(instance.GetRecommendByType(EActivityRecommendType.Area));
		list2.Sort(delegate(ActivityRecommend a, ActivityRecommend b)
		{
			if (a.Sort != b.Sort)
			{
				return a.Sort - b.Sort;
			}
			ExploreAreaData exploreAreaData2 = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(a.JumpParam);
			ExploreAreaData exploreAreaData3 = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(b.JumpParam);
			return ((exploreAreaData2 != null) ? exploreAreaData2.GetProgress() : 0) - ((exploreAreaData3 != null) ? exploreAreaData3.GetProgress() : 0);
		});
		ActivityRecommend? activityRecommend5 = null;
		foreach (ActivityRecommend value in list2)
		{
			ExploreAreaData exploreAreaData = ModelBase<ExploreProgressModel>.Instance.GetExploreAreaData(value.JumpParam);
			if (exploreAreaData == null || !exploreAreaData.IsReachMaxProgress)
			{
				activityRecommend5 = new ActivityRecommend?(value);
				break;
			}
		}
		if (activityRecommend5 != null)
		{
			list.Add(activityRecommend5.Value.Id);
		}
		foreach (ActivityRecommendModel.PreOpenItem preOpenItem in preOpenList)
		{
			list.Add(preOpenItem.Id);
		}
		foreach (ActivityRecommend activityRecommend6 in activityCurrentFinishedList)
		{
			list.Add(activityRecommend6.Id);
		}
		foreach (ActivityRecommend activityRecommend7 in dailyFinishedList)
		{
			list.Add(activityRecommend7.Id);
		}
		foreach (ActivityRecommend activityRecommend8 in weeklyFinishedList)
		{
			list.Add(activityRecommend8.Id);
		}
		foreach (ActivityRecommend activityRecommend9 in periodFinishedList)
		{
			list.Add(activityRecommend9.Id);
		}
		return list;
	}

	// Token: 0x060074D6 RID: 29910 RVA: 0x001EA980 File Offset: 0x001E8B80
	private void ClassifyRecommend(ActivityRecommend recommend, ActivityRecommendModel.RecommendBuckets buckets)
	{
		switch (recommend.Type)
		{
		case 2:
		case 3:
			this.ClassifyActivity(recommend, buckets);
			break;
		case 4:
			break;
		case 5:
			this.ClassifyDailyActivity(recommend, buckets);
			return;
		case 6:
			this.ClassifyWeeklyChallenge(recommend, buckets);
			return;
		default:
			return;
		}
	}

	// Token: 0x060074D7 RID: 29911 RVA: 0x001EA9CC File Offset: 0x001E8BCC
	private void ClassifyDailyActivity(ActivityRecommend recommend, ActivityRecommendModel.RecommendBuckets buckets)
	{
		if (!ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.DailyActivity))
		{
			return;
		}
		DailyActivityModel instance = ModelBase<DailyActivityModel>.Instance;
		((instance != null && instance.CheckIsFinish()) ? buckets.DailyFinishedList : buckets.DailyUnFinishedList).Add(recommend);
	}

	// Token: 0x060074D8 RID: 29912 RVA: 0x001EAA08 File Offset: 0x001E8C08
	private void ClassifyWeeklyChallenge(ActivityRecommend recommend, ActivityRecommendModel.RecommendBuckets buckets)
	{
		bool flag = ModelBase<FunctionModel>.Instance.IsOpen(EFunctionType.WeeklyChallenge);
		WeeklyChallengeModel instance = ModelBase<WeeklyChallengeModel>.Instance;
		int num = (instance != null) ? instance.WeeklyConfigId : 0;
		if (!flag || num == 0)
		{
			return;
		}
		WeeklyChallengeModel instance2 = ModelBase<WeeklyChallengeModel>.Instance;
		((instance2 != null && instance2.CheckIsFinish()) ? buckets.WeeklyFinishedList : buckets.WeeklyUnFinishedList).Add(recommend);
	}

	// Token: 0x060074D9 RID: 29913 RVA: 0x001EAA64 File Offset: 0x001E8C64
	private void ClassifyActivity(ActivityRecommend recommend, ActivityRecommendModel.RecommendBuckets buckets)
	{
		ActivityBaseData activityById = ModelBase<ActivityModel>.Instance.GetActivityById(recommend.JumpParam);
		if (activityById == null || !activityById.CheckIfInShowTime())
		{
			long? activityPreOpenTime = this.GetActivityPreOpenTime(recommend.JumpParam);
			if (activityPreOpenTime != null)
			{
				buckets.PreOpenList.Add(new ActivityRecommendModel.PreOpenItem
				{
					Id = recommend.Id,
					Sort = recommend.Sort,
					PreOpenTime = activityPreOpenTime.Value
				});
			}
			return;
		}
		bool finishShowState = activityById.FinishShowState;
		if (this.IsPeriodActivity(recommend.JumpParam))
		{
			(finishShowState ? buckets.PeriodFinishedList : buckets.PeriodUnFinishedList).Add(recommend);
			return;
		}
		(finishShowState ? buckets.ActivityCurrentFinishedList : buckets.ActivityCurrentUnFinishedList).Add(recommend);
	}

	// Token: 0x060074DA RID: 29914 RVA: 0x001EAB2C File Offset: 0x001E8D2C
	public int GetCurrentMainLineQuest()
	{
		List<global::Quest> questsByType = ModelBase<QuestNewModel>.Instance.GetQuestsByType(1);
		if (questsByType.Count > 0)
		{
			int result = 0;
			int num = 0;
			int num2 = 0;
			foreach (global::Quest quest in questsByType)
			{
				bool flag = this.BranchOneMainLineQuestList.Contains(quest.Id);
				bool flag2 = this.BranchTwoMainLineQuestList.Contains(quest.Id);
				bool flag3 = this.BranchThreeMainLineQuestList.Contains(quest.Id);
				if (!flag && !flag2 && !flag3)
				{
					return quest.Id;
				}
				if (flag3)
				{
					num2 = quest.Id;
				}
				if (flag2)
				{
					num = quest.Id;
				}
				if (flag)
				{
					result = quest.Id;
				}
			}
			if (num2 > 0)
			{
				return num2;
			}
			if (num > 0)
			{
				return num;
			}
			return result;
		}
		return 0;
	}

	// Token: 0x060074DB RID: 29915 RVA: 0x001EAC24 File Offset: 0x001E8E24
	public ERegressBranchNumber GetCurrentMainLineBranch()
	{
		List<global::Quest> questsByType = ModelBase<QuestNewModel>.Instance.GetQuestsByType(1);
		if (questsByType.Count > 0)
		{
			List<int> list = new List<int>();
			foreach (global::Quest quest in questsByType)
			{
				list.Add(quest.Id);
			}
			return this.GetBranchByQuestIds(list);
		}
		return this.GetBranchByQuestIds(ModelBase<QuestNewModel>.Instance.FinishedMainQuests);
	}

	// Token: 0x060074DC RID: 29916 RVA: 0x001EACAC File Offset: 0x001E8EAC
	private ERegressBranchNumber GetBranchByQuestIds(IReadOnlyList<int> questIds)
	{
		ERegressBranchNumber eregressBranchNumber = ERegressBranchNumber.BranchOne;
		foreach (int value in questIds)
		{
			if (!this.BranchOneMainLineQuestList.Contains(value))
			{
				if (this.BranchTwoMainLineQuestList.Contains(value))
				{
					if (eregressBranchNumber < ERegressBranchNumber.BranchTwo)
					{
						eregressBranchNumber = ERegressBranchNumber.BranchTwo;
					}
				}
				else
				{
					if (!this.BranchThreeMainLineQuestList.Contains(value))
					{
						return (ERegressBranchNumber)this.LatestBranch;
					}
					if (eregressBranchNumber < ERegressBranchNumber.BranchThree)
					{
						eregressBranchNumber = ERegressBranchNumber.BranchThree;
					}
				}
			}
		}
		return eregressBranchNumber;
	}

	// Token: 0x060074DD RID: 29917 RVA: 0x001EAD38 File Offset: 0x001E8F38
	public List<TItem> GetDropPreviewRewardItemListForPreview(int dropId)
	{
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId);
		List<TItem> list = new List<TItem>();
		Dictionary<int, int> dictionary = (dropPackage != null) ? dropPackage.GetValueOrDefault().DropPreview() : null;
		if (dictionary != null && dictionary.Count > 0)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dictionary)
			{
				list.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
			}
			return list;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.ActivityRegress;
		ELogAuthor author = ELogAuthor.TZJ;
		string message = "活动推荐->掉落包预览道具不存在";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("dropId", dropId);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return list;
	}

	// Token: 0x060074DE RID: 29918 RVA: 0x001EAE10 File Offset: 0x001E9010
	public bool IsEntryFirstClickRedDotShow()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ActivityRecommend) as ServerStorageBoolean;
		return !((serverStorageBoolean != null) ? serverStorageBoolean.Get() : null).GetValueOrDefault();
	}

	// Token: 0x060074DF RID: 29919 RVA: 0x001EAE50 File Offset: 0x001E9050
	public void MarkEntryFirstClickRead()
	{
		ServerStorageBoolean serverStorageBoolean = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.ActivityRecommend) as ServerStorageBoolean;
		if (serverStorageBoolean != null && serverStorageBoolean.Get().GetValueOrDefault())
		{
			return;
		}
		if (serverStorageBoolean != null)
		{
			serverStorageBoolean.Set(new bool?(true));
		}
	}

	// Token: 0x0400386C RID: 14444
	private const int PERIOD_FILTER_TAB_TYPE = 3;

	// Token: 0x0400386D RID: 14445
	public int CurrentGroupId;

	// Token: 0x0400386E RID: 14446
	public int LatestBranch;

	// Token: 0x0400386F RID: 14447
	private IReadOnlyList<int> BranchOneMainLineQuestList = new List<int>();

	// Token: 0x04003870 RID: 14448
	private IReadOnlyList<int> BranchTwoMainLineQuestList = new List<int>();

	// Token: 0x04003871 RID: 14449
	private IReadOnlyList<int> BranchThreeMainLineQuestList = new List<int>();

	// Token: 0x04003872 RID: 14450
	private readonly Dictionary<int, ActivityRecommendModel.RecommendFallbackData> RecommendFallbackMap = new Dictionary<int, ActivityRecommendModel.RecommendFallbackData>();

	// Token: 0x020074D8 RID: 29912
	[NullableContext(0)]
	private struct RecommendFallbackData
	{
		// Token: 0x0402856D RID: 165229
		public long BeginShowTime;

		// Token: 0x0402856E RID: 165230
		public long BeginOpenTime;
	}

	// Token: 0x020074D9 RID: 29913
	[NullableContext(0)]
	private struct PreOpenItem
	{
		// Token: 0x0402856F RID: 165231
		public int Id;

		// Token: 0x04028570 RID: 165232
		public int Sort;

		// Token: 0x04028571 RID: 165233
		public long PreOpenTime;
	}

	// Token: 0x020074DA RID: 29914
	[Nullable(0)]
	private class RecommendBuckets
	{
		// Token: 0x04028572 RID: 165234
		public readonly List<ActivityRecommend> ActivityCurrentUnFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028573 RID: 165235
		public readonly List<ActivityRecommend> DailyUnFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028574 RID: 165236
		public readonly List<ActivityRecommend> WeeklyUnFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028575 RID: 165237
		public readonly List<ActivityRecommend> PeriodUnFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028576 RID: 165238
		public readonly List<ActivityRecommend> ActivityCurrentFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028577 RID: 165239
		public readonly List<ActivityRecommend> DailyFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028578 RID: 165240
		public readonly List<ActivityRecommend> WeeklyFinishedList = new List<ActivityRecommend>();

		// Token: 0x04028579 RID: 165241
		public readonly List<ActivityRecommend> PeriodFinishedList = new List<ActivityRecommend>();

		// Token: 0x0402857A RID: 165242
		public readonly List<ActivityRecommendModel.PreOpenItem> PreOpenList = new List<ActivityRecommendModel.PreOpenItem>();
	}
}
