using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D2B RID: 23851
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class FlagChallengeConfig : ConfigBase<FlagChallengeConfig>
	{
		// Token: 0x0603C2A6 RID: 246438 RVA: 0x00F41E6F File Offset: 0x00F4006F
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603C2A7 RID: 246439 RVA: 0x00F41E72 File Offset: 0x00F40072
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603C2A8 RID: 246440 RVA: 0x00F41E78 File Offset: 0x00F40078
		public FlagChallengeActivity? GetActivityConfig(int id)
		{
			FlagChallengeActivity? config = ConfigFlagChallengeActivityByActivityId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "活动配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2A9 RID: 246441 RVA: 0x00F41EC8 File Offset: 0x00F400C8
		public FlagChallengeTask? GetTaskConfig(int id)
		{
			FlagChallengeTask? config = ConfigFlagChallengeTaskById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "任务配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2AA RID: 246442 RVA: 0x00F41F18 File Offset: 0x00F40118
		public FlagChallengeLevel? GetLevelConfig(int id)
		{
			FlagChallengeLevel? config = ConfigFlagChallengeLevelById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "关卡配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2AB RID: 246443 RVA: 0x00F41F68 File Offset: 0x00F40168
		public FlagStronghold? GetStrongholdConfig(int id)
		{
			FlagStronghold? config = ConfigFlagStrongholdById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "据点配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2AC RID: 246444 RVA: 0x00F41FB8 File Offset: 0x00F401B8
		public FlagChallengeRoleBuff? GetRoleBuffConfig(int id)
		{
			FlagChallengeRoleBuff? config = ConfigFlagChallengeRoleBuffById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "角色Buff配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2AD RID: 246445 RVA: 0x00F42008 File Offset: 0x00F40208
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeRoleBuff> GetRoleBuffConfigListByActivityId(int activityId)
		{
			IReadOnlyList<FlagChallengeRoleBuff> configList = ConfigFlagChallengeRoleBuffByActivityId.GetConfigList(activityId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "活动角色Buff配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x0603C2AE RID: 246446 RVA: 0x00F42050 File Offset: 0x00F40250
		public FlagChallengeRoleLevel? GetRoleLevelConfig(int id)
		{
			FlagChallengeRoleLevel? config = ConfigFlagChallengeRoleLevelById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "角色等级配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2AF RID: 246447 RVA: 0x00F420A0 File Offset: 0x00F402A0
		public unsafe FlagChallengeRoleLevel? GetRoleLevelConfigByActivityIdAndLevel(int activityId, int level)
		{
			FlagChallengeRoleLevel? config = ConfigFlagChallengeRoleLevelByActivityIdAndLevel.GetConfig(activityId, level, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "角色等级配置为空";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", activityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Level", level);
				instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			return config;
		}

		// Token: 0x0603C2B0 RID: 246448 RVA: 0x00F42120 File Offset: 0x00F40320
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeRoleLevel> GetRoleLevelConfigListByActivityId(int activityId)
		{
			IReadOnlyList<FlagChallengeRoleLevel> configList = ConfigFlagChallengeRoleLevelByActivityId.GetConfigList(activityId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "角色等级配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x0603C2B1 RID: 246449 RVA: 0x00F42168 File Offset: 0x00F40368
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeLevelDiffShow> GetLevelDiffShowConfigList()
		{
			IReadOnlyList<FlagChallengeLevelDiffShow> configList = ConfigFlagChallengeLevelDiffShowAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "插旗等级差表现配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603C2B2 RID: 246450 RVA: 0x00F421A0 File Offset: 0x00F403A0
		public FlagChallengeArea? GetAreaConfig(int id)
		{
			FlagChallengeArea? config = ConfigFlagChallengeAreaById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "插旗区域配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2B3 RID: 246451 RVA: 0x00F421F0 File Offset: 0x00F403F0
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeArea> GetAreaConfigList()
		{
			IReadOnlyList<FlagChallengeArea> configList = ConfigFlagChallengeAreaAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "插旗区域配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603C2B4 RID: 246452 RVA: 0x00F42228 File Offset: 0x00F40428
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeArea> GetAreaConfigListByLevelId(int levelId)
		{
			IReadOnlyList<FlagChallengeArea> configList = ConfigFlagChallengeAreaByLevelId.GetConfigList(levelId, true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "插旗区域配置为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603C2B5 RID: 246453 RVA: 0x00F42260 File Offset: 0x00F40460
		public FlagChallengeMonLevel? GetMonsterLevelConfigById(int id)
		{
			FlagChallengeMonLevel? config = ConfigFlagChallengeMonLevelById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "插旗局内怪物等级配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603C2B6 RID: 246454 RVA: 0x00F422B0 File Offset: 0x00F404B0
		[NullableContext(2)]
		public IReadOnlyList<FlagChallengeRoleGrowth> GetRoleGrowthConfigListByActivityId(int activityId)
		{
			IReadOnlyList<FlagChallengeRoleGrowth> configList = ConfigFlagChallengeRoleGrowthByActivityId.GetConfigList(activityId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "插旗局内角色成长配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x0603C2B7 RID: 246455 RVA: 0x00F422F8 File Offset: 0x00F404F8
		public int GetRewardHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeRewardHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2B8 RID: 246456 RVA: 0x00F42324 File Offset: 0x00F40524
		public int GetFormationHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeFormationHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2B9 RID: 246457 RVA: 0x00F42350 File Offset: 0x00F40550
		public int GetBuffHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeBuffHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2BA RID: 246458 RVA: 0x00F4237C File Offset: 0x00F4057C
		public int GetRoleLevelHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeRoleLevelHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2BB RID: 246459 RVA: 0x00F423A8 File Offset: 0x00F405A8
		public int GetMainViewHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeMainViewHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2BC RID: 246460 RVA: 0x00F423D4 File Offset: 0x00F405D4
		public int GetAreaDetailViewHelpId()
		{
			int? intConfig = ConfigCommonParamById.GetIntConfig("FlagChallengeAreaDetailViewHelpId");
			if (intConfig == null)
			{
				return 0;
			}
			return intConfig.Value;
		}

		// Token: 0x0603C2BD RID: 246461 RVA: 0x00F42400 File Offset: 0x00F40600
		public IReadOnlyList<int> GetAllAttrAddIdList()
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("FlagChallengeRoleAttrAddIdList");
			if (intArrayConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "属性加成id列表为空 - FlagChallengeRoleAttrAddIdList", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new List<int>();
			}
			return intArrayConfig;
		}

		// Token: 0x0603C2BE RID: 246462 RVA: 0x00F42444 File Offset: 0x00F40644
		public int GetTempExpItemInterval()
		{
			return ConfigCommonParamById.GetIntConfig("FlagChallengeTempExpUnitInterval").GetValueOrDefault(20);
		}

		// Token: 0x0603C2BF RID: 246463 RVA: 0x00F42468 File Offset: 0x00F40668
		public int GetTempExpCrossLevel()
		{
			return ConfigCommonParamById.GetIntConfig("FlagChallengeTempExpCrossLevel").GetValueOrDefault(3);
		}

		// Token: 0x0603C2C0 RID: 246464 RVA: 0x00F42488 File Offset: 0x00F40688
		public string GetMainViewLevelButtonIcon()
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("FlagChallengeLevelButtonIcon");
			if (stringConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "主界面关卡按钮图标路径配置为空 - FlagChallengeLevelButtonIcon", default(ReadOnlySpan<ValueTuple<string, object>>));
				return "";
			}
			return stringConfig;
		}

		// Token: 0x0603C2C1 RID: 246465 RVA: 0x00F424CC File Offset: 0x00F406CC
		public string GetMainViewBuffButtonIcon()
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("FlagChallengeBuffButtonIcon");
			if (stringConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "主界面增益按钮图标路径配置为空 - FlagChallengeBuffButtonIcon", default(ReadOnlySpan<ValueTuple<string, object>>));
				return "";
			}
			return stringConfig;
		}

		// Token: 0x0603C2C2 RID: 246466 RVA: 0x00F42510 File Offset: 0x00F40710
		public string GetMainViewPauseButtonIcon()
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("FlagChallengePauseButtonIcon");
			if (stringConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "主界面暂停按钮图标路径配置为空 - FlagChallengePauseButtonIcon", default(ReadOnlySpan<ValueTuple<string, object>>));
				return "";
			}
			return stringConfig;
		}

		// Token: 0x0603C2C3 RID: 246467 RVA: 0x00F42554 File Offset: 0x00F40754
		public string GetMainViewVideoPath()
		{
			string stringConfig = ConfigCommonParamById.GetStringConfig("FlagChallengeMainViewVideoPath");
			if (stringConfig == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.FlagChallenge, ELogAuthor.LJS, "主界面视频路径配置为空 - FlagChallengeMainViewVideoPath", default(ReadOnlySpan<ValueTuple<string, object>>));
				return "";
			}
			return stringConfig;
		}

		// Token: 0x0603C2C4 RID: 246468 RVA: 0x00F42598 File Offset: 0x00F40798
		public string GetViewVideoPathByStyle(EFlagChallengeUiStyleType style)
		{
			string text;
			if (!Singleton<FlagChallengeDefine>.Instance.flagChallengeStyleVideoPath.TryGetValue(style, out text) || text == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.FlagChallenge;
				ELogAuthor author = ELogAuthor.LJS;
				string message = "界面视频路径配置为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("style", style);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return "";
			}
			return text;
		}

		// Token: 0x0603C2C5 RID: 246469 RVA: 0x00F425F4 File Offset: 0x00F407F4
		public int GetBuffShowTime()
		{
			return ConfigCommonParamById.GetIntConfig("FlagChallengeBuffShowTime").GetValueOrDefault(1);
		}
	}
}
