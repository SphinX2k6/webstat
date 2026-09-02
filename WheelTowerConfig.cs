using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001708 RID: 5896
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class WheelTowerConfig : ConfigBase<WheelTowerConfig>
{
	// Token: 0x0600A357 RID: 41815 RVA: 0x002B29F9 File Offset: 0x002B0BF9
	public NewTowerParam? GetTowerConfig(int cycleId)
	{
		return ConfigNewTowerParamByCycleId.GetConfig(cycleId, true);
	}

	// Token: 0x0600A358 RID: 41816 RVA: 0x002B2A02 File Offset: 0x002B0C02
	public NewTowerLevel? GetLevelConfigById(int levelId)
	{
		return ConfigNewTowerLevelById.GetConfig(levelId, true);
	}

	// Token: 0x0600A359 RID: 41817 RVA: 0x002B2A0B File Offset: 0x002B0C0B
	public IReadOnlyList<NewTowerLevel> GetLevelConfigListByCycleId(int cycleId)
	{
		return ConfigNewTowerLevelByCycleId.GetConfigList(cycleId, true);
	}

	// Token: 0x0600A35A RID: 41818 RVA: 0x002B2A14 File Offset: 0x002B0C14
	public NewTowerWave? GetWaveConfigById(int waveId)
	{
		return ConfigNewTowerWaveById.GetConfig(waveId, true);
	}

	// Token: 0x0600A35B RID: 41819 RVA: 0x002B2A1D File Offset: 0x002B0C1D
	public IReadOnlyList<NewTowerWave> GetWaveConfigListByLevelId(int levelId)
	{
		return ConfigNewTowerWaveByLevel.GetConfigList(levelId, true);
	}

	// Token: 0x0600A35C RID: 41820 RVA: 0x002B2A26 File Offset: 0x002B0C26
	public NewTowerBossBuff? GetBossBuffConfigById(int buffId)
	{
		return ConfigNewTowerBossBuffById.GetConfig(buffId, true);
	}

	// Token: 0x0600A35D RID: 41821 RVA: 0x002B2A2F File Offset: 0x002B0C2F
	public NewTowerBuff? GetBuffConfigById(int buffId)
	{
		return ConfigNewTowerBuffById.GetConfig(buffId, true);
	}

	// Token: 0x0600A35E RID: 41822 RVA: 0x002B2A38 File Offset: 0x002B0C38
	public NewTowerScoreReward? GetRewardConfigById(int rewardId)
	{
		return ConfigNewTowerScoreRewardById.GetConfig(rewardId, true);
	}

	// Token: 0x0600A35F RID: 41823 RVA: 0x002B2A41 File Offset: 0x002B0C41
	public IReadOnlyList<NewTowerScoreReward> GetRewardConfigListByLevelId(int levelId)
	{
		return ConfigNewTowerScoreRewardByLevelId.GetConfigList(levelId, true);
	}

	// Token: 0x0600A360 RID: 41824 RVA: 0x002B2A4A File Offset: 0x002B0C4A
	public IReadOnlyList<NewTowerRole> GetRoleConfigList()
	{
		return ConfigNewTowerRoleAll.GetConfigList(true);
	}

	// Token: 0x0600A361 RID: 41825 RVA: 0x002B2A52 File Offset: 0x002B0C52
	public NewTowerRole? GetRoleConfigByRoleId(int roleId)
	{
		return ConfigNewTowerRoleById.GetConfig(roleId, true);
	}

	// Token: 0x0600A362 RID: 41826 RVA: 0x002B2A5B File Offset: 0x002B0C5B
	public NewTowerTag? GetTagConfigByTagId(int tagId)
	{
		return ConfigNewTowerTagById.GetConfig(tagId, true);
	}

	// Token: 0x0600A363 RID: 41827 RVA: 0x002B2A64 File Offset: 0x002B0C64
	public NewTowerBossBuff? GetBossBuffConfig(int id)
	{
		return ConfigNewTowerBossBuffById.GetConfig(id, true);
	}

	// Token: 0x0600A364 RID: 41828 RVA: 0x002B2A6D File Offset: 0x002B0C6D
	public NewTowerSeason? GetSeasonConfig(int seasonId)
	{
		return ConfigNewTowerSeasonById.GetConfig(seasonId, true);
	}

	// Token: 0x0600A365 RID: 41829 RVA: 0x002B2A78 File Offset: 0x002B0C78
	public int GetSeasonScoreItemId(int seasonId)
	{
		if (this.GetSeasonConfig(seasonId) == null)
		{
			return 0;
		}
		NewTowerSeason? newTowerSeason;
		return newTowerSeason.GetValueOrDefault().ScoreItem;
	}

	// Token: 0x0600A366 RID: 41830 RVA: 0x002B2AA7 File Offset: 0x002B0CA7
	public IReadOnlyList<NewTowerSeason> GetAllSeasonConfigs()
	{
		return ConfigNewTowerSeasonAll.GetConfigList(true);
	}

	// Token: 0x0600A367 RID: 41831 RVA: 0x002B2AAF File Offset: 0x002B0CAF
	public NewTowerSeasonAward? GetSeasonTaskRewardConfig(int taskId)
	{
		return ConfigNewTowerSeasonAwardById.GetConfig(taskId, true);
	}

	// Token: 0x0600A368 RID: 41832 RVA: 0x002B2AB8 File Offset: 0x002B0CB8
	public NewTowerSeasonSAward? GetSeasonScoreRewardConfig(int rewardId)
	{
		return ConfigNewTowerSeasonSAwardById.GetConfig(rewardId, true);
	}

	// Token: 0x0600A369 RID: 41833 RVA: 0x002B2AC1 File Offset: 0x002B0CC1
	public IReadOnlyList<NewTowerSeasonSAward> GetSeasonScoreRewardConfigList(int seasonId)
	{
		return ConfigNewTowerSeasonSAwardBySeasonId.GetConfigList(seasonId, true);
	}

	// Token: 0x0600A36A RID: 41834 RVA: 0x002B2ACA File Offset: 0x002B0CCA
	public NewTowerTeamFeature? GetTeamFeatureConfig(int id)
	{
		return ConfigNewTowerTeamFeatureById.GetConfig(id, true);
	}

	// Token: 0x0600A36B RID: 41835 RVA: 0x002B2AD3 File Offset: 0x002B0CD3
	[NullableContext(1)]
	public NewTowerScoreLevel? GetScoreLevelConfigByLevel(string level)
	{
		return ConfigNewTowerScoreLevelByLevel.GetConfig(level, true);
	}

	// Token: 0x0600A36C RID: 41836 RVA: 0x002B2ADC File Offset: 0x002B0CDC
	public NewTowerScoreLevel? GetScoreLevelConfigById(int id)
	{
		return ConfigNewTowerScoreLevelById.GetConfig(id, true);
	}

	// Token: 0x0600A36D RID: 41837 RVA: 0x002B2AE5 File Offset: 0x002B0CE5
	public NewTowerMedal? GetMedalConfigById(int id)
	{
		return ConfigNewTowerMedalById.GetConfig(id, true);
	}

	// Token: 0x0600A36E RID: 41838 RVA: 0x002B2AEE File Offset: 0x002B0CEE
	public IReadOnlyList<NewTowerMedal> GetMedalConfigListByGroupId(int groupId)
	{
		return ConfigNewTowerMedalByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x0600A36F RID: 41839 RVA: 0x002B2AF7 File Offset: 0x002B0CF7
	public IReadOnlyList<NewTowerMedal> GetMedalConfigListBySeasonId(int seasonId)
	{
		return ConfigNewTowerMedalBySeasonId.GetConfigList(seasonId, true);
	}
}
