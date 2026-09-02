using System;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044B2 RID: 17586
	public static class EMetaTypeExtensions
	{
		// Token: 0x0602E59B RID: 189851 RVA: 0x00AE2BBC File Offset: 0x00AE0DBC
		public static string ToEnumString(this EMetaType value)
		{
			string result;
			if (value != EMetaType.Map)
			{
				if (value != EMetaType.Set)
				{
					result = value.ToString();
				}
				else
				{
					result = "___Set___";
				}
			}
			else
			{
				result = "___Map___";
			}
			return result;
		}

		// Token: 0x0602E59C RID: 189852 RVA: 0x00AE2BF4 File Offset: 0x00AE0DF4
		public static EMetaType FromString(string name)
		{
			EMetaType result;
			if (!EMetaTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EMetaType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602E59D RID: 189853 RVA: 0x00AE2C1D File Offset: 0x00AE0E1D
		public static bool TryFromString(string name, out EMetaType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EMetaType.Map;
				return false;
			}
			if (name == "___Map___")
			{
				value = EMetaType.Map;
				return true;
			}
			if (!(name == "___Set___"))
			{
				value = EMetaType.Map;
				return false;
			}
			value = EMetaType.Set;
			return true;
		}

		// Token: 0x0602E59E RID: 189854 RVA: 0x00AE2C56 File Offset: 0x00AE0E56
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"___Map___",
				"___Set___"
			};
		}

		// Token: 0x0602E59F RID: 189855 RVA: 0x00AE2C6E File Offset: 0x00AE0E6E
		public static EMetaType[] GetValues()
		{
			return new EMetaType[]
			{
				EMetaType.Map,
				EMetaType.Set
			};
		}

		// Token: 0x0602E5A0 RID: 189856 RVA: 0x00AE2C7A File Offset: 0x00AE0E7A
		public static string[] GetNames()
		{
			return new string[]
			{
				"Map",
				"Set"
			};
		}
	}
}
