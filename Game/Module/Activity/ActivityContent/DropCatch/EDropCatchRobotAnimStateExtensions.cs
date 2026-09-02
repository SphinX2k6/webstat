using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D2 RID: 26834
	public static class EDropCatchRobotAnimStateExtensions
	{
		// Token: 0x06042B94 RID: 273300 RVA: 0x011202F8 File Offset: 0x0111E4F8
		public static string ToEnumString(this EDropCatchRobotAnimState value)
		{
			string result;
			switch (value)
			{
			case EDropCatchRobotAnimState.HappyLeft:
				result = "happy_R";
				break;
			case EDropCatchRobotAnimState.HappyRight:
				result = "happy_L";
				break;
			case EDropCatchRobotAnimState.IdleLeft:
				result = "idle_R";
				break;
			case EDropCatchRobotAnimState.IdleRight:
				result = "idle_L";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06042B95 RID: 273301 RVA: 0x0112034C File Offset: 0x0111E54C
		public static EDropCatchRobotAnimState FromString(string name)
		{
			EDropCatchRobotAnimState result;
			if (!EDropCatchRobotAnimStateExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDropCatchRobotAnimState 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06042B96 RID: 273302 RVA: 0x01120378 File Offset: 0x0111E578
		public static bool TryFromString(string name, out EDropCatchRobotAnimState value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDropCatchRobotAnimState.HappyLeft;
				return false;
			}
			if (name == "happy_R")
			{
				value = EDropCatchRobotAnimState.HappyLeft;
				return true;
			}
			if (name == "happy_L")
			{
				value = EDropCatchRobotAnimState.HappyRight;
				return true;
			}
			if (name == "idle_R")
			{
				value = EDropCatchRobotAnimState.IdleLeft;
				return true;
			}
			if (!(name == "idle_L"))
			{
				value = EDropCatchRobotAnimState.HappyLeft;
				return false;
			}
			value = EDropCatchRobotAnimState.IdleRight;
			return true;
		}

		// Token: 0x06042B97 RID: 273303 RVA: 0x011203E0 File Offset: 0x0111E5E0
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"happy_R",
				"happy_L",
				"idle_R",
				"idle_L"
			};
		}

		// Token: 0x06042B98 RID: 273304 RVA: 0x01120408 File Offset: 0x0111E608
		public static EDropCatchRobotAnimState[] GetValues()
		{
			return new EDropCatchRobotAnimState[]
			{
				EDropCatchRobotAnimState.HappyLeft,
				EDropCatchRobotAnimState.HappyRight,
				EDropCatchRobotAnimState.IdleLeft,
				EDropCatchRobotAnimState.IdleRight
			};
		}

		// Token: 0x06042B99 RID: 273305 RVA: 0x0112041B File Offset: 0x0111E61B
		public static string[] GetNames()
		{
			return new string[]
			{
				"HappyLeft",
				"HappyRight",
				"IdleLeft",
				"IdleRight"
			};
		}
	}
}
