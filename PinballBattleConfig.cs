using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000F5B RID: 3931
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PinballBattleConfig : ConfigBase<PinballBattleConfig>
{
	// Token: 0x0600631F RID: 25375 RVA: 0x0018EDAE File Offset: 0x0018CFAE
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x06006320 RID: 25376 RVA: 0x0018EDB1 File Offset: 0x0018CFB1
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x06006321 RID: 25377 RVA: 0x0018EDB4 File Offset: 0x0018CFB4
	public PinballWorldConfig? GetWorldConfig(int id)
	{
		return ConfigPinballWorldConfigById.GetConfig(id, true);
	}

	// Token: 0x06006322 RID: 25378 RVA: 0x0018EDC0 File Offset: 0x0018CFC0
	public PinballWorldConfig? GetWorldConfigByMapId(int mapId)
	{
		IReadOnlyList<PinballWorldConfig> configList = ConfigPinballWorldConfigByMapId.GetConfigList(mapId, true);
		if (configList != null)
		{
			return new PinballWorldConfig?(configList[0]);
		}
		return null;
	}

	// Token: 0x06006323 RID: 25379 RVA: 0x0018EDEE File Offset: 0x0018CFEE
	public IReadOnlyList<PinballEntityTest> GetWorldEntities(int mapId)
	{
		return ConfigPinballEntityTestByMapId.GetConfigList(mapId, true);
	}

	// Token: 0x06006324 RID: 25380 RVA: 0x0018EDF7 File Offset: 0x0018CFF7
	public PinballEntityTest? GetWorldEntityById(int configId)
	{
		return ConfigPinballEntityTestById.GetConfig(configId, true);
	}

	// Token: 0x06006325 RID: 25381 RVA: 0x0018EE00 File Offset: 0x0018D000
	public PinballCreature? GetCreatureConfigById(int configId)
	{
		return ConfigPinballCreatureById.GetConfig(configId, true);
	}

	// Token: 0x06006326 RID: 25382 RVA: 0x0018EE09 File Offset: 0x0018D009
	public IReadOnlyList<PinballCreature> GetAllCreatureConfigs()
	{
		return ConfigPinballCreatureAll.GetConfigList(true);
	}

	// Token: 0x06006327 RID: 25383 RVA: 0x0018EE11 File Offset: 0x0018D011
	public IReadOnlyList<PinballDamage> GetAllDamageConfigs()
	{
		return ConfigPinballDamageAll.GetConfigList(true);
	}

	// Token: 0x06006328 RID: 25384 RVA: 0x0018EE19 File Offset: 0x0018D019
	public PinballAttr? GetAttrConfig(int attrId)
	{
		return ConfigPinballAttrById.GetConfig(attrId, true);
	}

	// Token: 0x06006329 RID: 25385 RVA: 0x0018EE22 File Offset: 0x0018D022
	public IReadOnlyList<PinballAttr> GetAllAttrConfigs()
	{
		return ConfigPinballAttrAll.GetConfigList(true);
	}

	// Token: 0x0600632A RID: 25386 RVA: 0x0018EE2A File Offset: 0x0018D02A
	public IReadOnlyList<PinballMonsterAttr> GetAllMonsterAttrConfigs()
	{
		return ConfigPinballMonsterAttrAll.GetConfigList(true);
	}

	// Token: 0x0600632B RID: 25387 RVA: 0x0018EE32 File Offset: 0x0018D032
	public PinballRoleConfig? GetRoleConfig(int configId)
	{
		return ConfigPinballRoleConfigById.GetConfig(configId, true);
	}

	// Token: 0x0600632C RID: 25388 RVA: 0x0018EE3B File Offset: 0x0018D03B
	public PinballRoleLevelConfig? GetLevelConfig(int groupId, int level)
	{
		return ConfigPinballRoleLevelConfigByGroupIdAndLevel.GetConfig(groupId, level, true);
	}

	// Token: 0x0600632D RID: 25389 RVA: 0x0018EE45 File Offset: 0x0018D045
	public PinballRoleLevelConfig? GetRoleLevelConfig(int configId)
	{
		return ConfigPinballRoleLevelConfigById.GetConfig(configId, true);
	}

	// Token: 0x0600632E RID: 25390 RVA: 0x0018EE4E File Offset: 0x0018D04E
	public PinballWeaponConfig? GetWeaponConfig(int configId)
	{
		return ConfigPinballWeaponConfigById.GetConfig(configId, true);
	}

	// Token: 0x0600632F RID: 25391 RVA: 0x0018EE57 File Offset: 0x0018D057
	public PinballWeaponMainEntry? GetWeaponMainEntryConfig(int configId)
	{
		return ConfigPinballWeaponMainEntryById.GetConfig(configId, true);
	}

	// Token: 0x06006330 RID: 25392 RVA: 0x0018EE60 File Offset: 0x0018D060
	public PinballWeaponSubEntry? GetWeaponSubEntryConfig(int configId)
	{
		return ConfigPinballWeaponSubEntryById.GetConfig(configId, true);
	}

	// Token: 0x06006331 RID: 25393 RVA: 0x0018EE69 File Offset: 0x0018D069
	public PinballWeaponAttr? GetWeaponAttrConfig(int configId)
	{
		return ConfigPinballWeaponAttrById.GetConfig(configId, true);
	}

	// Token: 0x06006332 RID: 25394 RVA: 0x0018EE72 File Offset: 0x0018D072
	public PinballCommonItem? GetCommonItemConfigByConfigId(int configId)
	{
		return ConfigPinballCommonItemById.GetConfig(configId, true);
	}

	// Token: 0x06006333 RID: 25395 RVA: 0x0018EE7B File Offset: 0x0018D07B
	public PinballDeathrattle? GetDeathrattleConfig(int configId)
	{
		return ConfigPinballDeathrattleById.GetConfig(configId, true);
	}

	// Token: 0x06006334 RID: 25396 RVA: 0x0018EE84 File Offset: 0x0018D084
	public PinballEffect? GetEffectConfig(int configId)
	{
		return ConfigPinballEffectById.GetConfig(configId, true);
	}
}
