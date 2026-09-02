using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;

// Token: 0x02002AF9 RID: 11001
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsWeaponGainData : global::SurvivorsGainData
{
	// Token: 0x06015FF0 RID: 90096 RVA: 0x0061A718 File Offset: 0x00618918
	public SurvivorsWeaponGainData(int incId, int configId, Aki.Protocol.SurvivorsWeapon data, ESurvivorsRogueItemType type = ESurvivorsRogueItemType.Weapon) : base(incId, configId)
	{
		this.Data = data;
		this.Type = type;
	}

	// Token: 0x06015FF1 RID: 90097 RVA: 0x0061A731 File Offset: 0x00618931
	public int GetCurrentEvolveId()
	{
		if (this.Data.Evolves.Count == 0)
		{
			return 0;
		}
		return this.Data.Evolves[this.Data.Evolves.Count - 1];
	}

	// Token: 0x06015FF2 RID: 90098 RVA: 0x0061A769 File Offset: 0x00618969
	public void SetWeaponKillCount(int count)
	{
		this.Data.KillMonsterCount = count;
	}

	// Token: 0x06015FF3 RID: 90099 RVA: 0x0061A778 File Offset: 0x00618978
	public List<ISurvivorsWeaponAttributeData> GetWeaponSpecialAttributeList()
	{
		List<ISurvivorsWeaponAttributeData> list = new List<ISurvivorsWeaponAttributeData>();
		for (int i = 0; i < this.Data.Affixs.Count; i++)
		{
			int num = this.Data.Affixs[i];
			Aki.Config.SurvivorsWeaponLv? survivorsWeaponLv = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponLv(num);
			if (survivorsWeaponLv != null)
			{
				SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(survivorsWeaponLv.Value.PropertyId);
				if (propertyConfig != null && propertyConfig.Value.IsSpecial)
				{
					list.Add(new SurvivorsWeaponAttributeData
					{
						WeaponLvId = num,
						AttrId = propertyConfig.Value.Id,
						SortId = propertyConfig.Value.Priority
					});
				}
			}
		}
		list.Sort((ISurvivorsWeaponAttributeData a, ISurvivorsWeaponAttributeData b) => a.SortId - b.SortId);
		return list;
	}

	// Token: 0x0400A8E5 RID: 43237
	public Aki.Protocol.SurvivorsWeapon Data;
}
