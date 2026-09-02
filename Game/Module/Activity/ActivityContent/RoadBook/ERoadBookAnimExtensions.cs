using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064C2 RID: 25794
	public static class ERoadBookAnimExtensions
	{
		// Token: 0x06040A17 RID: 264727 RVA: 0x01091404 File Offset: 0x0108F604
		public static string ToEnumString(this ERoadBookAnim value)
		{
			string result;
			if (value != ERoadBookAnim.AniOpen)
			{
				if (value != ERoadBookAnim.AniClose)
				{
					result = value.ToString();
				}
				else
				{
					result = "AniClose";
				}
			}
			else
			{
				result = "AniOpen";
			}
			return result;
		}

		// Token: 0x06040A18 RID: 264728 RVA: 0x0109143C File Offset: 0x0108F63C
		public static ERoadBookAnim FromString(string name)
		{
			ERoadBookAnim result;
			if (!ERoadBookAnimExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ERoadBookAnim 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06040A19 RID: 264729 RVA: 0x01091465 File Offset: 0x0108F665
		public static bool TryFromString(string name, out ERoadBookAnim value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ERoadBookAnim.AniOpen;
				return false;
			}
			if (name == "AniOpen")
			{
				value = ERoadBookAnim.AniOpen;
				return true;
			}
			if (!(name == "AniClose"))
			{
				value = ERoadBookAnim.AniOpen;
				return false;
			}
			value = ERoadBookAnim.AniClose;
			return true;
		}

		// Token: 0x06040A1A RID: 264730 RVA: 0x0109149E File Offset: 0x0108F69E
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"AniOpen",
				"AniClose"
			};
		}

		// Token: 0x06040A1B RID: 264731 RVA: 0x010914B6 File Offset: 0x0108F6B6
		public static ERoadBookAnim[] GetValues()
		{
			return new ERoadBookAnim[]
			{
				ERoadBookAnim.AniOpen,
				ERoadBookAnim.AniClose
			};
		}

		// Token: 0x06040A1C RID: 264732 RVA: 0x010914C2 File Offset: 0x0108F6C2
		public static string[] GetNames()
		{
			return new string[]
			{
				"AniOpen",
				"AniClose"
			};
		}
	}
}
