using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020017CD RID: 6093
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class CalabashConfig : ConfigBase<CalabashConfig>
{
	// Token: 0x0600ACE8 RID: 44264 RVA: 0x002E1F34 File Offset: 0x002E0134
	public CalabashLevel? GetCalabashConfigByLevel(int level)
	{
		CalabashLevel? config = ConfigCalabashLevelByLevel.GetConfig(level, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取鸣域终端配置失败，请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("level", level);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return config;
	}

	// Token: 0x0600ACE9 RID: 44265 RVA: 0x002E1F8C File Offset: 0x002E018C
	public IReadOnlyList<CalabashLevel> GetCalabashConfigList()
	{
		return ConfigCalabashLevelAll.GetConfigList(true);
	}

	// Token: 0x0600ACEA RID: 44266 RVA: 0x002E1F94 File Offset: 0x002E0194
	[NullableContext(1)]
	public string GetCalabashQuality(int level)
	{
		return this.GetCalabashConfigByLevel(level).Value.QualityDescription;
	}

	// Token: 0x0600ACEB RID: 44267 RVA: 0x002E1FB8 File Offset: 0x002E01B8
	public IReadOnlyList<CalabashDevelopReward> GetCalabashDevelopList()
	{
		return ConfigCalabashDevelopRewardAll.GetConfigList(true);
	}

	// Token: 0x0600ACEC RID: 44268 RVA: 0x002E1FC0 File Offset: 0x002E01C0
	public CalabashDevelopReward? GetCalabashDevelopRewardByMonsterId(int monsterId)
	{
		CalabashDevelopReward? config = ConfigCalabashDevelopRewardByMonsterId.GetConfig(monsterId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取鸣域终端养成奖励配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MonsterId", monsterId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return new CalabashDevelopReward?(config.Value);
	}

	// Token: 0x0600ACED RID: 44269 RVA: 0x002E201C File Offset: 0x002E021C
	[NullableContext(1)]
	public string GetMonsterNameByMonsterId(int monsterId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(ConfigMonsterInfoById.GetConfig(this.GetCalabashDevelopRewardByMonsterId(monsterId).Value.MonsterInfoId, true).Value.Name, null) ?? "";
	}

	// Token: 0x0600ACEE RID: 44270 RVA: 0x002E2068 File Offset: 0x002E0268
	public CalabashDevelopCondition GetCalabashConditionById(int id)
	{
		CalabashDevelopCondition? config = ConfigCalabashDevelopConditionById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "获取鸣域终端养成条件配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config.Value;
	}

	// Token: 0x0600ACEF RID: 44271 RVA: 0x002E20BC File Offset: 0x002E02BC
	public int GetCalabashConditionExp(int id)
	{
		return this.GetCalabashConditionRewardExp(this.GetCalabashConditionById(id));
	}

	// Token: 0x0600ACF0 RID: 44272 RVA: 0x002E20CC File Offset: 0x002E02CC
	public int GetCalabashConditionRewardExp(CalabashDevelopCondition config)
	{
		Dictionary<int, int> dictionary = config.RewardExp();
		if (dictionary == null)
		{
			return 0;
		}
		int? intConfig = ConfigCommonParamById.GetIntConfig("CalabashExpItemId");
		int? num = intConfig;
		int num2 = 0;
		if (num.GetValueOrDefault() == num2 & num != null)
		{
			return 0;
		}
		int result;
		if (!dictionary.TryGetValue(intConfig.Value, out result))
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x0600ACF1 RID: 44273 RVA: 0x002E2124 File Offset: 0x002E0324
	public int GetCalabashMaxLevel()
	{
		IEnumerable<CalabashLevel> calabashConfigList = this.GetCalabashConfigList();
		int num = 0;
		foreach (CalabashLevel calabashLevel in calabashConfigList)
		{
			if (num < calabashLevel.Level)
			{
				num = calabashLevel.Level;
			}
		}
		return num;
	}

	// Token: 0x0600ACF2 RID: 44274 RVA: 0x002E2180 File Offset: 0x002E0380
	public ConditionGroup? GetConditionInfo(int upConditionId)
	{
		return ConfigConditionGroupById.GetConfig(upConditionId, true);
	}

	// Token: 0x17000DF0 RID: 3568
	// (get) Token: 0x0600ACF3 RID: 44275 RVA: 0x002E218C File Offset: 0x002E038C
	public int MaxTipCd
	{
		get
		{
			return ConfigCommonParamById.GetIntConfig("VisionUnlockDisplayTime").Value;
		}
	}

	// Token: 0x17000DF1 RID: 3569
	// (get) Token: 0x0600ACF4 RID: 44276 RVA: 0x002E21AC File Offset: 0x002E03AC
	public int DelayTime
	{
		get
		{
			return ConfigCommonParamById.GetIntConfig("VisionUnlockDelayTime").Value;
		}
	}

	// Token: 0x0600ACF5 RID: 44277 RVA: 0x002E21CC File Offset: 0x002E03CC
	public int GetVisionBatchRecoveryMaxCount()
	{
		return ConfigCommonParamById.GetIntConfig("PhantomRefiningMaxCount").Value;
	}

	// Token: 0x0600ACF6 RID: 44278 RVA: 0x002E21EB File Offset: 0x002E03EB
	public IReadOnlyList<CalabashDevelopReward> GetCalabashRewardListByAreaId(int areaId)
	{
		return ConfigCalabashDevelopRewardByInteractAreaId.GetConfigList(areaId, true);
	}

	// Token: 0x0600ACF7 RID: 44279 RVA: 0x002E21F4 File Offset: 0x002E03F4
	public IReadOnlyList<PhantomDirectRefining> GetPhantomDirectRefiningAll()
	{
		return ConfigPhantomDirectRefiningAll.GetConfigList(true);
	}
}
