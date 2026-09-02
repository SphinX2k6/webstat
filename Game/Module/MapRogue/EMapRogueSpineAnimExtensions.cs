using System;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599E RID: 22942
	public static class EMapRogueSpineAnimExtensions
	{
		// Token: 0x0603A15B RID: 237915 RVA: 0x00EB3384 File Offset: 0x00EB1584
		public static string ToEnumString(this EMapRogueSpineAnim value)
		{
			string result;
			switch (value)
			{
			case EMapRogueSpineAnim.Idle:
				result = "Idle";
				break;
			case EMapRogueSpineAnim.Move:
				result = "Run";
				break;
			case EMapRogueSpineAnim.Cheer:
				result = "Cheer";
				break;
			case EMapRogueSpineAnim.Fight:
				result = "Fight";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0603A15C RID: 237916 RVA: 0x00EB33D8 File Offset: 0x00EB15D8
		public static EMapRogueSpineAnim FromString(string name)
		{
			EMapRogueSpineAnim result;
			if (!EMapRogueSpineAnimExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EMapRogueSpineAnim 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0603A15D RID: 237917 RVA: 0x00EB3404 File Offset: 0x00EB1604
		public static bool TryFromString(string name, out EMapRogueSpineAnim value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EMapRogueSpineAnim.Idle;
				return false;
			}
			if (name == "Idle")
			{
				value = EMapRogueSpineAnim.Idle;
				return true;
			}
			if (name == "Run")
			{
				value = EMapRogueSpineAnim.Move;
				return true;
			}
			if (name == "Cheer")
			{
				value = EMapRogueSpineAnim.Cheer;
				return true;
			}
			if (!(name == "Fight"))
			{
				value = EMapRogueSpineAnim.Idle;
				return false;
			}
			value = EMapRogueSpineAnim.Fight;
			return true;
		}

		// Token: 0x0603A15E RID: 237918 RVA: 0x00EB346C File Offset: 0x00EB166C
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Idle",
				"Run",
				"Cheer",
				"Fight"
			};
		}

		// Token: 0x0603A15F RID: 237919 RVA: 0x00EB3494 File Offset: 0x00EB1694
		public static EMapRogueSpineAnim[] GetValues()
		{
			return new EMapRogueSpineAnim[]
			{
				EMapRogueSpineAnim.Idle,
				EMapRogueSpineAnim.Move,
				EMapRogueSpineAnim.Cheer,
				EMapRogueSpineAnim.Fight
			};
		}

		// Token: 0x0603A160 RID: 237920 RVA: 0x00EB34A7 File Offset: 0x00EB16A7
		public static string[] GetNames()
		{
			return new string[]
			{
				"Idle",
				"Move",
				"Cheer",
				"Fight"
			};
		}
	}
}
