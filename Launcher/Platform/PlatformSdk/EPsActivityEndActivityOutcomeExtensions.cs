using System;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045CE RID: 17870
	public static class EPsActivityEndActivityOutcomeExtensions
	{
		// Token: 0x0602ED2F RID: 191791 RVA: 0x00B1694C File Offset: 0x00B14B4C
		public static string ToEnumString(this EPsActivityEndActivityOutcome value)
		{
			string result;
			switch (value)
			{
			case EPsActivityEndActivityOutcome.Completed:
				result = "completed";
				break;
			case EPsActivityEndActivityOutcome.Failed:
				result = "failed";
				break;
			case EPsActivityEndActivityOutcome.Abandoned:
				result = "abandoned";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602ED30 RID: 191792 RVA: 0x00B16994 File Offset: 0x00B14B94
		public static EPsActivityEndActivityOutcome FromString(string name)
		{
			EPsActivityEndActivityOutcome result;
			if (!EPsActivityEndActivityOutcomeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EPsActivityEndActivityOutcome 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602ED31 RID: 191793 RVA: 0x00B169C0 File Offset: 0x00B14BC0
		public static bool TryFromString(string name, out EPsActivityEndActivityOutcome value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EPsActivityEndActivityOutcome.Completed;
				return false;
			}
			if (name == "completed")
			{
				value = EPsActivityEndActivityOutcome.Completed;
				return true;
			}
			if (name == "failed")
			{
				value = EPsActivityEndActivityOutcome.Failed;
				return true;
			}
			if (!(name == "abandoned"))
			{
				value = EPsActivityEndActivityOutcome.Completed;
				return false;
			}
			value = EPsActivityEndActivityOutcome.Abandoned;
			return true;
		}

		// Token: 0x0602ED32 RID: 191794 RVA: 0x00B16A16 File Offset: 0x00B14C16
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"completed",
				"failed",
				"abandoned"
			};
		}

		// Token: 0x0602ED33 RID: 191795 RVA: 0x00B16A36 File Offset: 0x00B14C36
		public static EPsActivityEndActivityOutcome[] GetValues()
		{
			return new EPsActivityEndActivityOutcome[]
			{
				EPsActivityEndActivityOutcome.Completed,
				EPsActivityEndActivityOutcome.Failed,
				EPsActivityEndActivityOutcome.Abandoned
			};
		}

		// Token: 0x0602ED34 RID: 191796 RVA: 0x00B16A46 File Offset: 0x00B14C46
		public static string[] GetNames()
		{
			return new string[]
			{
				"Completed",
				"Failed",
				"Abandoned"
			};
		}
	}
}
