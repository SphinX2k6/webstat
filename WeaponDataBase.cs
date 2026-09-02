using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;

// Token: 0x02002CF2 RID: 11506
[NullableContext(1)]
[Nullable(0)]
public abstract class WeaponDataBase
{
	// Token: 0x06017337 RID: 95031
	public abstract int GetLevel();

	// Token: 0x06017338 RID: 95032
	public abstract int GetResonanceLevel();

	// Token: 0x06017339 RID: 95033
	public abstract int GetBreachLevel();

	// Token: 0x0601733A RID: 95034
	public abstract int GetItemId();

	// Token: 0x0601733B RID: 95035
	public abstract bool IsTrial();

	// Token: 0x0601733C RID: 95036
	public abstract bool HasRole();

	// Token: 0x0601733D RID: 95037
	public abstract void SetRoleId(int roleId);

	// Token: 0x0601733E RID: 95038
	public abstract int GetRoleId();

	// Token: 0x0601733F RID: 95039 RVA: 0x0066E570 File Offset: 0x0066C770
	public int GetModelId(int skinId)
	{
		if (skinId == -1)
		{
			return this.GetItemConfig().ModelId;
		}
		return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).ModelId;
	}

	// Token: 0x06017340 RID: 95040 RVA: 0x0066E5A4 File Offset: 0x0066C7A4
	public int[] GetModels(int skinId)
	{
		if (skinId == -1)
		{
			return this.GetItemConfig().GetModelsArray();
		}
		return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).GetModelsArray();
	}

	// Token: 0x06017341 RID: 95041 RVA: 0x0066E5D8 File Offset: 0x0066C7D8
	public int[] GetModelsIndex(int skinId)
	{
		if (skinId == -1)
		{
			return this.GetItemConfig().ModelsIndex();
		}
		return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).ModelsIndex();
	}

	// Token: 0x06017342 RID: 95042 RVA: 0x0066E60C File Offset: 0x0066C80C
	public int GetTransformId(int skinId)
	{
		if (skinId == -1)
		{
			return this.GetItemConfig().TransformId;
		}
		return ConfigBase<SkinConfig>.Instance.GetWeaponSkinConfig(skinId).TransformId;
	}

	// Token: 0x06017343 RID: 95043 RVA: 0x0066E63F File Offset: 0x0066C83F
	public WeaponConf? GetWeaponConfig()
	{
		return ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.GetItemId());
	}

	// Token: 0x06017344 RID: 95044 RVA: 0x0066E654 File Offset: 0x0066C854
	public WeaponBreach? GetBreachConfig()
	{
		WeaponConf? weaponConfig = this.GetWeaponConfig();
		if (weaponConfig != null)
		{
			int breachLevel = this.GetBreachLevel();
			return ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.Value.BreachId, breachLevel);
		}
		return null;
	}

	// Token: 0x06017345 RID: 95045 RVA: 0x0066E69C File Offset: 0x0066C89C
	[NullableContext(2)]
	public IReadOnlyList<WeaponBreach> GetBreachConfigList()
	{
		WeaponConf? weaponConfig = this.GetWeaponConfig();
		if (weaponConfig != null)
		{
			return ConfigBase<WeaponConfig>.Instance.GetWeaponBreachList(weaponConfig.Value.BreachId);
		}
		return null;
	}

	// Token: 0x06017346 RID: 95046 RVA: 0x0066E6D4 File Offset: 0x0066C8D4
	public WeaponReson? GetResonanceConfig()
	{
		WeaponConf? weaponConfig = this.GetWeaponConfig();
		if (weaponConfig != null)
		{
			int resonanceLevel = this.GetResonanceLevel();
			return ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(weaponConfig.Value.ResonId, resonanceLevel);
		}
		return null;
	}

	// Token: 0x06017347 RID: 95047 RVA: 0x0066E71C File Offset: 0x0066C91C
	public virtual bool CanGoBreach()
	{
		int level = this.GetLevel();
		int levelLimit = this.GetLastBreachConfig().LevelLimit;
		if (level >= levelLimit)
		{
			return false;
		}
		WeaponBreach? breachConfig = this.GetBreachConfig();
		return breachConfig != null && level >= breachConfig.Value.LevelLimit;
	}

	// Token: 0x06017348 RID: 95048 RVA: 0x0066E76C File Offset: 0x0066C96C
	public WeaponBreach GetLastBreachConfig()
	{
		int breachId = this.GetWeaponConfig().Value.BreachId;
		IReadOnlyList<WeaponBreach> weaponBreachList = ConfigBase<WeaponConfig>.Instance.GetWeaponBreachList(breachId);
		return weaponBreachList[weaponBreachList.Count - 1];
	}

	// Token: 0x06017349 RID: 95049 RVA: 0x0066E7A8 File Offset: 0x0066C9A8
	public WeaponBreach? GetBreachConsume()
	{
		WeaponConf? weaponConfig = this.GetWeaponConfig();
		int breachLevel = this.GetBreachLevel();
		return ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.Value.BreachId, breachLevel);
	}

	// Token: 0x0601734A RID: 95050 RVA: 0x0066E7E0 File Offset: 0x0066C9E0
	public int GetMaxLevel()
	{
		return Math.Min(ConfigBase<WeaponConfig>.Instance.GetWeaponLevelLimit(this.GetItemConfig().QualityId), this.GetLastBreachConfig().LevelLimit);
	}

	// Token: 0x0601734B RID: 95051 RVA: 0x0066E818 File Offset: 0x0066CA18
	public bool IsLevelMax()
	{
		int maxLevel = this.GetMaxLevel();
		return this.GetLevel() >= maxLevel;
	}

	// Token: 0x0601734C RID: 95052 RVA: 0x0066E838 File Offset: 0x0066CA38
	public int GetMaterialCost()
	{
		int qualityId = this.GetItemConfig().QualityId;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponQualityInfo(qualityId).Value.Cost;
	}

	// Token: 0x0601734D RID: 95053 RVA: 0x0066E870 File Offset: 0x0066CA70
	public int GetMaxExp(int weaponLevel)
	{
		IEnumerable<WeaponLevel> weaponLevelList = ConfigBase<WeaponConfig>.Instance.GetWeaponLevelList(this.GetWeaponConfig().Value.LevelId);
		int num = 0;
		foreach (WeaponLevel weaponLevel2 in weaponLevelList)
		{
			if (weaponLevel2.Level > weaponLevel)
			{
				return num;
			}
			num += weaponLevel2.Exp;
		}
		return num;
	}

	// Token: 0x0601734E RID: 95054 RVA: 0x0066E8F4 File Offset: 0x0066CAF4
	protected int GetLevelLimitMaxExp()
	{
		int breachLevel = this.GetBreachLevel();
		return this.GetMaxExp(ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(this.GetWeaponConfig().Value.BreachId, breachLevel).Value.LevelLimit - 1);
	}

	// Token: 0x0601734F RID: 95055 RVA: 0x0066E944 File Offset: 0x0066CB44
	public int GetLevelExp(int level)
	{
		int result = 0;
		if (level <= 0)
		{
			return 0;
		}
		WeaponLevel? weaponLevelConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponLevelConfig(this.GetWeaponConfig().Value.LevelId, level);
		if (weaponLevelConfig != null)
		{
			result = weaponLevelConfig.Value.Exp;
		}
		return result;
	}

	// Token: 0x06017350 RID: 95056 RVA: 0x0066E998 File Offset: 0x0066CB98
	public int GetCurrentMaxLevel()
	{
		WeaponConf? weaponConfig = this.GetWeaponConfig();
		if (weaponConfig != null)
		{
			int breachLevel = this.GetBreachLevel();
			return ConfigBase<WeaponConfig>.Instance.GetWeaponBreach(weaponConfig.Value.BreachId, breachLevel).Value.LevelLimit;
		}
		return 0;
	}

	// Token: 0x06017351 RID: 95057 RVA: 0x0066E9E9 File Offset: 0x0066CBE9
	public int GetLastLevelMaxExp()
	{
		return this.GetMaxExp(this.GetLevel() - 1);
	}

	// Token: 0x06017352 RID: 95058 RVA: 0x0066E9FC File Offset: 0x0066CBFC
	public WeaponConf GetItemConfig()
	{
		return ConfigBase<InventoryConfig>.Instance.GetWeaponItemConfig(this.GetItemId()).Value;
	}
}
