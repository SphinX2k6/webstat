using System;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x02005302 RID: 21250
	public static class EQuickHackSkillConditionExtensions
	{
		// Token: 0x06036400 RID: 222208 RVA: 0x00DABD84 File Offset: 0x00DA9F84
		public static string ToEnumString(this EQuickHackSkillCondition value)
		{
			string result;
			switch (value)
			{
			case EQuickHackSkillCondition.CheckTargetTypeMatch:
				result = "CheckTargetTypeMatch";
				break;
			case EQuickHackSkillCondition.CheckRamEnough:
				result = "CheckRamEnough";
				break;
			case EQuickHackSkillCondition.CheckUsageCountEnough:
				result = "CheckUsageCountEnough";
				break;
			case EQuickHackSkillCondition.CheckAnyMonsterTypeMatch:
				result = "CheckAnyMonsterTypeMatch";
				break;
			case EQuickHackSkillCondition.CheckAnySceneItemCanHack:
				result = "CheckAnySceneItemCanHack";
				break;
			case EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill:
				result = "CheckAnyTargetNotBeenUsedSkill";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06036401 RID: 222209 RVA: 0x00DABDF0 File Offset: 0x00DA9FF0
		public static EQuickHackSkillCondition FromString(string name)
		{
			EQuickHackSkillCondition result;
			if (!EQuickHackSkillConditionExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EQuickHackSkillCondition 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06036402 RID: 222210 RVA: 0x00DABE1C File Offset: 0x00DAA01C
		public static bool TryFromString(string name, out EQuickHackSkillCondition value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EQuickHackSkillCondition.CheckTargetTypeMatch;
				return false;
			}
			if (name == "CheckTargetTypeMatch")
			{
				value = EQuickHackSkillCondition.CheckTargetTypeMatch;
				return true;
			}
			if (name == "CheckRamEnough")
			{
				value = EQuickHackSkillCondition.CheckRamEnough;
				return true;
			}
			if (name == "CheckUsageCountEnough")
			{
				value = EQuickHackSkillCondition.CheckUsageCountEnough;
				return true;
			}
			if (name == "CheckAnyMonsterTypeMatch")
			{
				value = EQuickHackSkillCondition.CheckAnyMonsterTypeMatch;
				return true;
			}
			if (name == "CheckAnySceneItemCanHack")
			{
				value = EQuickHackSkillCondition.CheckAnySceneItemCanHack;
				return true;
			}
			if (!(name == "CheckAnyTargetNotBeenUsedSkill"))
			{
				value = EQuickHackSkillCondition.CheckTargetTypeMatch;
				return false;
			}
			value = EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill;
			return true;
		}

		// Token: 0x06036403 RID: 222211 RVA: 0x00DABEA8 File Offset: 0x00DAA0A8
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"CheckTargetTypeMatch",
				"CheckRamEnough",
				"CheckUsageCountEnough",
				"CheckAnyMonsterTypeMatch",
				"CheckAnySceneItemCanHack",
				"CheckAnyTargetNotBeenUsedSkill"
			};
		}

		// Token: 0x06036404 RID: 222212 RVA: 0x00DABEE0 File Offset: 0x00DAA0E0
		public static EQuickHackSkillCondition[] GetValues()
		{
			return new EQuickHackSkillCondition[]
			{
				EQuickHackSkillCondition.CheckTargetTypeMatch,
				EQuickHackSkillCondition.CheckRamEnough,
				EQuickHackSkillCondition.CheckUsageCountEnough,
				EQuickHackSkillCondition.CheckAnyMonsterTypeMatch,
				EQuickHackSkillCondition.CheckAnySceneItemCanHack,
				EQuickHackSkillCondition.CheckAnyTargetNotBeenUsedSkill
			};
		}

		// Token: 0x06036405 RID: 222213 RVA: 0x00DABEF3 File Offset: 0x00DAA0F3
		public static string[] GetNames()
		{
			return new string[]
			{
				"CheckTargetTypeMatch",
				"CheckRamEnough",
				"CheckUsageCountEnough",
				"CheckAnyMonsterTypeMatch",
				"CheckAnySceneItemCanHack",
				"CheckAnyTargetNotBeenUsedSkill"
			};
		}
	}
}
