using System;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004695 RID: 18069
	public static class EAppTypeExtensions
	{
		// Token: 0x0602F099 RID: 192665 RVA: 0x00B2561C File Offset: 0x00B2381C
		public static string ToEnumString(this EAppType value)
		{
			string result;
			switch (value)
			{
			case EAppType.DEVELOPMENT:
				result = "Development";
				break;
			case EAppType.PREREKEASE:
				result = "Prerelease";
				break;
			case EAppType.PRODUCT:
				result = "Product";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F09A RID: 192666 RVA: 0x00B25664 File Offset: 0x00B23864
		public static EAppType FromString(string name)
		{
			EAppType result;
			if (!EAppTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EAppType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F09B RID: 192667 RVA: 0x00B25690 File Offset: 0x00B23890
		public static bool TryFromString(string name, out EAppType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EAppType.DEVELOPMENT;
				return false;
			}
			if (name == "Development")
			{
				value = EAppType.DEVELOPMENT;
				return true;
			}
			if (name == "Prerelease")
			{
				value = EAppType.PREREKEASE;
				return true;
			}
			if (!(name == "Product"))
			{
				value = EAppType.DEVELOPMENT;
				return false;
			}
			value = EAppType.PRODUCT;
			return true;
		}

		// Token: 0x0602F09C RID: 192668 RVA: 0x00B256E6 File Offset: 0x00B238E6
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Development",
				"Prerelease",
				"Product"
			};
		}

		// Token: 0x0602F09D RID: 192669 RVA: 0x00B25706 File Offset: 0x00B23906
		public static EAppType[] GetValues()
		{
			return new EAppType[]
			{
				EAppType.DEVELOPMENT,
				EAppType.PREREKEASE,
				EAppType.PRODUCT
			};
		}

		// Token: 0x0602F09E RID: 192670 RVA: 0x00B25716 File Offset: 0x00B23916
		public static string[] GetNames()
		{
			return new string[]
			{
				"DEVELOPMENT",
				"PREREKEASE",
				"PRODUCT"
			};
		}
	}
}
