using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068CC RID: 26828
	public static class EDropCatchTextIdExtensions
	{
		// Token: 0x06042B79 RID: 273273 RVA: 0x0111FD90 File Offset: 0x0111DF90
		public static string ToEnumString(this EDropCatchTextId value)
		{
			string result;
			if (value == EDropCatchTextId.TextScoreLevel)
			{
				result = "DropCatch_ScoreLevel";
			}
			else
			{
				result = value.ToString();
			}
			return result;
		}

		// Token: 0x06042B7A RID: 273274 RVA: 0x0111FDB8 File Offset: 0x0111DFB8
		public static EDropCatchTextId FromString(string name)
		{
			EDropCatchTextId result;
			if (!EDropCatchTextIdExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchTextId 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042B7B RID: 273275 RVA: 0x0111FDE1 File Offset: 0x0111DFE1
		public static bool TryFromString(string name, out EDropCatchTextId value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchTextId.TextScoreLevel;
				return false;
			}
			if (name == "DropCatch_ScoreLevel")
			{
				value = EDropCatchTextId.TextScoreLevel;
				return true;
			}
			value = EDropCatchTextId.TextScoreLevel;
			return false;
		}

		// Token: 0x06042B7C RID: 273276 RVA: 0x0111FE06 File Offset: 0x0111E006
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"DropCatch_ScoreLevel"
			};
		}

		// Token: 0x06042B7D RID: 273277 RVA: 0x0111FE16 File Offset: 0x0111E016
		public static EDropCatchTextId[] GetValues()
		{
			return new EDropCatchTextId[1];
		}

		// Token: 0x06042B7E RID: 273278 RVA: 0x0111FE1E File Offset: 0x0111E01E
		public static string[] GetNames()
		{
			return new string[]
			{
				"TextScoreLevel"
			};
		}
	}
}
