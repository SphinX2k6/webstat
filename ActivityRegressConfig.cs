using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Launcher.NetworkDetection;

// Token: 0x02001500 RID: 5376
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class ActivityRegressConfig : ConfigBase<ActivityRegressConfig>
{
	// Token: 0x06009673 RID: 38515 RVA: 0x00275824 File Offset: 0x00273A24
	public unsafe IReadOnlyList<RegressSignReward> GetRegressSignRewards(int activityId, ERegressGrade grade)
	{
		IReadOnlyList<RegressSignReward> configList = ConfigRegressSignRewardByGradeAndActivityId.GetConfigList((int)grade, activityId, true);
		if (configList == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回归活动->获取回流签到奖励配置失败,请检查配置表RegressSignReward";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("activityId:", activityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("grade:", grade);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		List<RegressSignReward> list = new List<RegressSignReward>();
		IReadOnlyList<RegressSignReward> readOnlyList = configList;
		foreach (RegressSignReward item in (readOnlyList ?? Array.Empty<RegressSignReward>()))
		{
			if (item.Version > 0)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06009674 RID: 38516 RVA: 0x002758F4 File Offset: 0x00273AF4
	public unsafe RegressInvestigation? GetRegressQuestionnaireConfig(ERegressQuestionnaireType type)
	{
		bool flag = Singleton<LauncherNetworkDetectionController>.Instance.IsGlobalPlayer();
		RegressInvestigation? config = ConfigRegressInvestigationByInvestigationTypeAndIfGlobal.GetConfig((int)type, flag, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "回归活动->获取回流调查问卷配置失败,请检查配置表RegressInvestigation";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("type:", type);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ifGlobal:", flag);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return new RegressInvestigation?(config.Value);
	}

	// Token: 0x06009675 RID: 38517 RVA: 0x00275994 File Offset: 0x00273B94
	public IReadOnlyList<RegressBase> GetRegressBaseConfigListByType(EActivityRegressEntranceType entryType)
	{
		if (entryType == EActivityRegressEntranceType.NewRole2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[回流活动]ActivityRecallConfig.GetRecallBaseConfigByType->";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("获取回流基础配置失败,请检查传入参数,请传入新角色1类型来获取配置，EntryType:", entryType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		IReadOnlyList<RegressBase> configList = ConfigRegressBaseByEntryType.GetConfigList((int)entryType, true);
		if (configList == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.ActivityRegress;
			ELogAuthor author2 = ELogAuthor.LRX;
			string message2 = "[回流活动]ActivityRecallConfig.GetRecallBaseConfigByType->";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("获取回流基础配置失败,请检查配置表RegressBase: entryType:", entryType);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
		}
		return configList;
	}

	// Token: 0x06009676 RID: 38518 RVA: 0x00275A10 File Offset: 0x00273C10
	public RewardConfig? GetRewardConfig(int rewardGroupId)
	{
		RewardConfig? config = ConfigRewardConfigById.GetConfig(rewardGroupId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[回流活动]ActivityRecallConfig.GetRewardConfig->";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("获取回归奖励配置失败,请检查配置表奖励档次|RewardConfig: rewardGroupId:", rewardGroupId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x06009677 RID: 38519 RVA: 0x00275A68 File Offset: 0x00273C68
	public RegressQuest? GetRegressQuestConfig(int taskId)
	{
		RegressQuest? config = ConfigRegressQuestById.GetConfig(taskId, true);
		if (config != null)
		{
			return new RegressQuest?(config.Value);
		}
		return null;
	}

	// Token: 0x06009678 RID: 38520 RVA: 0x00275A9C File Offset: 0x00273C9C
	public IReadOnlyList<RegressBonusReward> GetRegressBonusRewardConfigList(ERegressGrade grade)
	{
		IReadOnlyList<RegressBonusReward> configList = ConfigRegressBonusRewardByGrade.GetConfigList((int)grade, true);
		List<RegressBonusReward> list = new List<RegressBonusReward>();
		IReadOnlyList<RegressBonusReward> readOnlyList = configList;
		foreach (RegressBonusReward item in (readOnlyList ?? Array.Empty<RegressBonusReward>()))
		{
			if (item.Version > 0)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06009679 RID: 38521 RVA: 0x00275B08 File Offset: 0x00273D08
	[NullableContext(0)]
	public ValueTuple<RegressEntry?, RegressEntry?> GetRegressRoleEntryConfigTuple()
	{
		List<RegressEntry?> sortedOpenRegressEntryConfigList = this.GetSortedOpenRegressEntryConfigList();
		return new ValueTuple<RegressEntry?, RegressEntry?>(sortedOpenRegressEntryConfigList[0], sortedOpenRegressEntryConfigList[1]);
	}

	// Token: 0x0600967A RID: 38522 RVA: 0x00275B30 File Offset: 0x00273D30
	[NullableContext(1)]
	public List<RegressEntry?> GetSortedOpenRegressEntryConfigList()
	{
		List<RegressEntry> regressEntryConfigByType = this.GetRegressEntryConfigByType(EActivityRegressEntranceType.NewRole1);
		if (regressEntryConfigByType == null)
		{
			return new List<RegressEntry?>();
		}
		List<RegressEntry?> list = new List<RegressEntry?>();
		foreach (RegressEntry value in regressEntryConfigByType)
		{
			list.Add(new RegressEntry?(value));
		}
		list.Sort(delegate(RegressEntry? config1, RegressEntry? config2)
		{
			if (config1 == null || config2 == null)
			{
				int num = ((config1 != null) > false) ? 1 : 0;
				return (((config2 != null) > false) ? 1 : 0) - num;
			}
			int num2 = (ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(config1.Value).Item1 > false) ? 1 : 0;
			int num3 = (ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(config2.Value).Item1 > false) ? 1 : 0;
			if (num3 == num2)
			{
				return config1.Value.Id - config2.Value.Id;
			}
			return num3 - num2;
		});
		return list;
	}

	// Token: 0x0600967B RID: 38523 RVA: 0x00275BC0 File Offset: 0x00273DC0
	[NullableContext(1)]
	public List<RegressBase?> GetSortedOpenRegressBaseConfigList()
	{
		IReadOnlyList<RegressBase> lastestRegressBaseConfigList = ModelBase<ActivityRegressModel>.Instance.GetLastestRegressBaseConfigList(EActivityRegressEntranceType.NewRole1);
		if (lastestRegressBaseConfigList == null)
		{
			return new List<RegressBase?>();
		}
		List<RegressBase?> list = new List<RegressBase?>();
		foreach (RegressBase regressBase in lastestRegressBaseConfigList)
		{
			if (ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(regressBase).Item1)
			{
				list.Add(new RegressBase?(regressBase));
			}
		}
		return list;
	}

	// Token: 0x0600967C RID: 38524 RVA: 0x00275C3C File Offset: 0x00273E3C
	public RegressEntry? GetRegressEntrySingleConfigByType(EActivityRegressEntranceType entryType)
	{
		List<RegressEntry> regressEntryConfigByType = this.GetRegressEntryConfigByType(entryType);
		if (regressEntryConfigByType == null || regressEntryConfigByType.Count == 0)
		{
			return null;
		}
		return new RegressEntry?(regressEntryConfigByType[0]);
	}

	// Token: 0x0600967D RID: 38525 RVA: 0x00275C74 File Offset: 0x00273E74
	[NullableContext(1)]
	public List<RegressEntry> GetRegressEntryConfigByType(EActivityRegressEntranceType entryType)
	{
		if (entryType == EActivityRegressEntranceType.NewRole2)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.ActivityRegress;
			ELogAuthor author = ELogAuthor.LRX;
			string message = "[回流活动]ActivityRecallConfig.GetRegressEntryConfigByType->";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("获取回流配置失败,请检查传入参数,请传入新角色1类型来获取配置,RegressEntry:entryType:", entryType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<RegressEntry>();
		}
		IReadOnlyList<RegressEntry> configList = ConfigRegressEntryByEntryType.GetConfigList((int)entryType, true);
		if (configList == null)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.ActivityRegress;
			ELogAuthor author2 = ELogAuthor.LRX;
			string message2 = "[回流活动]ActivityRecallConfig.GetRegressEntryConfigByType->";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("获取回流配置失败,请检查配置表RegressEntry: entryType:", entryType);
			instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			return new List<RegressEntry>();
		}
		return configList.ToList<RegressEntry>();
	}

	// Token: 0x0600967E RID: 38526 RVA: 0x00275D00 File Offset: 0x00273F00
	[NullableContext(1)]
	public List<RegressEntry> GetUnlockRegressEntryViewConfigList()
	{
		List<RegressEntry> list = new List<RegressEntry>();
		RegressEntry? regressEntrySingleConfigByType = this.GetRegressEntrySingleConfigByType(EActivityRegressEntranceType.NewMainLine);
		if (regressEntrySingleConfigByType != null)
		{
			list.Add(regressEntrySingleConfigByType.Value);
		}
		RegressEntry? regressEntrySingleConfigByType2 = this.GetRegressEntrySingleConfigByType(EActivityRegressEntranceType.NewArea);
		if (regressEntrySingleConfigByType2 != null)
		{
			list.Add(regressEntrySingleConfigByType2.Value);
		}
		ValueTuple<RegressEntry?, RegressEntry?> regressRoleEntryConfigTuple = this.GetRegressRoleEntryConfigTuple();
		RegressEntry? item = regressRoleEntryConfigTuple.Item1;
		RegressEntry? item2 = regressRoleEntryConfigTuple.Item2;
		bool flag = false;
		if (item != null)
		{
			flag = ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(item.Value).Item1;
		}
		bool flag2 = false;
		if (item2 != null)
		{
			flag2 = ModelBase<ActivityRegressModel>.Instance.CheckIfEntryOpen(item2.Value).Item1;
		}
		if (flag || flag2)
		{
			if (flag && item != null)
			{
				list.Add(item.Value);
			}
			if (!flag && flag2 && item2 != null)
			{
				list.Add(item2.Value);
			}
		}
		return list;
	}

	// Token: 0x0600967F RID: 38527 RVA: 0x00275DF0 File Offset: 0x00273FF0
	public RegressDoubleDrop? GetDoubleDropConfig(ERegressGrade grade)
	{
		RegressDoubleDrop? config = ConfigRegressDoubleDropByGrade.GetConfig((int)grade, true);
		if (config != null)
		{
			return new RegressDoubleDrop?(config.Value);
		}
		return null;
	}

	// Token: 0x06009680 RID: 38528 RVA: 0x00275E24 File Offset: 0x00274024
	public ConditionGroup? GetConditionGroup(int conditionId)
	{
		ConditionGroup? config = ConfigConditionGroupById.GetConfig(conditionId, true);
		if (config != null)
		{
			return new ConditionGroup?(config.Value);
		}
		return null;
	}

	// Token: 0x06009681 RID: 38529 RVA: 0x00275E58 File Offset: 0x00274058
	public RegressRecommend? GetRegressRecommend(int id)
	{
		RegressRecommend? config = ConfigRegressRecommendById.GetConfig(id, true);
		if (config != null)
		{
			return new RegressRecommend?(config.Value);
		}
		return null;
	}

	// Token: 0x06009682 RID: 38530 RVA: 0x00275E8C File Offset: 0x0027408C
	public IReadOnlyList<RegressRecommend> GetAllRegressRecommend()
	{
		return ConfigRegressRecommendAll.GetConfigList(true);
	}

	// Token: 0x06009683 RID: 38531 RVA: 0x00275E94 File Offset: 0x00274094
	public IReadOnlyList<RegressRecommend> GetRegressRecommendByType(ERegressRecommendType type)
	{
		return ConfigRegressRecommendByType.GetConfigList((int)type, true);
	}

	// Token: 0x06009684 RID: 38532 RVA: 0x00275E9D File Offset: 0x0027409D
	public IReadOnlyList<RegressRecommend> GetRegressRecommendByGroup(int groupId)
	{
		return ConfigRegressRecommendByActivityGroup.GetConfigList(groupId, true);
	}

	// Token: 0x06009685 RID: 38533 RVA: 0x00275EA8 File Offset: 0x002740A8
	public RegressDisposableReward? GetRegressDisposableReward(int id)
	{
		RegressDisposableReward? config = ConfigRegressDisposableRewardById.GetConfig(id, true);
		if (config != null)
		{
			return new RegressDisposableReward?(config.Value);
		}
		return null;
	}

	// Token: 0x06009686 RID: 38534 RVA: 0x00275EDC File Offset: 0x002740DC
	public GachaRoleDevelopIns? GetGachaRoleDevelopIns(int id)
	{
		GachaRoleDevelopIns? config = ConfigGachaRoleDevelopInsById.GetConfig(id, true);
		if (config != null)
		{
			return new GachaRoleDevelopIns?(config.Value);
		}
		return null;
	}

	// Token: 0x06009687 RID: 38535 RVA: 0x00275F10 File Offset: 0x00274110
	public IReadOnlyList<GachaRoleDevelopIns> GetGachaRoleDevelopInsByRoleId(int roleId)
	{
		return ConfigGachaRoleDevelopInsByRoleId.GetConfigList(roleId, true);
	}

	// Token: 0x06009688 RID: 38536 RVA: 0x00275F1C File Offset: 0x0027411C
	public GachaRoleDevelopIns? GetGachaRoleDevelopInsByDungeonId(int dungeon)
	{
		GachaRoleDevelopIns? config = ConfigGachaRoleDevelopInsByDungeonDetection.GetConfig(dungeon, true);
		if (config != null)
		{
			return new GachaRoleDevelopIns?(config.Value);
		}
		return null;
	}

	// Token: 0x06009689 RID: 38537 RVA: 0x00275F50 File Offset: 0x00274150
	public IReadOnlyList<RegressTrialRole> GetTrialRoleAll()
	{
		return ConfigRegressTrialRoleAll.GetConfigList(true);
	}

	// Token: 0x0600968A RID: 38538 RVA: 0x00275F58 File Offset: 0x00274158
	[NullableContext(1)]
	public Dictionary<int, string> GetTrialRoleUnlockDesc()
	{
		Dictionary<int, string> dictionary = new Dictionary<int, string>();
		foreach (RegressTrialRole regressTrialRole in (this.GetTrialRoleAll() ?? new List<RegressTrialRole>()))
		{
			ConditionGroup? conditionGroupConfig = ConfigBase<ConditionConfig>.Instance.GetConditionGroupConfig(regressTrialRole.ConditionGroup);
			if (conditionGroupConfig != null)
			{
				string hintText = conditionGroupConfig.Value.HintText;
				dictionary[regressTrialRole.TrialRoleGroupId] = hintText;
			}
		}
		return dictionary;
	}
}
