using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EDC RID: 28380
	public static class EDollGrabMachineStateExtensions
	{
		// Token: 0x06044CE4 RID: 281828 RVA: 0x011E6978 File Offset: 0x011E4B78
		public static string ToEnumString(this EDollGrabMachineState value)
		{
			string result;
			switch (value)
			{
			case EDollGrabMachineState.InActive:
				result = "InActive";
				break;
			case EDollGrabMachineState.WaitingCountDown:
				result = "WaitingCountDown";
				break;
			case EDollGrabMachineState.Active:
				result = "Active";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06044CE5 RID: 281829 RVA: 0x011E69C0 File Offset: 0x011E4BC0
		public static EDollGrabMachineState FromString(string name)
		{
			EDollGrabMachineState result;
			if (!EDollGrabMachineStateExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDollGrabMachineState 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06044CE6 RID: 281830 RVA: 0x011E69EC File Offset: 0x011E4BEC
		public static bool TryFromString(string name, out EDollGrabMachineState value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDollGrabMachineState.InActive;
				return false;
			}
			if (name == "InActive")
			{
				value = EDollGrabMachineState.InActive;
				return true;
			}
			if (name == "WaitingCountDown")
			{
				value = EDollGrabMachineState.WaitingCountDown;
				return true;
			}
			if (!(name == "Active"))
			{
				value = EDollGrabMachineState.InActive;
				return false;
			}
			value = EDollGrabMachineState.Active;
			return true;
		}

		// Token: 0x06044CE7 RID: 281831 RVA: 0x011E6A42 File Offset: 0x011E4C42
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"InActive",
				"WaitingCountDown",
				"Active"
			};
		}

		// Token: 0x06044CE8 RID: 281832 RVA: 0x011E6A62 File Offset: 0x011E4C62
		public static EDollGrabMachineState[] GetValues()
		{
			return new EDollGrabMachineState[]
			{
				EDollGrabMachineState.InActive,
				EDollGrabMachineState.WaitingCountDown,
				EDollGrabMachineState.Active
			};
		}

		// Token: 0x06044CE9 RID: 281833 RVA: 0x011E6A72 File Offset: 0x011E4C72
		public static string[] GetNames()
		{
			return new string[]
			{
				"InActive",
				"WaitingCountDown",
				"Active"
			};
		}
	}
}
