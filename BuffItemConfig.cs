using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.World.Model;

// Token: 0x020017C2 RID: 6082
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class BuffItemConfig : ConfigBase<BuffItemConfig>
{
	// Token: 0x0600AC49 RID: 44105 RVA: 0x002DF2B0 File Offset: 0x002DD4B0
	public Damage? GetDamageConfig(int entityId, int damageId)
	{
		DamageModel instance = ModelBase<DamageModel>.Instance;
		if (instance == null)
		{
			return null;
		}
		return instance.GetDamageConfigById((long)damageId);
	}

	// Token: 0x0600AC4A RID: 44106 RVA: 0x002DF2D8 File Offset: 0x002DD4D8
	[NullableContext(2)]
	public Buff[] GetBuffItemBuffConfig(int itemConfigId)
	{
		BuffItem? buffItemConfig = this.GetBuffItemConfig(itemConfigId);
		if (buffItemConfig == null || buffItemConfig.Value.BuffsLength == 0)
		{
			return null;
		}
		List<Buff> list = new List<Buff>();
		long[] buffsArray = buffItemConfig.Value.GetBuffsArray();
		for (int i = 0; i < buffsArray.Length; i++)
		{
			Buff? config = ConfigBuffById.GetConfig(buffsArray[i], true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600AC4B RID: 44107 RVA: 0x002DF359 File Offset: 0x002DD559
	public Buff? GetBuffConfig(int entityId, long buffId)
	{
		return ConfigBuffById.GetConfig(buffId, true);
	}

	// Token: 0x0600AC4C RID: 44108 RVA: 0x002DF364 File Offset: 0x002DD564
	[return: Nullable(2)]
	public Buff[] GetBuffConfigs(int entityId, IList<long> buffs)
	{
		if (buffs.Count == 0)
		{
			return null;
		}
		List<Buff> list = new List<Buff>();
		foreach (long p0Id in buffs)
		{
			Buff? config = ConfigBuffById.GetConfig(p0Id, true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600AC4D RID: 44109 RVA: 0x002DF3D8 File Offset: 0x002DD5D8
	public bool IsResurrectionItem(int itemConfigId)
	{
		Buff[] buffItemBuffConfig = this.GetBuffItemBuffConfig(itemConfigId);
		if (buffItemBuffConfig == null)
		{
			return false;
		}
		foreach (Buff buff in buffItemBuffConfig)
		{
			if (buff.ExtraEffectID == 101)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600AC4E RID: 44110 RVA: 0x002DF418 File Offset: 0x002DD618
	public bool IsTeamBuffItem(int itemConfigId)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(itemConfigId, true);
		if (config == null)
		{
			return false;
		}
		if (!config.Value.IsBuffItem)
		{
			return false;
		}
		BuffItem? buffItemConfig = this.GetBuffItemConfig(itemConfigId);
		return buffItemConfig != null && buffItemConfig.Value.Share;
	}

	// Token: 0x0600AC4F RID: 44111 RVA: 0x002DF470 File Offset: 0x002DD670
	public int GetBuffItemTotalCdTime(int itemConfigId)
	{
		BuffItem? buffItemConfig = this.GetBuffItemConfig(itemConfigId);
		if (buffItemConfig == null)
		{
			return 0;
		}
		int publicCdGroup = buffItemConfig.Value.PublicCdGroup;
		if (publicCdGroup > 0)
		{
			BuffItemCdGroup? buffItemCdGroup = this.GetBuffItemCdGroup(publicCdGroup);
			if (buffItemCdGroup != null)
			{
				return buffItemCdGroup.Value.CoolDownTime;
			}
		}
		return buffItemConfig.Value.Cd;
	}

	// Token: 0x0600AC50 RID: 44112 RVA: 0x002DF4D5 File Offset: 0x002DD6D5
	public BuffItem? GetBuffItemConfig(int itemConfigId)
	{
		return ConfigBuffItemById.GetConfig(itemConfigId, true);
	}

	// Token: 0x0600AC51 RID: 44113 RVA: 0x002DF4DE File Offset: 0x002DD6DE
	[NullableContext(2)]
	public IReadOnlyList<BuffItem> GetBuffItemConfigByPublicCdGroup(int publicCdGroup)
	{
		return ConfigBuffItemByPublicCdGroup.GetConfigList(publicCdGroup, true);
	}

	// Token: 0x0600AC52 RID: 44114 RVA: 0x002DF4E7 File Offset: 0x002DD6E7
	public BuffItemCdGroup? GetBuffItemCdGroup(int publicCdGroup)
	{
		return ConfigBuffItemCdGroupById.GetConfig(publicCdGroup, true);
	}

	// Token: 0x0600AC53 RID: 44115 RVA: 0x002DF4F0 File Offset: 0x002DD6F0
	public bool IsBuffItem(int itemConfigId)
	{
		ItemInfo? config = ConfigItemInfoById.GetConfig(itemConfigId, true);
		return config != null && config.Value.IsBuffItem && this.GetBuffItemConfig(itemConfigId) != null;
	}

	// Token: 0x0600AC54 RID: 44116 RVA: 0x002DF534 File Offset: 0x002DD734
	public bool IsEquipBuffItem(int itemConfigId)
	{
		return ConfigItemInfoById.GetConfig(itemConfigId, true) != null && this.GetBuffEquipItemByItemId(itemConfigId).Count > 0;
	}

	// Token: 0x0600AC55 RID: 44117 RVA: 0x002DF563 File Offset: 0x002DD763
	public IReadOnlyList<BuffEquipItem> GetBuffEquipItemByRoleId(int roleId)
	{
		return ConfigBuffEquipItemByRoleId.GetConfigList(roleId, true) ?? Array.Empty<BuffEquipItem>();
	}

	// Token: 0x0600AC56 RID: 44118 RVA: 0x002DF575 File Offset: 0x002DD775
	public IReadOnlyList<BuffEquipItem> GetBuffEquipItemByItemId(int itemConfigId)
	{
		return ConfigBuffEquipItemByItemId.GetConfigList(itemConfigId, true) ?? Array.Empty<BuffEquipItem>();
	}

	// Token: 0x0600AC57 RID: 44119 RVA: 0x002DF588 File Offset: 0x002DD788
	public int GetBuffEquipItemCategory(int itemConfigId)
	{
		IReadOnlyList<BuffEquipItem> buffEquipItemByItemId = this.GetBuffEquipItemByItemId(itemConfigId);
		if (buffEquipItemByItemId.Count > 0)
		{
			return buffEquipItemByItemId[0].WearPos;
		}
		return 0;
	}
}
