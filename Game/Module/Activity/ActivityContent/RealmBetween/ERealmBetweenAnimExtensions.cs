using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RealmBetween
{
	// Token: 0x02006561 RID: 25953
	public static class ERealmBetweenAnimExtensions
	{
		// Token: 0x06040D6C RID: 265580 RVA: 0x010A0A68 File Offset: 0x0109EC68
		public static string ToEnumString(this ERealmBetweenAnim value)
		{
			string result;
			if (value != ERealmBetweenAnim.AniOpen)
			{
				if (value != ERealmBetweenAnim.AniClose)
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

		// Token: 0x06040D6D RID: 265581 RVA: 0x010A0AA0 File Offset: 0x0109ECA0
		public static ERealmBetweenAnim FromString(string name)
		{
			ERealmBetweenAnim result;
			if (!ERealmBetweenAnimExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ERealmBetweenAnim 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06040D6E RID: 265582 RVA: 0x010A0AC9 File Offset: 0x0109ECC9
		public static bool TryFromString(string name, out ERealmBetweenAnim value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ERealmBetweenAnim.AniOpen;
				return false;
			}
			if (name == "AniOpen")
			{
				value = ERealmBetweenAnim.AniOpen;
				return true;
			}
			if (!(name == "AniClose"))
			{
				value = ERealmBetweenAnim.AniOpen;
				return false;
			}
			value = ERealmBetweenAnim.AniClose;
			return true;
		}

		// Token: 0x06040D6F RID: 265583 RVA: 0x010A0B02 File Offset: 0x0109ED02
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"AniOpen",
				"AniClose"
			};
		}

		// Token: 0x06040D70 RID: 265584 RVA: 0x010A0B1A File Offset: 0x0109ED1A
		public static ERealmBetweenAnim[] GetValues()
		{
			return new ERealmBetweenAnim[]
			{
				ERealmBetweenAnim.AniOpen,
				ERealmBetweenAnim.AniClose
			};
		}

		// Token: 0x06040D71 RID: 265585 RVA: 0x010A0B26 File Offset: 0x0109ED26
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
