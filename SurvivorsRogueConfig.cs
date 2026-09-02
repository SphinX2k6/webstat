using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002B87 RID: 11143
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SurvivorsRogueConfig : ConfigBase<SurvivorsRogueConfig>
{
	// Token: 0x06016302 RID: 90882 RVA: 0x00627FFA File Offset: 0x006261FA
	public SurvivorsActivityConfig? GetSurvivorsActivityConfigByActivityId(int activityId)
	{
		return ConfigSurvivorsActivityConfigByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x06016303 RID: 90883 RVA: 0x00628004 File Offset: 0x00626204
	public IReadOnlyList<SurvivorsLevel> GetAllSurvivorsLevelByActId(int actId)
	{
		IReadOnlyList<SurvivorsLevel> configList = ConfigSurvivorsLevelByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsLevel>();
	}

	// Token: 0x06016304 RID: 90884 RVA: 0x00628023 File Offset: 0x00626223
	public SurvivorsLevel? GetSurvivorsLevel(int levelId)
	{
		return ConfigSurvivorsLevelById.GetConfig(levelId, true);
	}

	// Token: 0x06016305 RID: 90885 RVA: 0x0062802C File Offset: 0x0062622C
	public int GetMaxWaveNumByLevelId(int levelId)
	{
		IReadOnlyList<SurvivorsWave> configList = ConfigSurvivorsWaveByLevel.GetConfigList(levelId, true);
		if (configList == null)
		{
			return 0;
		}
		return configList.Count;
	}

	// Token: 0x06016306 RID: 90886 RVA: 0x0062804C File Offset: 0x0062624C
	public int GetWaveDuration(int levelId, int waveId)
	{
		IReadOnlyList<SurvivorsWave> configList = ConfigSurvivorsWaveByLevel.GetConfigList(levelId, true);
		if (configList == null)
		{
			return 0;
		}
		for (int i = 0; i < configList.Count; i++)
		{
			SurvivorsWave survivorsWave = configList[i];
			if (survivorsWave.Wave == waveId)
			{
				return survivorsWave.WaveTime;
			}
		}
		return 0;
	}

	// Token: 0x06016307 RID: 90887 RVA: 0x00628094 File Offset: 0x00626294
	public int GetWaveType(int levelId, int waveId)
	{
		IReadOnlyList<SurvivorsWave> configList = ConfigSurvivorsWaveByLevel.GetConfigList(levelId, true);
		if (configList == null)
		{
			return 0;
		}
		for (int i = 0; i < configList.Count; i++)
		{
			SurvivorsWave survivorsWave = configList[i];
			if (survivorsWave.Wave == waveId)
			{
				return survivorsWave.WaveType;
			}
		}
		return 0;
	}

	// Token: 0x06016308 RID: 90888 RVA: 0x006280DC File Offset: 0x006262DC
	public bool IsBonusWave(int levelId, int waveId)
	{
		IReadOnlyList<SurvivorsWave> configList = ConfigSurvivorsWaveByLevel.GetConfigList(levelId, true);
		if (configList == null)
		{
			return false;
		}
		for (int i = 0; i < configList.Count; i++)
		{
			SurvivorsWave survivorsWave = configList[i];
			if (survivorsWave.Wave == waveId)
			{
				return survivorsWave.TreasurePoolLength > 0;
			}
		}
		return false;
	}

	// Token: 0x06016309 RID: 90889 RVA: 0x00628128 File Offset: 0x00626328
	public bool IsBoss(int templateId)
	{
		SurvivorsMonsterType? config = ConfigSurvivorsMonsterTypeByTemplateId.GetConfig(templateId, true);
		return config != null && config.Value.RiskType == 3;
	}

	// Token: 0x0601630A RID: 90890 RVA: 0x0062815C File Offset: 0x0062635C
	public IReadOnlyList<SurvivorsRole> GetAllSurvivorsRoleByActId(int actId)
	{
		IReadOnlyList<SurvivorsRole> configList = ConfigSurvivorsRoleByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsRole>();
	}

	// Token: 0x0601630B RID: 90891 RVA: 0x0062817B File Offset: 0x0062637B
	public SurvivorsRole? GetSurvivorsRole(int roleId)
	{
		return ConfigSurvivorsRoleById.GetConfig(roleId, true);
	}

	// Token: 0x0601630C RID: 90892 RVA: 0x00628184 File Offset: 0x00626384
	public SurvivorsRoleLv? GetSurvivorsRoleLv(int lvId)
	{
		return ConfigSurvivorsRoleLvById.GetConfig(lvId, true);
	}

	// Token: 0x0601630D RID: 90893 RVA: 0x00628190 File Offset: 0x00626390
	public IReadOnlyList<SurvivorsRoleLv> GetSurvivorsRoleLvListByRoleId(int roleId)
	{
		IReadOnlyList<SurvivorsRoleLv> configList = ConfigSurvivorsRoleLvByRoleId.GetConfigList(roleId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsRoleLv>();
	}

	// Token: 0x0601630E RID: 90894 RVA: 0x006281AF File Offset: 0x006263AF
	public SurvivorsRoleEvolve? GetSurvivorsRoleEvolve(int evolveId)
	{
		return ConfigSurvivorsRoleEvolveById.GetConfig(evolveId, true);
	}

	// Token: 0x0601630F RID: 90895 RVA: 0x006281B8 File Offset: 0x006263B8
	public SurvivorsRoleEvolve? GetSurvivorsRoleDefaultEvolve(int roleId)
	{
		SurvivorsRole? survivorsRole = this.GetSurvivorsRole(roleId);
		if (survivorsRole == null)
		{
			return null;
		}
		int num = 0;
		int num2 = int.MaxValue;
		for (int i = 0; i < survivorsRole.Value.EvolveIdsLength; i++)
		{
			DicIntInt? dicIntInt = survivorsRole.Value.EvolveIds(i);
			if (dicIntInt != null && dicIntInt.Value.Value <= num2)
			{
				num2 = dicIntInt.Value.Value;
				num = dicIntInt.Value.Key;
			}
		}
		if (num == 0)
		{
			return null;
		}
		return this.GetSurvivorsRoleEvolve(num);
	}

	// Token: 0x06016310 RID: 90896 RVA: 0x00628270 File Offset: 0x00626470
	public IReadOnlyList<SurvivorsWeapon> GetAllSurvivorsWeaponByActId(int actId)
	{
		IReadOnlyList<SurvivorsWeapon> configList = ConfigSurvivorsWeaponByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsWeapon>();
	}

	// Token: 0x06016311 RID: 90897 RVA: 0x0062828F File Offset: 0x0062648F
	public SurvivorsWeapon? GetSurvivorsWeapon(int weaponId)
	{
		return ConfigSurvivorsWeaponById.GetConfig(weaponId, true);
	}

	// Token: 0x06016312 RID: 90898 RVA: 0x00628298 File Offset: 0x00626498
	public SurvivorsWeaponEvolve? GetSurvivorsWeaponDefaultEvolve(int weaponId)
	{
		SurvivorsWeapon? survivorsWeapon = this.GetSurvivorsWeapon(weaponId);
		if (survivorsWeapon == null)
		{
			return null;
		}
		int num = 0;
		int num2 = int.MaxValue;
		for (int i = 0; i < survivorsWeapon.Value.EvolveIdsLength; i++)
		{
			DicIntInt? dicIntInt = survivorsWeapon.Value.EvolveIds(i);
			if (dicIntInt != null && dicIntInt.Value.Value <= num2)
			{
				num2 = dicIntInt.Value.Value;
				num = dicIntInt.Value.Key;
			}
		}
		if (num == 0)
		{
			return null;
		}
		return this.GetSurvivorsWeaponEvolve(num);
	}

	// Token: 0x06016313 RID: 90899 RVA: 0x0062834D File Offset: 0x0062654D
	public SurvivorsWeaponLv? GetSurvivorsWeaponLv(int lvId)
	{
		return ConfigSurvivorsWeaponLvById.GetConfig(lvId, true);
	}

	// Token: 0x06016314 RID: 90900 RVA: 0x00628358 File Offset: 0x00626558
	public IReadOnlyList<SurvivorsWeaponLv> GetSurvivorsWeaponLvListByWeaponId(int weaponId)
	{
		IReadOnlyList<SurvivorsWeaponLv> configList = ConfigSurvivorsWeaponLvByWeaponId.GetConfigList(weaponId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsWeaponLv>();
	}

	// Token: 0x06016315 RID: 90901 RVA: 0x00628377 File Offset: 0x00626577
	public SurvivorsWeaponEvolve? GetSurvivorsWeaponEvolve(int evolveId)
	{
		return ConfigSurvivorsWeaponEvolveById.GetConfig(evolveId, true);
	}

	// Token: 0x06016316 RID: 90902 RVA: 0x00628380 File Offset: 0x00626580
	public IReadOnlyList<SurvivorsTalentTree> GetAllTalentTreeNodeByActId(int actId)
	{
		IReadOnlyList<SurvivorsTalentTree> configList = ConfigSurvivorsTalentTreeByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsTalentTree>();
	}

	// Token: 0x06016317 RID: 90903 RVA: 0x0062839F File Offset: 0x0062659F
	public SurvivorsTalentTree? GetTalentTreeNode(int nodeId)
	{
		return ConfigSurvivorsTalentTreeById.GetConfig(nodeId, true);
	}

	// Token: 0x06016318 RID: 90904 RVA: 0x006283A8 File Offset: 0x006265A8
	public SurvivorsTalentEffect? GetTalentTreeEffect(int effectId)
	{
		return ConfigSurvivorsTalentEffectById.GetConfig(effectId, true);
	}

	// Token: 0x06016319 RID: 90905 RVA: 0x006283B4 File Offset: 0x006265B4
	public IReadOnlyList<SurvivorsItem> GetAllSurvivorsItemByActId(int actId)
	{
		IReadOnlyList<SurvivorsItem> configList = ConfigSurvivorsItemByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsItem>();
	}

	// Token: 0x0601631A RID: 90906 RVA: 0x006283D3 File Offset: 0x006265D3
	public SurvivorsItem? GetSurvivorsItem(int weaponId)
	{
		return ConfigSurvivorsItemById.GetConfig(weaponId, true);
	}

	// Token: 0x0601631B RID: 90907 RVA: 0x006283DC File Offset: 0x006265DC
	public SurvivorsQuality? GetQualityConfig(int qualityId)
	{
		return ConfigSurvivorsQualityById.GetConfig(qualityId, true);
	}

	// Token: 0x0601631C RID: 90908 RVA: 0x006283E5 File Offset: 0x006265E5
	public SurvivorsProperty? GetPropertyConfig(int propertyId)
	{
		return ConfigSurvivorsPropertyById.GetConfig(propertyId, true);
	}

	// Token: 0x0601631D RID: 90909 RVA: 0x006283EE File Offset: 0x006265EE
	[NullableContext(2)]
	public IReadOnlyList<SkillGameplayButton> GetSkillButtonConfigByType(int type)
	{
		return ConfigSkillGameplayButtonByGameplayType.GetConfigList(type, true);
	}

	// Token: 0x0601631E RID: 90910 RVA: 0x006283F8 File Offset: 0x006265F8
	public SurvivorsCombo? GetComboConfig(int levelId)
	{
		SurvivorsLevel? survivorsLevel = this.GetSurvivorsLevel(levelId);
		if (survivorsLevel == null)
		{
			return null;
		}
		return ConfigSurvivorsComboById.GetConfig(survivorsLevel.Value.ComboCfgId, true);
	}

	// Token: 0x0601631F RID: 90911 RVA: 0x00628435 File Offset: 0x00626635
	public SurvivorsTask? GetSurvivorsTask(int taskId)
	{
		return ConfigSurvivorsTaskById.GetConfig(taskId, true);
	}

	// Token: 0x06016320 RID: 90912 RVA: 0x00628440 File Offset: 0x00626640
	public IReadOnlyList<SurvivorsTask> GetSurvivorsTaskByActId(int actId)
	{
		IReadOnlyList<SurvivorsTask> configList = ConfigSurvivorsTaskByActivityId.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsTask>();
	}

	// Token: 0x06016321 RID: 90913 RVA: 0x00628460 File Offset: 0x00626660
	public IReadOnlyList<SurvivorsScoreReward> GetAllSurvivorsScoreRewardByActId(int actId)
	{
		IReadOnlyList<SurvivorsScoreReward> configList = ConfigSurvivorsScoreRewardByActivity.GetConfigList(actId, true);
		if (configList != null)
		{
			return configList;
		}
		return new List<SurvivorsScoreReward>();
	}
}
