using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002E4C RID: 11852
[NullableContext(1)]
[Nullable(0)]
public class AbilityUtils
{
	// Token: 0x06018486 RID: 99462 RVA: 0x006C85A1 File Offset: 0x006C67A1
	public static T GetLevelValue<[Nullable(2)] T>([Nullable(new byte[]
	{
		2,
		1
	})] T[] array, int level, T defaultValueIfNotFound)
	{
		if (array == null || array.Length == 0)
		{
			return defaultValueIfNotFound;
		}
		if (level >= 1 && level - 1 < array.Length)
		{
			return array[level - 1];
		}
		if (level == 0)
		{
			return array[0];
		}
		return array[array.Length - 1];
	}

	// Token: 0x06018487 RID: 99463 RVA: 0x006C85D8 File Offset: 0x006C67D8
	[NullableContext(2)]
	public static double GetArrayValue(double[] array, int index, double defaultValueIfNotFound)
	{
		if (array == null || array.Length == 0 || index < 0)
		{
			return defaultValueIfNotFound;
		}
		if (index < array.Length)
		{
			return array[index];
		}
		return array[array.Length - 1];
	}

	// Token: 0x06018488 RID: 99464 RVA: 0x006C85F8 File Offset: 0x006C67F8
	[NullableContext(2)]
	public static float GetAttrValue(IAttributeSet attrSet, EAttributeType attrId, EAttributeBasedFloatCalculationType attrCalcPolicy)
	{
		if (attrSet == null)
		{
			return 0f;
		}
		switch (attrCalcPolicy)
		{
		case EAttributeBasedFloatCalculationType.CurrentValue:
			return attrSet.GetCurrentValue(attrId);
		case EAttributeBasedFloatCalculationType.BonusValue:
			return attrSet.GetCurrentValue(attrId) - attrSet.GetBaseValue(attrId);
		}
		return attrSet.GetBaseValue(attrId);
	}

	// Token: 0x06018489 RID: 99465 RVA: 0x006C8638 File Offset: 0x006C6838
	public static void SetSpecialEnergyAttrValue(int entityId, int attrId, float value)
	{
		if (!CharacterAttributeTypes.specialEnergyIds.Contains((EAttributeType)attrId))
		{
			return;
		}
		BaseAttributeComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseAttributeComponent>(entityId);
		if (component != null && component.Valid)
		{
			component.SetBaseValue((EAttributeType)attrId, value);
		}
	}

	// Token: 0x0601848A RID: 99466 RVA: 0x006C8674 File Offset: 0x006C6874
	public static bool ModifyFuLuoLuoSpecialEnergy(Entity target, int energyType)
	{
		SpecialSkillBase specialSkillBase;
		if (target == null)
		{
			specialSkillBase = null;
		}
		else
		{
			CharacterSpecialSkillComponent component = target.GetComponent<CharacterSpecialSkillComponent>();
			specialSkillBase = ((component != null) ? component.SpecialSkill : null);
		}
		SpecialSkillBase specialSkillBase2 = specialSkillBase;
		if (specialSkillBase2 == null)
		{
			return false;
		}
		SpecialSkillFuLuoLuo specialSkillFuLuoLuo = specialSkillBase2 as SpecialSkillFuLuoLuo;
		if (specialSkillFuLuoLuo != null)
		{
			if (energyType == 0)
			{
				specialSkillFuLuoLuo.RemoveSpecialEnergy();
			}
			else
			{
				specialSkillFuLuoLuo.AddSpecialEnergy(energyType);
			}
			return true;
		}
		return false;
	}

	// Token: 0x0601848B RID: 99467 RVA: 0x006C86C0 File Offset: 0x006C68C0
	public static int GetFuLuoLuoSpecialEnergyType(Entity target, int index)
	{
		SpecialSkillBase specialSkillBase;
		if (target == null)
		{
			specialSkillBase = null;
		}
		else
		{
			CharacterSpecialSkillComponent component = target.GetComponent<CharacterSpecialSkillComponent>();
			specialSkillBase = ((component != null) ? component.SpecialSkill : null);
		}
		SpecialSkillBase specialSkillBase2 = specialSkillBase;
		if (specialSkillBase2 == null)
		{
			return 0;
		}
		SpecialSkillFuLuoLuo specialSkillFuLuoLuo = specialSkillBase2 as SpecialSkillFuLuoLuo;
		if (specialSkillFuLuoLuo != null)
		{
			return specialSkillFuLuoLuo.GetSpecialEnergyType(index);
		}
		return 0;
	}
}
