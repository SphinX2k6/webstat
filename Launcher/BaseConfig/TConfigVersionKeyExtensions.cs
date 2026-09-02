using System;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x0200468F RID: 18063
	public static class TConfigVersionKeyExtensions
	{
		// Token: 0x0602F07E RID: 192638 RVA: 0x00B24E14 File Offset: 0x00B23014
		public static string ToEnumString(this TConfigVersionKey value)
		{
			string result;
			switch (value)
			{
			case TConfigVersionKey.FsmVersion:
				result = "FsmVersion";
				break;
			case TConfigVersionKey.MiscVersion:
				result = "MiscVersion";
				break;
			case TConfigVersionKey.PublicJsonVersion:
				result = "PublicJsonVersion";
				break;
			case TConfigVersionKey.UniverseEditorVersion:
				result = "UniverseEditorVersion";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F07F RID: 192639 RVA: 0x00B24E68 File Offset: 0x00B23068
		public static TConfigVersionKey FromString(string name)
		{
			TConfigVersionKey result;
			if (!TConfigVersionKeyExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 TConfigVersionKey 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F080 RID: 192640 RVA: 0x00B24E94 File Offset: 0x00B23094
		public static bool TryFromString(string name, out TConfigVersionKey value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = TConfigVersionKey.FsmVersion;
				return false;
			}
			if (name == "FsmVersion")
			{
				value = TConfigVersionKey.FsmVersion;
				return true;
			}
			if (name == "MiscVersion")
			{
				value = TConfigVersionKey.MiscVersion;
				return true;
			}
			if (name == "PublicJsonVersion")
			{
				value = TConfigVersionKey.PublicJsonVersion;
				return true;
			}
			if (!(name == "UniverseEditorVersion"))
			{
				value = TConfigVersionKey.FsmVersion;
				return false;
			}
			value = TConfigVersionKey.UniverseEditorVersion;
			return true;
		}

		// Token: 0x0602F081 RID: 192641 RVA: 0x00B24EFC File Offset: 0x00B230FC
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"FsmVersion",
				"MiscVersion",
				"PublicJsonVersion",
				"UniverseEditorVersion"
			};
		}

		// Token: 0x0602F082 RID: 192642 RVA: 0x00B24F24 File Offset: 0x00B23124
		public static TConfigVersionKey[] GetValues()
		{
			return new TConfigVersionKey[]
			{
				TConfigVersionKey.FsmVersion,
				TConfigVersionKey.MiscVersion,
				TConfigVersionKey.PublicJsonVersion,
				TConfigVersionKey.UniverseEditorVersion
			};
		}

		// Token: 0x0602F083 RID: 192643 RVA: 0x00B24F37 File Offset: 0x00B23137
		public static string[] GetNames()
		{
			return new string[]
			{
				"FsmVersion",
				"MiscVersion",
				"PublicJsonVersion",
				"UniverseEditorVersion"
			};
		}
	}
}
