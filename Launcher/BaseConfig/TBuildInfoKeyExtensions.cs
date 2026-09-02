using System;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004691 RID: 18065
	public static class TBuildInfoKeyExtensions
	{
		// Token: 0x0602F087 RID: 192647 RVA: 0x00B24F9C File Offset: 0x00B2319C
		public static string ToEnumString(this TBuildInfoKey value)
		{
			string result;
			switch (value)
			{
			case TBuildInfoKey.BuildId:
				result = "BuildId";
				break;
			case TBuildInfoKey.Changelist:
				result = "Changelist";
				break;
			case TBuildInfoKey.JSDebugId:
				result = "JSDebugId";
				break;
			case TBuildInfoKey.PatchVersion:
				result = "PatchVersion";
				break;
			case TBuildInfoKey.Stream:
				result = "Stream";
				break;
			case TBuildInfoKey.WaterMask:
				result = "WaterMask";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F088 RID: 192648 RVA: 0x00B25008 File Offset: 0x00B23208
		public static TBuildInfoKey FromString(string name)
		{
			TBuildInfoKey result;
			if (!TBuildInfoKeyExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 TBuildInfoKey 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F089 RID: 192649 RVA: 0x00B25034 File Offset: 0x00B23234
		public static bool TryFromString(string name, out TBuildInfoKey value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = TBuildInfoKey.BuildId;
				return false;
			}
			if (name == "BuildId")
			{
				value = TBuildInfoKey.BuildId;
				return true;
			}
			if (name == "Changelist")
			{
				value = TBuildInfoKey.Changelist;
				return true;
			}
			if (name == "JSDebugId")
			{
				value = TBuildInfoKey.JSDebugId;
				return true;
			}
			if (name == "PatchVersion")
			{
				value = TBuildInfoKey.PatchVersion;
				return true;
			}
			if (name == "Stream")
			{
				value = TBuildInfoKey.Stream;
				return true;
			}
			if (!(name == "WaterMask"))
			{
				value = TBuildInfoKey.BuildId;
				return false;
			}
			value = TBuildInfoKey.WaterMask;
			return true;
		}

		// Token: 0x0602F08A RID: 192650 RVA: 0x00B250C0 File Offset: 0x00B232C0
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"BuildId",
				"Changelist",
				"JSDebugId",
				"PatchVersion",
				"Stream",
				"WaterMask"
			};
		}

		// Token: 0x0602F08B RID: 192651 RVA: 0x00B250F8 File Offset: 0x00B232F8
		public static TBuildInfoKey[] GetValues()
		{
			return new TBuildInfoKey[]
			{
				TBuildInfoKey.BuildId,
				TBuildInfoKey.Changelist,
				TBuildInfoKey.JSDebugId,
				TBuildInfoKey.PatchVersion,
				TBuildInfoKey.Stream,
				TBuildInfoKey.WaterMask
			};
		}

		// Token: 0x0602F08C RID: 192652 RVA: 0x00B2510B File Offset: 0x00B2330B
		public static string[] GetNames()
		{
			return new string[]
			{
				"BuildId",
				"Changelist",
				"JSDebugId",
				"PatchVersion",
				"Stream",
				"WaterMask"
			};
		}
	}
}
