using System;

namespace CSharpScript.Launcher.Platform.PlatformSdk
{
	// Token: 0x020045CC RID: 17868
	public static class PlatformSdkServerMsgExtensions
	{
		// Token: 0x0602ED26 RID: 191782 RVA: 0x00B16838 File Offset: 0x00B14A38
		public static string ToEnumString(this PlatformSdkServerMsg value)
		{
			string result;
			if (value != PlatformSdkServerMsg.BadHttp)
			{
				if (value != PlatformSdkServerMsg.PsnAuthFail)
				{
					result = value.ToString();
				}
				else
				{
					result = "PsnAuthFail";
				}
			}
			else
			{
				result = "HttpFail";
			}
			return result;
		}

		// Token: 0x0602ED27 RID: 191783 RVA: 0x00B16870 File Offset: 0x00B14A70
		public static PlatformSdkServerMsg FromString(string name)
		{
			PlatformSdkServerMsg result;
			if (!PlatformSdkServerMsgExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 PlatformSdkServerMsg 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602ED28 RID: 191784 RVA: 0x00B16899 File Offset: 0x00B14A99
		public static bool TryFromString(string name, out PlatformSdkServerMsg value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = PlatformSdkServerMsg.BadHttp;
				return false;
			}
			if (name == "HttpFail")
			{
				value = PlatformSdkServerMsg.BadHttp;
				return true;
			}
			if (!(name == "PsnAuthFail"))
			{
				value = PlatformSdkServerMsg.BadHttp;
				return false;
			}
			value = PlatformSdkServerMsg.PsnAuthFail;
			return true;
		}

		// Token: 0x0602ED29 RID: 191785 RVA: 0x00B168D2 File Offset: 0x00B14AD2
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"HttpFail",
				"PsnAuthFail"
			};
		}

		// Token: 0x0602ED2A RID: 191786 RVA: 0x00B168EA File Offset: 0x00B14AEA
		public static PlatformSdkServerMsg[] GetValues()
		{
			return new PlatformSdkServerMsg[]
			{
				PlatformSdkServerMsg.BadHttp,
				PlatformSdkServerMsg.PsnAuthFail
			};
		}

		// Token: 0x0602ED2B RID: 191787 RVA: 0x00B168F6 File Offset: 0x00B14AF6
		public static string[] GetNames()
		{
			return new string[]
			{
				"BadHttp",
				"PsnAuthFail"
			};
		}
	}
}
