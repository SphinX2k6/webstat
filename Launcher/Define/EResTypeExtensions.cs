using System;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200466A RID: 18026
	public static class EResTypeExtensions
	{
		// Token: 0x0602F00A RID: 192522 RVA: 0x00B2275C File Offset: 0x00B2095C
		public static string ToEnumString(this EResType value)
		{
			string result;
			switch (value)
			{
			case EResType.Launcher:
				result = "Launcher";
				break;
			case EResType.Resource:
				result = "Resource";
				break;
			case EResType.Lang:
				result = "Lang";
				break;
			case EResType.Video:
				result = "Video";
				break;
			case EResType.Optional:
				result = "Option";
				break;
			default:
				result = value.ToString();
				break;
			}
			return result;
		}

		// Token: 0x0602F00B RID: 192523 RVA: 0x00B227BC File Offset: 0x00B209BC
		public static EResType FromString(string name)
		{
			EResType result;
			if (!EResTypeExtensions.TryFromString(name, out result))
			{
				throw new InvalidCastException("从字符串转成枚举 EResType 失败, 字符串: " + name);
			}
			return result;
		}

		// Token: 0x0602F00C RID: 192524 RVA: 0x00B227E8 File Offset: 0x00B209E8
		public static bool TryFromString(string name, out EResType value)
		{
			if (string.IsNullOrEmpty(name))
			{
				value = EResType.Launcher;
				return false;
			}
			if (name == "Launcher")
			{
				value = EResType.Launcher;
				return true;
			}
			if (name == "Resource")
			{
				value = EResType.Resource;
				return true;
			}
			if (name == "Lang")
			{
				value = EResType.Lang;
				return true;
			}
			if (name == "Video")
			{
				value = EResType.Video;
				return true;
			}
			if (!(name == "Option"))
			{
				value = EResType.Launcher;
				return false;
			}
			value = EResType.Optional;
			return true;
		}

		// Token: 0x0602F00D RID: 192525 RVA: 0x00B22862 File Offset: 0x00B20A62
		public static string[] GetStringValues()
		{
			return new string[]
			{
				"Launcher",
				"Resource",
				"Lang",
				"Video",
				"Option"
			};
		}

		// Token: 0x0602F00E RID: 192526 RVA: 0x00B22892 File Offset: 0x00B20A92
		public static EResType[] GetValues()
		{
			return new EResType[]
			{
				EResType.Launcher,
				EResType.Resource,
				EResType.Lang,
				EResType.Video,
				EResType.Optional
			};
		}

		// Token: 0x0602F00F RID: 192527 RVA: 0x00B228A5 File Offset: 0x00B20AA5
		public static string[] GetNames()
		{
			return new string[]
			{
				"Launcher",
				"Resource",
				"Lang",
				"Video",
				"Optional"
			};
		}
	}
}
