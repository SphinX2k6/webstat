using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D4 RID: 26836
	public static class EDropCatchRoleSkillStateExtensions
	{
		// Token: 0x06042B9D RID: 273309 RVA: 0x01120480 File Offset: 0x0111E680
		public static string ToEnumString(this EDropCatchRoleSkillState value)
		{
			string result;
			switch (value)
			{
			case EDropCatchRoleSkillState.Disable:
				result = "Disable";
				break;
			case EDropCatchRoleSkillState.Enable:
				result = "Enable";
				break;
			case EDropCatchRoleSkillState.InSkill:
				result = "InSkill";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06042B9E RID: 273310 RVA: 0x011204C8 File Offset: 0x0111E6C8
		public static EDropCatchRoleSkillState FromString(string name)
		{
			EDropCatchRoleSkillState result;
			if (!EDropCatchRoleSkillStateExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchRoleSkillState 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042B9F RID: 273311 RVA: 0x011204F4 File Offset: 0x0111E6F4
		public static bool TryFromString(string name, out EDropCatchRoleSkillState value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchRoleSkillState.Disable;
				return false;
			}
			if (name == "Disable")
			{
				value = EDropCatchRoleSkillState.Disable;
				return true;
			}
			if (name == "Enable")
			{
				value = EDropCatchRoleSkillState.Enable;
				return true;
			}
			if (!(name == "InSkill"))
			{
				value = EDropCatchRoleSkillState.Disable;
				return false;
			}
			value = EDropCatchRoleSkillState.InSkill;
			return true;
		}

		// Token: 0x06042BA0 RID: 273312 RVA: 0x0112054A File Offset: 0x0111E74A
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Disable",
				"Enable",
				"InSkill"
			};
		}

		// Token: 0x06042BA1 RID: 273313 RVA: 0x0112056A File Offset: 0x0111E76A
		public static EDropCatchRoleSkillState[] GetValues()
		{
			return new EDropCatchRoleSkillState[]
			{
				EDropCatchRoleSkillState.Disable,
				EDropCatchRoleSkillState.Enable,
				EDropCatchRoleSkillState.InSkill
			};
		}

		// Token: 0x06042BA2 RID: 273314 RVA: 0x0112057A File Offset: 0x0111E77A
		public static string[] GetNames()
		{
			return new string[]
			{
				"Disable",
				"Enable",
				"InSkill"
			};
		}
	}
}
