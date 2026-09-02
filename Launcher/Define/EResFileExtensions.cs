using System;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004668 RID: 18024
	public static class EResFileExtensions
	{
		// Token: 0x0602F001 RID: 192513 RVA: 0x00B225D4 File Offset: 0x00B207D4
		public static string ToEnumString(this EResFile value)
		{
			string result;
			switch (value)
			{
			case EResFile.PAK:
				result = ".pak";
				break;
			case EResFile.SIG:
				result = ".sig";
				break;
			case EResFile.UTOC:
				result = ".utoc";
				break;
			case EResFile.UCAS:
				result = ".ucas";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F002 RID: 192514 RVA: 0x00B22628 File Offset: 0x00B20828
		public static EResFile FromString(string name)
		{
			EResFile result;
			if (!EResFileExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EResFile 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F003 RID: 192515 RVA: 0x00B22654 File Offset: 0x00B20854
		public static bool TryFromString(string name, out EResFile value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EResFile.PAK;
				return false;
			}
			if (name == ".pak")
			{
				value = EResFile.PAK;
				return true;
			}
			if (name == ".sig")
			{
				value = EResFile.SIG;
				return true;
			}
			if (name == ".utoc")
			{
				value = EResFile.UTOC;
				return true;
			}
			if (!(name == ".ucas"))
			{
				value = EResFile.PAK;
				return false;
			}
			value = EResFile.UCAS;
			return true;
		}

		// Token: 0x0602F004 RID: 192516 RVA: 0x00B226BC File Offset: 0x00B208BC
		public static string[] GetStringValues()
		{
			return new string[]
			{
				".pak",
				".sig",
				".utoc",
				".ucas"
			};
		}

		// Token: 0x0602F005 RID: 192517 RVA: 0x00B226E4 File Offset: 0x00B208E4
		public static EResFile[] GetValues()
		{
			return new EResFile[]
			{
				EResFile.PAK,
				EResFile.SIG,
				EResFile.UTOC,
				EResFile.UCAS
			};
		}

		// Token: 0x0602F006 RID: 192518 RVA: 0x00B226F7 File Offset: 0x00B208F7
		public static string[] GetNames()
		{
			return new string[]
			{
				"PAK",
				"SIG",
				"UTOC",
				"UCAS"
			};
		}
	}
}
