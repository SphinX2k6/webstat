using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200149D RID: 5277
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PinballConfig : ConfigBase<PinballConfig>
{
	// Token: 0x060093BB RID: 37819 RVA: 0x00270011 File Offset: 0x0026E211
	public PinballActivity? GetPinballActivityConfigByActivityId(int activityId)
	{
		return ConfigPinballActivityByActivityId.GetConfig(activityId, true);
	}

	// Token: 0x060093BC RID: 37820 RVA: 0x0027001A File Offset: 0x0026E21A
	public PinballRoleConfig? GetPinballRoleConfigById(int id)
	{
		return ConfigPinballRoleConfigById.GetConfig(id, true);
	}

	// Token: 0x060093BD RID: 37821 RVA: 0x00270024 File Offset: 0x0026E224
	[NullableContext(1)]
	public int[] GetPinballRoleIdList()
	{
		List<int> list = new List<int>();
		foreach (PinballRoleConfig pinballRoleConfig in (ConfigPinballRoleConfigAll.GetConfigList(true) ?? Array.Empty<PinballRoleConfig>()))
		{
			list.Add(pinballRoleConfig.Id);
		}
		return list.ToArray();
	}

	// Token: 0x060093BE RID: 37822 RVA: 0x0027008C File Offset: 0x0026E28C
	public PinballChapterConfig? GetPinballChapterConfigById(int chapter)
	{
		return ConfigPinballChapterConfigById.GetConfig(chapter, true);
	}

	// Token: 0x060093BF RID: 37823 RVA: 0x00270095 File Offset: 0x0026E295
	public PinballLevelConfig? GetPinballLevelConfigById(int id)
	{
		return ConfigPinballLevelConfigById.GetConfig(id, true);
	}

	// Token: 0x060093C0 RID: 37824 RVA: 0x0027009E File Offset: 0x0026E29E
	[NullableContext(1)]
	public IReadOnlyList<PinballDailyConfig> GetAllPinballDailyConfigList()
	{
		return ConfigPinballDailyConfigAll.GetConfigList(true) ?? Array.Empty<PinballDailyConfig>();
	}

	// Token: 0x060093C1 RID: 37825 RVA: 0x002700AF File Offset: 0x0026E2AF
	public PinballLevelTarget? GetPinballLevelTargetConfigById(int targetId)
	{
		return ConfigPinballLevelTargetById.GetConfig(targetId, true);
	}

	// Token: 0x060093C2 RID: 37826 RVA: 0x002700B8 File Offset: 0x0026E2B8
	public PinballLevelConfig? GetPinballLevelConfigByRoleId(int roleId)
	{
		return ConfigPinballLevelConfigByShowRoleId.GetConfig(roleId, true);
	}

	// Token: 0x060093C3 RID: 37827 RVA: 0x002700C1 File Offset: 0x0026E2C1
	[NullableContext(1)]
	public string CovertOptionIndexToText(int optionIndex)
	{
		switch (optionIndex)
		{
		case 0:
			return "A.";
		case 1:
			return "B.";
		case 2:
			return "C.";
		default:
			return "";
		}
	}

	// Token: 0x060093C4 RID: 37828 RVA: 0x002700EE File Offset: 0x0026E2EE
	public PinballBuffConfig? GetPinballBuffConfigById(int buffId)
	{
		return ConfigPinballBuffConfigById.GetConfig(buffId, true);
	}

	// Token: 0x060093C5 RID: 37829 RVA: 0x002700F8 File Offset: 0x0026E2F8
	[NullableContext(1)]
	public int[] GetPinballBroadcastBuffIdAll()
	{
		IEnumerable<PinballBuffConfig> configList = ConfigPinballBuffConfigAll.GetConfigList(true);
		List<int> list = new List<int>();
		foreach (PinballBuffConfig pinballBuffConfig in configList)
		{
			list.Add(pinballBuffConfig.BuffId);
		}
		return list.ToArray();
	}

	// Token: 0x060093C6 RID: 37830 RVA: 0x00270158 File Offset: 0x0026E358
	public PinballWeaponConfig? GetPinballWeaponConfigById(int id)
	{
		return ConfigPinballWeaponConfigById.GetConfig(id, true);
	}

	// Token: 0x060093C7 RID: 37831 RVA: 0x00270161 File Offset: 0x0026E361
	public PinballMonster? GetPinballMonsterConfigById(int id)
	{
		return ConfigPinballMonsterById.GetConfig(id, true);
	}

	// Token: 0x060093C8 RID: 37832 RVA: 0x0027016A File Offset: 0x0026E36A
	public PinballMonsterType? GetPinballMonsterTypeConfigById(int id)
	{
		return ConfigPinballMonsterTypeById.GetConfig(id, true);
	}

	// Token: 0x060093C9 RID: 37833 RVA: 0x00270173 File Offset: 0x0026E373
	public PinballWeaponMainEntry? GetPinballWeaponMainEntryConfigById(int id)
	{
		return ConfigPinballWeaponMainEntryById.GetConfig(id, true);
	}

	// Token: 0x060093CA RID: 37834 RVA: 0x0027017C File Offset: 0x0026E37C
	public PinballWeaponSubEntry? GetPinballWeaponSubEntryConfigById(int id)
	{
		return ConfigPinballWeaponSubEntryById.GetConfig(id, true);
	}

	// Token: 0x060093CB RID: 37835 RVA: 0x00270185 File Offset: 0x0026E385
	public PinballWeaponAttr? GetPinballWeaponAttrConfigById(int id)
	{
		return ConfigPinballWeaponAttrById.GetConfig(id, true);
	}

	// Token: 0x060093CC RID: 37836 RVA: 0x0027018E File Offset: 0x0026E38E
	public PinballWeaponQuality? GetPinballWeaponQualityConfigById(int qualityId)
	{
		return ConfigPinballWeaponQualityById.GetConfig(qualityId, true);
	}

	// Token: 0x060093CD RID: 37837 RVA: 0x00270198 File Offset: 0x0026E398
	public PinballWeaponType? GetPinballWeaponTypeConfigById(int typeId)
	{
		PinballWeaponType? config = ConfigPinballWeaponTypeById.GetConfig(typeId, true);
		if (config == null)
		{
			return null;
		}
		return config;
	}

	// Token: 0x060093CE RID: 37838 RVA: 0x002701C4 File Offset: 0x0026E3C4
	public string GetPinballWeaponTypeName(int typeId)
	{
		PinballWeaponType? config = ConfigPinballWeaponTypeById.GetConfig(typeId, true);
		if (config == null)
		{
			return null;
		}
		return config.Value.Name;
	}

	// Token: 0x060093CF RID: 37839 RVA: 0x002701F3 File Offset: 0x0026E3F3
	public PinballBdConfig? GetPinballRoleBdConfigById(int bdId)
	{
		return ConfigPinballBdConfigById.GetConfig(bdId, true);
	}

	// Token: 0x060093D0 RID: 37840 RVA: 0x002701FC File Offset: 0x0026E3FC
	public IReadOnlyList<PinballRoleConfig> GetPinballRoleConfigListByActivityId(int activityId)
	{
		return ConfigPinballRoleConfigByActivityId.GetConfigList(activityId, true);
	}

	// Token: 0x060093D1 RID: 37841 RVA: 0x00270205 File Offset: 0x0026E405
	public PinballRoleLevelConfig? GetPinballRoleLevelConfigByGroupIdAndLevel(int groupId, int level)
	{
		return ConfigPinballRoleLevelConfigByGroupIdAndLevel.GetConfig(groupId, level, true);
	}

	// Token: 0x060093D2 RID: 37842 RVA: 0x0027020F File Offset: 0x0026E40F
	public IReadOnlyList<PinballRoleLevelConfig> GetPinballRoleLevelConfigListByGroupId(int groupId)
	{
		return ConfigPinballRoleLevelConfigByGroupId.GetConfigList(groupId, true);
	}

	// Token: 0x060093D3 RID: 37843 RVA: 0x00270218 File Offset: 0x0026E418
	public PinballAttr? GetPinballRoleAttrConfigById(int id)
	{
		return ConfigPinballAttrById.GetConfig(id, true);
	}

	// Token: 0x060093D4 RID: 37844 RVA: 0x00270221 File Offset: 0x0026E421
	public PinballPropertyIndex? GetPinballPropertyIndexConfigById(int id)
	{
		return ConfigPinballPropertyIndexById.GetConfig(id, true);
	}

	// Token: 0x060093D5 RID: 37845 RVA: 0x0027022A File Offset: 0x0026E42A
	public PinballClassConfig? GetPinballClassConfigById(int id)
	{
		return ConfigPinballClassConfigById.GetConfig(id, true);
	}

	// Token: 0x060093D6 RID: 37846 RVA: 0x00270233 File Offset: 0x0026E433
	public PinballSkillDisplayConfig? GetPinballSkillDisplayConfigById(int id)
	{
		return ConfigPinballSkillDisplayConfigById.GetConfig(id, true);
	}

	// Token: 0x060093D7 RID: 37847 RVA: 0x0027023C File Offset: 0x0026E43C
	public PinballTask? GetPinballTaskConfigById(int id)
	{
		return ConfigPinballTaskById.GetConfig(id, true);
	}

	// Token: 0x060093D8 RID: 37848 RVA: 0x00270245 File Offset: 0x0026E445
	public PinballRank? GetPinballRankConfigByTower(int towerLevel)
	{
		return ConfigPinballRankByTower.GetConfig(towerLevel, true);
	}

	// Token: 0x060093D9 RID: 37849 RVA: 0x0027024E File Offset: 0x0026E44E
	public PinballRank? GetPinballRankConfigById(int id)
	{
		return ConfigPinballRankById.GetConfig(id, true);
	}

	// Token: 0x060093DA RID: 37850 RVA: 0x00270257 File Offset: 0x0026E457
	public IReadOnlyList<PinballRank> GetAllPinballRankConfigList()
	{
		return ConfigPinballRankAll.GetConfigList(true);
	}

	// Token: 0x060093DB RID: 37851 RVA: 0x0027025F File Offset: 0x0026E45F
	public PinballBdConfig? GetPinballBdConfigById(int id)
	{
		return ConfigPinballBdConfigById.GetConfig(id, true);
	}

	// Token: 0x060093DC RID: 37852 RVA: 0x00270268 File Offset: 0x0026E468
	public IReadOnlyList<PinballWaveConfig> GetPinballWaveConfigListByLevel(int level)
	{
		return ConfigPinballWaveConfigByLevel.GetConfigList(level, true);
	}

	// Token: 0x060093DD RID: 37853 RVA: 0x00270271 File Offset: 0x0026E471
	public PinballSpawnConfig? GetPinballSpawnConfigById(int id)
	{
		return ConfigPinballSpawnConfigById.GetConfig(id, true);
	}

	// Token: 0x060093DE RID: 37854 RVA: 0x0027027A File Offset: 0x0026E47A
	public PinballMonsterSkillDisplay? GetPinballMonsterSkillDisplayConfigById(int id)
	{
		return ConfigPinballMonsterSkillDisplayById.GetConfig(id, true);
	}

	// Token: 0x060093DF RID: 37855 RVA: 0x00270283 File Offset: 0x0026E483
	public PinballMonsterRiskType? GetPinballMonsterRiskTypeConfigById(int riskTypeId)
	{
		return ConfigPinballMonsterRiskTypeById.GetConfig(riskTypeId, true);
	}

	// Token: 0x060093E0 RID: 37856 RVA: 0x0027028C File Offset: 0x0026E48C
	public PinballAvgStyleConfig? GetPinballAvgStyleConfigById(int style)
	{
		return ConfigPinballAvgStyleConfigById.GetConfig(style, true);
	}
}
