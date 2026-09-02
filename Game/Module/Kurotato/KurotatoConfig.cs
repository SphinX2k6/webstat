using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A28 RID: 23080
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class KurotatoConfig : ConfigBase<KurotatoConfig>
	{
		// Token: 0x0603A6FA RID: 239354 RVA: 0x00ED1697 File Offset: 0x00ECF897
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603A6FB RID: 239355 RVA: 0x00ED169A File Offset: 0x00ECF89A
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603A6FC RID: 239356 RVA: 0x00ED169D File Offset: 0x00ECF89D
		public bool IsServerCtrlProperty(int propertyId)
		{
			IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("KurotatoServerCtrlProperty");
			return intArrayConfig != null && intArrayConfig.Contains(propertyId);
		}

		// Token: 0x0603A6FD RID: 239357 RVA: 0x00ED16B5 File Offset: 0x00ECF8B5
		public KurotatoItem? GetItemConfigByItemId(int itemId)
		{
			return ConfigKurotatoItemById.GetConfig(itemId, true);
		}

		// Token: 0x0603A6FE RID: 239358 RVA: 0x00ED16BE File Offset: 0x00ECF8BE
		[NullableContext(2)]
		public IReadOnlyList<KurotatoItem> GetItemConfigList()
		{
			return ConfigKurotatoItemAll.GetConfigList(true);
		}

		// Token: 0x0603A6FF RID: 239359 RVA: 0x00ED16C6 File Offset: 0x00ECF8C6
		public KurotatoQuality? GetQualityByQuality(int quality)
		{
			return ConfigKurotatoQualityById.GetConfig(quality, true);
		}

		// Token: 0x0603A700 RID: 239360 RVA: 0x00ED16CF File Offset: 0x00ECF8CF
		[NullableContext(2)]
		public IReadOnlyList<KurotatoQuality> GetQualityList()
		{
			return ConfigKurotatoQualityAll.GetConfigList(true);
		}

		// Token: 0x0603A701 RID: 239361 RVA: 0x00ED16D8 File Offset: 0x00ECF8D8
		public int GetMaxQualityByGroupId(int groupId)
		{
			IReadOnlyList<KurotatoWeapon> configList = ConfigKurotatoWeaponByGroupId.GetConfigList(groupId, true);
			int num = 0;
			if (configList == null)
			{
				return num;
			}
			foreach (KurotatoWeapon kurotatoWeapon in configList)
			{
				num = Math.Max(num, kurotatoWeapon.Quality);
			}
			return num;
		}

		// Token: 0x0603A702 RID: 239362 RVA: 0x00ED1738 File Offset: 0x00ECF938
		public int GetHelpIdRoleInfo()
		{
			return ConfigCommonParamById.GetIntConfig("KurotatoRoleInfoHelpId").GetValueOrDefault();
		}

		// Token: 0x0603A703 RID: 239363 RVA: 0x00ED1758 File Offset: 0x00ECF958
		public int GetHelpIdAttrInfo()
		{
			return ConfigCommonParamById.GetIntConfig("KurotatoAttrInfoHelpId").GetValueOrDefault();
		}

		// Token: 0x0603A704 RID: 239364 RVA: 0x00ED1778 File Offset: 0x00ECF978
		public int GetHelpIdAttrSelect()
		{
			return ConfigCommonParamById.GetIntConfig("KurotatoAttrSelectHelpId").GetValueOrDefault();
		}

		// Token: 0x0603A705 RID: 239365 RVA: 0x00ED1798 File Offset: 0x00ECF998
		public int GetHelpIdShop()
		{
			return ConfigCommonParamById.GetIntConfig("KurotatoShopHelpId").GetValueOrDefault();
		}

		// Token: 0x0603A706 RID: 239366 RVA: 0x00ED17B7 File Offset: 0x00ECF9B7
		public KurotatoFormula? GetFormulaById(int id)
		{
			return ConfigKurotatoFormulaById.GetConfig(id, true);
		}

		// Token: 0x0603A707 RID: 239367 RVA: 0x00ED17C0 File Offset: 0x00ECF9C0
		public List<KurotatoExp> GetExpList()
		{
			List<KurotatoExp> list = ConfigKurotatoExpAll.GetConfigList(true).ToList<KurotatoExp>();
			list.Sort((KurotatoExp a, KurotatoExp b) => a.LevelExp - b.LevelExp);
			return list;
		}

		// Token: 0x0603A708 RID: 239368 RVA: 0x00ED17F4 File Offset: 0x00ECF9F4
		public int GetExpByLevel(int level, int activityConfigId)
		{
			if (ConfigKurotatoExpByLevelAndActivityId.GetConfig(level, activityConfigId, true) == null)
			{
				return 0;
			}
			KurotatoExp? kurotatoExp;
			return kurotatoExp.GetValueOrDefault().LevelExp;
		}

		// Token: 0x0603A709 RID: 239369 RVA: 0x00ED1824 File Offset: 0x00ECFA24
		public int GetMaxLevel(int activityConfigId)
		{
			IEnumerable<KurotatoExp> configList = ConfigKurotatoExpAll.GetConfigList(true);
			int num = 1;
			foreach (KurotatoExp kurotatoExp in configList)
			{
				if (kurotatoExp.ActivityId == activityConfigId)
				{
					num = Math.Max(num, kurotatoExp.RoleLevel);
				}
			}
			return num;
		}

		// Token: 0x0603A70A RID: 239370 RVA: 0x00ED1888 File Offset: 0x00ECFA88
		public KurotatoLevel? GetLevelConfig(int levelId)
		{
			return ConfigKurotatoLevelById.GetConfig(levelId, true);
		}

		// Token: 0x0603A70B RID: 239371 RVA: 0x00ED1891 File Offset: 0x00ECFA91
		[NullableContext(2)]
		public IReadOnlyList<KurotatoLevel> GetLevelListByDifficulty(int difficulty)
		{
			return ConfigKurotatoLevelByDifficulty.GetConfigList(difficulty, true);
		}

		// Token: 0x0603A70C RID: 239372 RVA: 0x00ED189A File Offset: 0x00ECFA9A
		[NullableContext(2)]
		public IReadOnlyList<KurotatoLevel> GetLevelList()
		{
			return ConfigKurotatoLevelAll.GetConfigList(true);
		}

		// Token: 0x0603A70D RID: 239373 RVA: 0x00ED18A2 File Offset: 0x00ECFAA2
		public KurotatoLevelGroup? GetLevelGroupConfig(int id)
		{
			return ConfigKurotatoLevelGroupByGroupId.GetConfig(id, true);
		}

		// Token: 0x0603A70E RID: 239374 RVA: 0x00ED18AB File Offset: 0x00ECFAAB
		public KurotatoWeaponBuild? GetWeaponBuildById(int buildId)
		{
			return ConfigKurotatoWeaponBuildById.GetConfig(buildId, true);
		}

		// Token: 0x0603A70F RID: 239375 RVA: 0x00ED18B4 File Offset: 0x00ECFAB4
		public KurotatoWeaponGroup? GetWeaponGroupById(int groupId)
		{
			return ConfigKurotatoWeaponGroupById.GetConfig(groupId, true);
		}

		// Token: 0x0603A710 RID: 239376 RVA: 0x00ED18BD File Offset: 0x00ECFABD
		public KurotatoWeapon? GetWeaponConfigByWeaponId(int weaponId)
		{
			return ConfigKurotatoWeaponById.GetConfig(weaponId, true);
		}

		// Token: 0x0603A711 RID: 239377 RVA: 0x00ED18C6 File Offset: 0x00ECFAC6
		[NullableContext(2)]
		public IReadOnlyList<KurotatoWeapon> GetWeaponConfigList()
		{
			return ConfigKurotatoWeaponAll.GetConfigList(true);
		}

		// Token: 0x0603A712 RID: 239378 RVA: 0x00ED18D0 File Offset: 0x00ECFAD0
		public KurotatoWeaponGroup? GetWeaponGroupConfigByWeaponId(int weaponId)
		{
			KurotatoWeapon? weaponConfigByWeaponId = this.GetWeaponConfigByWeaponId(weaponId);
			if (weaponConfigByWeaponId == null)
			{
				return null;
			}
			return this.GetWeaponGroupById(weaponConfigByWeaponId.Value.GroupId);
		}

		// Token: 0x0603A713 RID: 239379 RVA: 0x00ED190D File Offset: 0x00ECFB0D
		public KurotatoEffect? GetEffectById(int effectId)
		{
			return ConfigKurotatoEffectById.GetConfig(effectId, true);
		}

		// Token: 0x0603A714 RID: 239380 RVA: 0x00ED1916 File Offset: 0x00ECFB16
		public KurotatoProperty? GetPropertyById(int propertyId)
		{
			return ConfigKurotatoPropertyById.GetConfig(propertyId, true);
		}

		// Token: 0x0603A715 RID: 239381 RVA: 0x00ED191F File Offset: 0x00ECFB1F
		public KurotatoProperty? GetPropertyByName(string propertyName)
		{
			return ConfigKurotatoPropertyByName.GetConfig(propertyName, true);
		}

		// Token: 0x0603A716 RID: 239382 RVA: 0x00ED1928 File Offset: 0x00ECFB28
		public KurotatoProperty? GetPropertyByPropertyVarName(string propertyVarName)
		{
			return ConfigKurotatoPropertyByPropertyVarName.GetConfig(propertyVarName, true);
		}

		// Token: 0x0603A717 RID: 239383 RVA: 0x00ED1931 File Offset: 0x00ECFB31
		public IReadOnlyList<KurotatoProperty> GetAllProperty()
		{
			return ConfigKurotatoPropertyAll.GetConfigList(true) ?? new List<KurotatoProperty>();
		}

		// Token: 0x0603A718 RID: 239384 RVA: 0x00ED1942 File Offset: 0x00ECFB42
		public KurotatoCharacter? GetCharacterById(int characterId)
		{
			return ConfigKurotatoCharacterById.GetConfig(characterId, true);
		}

		// Token: 0x0603A719 RID: 239385 RVA: 0x00ED194B File Offset: 0x00ECFB4B
		[NullableContext(2)]
		public IReadOnlyList<KurotatoCharacter> GetCharacterList()
		{
			return ConfigKurotatoCharacterAll.GetConfigList(true);
		}

		// Token: 0x0603A71A RID: 239386 RVA: 0x00ED1953 File Offset: 0x00ECFB53
		[NullableContext(2)]
		public IReadOnlyList<KurotatoCharacter> GetCharacterListByActivityId(int activityId)
		{
			return ConfigKurotatoCharacterByActivityId.GetConfigList(activityId, true);
		}

		// Token: 0x0603A71B RID: 239387 RVA: 0x00ED195C File Offset: 0x00ECFB5C
		public KurotatoLevelCharacter? GetLevelCharacterByRoleIdAndLevelId(int roleId, int levelId)
		{
			IReadOnlyList<KurotatoLevelCharacter> configList = ConfigKurotatoLevelCharacterByCharacterIdAndLevelId.GetConfigList(roleId, levelId, true);
			if (configList == null || configList.Count == 0)
			{
				return null;
			}
			return new KurotatoLevelCharacter?(configList[0]);
		}

		// Token: 0x0603A71C RID: 239388 RVA: 0x00ED1993 File Offset: 0x00ECFB93
		[NullableContext(2)]
		public IReadOnlyList<KurotatoWaveLevel> GetWaveLevelConfigList()
		{
			return ConfigKurotatoWaveLevelAll.GetConfigList(true);
		}

		// Token: 0x0603A71D RID: 239389 RVA: 0x00ED199B File Offset: 0x00ECFB9B
		public KurotatoActivityConfig? GetActivityConfig(int activityId)
		{
			return ConfigKurotatoActivityConfigByActivityId.GetConfig(activityId, true);
		}

		// Token: 0x0603A71E RID: 239390 RVA: 0x00ED19A4 File Offset: 0x00ECFBA4
		public IReadOnlyList<KurotatoLevel> GetAllKurotatoLevelConfig()
		{
			return ConfigKurotatoLevelAll.GetConfigList(true) ?? new List<KurotatoLevel>();
		}

		// Token: 0x0603A71F RID: 239391 RVA: 0x00ED19B5 File Offset: 0x00ECFBB5
		public KurotatoLevel? GetKurotatoLevelConfig(int levelId)
		{
			return ConfigKurotatoLevelById.GetConfig(levelId, true);
		}

		// Token: 0x0603A720 RID: 239392 RVA: 0x00ED19BE File Offset: 0x00ECFBBE
		public IReadOnlyList<KurotatoLevelGroup> GetAllKurotatoLevelGroupConfig()
		{
			return ConfigKurotatoLevelGroupAll.GetConfigList(true) ?? new List<KurotatoLevelGroup>();
		}

		// Token: 0x0603A721 RID: 239393 RVA: 0x00ED19CF File Offset: 0x00ECFBCF
		public KurotatoLevelGroup? GetKurotatoLevelGroupConfig(int groupId)
		{
			return ConfigKurotatoLevelGroupByGroupId.GetConfig(groupId, true);
		}

		// Token: 0x0603A722 RID: 239394 RVA: 0x00ED19D8 File Offset: 0x00ECFBD8
		public KurotatoLevelSecondGroup? GetLevelSecondGroupConfig(int id)
		{
			return ConfigKurotatoLevelSecondGroupById.GetConfig(id, true);
		}

		// Token: 0x0603A723 RID: 239395 RVA: 0x00ED19E1 File Offset: 0x00ECFBE1
		[NullableContext(2)]
		public IReadOnlyList<KurotatoLevel> GetLevelListBySecondGroup(int secondGroupId)
		{
			return ConfigKurotatoLevelBySecondGroup.GetConfigList(secondGroupId, true);
		}

		// Token: 0x0603A724 RID: 239396 RVA: 0x00ED19EA File Offset: 0x00ECFBEA
		public IReadOnlyList<KurotatoWave> GetAllWaveConfig()
		{
			return ConfigKurotatoWaveAll.GetConfigList(true) ?? new List<KurotatoWave>();
		}

		// Token: 0x0603A725 RID: 239397 RVA: 0x00ED19FC File Offset: 0x00ECFBFC
		public List<KurotatoWave> GetWaveByLevelId(int levelId)
		{
			IReadOnlyList<KurotatoWave> configList = ConfigKurotatoWaveAll.GetConfigList(true);
			if (configList == null)
			{
				return new List<KurotatoWave>();
			}
			List<KurotatoWave> list = new List<KurotatoWave>();
			foreach (KurotatoWave item in configList)
			{
				if (item.Level == levelId)
				{
					list.Add(item);
				}
			}
			return list;
		}

		// Token: 0x0603A726 RID: 239398 RVA: 0x00ED1A68 File Offset: 0x00ECFC68
		public KurotatoWave? GetMonsterByLevelIdAndWaveId(int levelId, int waveId)
		{
			IReadOnlyList<KurotatoWave> configList = ConfigKurotatoWaveAll.GetConfigList(true);
			if (configList == null)
			{
				return null;
			}
			foreach (KurotatoWave value in configList)
			{
				if (value.Level == levelId && value.Wave == waveId)
				{
					return new KurotatoWave?(value);
				}
			}
			return null;
		}

		// Token: 0x0603A727 RID: 239399 RVA: 0x00ED1AE8 File Offset: 0x00ECFCE8
		public KurotatoSpawn? GetSpawnById(int spawnId)
		{
			return ConfigKurotatoSpawnById.GetConfig(spawnId, true);
		}

		// Token: 0x0603A728 RID: 239400 RVA: 0x00ED1AF1 File Offset: 0x00ECFCF1
		public KurotatoWaypoints? GetWaypointsById(int waypointsId)
		{
			return ConfigKurotatoWaypointsById.GetConfig(waypointsId, true);
		}

		// Token: 0x0603A729 RID: 239401 RVA: 0x00ED1AFA File Offset: 0x00ECFCFA
		public KurotatoStructure? GetStructureConfigById(int structureId)
		{
			return ConfigKurotatoStructureById.GetConfig(structureId, true);
		}

		// Token: 0x0603A72A RID: 239402 RVA: 0x00ED1B03 File Offset: 0x00ECFD03
		public KurotatoMonster? GetMonsterConfigById(int monsterId)
		{
			return ConfigKurotatoMonsterById.GetConfig(monsterId, true);
		}

		// Token: 0x0603A72B RID: 239403 RVA: 0x00ED1B0C File Offset: 0x00ECFD0C
		public KurotatoMonsterType? GetMonsterTypeById(int monsterId)
		{
			return ConfigKurotatoMonsterTypeById.GetConfig(monsterId, true);
		}

		// Token: 0x0603A72C RID: 239404 RVA: 0x00ED1B18 File Offset: 0x00ECFD18
		public bool WaveHasRiskType(KurotatoWave waveConfig, EKurotatoRiskType riskType)
		{
			foreach (int spawnId in waveConfig.MonsterSpawnGroupIter())
			{
				KurotatoSpawn? spawnById = this.GetSpawnById(spawnId);
				if (spawnById != null)
				{
					foreach (int monsterId in spawnById.Value.MonsterIdsIter())
					{
						KurotatoMonster? monsterConfigById = this.GetMonsterConfigById(monsterId);
						if (monsterConfigById != null)
						{
							KurotatoMonsterType? monsterTypeById = this.GetMonsterTypeById(monsterConfigById.Value.MonsterType);
							if (monsterTypeById != null && monsterTypeById.Value.RiskType == (int)riskType)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0603A72D RID: 239405 RVA: 0x00ED1C0C File Offset: 0x00ECFE0C
		public IReadOnlyList<KurotatoMonsterTag> GetAllMonsterTagList()
		{
			return ConfigKurotatoMonsterTagAll.GetConfigList(true) ?? new List<KurotatoMonsterTag>();
		}

		// Token: 0x0603A72E RID: 239406 RVA: 0x00ED1C1D File Offset: 0x00ECFE1D
		public KurotatoMonsterTag? GetMonsterTagById(int tagId)
		{
			return ConfigKurotatoMonsterTagById.GetConfig(tagId, true);
		}

		// Token: 0x0603A72F RID: 239407 RVA: 0x00ED1C26 File Offset: 0x00ECFE26
		public KurotatoMonsterRisk? GetMonsterRiskConfig(int typeId)
		{
			return ConfigKurotatoMonsterRiskById.GetConfig(typeId, true);
		}

		// Token: 0x0603A730 RID: 239408 RVA: 0x00ED1C2F File Offset: 0x00ECFE2F
		public KurotatoMonsterBody? GetBodyTypeConfig(int bodyTypeId)
		{
			return ConfigKurotatoMonsterBodyById.GetConfig(bodyTypeId, true);
		}

		// Token: 0x0603A731 RID: 239409 RVA: 0x00ED1C38 File Offset: 0x00ECFE38
		public KSCBaseProperty? GetBaseProperty(int id)
		{
			return ConfigKSCBasePropertyById.GetConfig(id, true);
		}

		// Token: 0x0603A732 RID: 239410 RVA: 0x00ED1C41 File Offset: 0x00ECFE41
		public KurotatoMonsterAttribute? GetMonsterAttribute(int id)
		{
			return ConfigKurotatoMonsterAttributeById.GetConfig(id, true);
		}

		// Token: 0x0603A733 RID: 239411 RVA: 0x00ED1C4A File Offset: 0x00ECFE4A
		public IReadOnlyList<KurotatoResAward> GetAllNormalRewardConfig()
		{
			return ConfigKurotatoResAwardAll.GetConfigList(true) ?? new List<KurotatoResAward>();
		}

		// Token: 0x0603A734 RID: 239412 RVA: 0x00ED1C5B File Offset: 0x00ECFE5B
		public KurotatoResAward? GetNormalRewardConfigById(int rewardId)
		{
			return ConfigKurotatoResAwardById.GetConfig(rewardId, true);
		}

		// Token: 0x0603A735 RID: 239413 RVA: 0x00ED1C64 File Offset: 0x00ECFE64
		public IReadOnlyList<KurotatoLimitAward> GetAllLimitRewardConfig()
		{
			return ConfigKurotatoLimitAwardAll.GetConfigList(true) ?? new List<KurotatoLimitAward>();
		}

		// Token: 0x0603A736 RID: 239414 RVA: 0x00ED1C75 File Offset: 0x00ECFE75
		public KurotatoLimitAward? GetLimitRewardConfigById(int rewardId)
		{
			return ConfigKurotatoLimitAwardById.GetConfig(rewardId, true);
		}

		// Token: 0x0603A737 RID: 239415 RVA: 0x00ED1C7E File Offset: 0x00ECFE7E
		public IReadOnlyList<KurotatoRewardTab> GetAllRewardTabConfig()
		{
			return ConfigKurotatoRewardTabAll.GetConfigList(true) ?? new List<KurotatoRewardTab>();
		}

		// Token: 0x0603A738 RID: 239416 RVA: 0x00ED1C8F File Offset: 0x00ECFE8F
		public KurotatoRewardTab? GetRewardTabConfigById(int tabId)
		{
			return ConfigKurotatoRewardTabById.GetConfig(tabId, true);
		}

		// Token: 0x0603A739 RID: 239417 RVA: 0x00ED1C98 File Offset: 0x00ECFE98
		public IReadOnlyList<KurotatoScoreAward> GetAllKurotatoScoreAwardConfig()
		{
			return ConfigKurotatoScoreAwardAll.GetConfigList(true) ?? new List<KurotatoScoreAward>();
		}

		// Token: 0x0603A73A RID: 239418 RVA: 0x00ED1CA9 File Offset: 0x00ECFEA9
		public KurotatoScoreAward? GetKurotatoScoreAwardConfigById(int rewardId)
		{
			return ConfigKurotatoScoreAwardById.GetConfig(rewardId, true);
		}

		// Token: 0x0603A73B RID: 239419 RVA: 0x00ED1CB2 File Offset: 0x00ECFEB2
		[NullableContext(2)]
		public IReadOnlyList<KurotatoHandbook> GetKurotatoHandBookListByActivityIdAndType(int activityId, EKurotatoHandBookType type)
		{
			return ConfigKurotatoHandbookByActivityIdAndType.GetConfigList(activityId, (int)type, true);
		}

		// Token: 0x0603A73C RID: 239420 RVA: 0x00ED1CBC File Offset: 0x00ECFEBC
		public int GetMonsterRiskType(int configId)
		{
			KurotatoMonster? config = ConfigKurotatoMonsterById.GetConfig(configId, true);
			if (config == null)
			{
				return 0;
			}
			KurotatoMonsterType? config2 = ConfigKurotatoMonsterTypeById.GetConfig(config.Value.MonsterType, true);
			if (config2 == null)
			{
				return 0;
			}
			return config2.Value.RiskType;
		}
	}
}
