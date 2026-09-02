using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002BD7 RID: 11223
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class TowerClimbConfig : ConfigBase<TowerClimbConfig>
{
	// Token: 0x0601665A RID: 91738 RVA: 0x00637E90 File Offset: 0x00636090
	public int GetAreaFloorNumber(int season, int difficulty, int area)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		int num = 0;
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == difficulty && towerConfig.AreaNum == area)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0601665B RID: 91739 RVA: 0x00637F00 File Offset: 0x00636100
	public int GetDifficultyFloorNumber(int season, int difficulty)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		int num = 0;
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == difficulty)
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x0601665C RID: 91740 RVA: 0x00637F64 File Offset: 0x00636164
	public int GetDifficultyLastFloor(int season, int difficulty)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		int num = -1;
		int num2 = -1;
		int result = -1;
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == difficulty)
				{
					if (num < towerConfig.AreaNum)
					{
						num = towerConfig.AreaNum;
						num2 = -1;
					}
					if (num2 < towerConfig.Floor)
					{
						result = towerConfig.Id;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x0601665D RID: 91741 RVA: 0x00637FF4 File Offset: 0x006361F4
	public int[] GetDifficultyAllFloor(int season, int difficulty)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		List<int> list = new List<int>();
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == difficulty)
				{
					list.Add(towerConfig.Id);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0601665E RID: 91742 RVA: 0x0063806C File Offset: 0x0063626C
	public int[] GetDifficultyAllAreaFirstFloor(int season, int difficulty)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		int num = -1;
		List<int> list = new List<int>();
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == difficulty && num != towerConfig.AreaNum)
				{
					list.Add(towerConfig.Id);
					num = towerConfig.AreaNum;
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x0601665F RID: 91743 RVA: 0x006380F8 File Offset: 0x006362F8
	public int[] GetDifficultyAreaAllFloor(int season, int difficulty, int area)
	{
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList((difficulty == 3) ? season : 0, true);
		List<int> list = new List<int>();
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (difficulty == towerConfig.Difficulty && area == towerConfig.AreaNum)
				{
					list.Add(towerConfig.Id);
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06016660 RID: 91744 RVA: 0x00638178 File Offset: 0x00636378
	[NullableContext(2)]
	public IReadOnlyList<IntPair> GetDifficultyReward(int difficulty, int rewardGroup)
	{
		if (rewardGroup == 0)
		{
			return null;
		}
		IReadOnlyList<TowerSeasonReward> configList = ConfigTowerSeasonRewardByDifficulty.GetConfigList(difficulty, true);
		if (configList == null)
		{
			return null;
		}
		foreach (TowerSeasonReward towerSeasonReward in configList)
		{
			if (towerSeasonReward.RewardGroup == rewardGroup)
			{
				return towerSeasonReward.Reward();
			}
		}
		return null;
	}

	// Token: 0x06016661 RID: 91745 RVA: 0x006381E4 File Offset: 0x006363E4
	public string GetTowerBuffDesc(long buffId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetTowerBuffConfig(buffId).Value.Desc, null);
	}

	// Token: 0x06016662 RID: 91746 RVA: 0x00638210 File Offset: 0x00636410
	public string GetTowerBuffName(long buffId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.GetTowerBuffConfig(buffId).Value.Name, null);
	}

	// Token: 0x06016663 RID: 91747 RVA: 0x0063823C File Offset: 0x0063643C
	[NullableContext(2)]
	public string GetTowerBuffIcon(long buffId)
	{
		TowerBuff? towerBuffConfig = this.GetTowerBuffConfig(buffId);
		if (towerBuffConfig == null)
		{
			return null;
		}
		return towerBuffConfig.GetValueOrDefault().Icon;
	}

	// Token: 0x06016664 RID: 91748 RVA: 0x0063826C File Offset: 0x0063646C
	public TowerBuff? GetTowerBuffConfig(long buffId)
	{
		TowerBuff? config = ConfigTowerBuffById.GetConfig(buffId, true);
		if (config != null)
		{
			return config;
		}
		return null;
	}

	// Token: 0x06016665 RID: 91749 RVA: 0x00638298 File Offset: 0x00636498
	[NullableContext(2)]
	public IReadOnlyList<int> GetFloorTarget(int floorId)
	{
		TowerConfig? config = ConfigTowerConfigById.GetConfig(floorId, true);
		if (config == null)
		{
			return null;
		}
		return config.GetValueOrDefault().TargetConfig();
	}

	// Token: 0x06016666 RID: 91750 RVA: 0x006382C7 File Offset: 0x006364C7
	public TowerTarget? GetTargetConfig(int targetId)
	{
		return ConfigTowerTargetById.GetConfig(targetId, true);
	}

	// Token: 0x06016667 RID: 91751 RVA: 0x006382D0 File Offset: 0x006364D0
	public int GetNextFloorInArea(int towerId)
	{
		TowerConfig? config = ConfigTowerConfigById.GetConfig(towerId, true);
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList(config.Value.Season, true);
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == config.Value.Difficulty && towerConfig.AreaNum == config.Value.AreaNum && towerConfig.Floor > config.Value.Floor)
				{
					return towerConfig.Id;
				}
			}
			return 0;
		}
		return 0;
	}

	// Token: 0x06016668 RID: 91752 RVA: 0x0063838C File Offset: 0x0063658C
	public int GetLastFloorInArea(int towerId)
	{
		TowerConfig? config = ConfigTowerConfigById.GetConfig(towerId, true);
		if (config.Value.Floor == 1)
		{
			return 0;
		}
		IReadOnlyList<TowerConfig> configList = ConfigTowerConfigBySeason.GetConfigList(config.Value.Season, true);
		int result = 0;
		if (configList != null)
		{
			foreach (TowerConfig towerConfig in configList)
			{
				if (towerConfig.Difficulty == config.Value.Difficulty && towerConfig.AreaNum == config.Value.AreaNum && towerConfig.Floor < config.Value.Floor)
				{
					result = towerConfig.Id;
				}
			}
		}
		return result;
	}

	// Token: 0x06016669 RID: 91753 RVA: 0x0063845C File Offset: 0x0063665C
	public TowerConfig? GetTowerInfo(int towerId)
	{
		return ConfigTowerConfigById.GetConfig(towerId, true);
	}

	// Token: 0x0601666A RID: 91754 RVA: 0x00638465 File Offset: 0x00636665
	public TowerSeason? GetTowerSeason(int seasonId)
	{
		return ConfigTowerSeasonById.GetConfig(seasonId, true);
	}

	// Token: 0x0601666B RID: 91755 RVA: 0x00638470 File Offset: 0x00636670
	public string GetTowerAreaName(int towerId)
	{
		return ConfigMultiTextLang.GetLocalTextNew(ConfigTowerConfigById.GetConfig(towerId, true).Value.AreaName, null);
	}

	// Token: 0x0601666C RID: 91756 RVA: 0x0063849C File Offset: 0x0063669C
	public string GetNewTowerDifficultTitle(int difficultId)
	{
		switch (difficultId)
		{
		case 1:
			return ConfigMultiTextLang.GetLocalTextNew("NewTower_Diffcult_1", null) ?? string.Empty;
		case 2:
			return ConfigMultiTextLang.GetLocalTextNew("NewTower_Diffcult_2", null) ?? string.Empty;
		case 3:
			return ConfigMultiTextLang.GetLocalTextNew("NewTower_Diffcult_3", null) ?? string.Empty;
		case 4:
			return ConfigMultiTextLang.GetLocalTextNew("NewTower_Diffcult_4", null) ?? string.Empty;
		default:
			return ConfigMultiTextLang.GetLocalTextNew("NewTower_Diffcult_1", null) ?? string.Empty;
		}
	}
}
