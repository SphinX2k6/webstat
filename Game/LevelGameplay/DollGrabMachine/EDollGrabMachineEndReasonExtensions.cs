using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EDE RID: 28382
	public static class EDollGrabMachineEndReasonExtensions
	{
		// Token: 0x06044CED RID: 281837 RVA: 0x011E6AD0 File Offset: 0x011E4CD0
		public static string ToEnumString(this EDollGrabMachineEndReason value)
		{
			string result;
			switch (value)
			{
			case EDollGrabMachineEndReason.TimeUp:
				result = "TimeUp";
				break;
			case EDollGrabMachineEndReason.GetAll:
				result = "GetAll";
				break;
			case EDollGrabMachineEndReason.Exit:
				result = "Exit";
				break;
			case EDollGrabMachineEndReason.Exception:
				result = "Exception";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x06044CEE RID: 281838 RVA: 0x011E6B24 File Offset: 0x011E4D24
		public static EDollGrabMachineEndReason FromString(string name)
		{
			EDollGrabMachineEndReason result;
			if (!EDollGrabMachineEndReasonExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EDollGrabMachineEndReason 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x06044CEF RID: 281839 RVA: 0x011E6B50 File Offset: 0x011E4D50
		public static bool TryFromString(string name, out EDollGrabMachineEndReason value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EDollGrabMachineEndReason.TimeUp;
				return false;
			}
			if (name == "TimeUp")
			{
				value = EDollGrabMachineEndReason.TimeUp;
				return true;
			}
			if (name == "GetAll")
			{
				value = EDollGrabMachineEndReason.GetAll;
				return true;
			}
			if (name == "Exit")
			{
				value = EDollGrabMachineEndReason.Exit;
				return true;
			}
			if (!(name == "Exception"))
			{
				value = EDollGrabMachineEndReason.TimeUp;
				return false;
			}
			value = EDollGrabMachineEndReason.Exception;
			return true;
		}

		// Token: 0x06044CF0 RID: 281840 RVA: 0x011E6BB8 File Offset: 0x011E4DB8
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"TimeUp",
				"GetAll",
				"Exit",
				"Exception"
			};
		}

		// Token: 0x06044CF1 RID: 281841 RVA: 0x011E6BE0 File Offset: 0x011E4DE0
		public static EDollGrabMachineEndReason[] GetValues()
		{
			return new EDollGrabMachineEndReason[]
			{
				EDollGrabMachineEndReason.TimeUp,
				EDollGrabMachineEndReason.GetAll,
				EDollGrabMachineEndReason.Exit,
				EDollGrabMachineEndReason.Exception
			};
		}

		// Token: 0x06044CF2 RID: 281842 RVA: 0x011E6BF3 File Offset: 0x011E4DF3
		public static string[] GetNames()
		{
			return new string[]
			{
				"TimeUp",
				"GetAll",
				"Exit",
				"Exception"
			};
		}
	}
}
