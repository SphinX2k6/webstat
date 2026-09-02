using System;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E06 RID: 28166
	public static class LevelConditionOnSkillButtonDataRefresh_EArgsTypeExtensions
	{
		// Token: 0x06044667 RID: 280167 RVA: 0x011C4EE0 File Offset: 0x011C30E0
		public static string ToEnumString(this LevelConditionOnSkillButtonDataRefresh.EArgsType value)
		{
			string result;
			if (value == LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType)
			{
				result = "skillId";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x06044668 RID: 280168 RVA: 0x011C4F08 File Offset: 0x011C3108
		public static LevelConditionOnSkillButtonDataRefresh.EArgsType FromString(string name)
		{
			LevelConditionOnSkillButtonDataRefresh.EArgsType result;
			if (!LevelConditionOnSkillButtonDataRefresh_EArgsTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 LevelConditionOnSkillButtonDataRefresh.EArgsType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06044669 RID: 280169 RVA: 0x011C4F31 File Offset: 0x011C3131
		public static bool TryFromString(string name, out LevelConditionOnSkillButtonDataRefresh.EArgsType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType;
				return false;
			}
			if (name == "skillId")
			{
				value = LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType;
				return true;
			}
			value = LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType;
			return false;
		}

		// Token: 0x0604466A RID: 280170 RVA: 0x011C4F56 File Offset: 0x011C3156
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"skillId"
			};
		}

		// Token: 0x0604466B RID: 280171 RVA: 0x011C4F66 File Offset: 0x011C3166
		public static LevelConditionOnSkillButtonDataRefresh.EArgsType[] GetValues()
		{
			return new LevelConditionOnSkillButtonDataRefresh.EArgsType[1];
		}

		// Token: 0x0604466C RID: 280172 RVA: 0x011C4F6E File Offset: 0x011C316E
		public static string[] GetNames()
		{
			return new string[]
			{
				"ActionType"
			};
		}
	}
}
