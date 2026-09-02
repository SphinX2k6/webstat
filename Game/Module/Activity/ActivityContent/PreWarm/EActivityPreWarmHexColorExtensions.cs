using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006587 RID: 25991
	public static class EActivityPreWarmHexColorExtensions
	{
		// Token: 0x06040E91 RID: 265873 RVA: 0x010A72D0 File Offset: 0x010A54D0
		public static string ToEnumString(this EActivityPreWarmHexColor value)
		{
			string result;
			switch (value)
			{
			case EActivityPreWarmHexColor.Red:
				result = "#50282AFF";
				break;
			case EActivityPreWarmHexColor.Green:
				result = "#0F855D66";
				break;
			case EActivityPreWarmHexColor.Brown:
				result = "#BE7A3766";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06040E92 RID: 265874 RVA: 0x010A7318 File Offset: 0x010A5518
		public static EActivityPreWarmHexColor FromString(string name)
		{
			EActivityPreWarmHexColor result;
			if (!EActivityPreWarmHexColorExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EActivityPreWarmHexColor 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06040E93 RID: 265875 RVA: 0x010A7344 File Offset: 0x010A5544
		public static bool TryFromString(string name, out EActivityPreWarmHexColor value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EActivityPreWarmHexColor.Red;
				return false;
			}
			if (name == "#50282AFF")
			{
				value = EActivityPreWarmHexColor.Red;
				return true;
			}
			if (name == "#0F855D66")
			{
				value = EActivityPreWarmHexColor.Green;
				return true;
			}
			if (!(name == "#BE7A3766"))
			{
				value = EActivityPreWarmHexColor.Red;
				return false;
			}
			value = EActivityPreWarmHexColor.Brown;
			return true;
		}

		// Token: 0x06040E94 RID: 265876 RVA: 0x010A739A File Offset: 0x010A559A
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"#50282AFF",
				"#0F855D66",
				"#BE7A3766"
			};
		}

		// Token: 0x06040E95 RID: 265877 RVA: 0x010A73BA File Offset: 0x010A55BA
		public static EActivityPreWarmHexColor[] GetValues()
		{
			return new EActivityPreWarmHexColor[]
			{
				EActivityPreWarmHexColor.Red,
				EActivityPreWarmHexColor.Green,
				EActivityPreWarmHexColor.Brown
			};
		}

		// Token: 0x06040E96 RID: 265878 RVA: 0x010A73CA File Offset: 0x010A55CA
		public static string[] GetNames()
		{
			return new string[]
			{
				"Red",
				"Green",
				"Brown"
			};
		}
	}
}
