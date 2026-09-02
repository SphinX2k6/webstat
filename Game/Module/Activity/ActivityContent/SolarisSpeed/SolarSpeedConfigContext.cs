using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SolarisSpeed
{
	// Token: 0x0200636D RID: 25453
	[NullableContext(1)]
	[Nullable(0)]
	public class SolarSpeedConfigContext : ActivityBaseData
	{
		// Token: 0x17009CDE RID: 40158
		// (get) Token: 0x0603FE93 RID: 261779 RVA: 0x01064B03 File Offset: 0x01062D03
		public Dictionary<int, TeamParKOurCfg> CurrentCfgCache
		{
			get
			{
				if (this.CurrentCfgCacheInternal == null)
				{
					this.InitCurrentCfgCache();
				}
				return this.CurrentCfgCacheInternal;
			}
		}

		// Token: 0x17009CDF RID: 40159
		// (get) Token: 0x0603FE94 RID: 261780 RVA: 0x01064B19 File Offset: 0x01062D19
		public Dictionary<int, TeamParKOurReward> CurrentRewardCache
		{
			get
			{
				if (this.CurrentRewardCacheInternal == null)
				{
					this.InitCurrentRewardCache();
				}
				return this.CurrentRewardCacheInternal;
			}
		}

		// Token: 0x17009CE0 RID: 40160
		// (get) Token: 0x0603FE95 RID: 261781 RVA: 0x01064B30 File Offset: 0x01062D30
		public List<SettleFlag> SortedSettleCfgCache
		{
			get
			{
				if (this.SortedSettleCfgCacheInternal == null)
				{
					this.SortedSettleCfgCacheInternal = new List<SettleFlag>();
					IReadOnlyList<SettleFlag> configList = ConfigSettleFlagAll.GetConfigList(true);
					if (configList != null)
					{
						foreach (SettleFlag item in configList)
						{
							this.SortedSettleCfgCacheInternal.Add(item);
						}
						this.SortedSettleCfgCacheInternal.Sort((SettleFlag a, SettleFlag b) => a.Priority - b.Priority);
					}
				}
				return this.SortedSettleCfgCacheInternal;
			}
		}

		// Token: 0x17009CE1 RID: 40161
		// (get) Token: 0x0603FE96 RID: 261782 RVA: 0x01064BCC File Offset: 0x01062DCC
		private Dictionary<int, int> InstanceId2LevelIdReverseMap
		{
			get
			{
				if (this.InstanceId2LevelIdReverseCacheInternal == null)
				{
					this.InitCurrentCfgCache();
				}
				return this.InstanceId2LevelIdReverseCacheInternal;
			}
		}

		// Token: 0x0603FE97 RID: 261783 RVA: 0x01064BE4 File Offset: 0x01062DE4
		private void InitCurrentCfgCache()
		{
			this.CurrentCfgCacheInternal = new Dictionary<int, TeamParKOurCfg>();
			this.InstanceId2LevelIdReverseCacheInternal = new Dictionary<int, int>();
			foreach (TeamParKOurCfg value in ConfigTeamParKOurCfgAll.GetConfigList(true))
			{
				if (value.ActivityId == this.AttachedModel.CurrentActivityId)
				{
					this.CurrentCfgCacheInternal[value.Id] = value;
					this.InstanceId2LevelIdReverseCacheInternal[value.InstId] = value.Id;
				}
			}
		}

		// Token: 0x0603FE98 RID: 261784 RVA: 0x01064C80 File Offset: 0x01062E80
		private void InitCurrentRewardCache()
		{
			this.CurrentRewardCacheInternal = new Dictionary<int, TeamParKOurReward>();
			foreach (TeamParKOurReward value in ConfigTeamParKOurRewardAll.GetConfigList(true))
			{
				if (value.ActivityId == this.AttachedModel.CurrentActivityId)
				{
					this.CurrentRewardCacheInternal[value.Id] = value;
				}
			}
		}

		// Token: 0x0603FE99 RID: 261785 RVA: 0x01064CF8 File Offset: 0x01062EF8
		public SolarSpeedConfigContext(SolarSpeedModel model)
		{
			this.AttachedModel = model;
		}

		// Token: 0x0603FE9A RID: 261786 RVA: 0x01064D07 File Offset: 0x01062F07
		public void Dispose()
		{
			this.CurrentCfgCache.Clear();
			this.CurrentRewardCache.Clear();
		}

		// Token: 0x0603FE9B RID: 261787 RVA: 0x01064D20 File Offset: 0x01062F20
		[NullableContext(2)]
		public string GetInfoPicturePathById(int id)
		{
			TeamParKOurCfg teamParKOurCfg;
			if (!this.CurrentCfgCache.TryGetValue(id, out teamParKOurCfg))
			{
				return null;
			}
			return teamParKOurCfg.DescPicPath;
		}

		// Token: 0x0603FE9C RID: 261788 RVA: 0x01064D48 File Offset: 0x01062F48
		public int? GetLevelIdByInstanceId(int instanceId)
		{
			int value;
			if (!this.InstanceId2LevelIdReverseMap.TryGetValue(instanceId, out value))
			{
				return null;
			}
			return new int?(value);
		}

		// Token: 0x0603FE9D RID: 261789 RVA: 0x01064D78 File Offset: 0x01062F78
		[NullableContext(2)]
		public string GetInfoPicturePathByInstanceId(int instanceId)
		{
			int? levelIdByInstanceId = this.GetLevelIdByInstanceId(instanceId);
			if (levelIdByInstanceId == null)
			{
				return null;
			}
			return this.GetInfoPicturePathById(levelIdByInstanceId.Value);
		}

		// Token: 0x0603FE9E RID: 261790 RVA: 0x01064DA8 File Offset: 0x01062FA8
		[NullableContext(2)]
		public string GetTitleTextIdById(int id)
		{
			TeamParKOurCfg teamParKOurCfg;
			if (!this.CurrentCfgCache.TryGetValue(id, out teamParKOurCfg))
			{
				return null;
			}
			if (ConfigInstanceDungeonById.GetConfig(teamParKOurCfg.InstId, true) == null)
			{
				return null;
			}
			InstanceDungeon? instanceDungeon;
			return instanceDungeon.GetValueOrDefault().MapName;
		}

		// Token: 0x0603FE9F RID: 261791 RVA: 0x01064DF0 File Offset: 0x01062FF0
		[NullableContext(2)]
		public string GetRomePathById(int id)
		{
			TeamParKOurCfg teamParKOurCfg;
			if (!this.CurrentCfgCache.TryGetValue(id, out teamParKOurCfg))
			{
				return null;
			}
			int instId = teamParKOurCfg.InstId;
			if (ConfigInstanceDungeonById.GetConfig(instId, true) == null)
			{
				return null;
			}
			InstanceDungeon? instanceDungeon;
			return instanceDungeon.GetValueOrDefault().DifficultyIcon;
		}

		// Token: 0x0603FEA0 RID: 261792 RVA: 0x01064E3C File Offset: 0x0106303C
		public IReadOnlyList<int> GetTaskListById(int id)
		{
			if (id == 99)
			{
				return SolarSpeedDefine.bonusRewardList;
			}
			TeamParKOurCfg teamParKOurCfg;
			if (!this.CurrentCfgCache.TryGetValue(id, out teamParKOurCfg) || teamParKOurCfg.GetTaskListArray() == null)
			{
				return new List<int>();
			}
			return teamParKOurCfg.GetTaskListArray();
		}

		// Token: 0x0603FEA1 RID: 261793 RVA: 0x01064E80 File Offset: 0x01063080
		public int GetRewardThresholdById(int id)
		{
			TeamParKOurReward teamParKOurReward;
			if (!this.CurrentRewardCache.TryGetValue(id, out teamParKOurReward))
			{
				return 0;
			}
			return teamParKOurReward.RewardThreshold;
		}

		// Token: 0x0603FEA2 RID: 261794 RVA: 0x01064EA8 File Offset: 0x010630A8
		public List<TItem> GetRewardItemDataListById(int id)
		{
			List<TItem> result = new List<TItem>();
			TeamParKOurReward? config = ConfigTeamParKOurRewardById.GetConfig(id, true);
			if (config == null)
			{
				return result;
			}
			if (config.Value.Reward == 0)
			{
				return result;
			}
			return ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(config.Value.Reward);
		}

		// Token: 0x0603FEA3 RID: 261795 RVA: 0x01064EFC File Offset: 0x010630FC
		[NullableContext(2)]
		public string GetRewardTitleTextId(int id)
		{
			if (ConfigTeamParKOurRewardById.GetConfig(id, true) == null)
			{
				return null;
			}
			TeamParKOurReward? teamParKOurReward;
			return teamParKOurReward.GetValueOrDefault().TaskTitle;
		}

		// Token: 0x04023E81 RID: 147073
		private readonly SolarSpeedModel AttachedModel;

		// Token: 0x04023E82 RID: 147074
		[Nullable(2)]
		private Dictionary<int, TeamParKOurCfg> CurrentCfgCacheInternal;

		// Token: 0x04023E83 RID: 147075
		[Nullable(2)]
		private Dictionary<int, TeamParKOurReward> CurrentRewardCacheInternal;

		// Token: 0x04023E84 RID: 147076
		[Nullable(2)]
		private Dictionary<int, int> InstanceId2LevelIdReverseCacheInternal;

		// Token: 0x04023E85 RID: 147077
		[Nullable(2)]
		private List<SettleFlag> SortedSettleCfgCacheInternal;
	}
}
