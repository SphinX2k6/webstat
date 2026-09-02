using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.PhantomArena
{
	// Token: 0x02005468 RID: 21608
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class PhantomArenaConfig : ConfigBase<PhantomArenaConfig>
	{
		// Token: 0x06037108 RID: 225544 RVA: 0x00DFB560 File Offset: 0x00DF9760
		public PhantomBattleCard GetPhantomBattleCardConfig(int configId)
		{
			return ConfigPhantomBattleCardById.GetConfig(configId, true).Value;
		}

		// Token: 0x06037109 RID: 225545 RVA: 0x00DFB57C File Offset: 0x00DF977C
		public IReadOnlyList<PhantomBattleCard> GetPhantomBattleCardByActivityId(int activityId)
		{
			return ConfigPhantomBattleCardByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0603710A RID: 225546 RVA: 0x00DFB585 File Offset: 0x00DF9785
		public IReadOnlyList<PhantomBattleCard> GetAllPhantomBattleCard()
		{
			return ConfigPhantomBattleCardAll.GetConfigList(true);
		}

		// Token: 0x0603710B RID: 225547 RVA: 0x00DFB590 File Offset: 0x00DF9790
		public PhantomBattleSkill GetPhantomBattleSkillConfig(int skillConfigId)
		{
			return ConfigPhantomBattleSkillById.GetConfig(skillConfigId, true).Value;
		}

		// Token: 0x0603710C RID: 225548 RVA: 0x00DFB5AC File Offset: 0x00DF97AC
		public PhantomBattleBuff GetPhantomBattleBuffConfig(int buffConfigId)
		{
			return ConfigPhantomBattleBuffById.GetConfig(buffConfigId, true).Value;
		}

		// Token: 0x0603710D RID: 225549 RVA: 0x00DFB5C8 File Offset: 0x00DF97C8
		public PhantomBattleFactor GetPhantomBattleFactorConfig(int factorConfigId)
		{
			return ConfigPhantomBattleFactorById.GetConfig(factorConfigId, true).Value;
		}

		// Token: 0x0603710E RID: 225550 RVA: 0x00DFB5E4 File Offset: 0x00DF97E4
		public IReadOnlyList<PhantomBattleFactor> GetPhantomBattleAllFactor()
		{
			return ConfigPhantomBattleFactorAll.GetConfigList(true);
		}

		// Token: 0x0603710F RID: 225551 RVA: 0x00DFB5EC File Offset: 0x00DF97EC
		public PhantomBattleEntry GetPhantomBattleEntryConfig(int entryId)
		{
			return ConfigPhantomBattleEntryById.GetConfig(entryId, true).Value;
		}

		// Token: 0x06037110 RID: 225552 RVA: 0x00DFB608 File Offset: 0x00DF9808
		public PhantomBattleCardElement GetPhantomBattleElementConfig(int elementId)
		{
			return ConfigPhantomBattleCardElementById.GetConfig(elementId, true).Value;
		}

		// Token: 0x06037111 RID: 225553 RVA: 0x00DFB624 File Offset: 0x00DF9824
		public PhantomBattleCardEffect GetPhantomBattleEffectConfig(int id)
		{
			return ConfigPhantomBattleCardEffectById.GetConfig(id, true).Value;
		}

		// Token: 0x06037112 RID: 225554 RVA: 0x00DFB640 File Offset: 0x00DF9840
		public IReadOnlyList<PhantomBattleCardFilter> GetAllPhantomBattleCardFilter()
		{
			return ConfigPhantomBattleCardFilterAll.GetConfigList(true);
		}

		// Token: 0x06037113 RID: 225555 RVA: 0x00DFB648 File Offset: 0x00DF9848
		public PhantomBattleCardFilter GetPhantomBattleCardFilter(int filterId)
		{
			return ConfigPhantomBattleCardFilterById.GetConfig(filterId, true).Value;
		}

		// Token: 0x06037114 RID: 225556 RVA: 0x00DFB664 File Offset: 0x00DF9864
		public IReadOnlyList<PhantomBattleCardSlotSort> GetAllPhantomBattleCardSlotSort()
		{
			return ConfigPhantomBattleCardSlotSortAll.GetConfigList(true);
		}

		// Token: 0x06037115 RID: 225557 RVA: 0x00DFB66C File Offset: 0x00DF986C
		public PhantomBattleCardSlotSort GetPhantomBattleCardSlotSort(int sortId)
		{
			return ConfigPhantomBattleCardSlotSortById.GetConfig(sortId, true).Value;
		}

		// Token: 0x06037116 RID: 225558 RVA: 0x00DFB688 File Offset: 0x00DF9888
		public PhantomBattleActivity GetPhantomBattleActivityConfig(int activityId)
		{
			return ConfigPhantomBattleActivityByActivityId.GetConfig(activityId, true).Value;
		}

		// Token: 0x06037117 RID: 225559 RVA: 0x00DFB6A4 File Offset: 0x00DF98A4
		public PhantomBattleChallenge GetPhantomBattleChallenge(int challengeId)
		{
			return ConfigPhantomBattleChallengeById.GetConfig(challengeId, true).Value;
		}

		// Token: 0x06037118 RID: 225560 RVA: 0x00DFB6C0 File Offset: 0x00DF98C0
		public IReadOnlyList<PhantomBattleBadge> GetAllPhantomBattleBadge()
		{
			return ConfigPhantomBattleBadgeAll.GetConfigList(true);
		}

		// Token: 0x06037119 RID: 225561 RVA: 0x00DFB6C8 File Offset: 0x00DF98C8
		public PhantomBattleBadge GetPhantomBattleBadgeById(int badgeId)
		{
			return ConfigPhantomBattleBadgeById.GetConfig(badgeId, true).Value;
		}

		// Token: 0x0603711A RID: 225562 RVA: 0x00DFB6E4 File Offset: 0x00DF98E4
		public int GetPhantomBattleBadgeGroupIdById(int badgeId)
		{
			return this.GetPhantomBattleBadgeById(badgeId).GroupId;
		}

		// Token: 0x0603711B RID: 225563 RVA: 0x00DFB700 File Offset: 0x00DF9900
		public PhantomBattleBadgeGroup GetPhantomBattleBadgeGroupById(int groupId)
		{
			return ConfigPhantomBattleBadgeGroupByGroupId.GetConfig(groupId, true).Value;
		}

		// Token: 0x0603711C RID: 225564 RVA: 0x00DFB71C File Offset: 0x00DF991C
		public PhantomBattleMasterTitle GetPhantomBattleMasterTitleById(int titleId)
		{
			return ConfigPhantomBattleMasterTitleById.GetConfig(titleId, true).Value;
		}

		// Token: 0x0603711D RID: 225565 RVA: 0x00DFB738 File Offset: 0x00DF9938
		public List<int> GetCardSkillList(PhantomBattleCard cardConfig, bool withActive, bool withPassive)
		{
			List<int> list = new List<int>();
			if (withActive)
			{
				int activeSkillId = cardConfig.ActiveSkillId;
				if (activeSkillId > 0)
				{
					list.Add(activeSkillId);
				}
			}
			if (withPassive)
			{
				list.AddRange(cardConfig.GetPassiveSkillIdBytes());
			}
			return list;
		}

		// Token: 0x0603711E RID: 225566 RVA: 0x00DFB778 File Offset: 0x00DF9978
		public PhantomBattleCardRole GetPhantomBattleCardRole(int id)
		{
			return ConfigPhantomBattleCardRoleById.GetConfig(id, true).Value;
		}

		// Token: 0x0603711F RID: 225567 RVA: 0x00DFB794 File Offset: 0x00DF9994
		public IReadOnlyList<PhantomBattleCardRole> GetPhantomBattleCardRoleByActivityId(int activityId)
		{
			return ConfigPhantomBattleCardRoleByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06037120 RID: 225568 RVA: 0x00DFB79D File Offset: 0x00DF999D
		public string GetDeckDefaultName()
		{
			return ConfigMultiTextLang.GetLocalTextNew("PhantomBattle_1038", null);
		}

		// Token: 0x06037121 RID: 225569 RVA: 0x00DFB7AC File Offset: 0x00DF99AC
		public PhantomBattleNPC GetPhantomBattleNpc(int id)
		{
			return ConfigPhantomBattleNPCById.GetConfig(id, true).Value;
		}

		// Token: 0x06037122 RID: 225570 RVA: 0x00DFB7C8 File Offset: 0x00DF99C8
		public IReadOnlyList<PhantomBattleNPC> GetPhantomBattleNpcList(int npcGroupId)
		{
			return ConfigPhantomBattleNPCByGroupId.GetConfigList(npcGroupId, true);
		}

		// Token: 0x06037123 RID: 225571 RVA: 0x00DFB7D1 File Offset: 0x00DF99D1
		public IReadOnlyList<PhantomBattleCardGroup> GetCardListByDeckConfigId(int deckConfigId)
		{
			return ConfigPhantomBattleCardGroupByGroupId.GetConfigList(deckConfigId, true);
		}

		// Token: 0x06037124 RID: 225572 RVA: 0x00DFB7DC File Offset: 0x00DF99DC
		public PhantomBattleCardGroupInfo GetDeckConfigInfo(int deckConfigId)
		{
			return ConfigPhantomBattleCardGroupInfoById.GetConfig(deckConfigId, true).Value;
		}

		// Token: 0x06037125 RID: 225573 RVA: 0x00DFB7F8 File Offset: 0x00DF99F8
		public PhantomBattleChallenge GetPhantomBattleChallengeConfig(int challengeId)
		{
			return ConfigPhantomBattleChallengeById.GetConfig(challengeId, true).Value;
		}

		// Token: 0x06037126 RID: 225574 RVA: 0x00DFB814 File Offset: 0x00DF9A14
		public IReadOnlyList<PhantomBattleGym> GetPhantomBattleGymConfig(int activityId)
		{
			return ConfigPhantomBattleGymByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x06037127 RID: 225575 RVA: 0x00DFB820 File Offset: 0x00DF9A20
		public int GetRepeatGymExpWeekLimitByLevel(int level)
		{
			if (ConfigPhantomBattleWeekExpById.GetConfig(level, true) == null)
			{
				return 0;
			}
			PhantomBattleWeekExp? phantomBattleWeekExp;
			return phantomBattleWeekExp.GetValueOrDefault().MaxWeekExp;
		}

		// Token: 0x06037128 RID: 225576 RVA: 0x00DFB850 File Offset: 0x00DF9A50
		public PhantomBattleGym? GetPhantomBattleGymConfigByLevel(int activityId, int gymLevel)
		{
			foreach (PhantomBattleGym value in this.GetPhantomBattleGymConfig(activityId))
			{
				if (value.Level == gymLevel)
				{
					return new PhantomBattleGym?(value);
				}
			}
			return null;
		}

		// Token: 0x06037129 RID: 225577 RVA: 0x00DFB8B8 File Offset: 0x00DF9AB8
		public PhantomBattleMasterLevel? GetPhantomBattleMasterLevelConfigById(int configId)
		{
			PhantomBattleMasterLevel? config = ConfigPhantomBattleMasterLevelById.GetConfig(configId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取召唤师等级配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", configId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603712A RID: 225578 RVA: 0x00DFB908 File Offset: 0x00DF9B08
		public unsafe PhantomBattleMasterLevel? GetPhantomBattleMasterLevelByLevelAndActivityId(int level, int activityId)
		{
			foreach (PhantomBattleMasterLevel value in ConfigPhantomBattleMasterLevelAll.GetConfigList(true))
			{
				if (value.Level == level && value.ActivityId == activityId)
				{
					return new PhantomBattleMasterLevel?(value);
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.CXJ;
			string message = "获取召唤师等级配置失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("level", level);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("activityId", activityId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}

		// Token: 0x0603712B RID: 225579 RVA: 0x00DFB9D8 File Offset: 0x00DF9BD8
		public List<PhantomBattleMasterLevel> GetPhantomBattleMasterLevelConfigByActivityId(int activityId)
		{
			IEnumerable<PhantomBattleMasterLevel> configList = ConfigPhantomBattleMasterLevelAll.GetConfigList(true);
			List<PhantomBattleMasterLevel> list = new List<PhantomBattleMasterLevel>();
			foreach (PhantomBattleMasterLevel item in configList)
			{
				if (item.ActivityId == activityId)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0603712C RID: 225580 RVA: 0x00DFBA38 File Offset: 0x00DF9C38
		public unsafe PhantomBattleMasterLevel? GetPhantomBattleMasterLevelConfigByLevel(int activityId, int level)
		{
			foreach (PhantomBattleMasterLevel value in ConfigPhantomBattleMasterLevelAll.GetConfigList(true))
			{
				if (value.ActivityId == activityId && value.Level == level)
				{
					return new PhantomBattleMasterLevel?(value);
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.PhantomArena;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取召唤师等级配置失败";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", activityId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Level", level);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}

		// Token: 0x0603712D RID: 225581 RVA: 0x00DFBB08 File Offset: 0x00DF9D08
		public unsafe List<int> GetPhantomBattleChallengeIdListByGymId(int activityId, int gymId)
		{
			IReadOnlyList<PhantomBattleChallenge> configList = ConfigPhantomBattleChallengeByActivityGymId.GetConfigList(activityId, gymId, true);
			if (configList == null || configList.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取道馆的挑战列表失败，请检查PhantomBattleChallenge表";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ActivityId", activityId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("GymId", gymId);
				instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return new List<int>();
			}
			List<int> list = new List<int>();
			foreach (PhantomBattleChallenge phantomBattleChallenge in configList)
			{
				list.Add(phantomBattleChallenge.Id);
			}
			return list;
		}

		// Token: 0x0603712E RID: 225582 RVA: 0x00DFBBDC File Offset: 0x00DF9DDC
		public PhantomBattleCardReward GetPhantomBattleCardRewardById(int configId)
		{
			PhantomBattleCardReward? config = ConfigPhantomBattleCardRewardById.GetConfig(configId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取卡牌奖励列表失败，请检查PhantomBattleCardReward表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", config);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603712F RID: 225583 RVA: 0x00DFBC30 File Offset: 0x00DF9E30
		public PhantomBattleBadgeReward GetPhantomBattleBadgeRewardById(int configId)
		{
			PhantomBattleBadgeReward? config = ConfigPhantomBattleBadgeRewardById.GetConfig(configId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取卡牌奖励列表失败，请检查PhantomBattleBadgeReward表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId", config);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x06037130 RID: 225584 RVA: 0x00DFBC84 File Offset: 0x00DF9E84
		private int RewardSortByFlagId(PhantomBattleBadgeReward configA, PhantomBattleBadgeReward configB)
		{
			int bitFlagId = configA.BitFlagId;
			int bitFlagId2 = configB.BitFlagId;
			return bitFlagId - bitFlagId2;
		}

		// Token: 0x06037131 RID: 225585 RVA: 0x00DFBCA4 File Offset: 0x00DF9EA4
		private int RewardSortByFlagId(PhantomBattleCardReward configA, PhantomBattleCardReward configB)
		{
			int bitFlagId = configA.BitFlagId;
			int bitFlagId2 = configB.BitFlagId;
			return bitFlagId - bitFlagId2;
		}

		// Token: 0x06037132 RID: 225586 RVA: 0x00DFBCC4 File Offset: 0x00DF9EC4
		public List<int> GetPhantomBattleCardRewardIdList(int activityId)
		{
			IReadOnlyList<PhantomBattleCardReward> configList = ConfigPhantomBattleCardRewardByActivityId.GetConfigList(activityId, true);
			if (configList == null || configList.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取卡牌奖励列表失败，请检查PhantomBattleCardReward表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new List<int>();
			}
			List<PhantomBattleCardReward> list = new List<PhantomBattleCardReward>(configList);
			list.Sort(new Comparison<PhantomBattleCardReward>(this.RewardSortByFlagId));
			List<int> list2 = new List<int>();
			foreach (PhantomBattleCardReward phantomBattleCardReward in list)
			{
				list2.Add(phantomBattleCardReward.Id);
			}
			return list2;
		}

		// Token: 0x06037133 RID: 225587 RVA: 0x00DFBD80 File Offset: 0x00DF9F80
		public List<int> GetPhantomBattleBadgeRewardIdList(int activityId)
		{
			IReadOnlyList<PhantomBattleBadgeReward> configList = ConfigPhantomBattleBadgeRewardByActivityId.GetConfigList(activityId, true);
			if (configList == null || configList.Count <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PhantomArena;
				ELogAuthor author = ELogAuthor.WDX;
				string message = "获取卡牌奖励列表失败，请检查PhantomBattleBadgeReward表";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", activityId);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new List<int>();
			}
			List<PhantomBattleBadgeReward> list = new List<PhantomBattleBadgeReward>(configList);
			list.Sort(new Comparison<PhantomBattleBadgeReward>(this.RewardSortByFlagId));
			List<int> list2 = new List<int>();
			foreach (PhantomBattleBadgeReward phantomBattleBadgeReward in list)
			{
				list2.Add(phantomBattleBadgeReward.Id);
			}
			return list2;
		}

		// Token: 0x06037134 RID: 225588 RVA: 0x00DFBE3C File Offset: 0x00DFA03C
		public List<int> GetQuicklyBuildDeckList(int activityId)
		{
			return this.GetPhantomBattleActivityConfig(activityId).GetQuicklyBuildBytes().ToArray().ToList<int>();
		}

		// Token: 0x06037135 RID: 225589 RVA: 0x00DFBE68 File Offset: 0x00DFA068
		public int GetSlotLongPressTime(int activityId)
		{
			return this.GetPhantomBattleActivityConfig(activityId).SlotLongPressTime;
		}

		// Token: 0x06037136 RID: 225590 RVA: 0x00DFBE84 File Offset: 0x00DFA084
		public int GetSlotLongPressStartTime(int activityId)
		{
			return this.GetPhantomBattleActivityConfig(activityId).SlotLongPressStartTime;
		}

		// Token: 0x06037137 RID: 225591 RVA: 0x00DFBEA0 File Offset: 0x00DFA0A0
		public int GetSlotLongPressEndTime(int activityId)
		{
			return this.GetPhantomBattleActivityConfig(activityId).SlotLongPressEndTime;
		}

		// Token: 0x06037138 RID: 225592 RVA: 0x00DFBEBC File Offset: 0x00DFA0BC
		public PhantomBattleDialog GetPhantomBattleDialog(int id)
		{
			return ConfigPhantomBattleDialogById.GetConfig(id, true).Value;
		}

		// Token: 0x06037139 RID: 225593 RVA: 0x00DFBED8 File Offset: 0x00DFA0D8
		public int GetPhantomArenaOwnSpeakerId()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomArenaOwnSpeakerId").Value;
		}

		// Token: 0x0603713A RID: 225594 RVA: 0x00DFBEF8 File Offset: 0x00DFA0F8
		public int GetPhantomArenaOpponentSpeakerId()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomArenaOpponentSpeakerId").Value;
		}

		// Token: 0x0603713B RID: 225595 RVA: 0x00DFBF18 File Offset: 0x00DFA118
		public int GetPhantomArenaCardCoreCost()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomBattleKeyCost").Value;
		}

		// Token: 0x0603713C RID: 225596 RVA: 0x00DFBF38 File Offset: 0x00DFA138
		public int GetPhantomArenaRoundOverCheck()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomArenaRoundOverCheck").Value;
		}

		// Token: 0x0603713D RID: 225597 RVA: 0x00DFBF58 File Offset: 0x00DFA158
		public PhantomBattleFourCTask GetPhantomArenaFourTask(int cardId)
		{
			return ConfigPhantomBattleFourCTaskByCardId.GetConfig(cardId, true).Value;
		}

		// Token: 0x0603713E RID: 225598 RVA: 0x00DFBF74 File Offset: 0x00DFA174
		public PhantomBattleTask? GetTaskConfigById(int taskId)
		{
			return ConfigPhantomBattleTaskByTaskId.GetConfig(taskId, true);
		}

		// Token: 0x0603713F RID: 225599 RVA: 0x00DFBF7D File Offset: 0x00DFA17D
		public PhantomBattleWinSeq? GetSeqConfig(int instId)
		{
			return ConfigPhantomBattleWinSeqById.GetConfig(instId, true);
		}

		// Token: 0x06037140 RID: 225600 RVA: 0x00DFBF86 File Offset: 0x00DFA186
		public PhantomBattleTaskTab? GetTaskTabConfigById(int tabId)
		{
			return ConfigPhantomBattleTaskTabById.GetConfig(tabId, true);
		}

		// Token: 0x06037141 RID: 225601 RVA: 0x00DFBF90 File Offset: 0x00DFA190
		public float GetCardSlotItemLongPressOffsetX()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return 0f;
			}
			return ConfigCommonParamById.GetFloatConfig("BvbVisionScrollerOffsetX").Value;
		}

		// Token: 0x06037142 RID: 225602 RVA: 0x00DFBFC4 File Offset: 0x00DFA1C4
		public float GetCardSlotItemLongPressOffsetY()
		{
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				return 0f;
			}
			return ConfigCommonParamById.GetFloatConfig("BvbVisionScrollerOffsetY").Value;
		}

		// Token: 0x06037143 RID: 225603 RVA: 0x00DFBFF5 File Offset: 0x00DFA1F5
		public PhantomBattleChallenge? GetPhantomBattleChallengeByMarkId(int markId)
		{
			return ConfigPhantomBattleChallengeByMarkId.GetConfig(markId, true);
		}

		// Token: 0x06037144 RID: 225604 RVA: 0x00DFBFFE File Offset: 0x00DFA1FE
		public PhantomBattleMapParam? GetPhantomBattleMapParamById(int id)
		{
			return ConfigPhantomBattleMapParamById.GetConfig(id, true);
		}

		// Token: 0x06037145 RID: 225605 RVA: 0x00DFC007 File Offset: 0x00DFA207
		[NullableContext(2)]
		public IReadOnlyList<PhantomBattleMapParam> GetAllPhantomBattleMapParams()
		{
			return ConfigPhantomBattleMapParamAll.GetConfigList(true);
		}

		// Token: 0x06037146 RID: 225606 RVA: 0x00DFC00F File Offset: 0x00DFA20F
		[NullableContext(2)]
		public IReadOnlyList<PhantomBattleMapParam> GetPhantomBattleMapParamByMapId(int mapId)
		{
			return ConfigPhantomBattleMapParamByMapIdNew.GetConfigList(mapId, true);
		}

		// Token: 0x06037147 RID: 225607 RVA: 0x00DFC018 File Offset: 0x00DFA218
		[NullableContext(2)]
		public IReadOnlyList<PhantomBattleChallenge> GetPhantomBattleChallengeByMapId(int mapId)
		{
			return ConfigPhantomBattleChallengeByMapId.GetConfigList(mapId, true);
		}
	}
}
