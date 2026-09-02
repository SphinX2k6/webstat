using System;

namespace CSharpScript.Launcher.Platform
{
	// Token: 0x02004555 RID: 17749
	public static class ECloudGamePlatformExtensions
	{
		// Token: 0x0602EB49 RID: 191305 RVA: 0x00B10F2C File Offset: 0x00B0F12C
		public static string ToEnumString(this ECloudGamePlatform value)
		{
			string result;
			switch (value)
			{
			case ECloudGamePlatform.Android:
				result = "Android";
				break;
			case ECloudGamePlatform.IOS:
				result = "IOS";
				break;
			case ECloudGamePlatform.Mac:
				result = "Mac";
				break;
			case ECloudGamePlatform.Windows:
				result = "Windows";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602EB4A RID: 191306 RVA: 0x00B10F80 File Offset: 0x00B0F180
		public static ECloudGamePlatform FromString(string name)
		{
			ECloudGamePlatform result;
			if (!ECloudGamePlatformExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 ECloudGamePlatform 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602EB4B RID: 191307 RVA: 0x00B10FAC File Offset: 0x00B0F1AC
		public static bool TryFromString(string name, out ECloudGamePlatform value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = ECloudGamePlatform.Android;
				return false;
			}
			if (name == "Android")
			{
				value = ECloudGamePlatform.Android;
				return true;
			}
			if (name == "IOS")
			{
				value = ECloudGamePlatform.IOS;
				return true;
			}
			if (name == "Mac")
			{
				value = ECloudGamePlatform.Mac;
				return true;
			}
			if (!(name == "Windows"))
			{
				value = ECloudGamePlatform.Android;
				return false;
			}
			value = ECloudGamePlatform.Windows;
			return true;
		}

		// Token: 0x0602EB4C RID: 191308 RVA: 0x00B11014 File Offset: 0x00B0F214
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Android",
				"IOS",
				"Mac",
				"Windows"
			};
		}

		// Token: 0x0602EB4D RID: 191309 RVA: 0x00B1103C File Offset: 0x00B0F23C
		public static ECloudGamePlatform[] GetValues()
		{
			return new ECloudGamePlatform[]
			{
				ECloudGamePlatform.Android,
				ECloudGamePlatform.IOS,
				ECloudGamePlatform.Mac,
				ECloudGamePlatform.Windows
			};
		}

		// Token: 0x0602EB4E RID: 191310 RVA: 0x00B1104F File Offset: 0x00B0F24F
		public static string[] GetNames()
		{
			return new string[]
			{
				"Android",
				"IOS",
				"Mac",
				"Windows"
			};
		}
	}
}
