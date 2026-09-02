using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D8 RID: 26840
	public static class EDropCatchModifierTypeExtensions
	{
		// Token: 0x06042BAF RID: 273327 RVA: 0x01120BCC File Offset: 0x0111EDCC
		public static string ToEnumString(this EDropCatchModifierType value)
		{
			string result;
			switch (value)
			{
			case EDropCatchModifierType.Override:
				result = "Override";
				break;
			case EDropCatchModifierType.Rate:
				result = "Rate";
				break;
			case EDropCatchModifierType.Offset:
				result = "Offset";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06042BB0 RID: 273328 RVA: 0x01120C14 File Offset: 0x0111EE14
		public static EDropCatchModifierType FromString(string name)
		{
			EDropCatchModifierType result;
			if (!EDropCatchModifierTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchModifierType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042BB1 RID: 273329 RVA: 0x01120C40 File Offset: 0x0111EE40
		public static bool TryFromString(string name, out EDropCatchModifierType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchModifierType.Override;
				return false;
			}
			if (name == "Override")
			{
				value = EDropCatchModifierType.Override;
				return true;
			}
			if (name == "Rate")
			{
				value = EDropCatchModifierType.Rate;
				return true;
			}
			if (!(name == "Offset"))
			{
				value = EDropCatchModifierType.Override;
				return false;
			}
			value = EDropCatchModifierType.Offset;
			return true;
		}

		// Token: 0x06042BB2 RID: 273330 RVA: 0x01120C96 File Offset: 0x0111EE96
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Override",
				"Rate",
				"Offset"
			};
		}

		// Token: 0x06042BB3 RID: 273331 RVA: 0x01120CB6 File Offset: 0x0111EEB6
		public static EDropCatchModifierType[] GetValues()
		{
			return new EDropCatchModifierType[]
			{
				EDropCatchModifierType.Override,
				EDropCatchModifierType.Rate,
				EDropCatchModifierType.Offset
			};
		}

		// Token: 0x06042BB4 RID: 273332 RVA: 0x01120CC6 File Offset: 0x0111EEC6
		public static string[] GetNames()
		{
			return new string[]
			{
				"Override",
				"Rate",
				"Offset"
			};
		}
	}
}
