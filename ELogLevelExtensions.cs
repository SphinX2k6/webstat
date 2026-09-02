using System;

// Token: 0x020034F6 RID: 13558
public static class ELogLevelExtensions
{
	// Token: 0x0601CA63 RID: 117347 RVA: 0x00898BE4 File Offset: 0x00896DE4
	public static string ToEnumString(this ELogLevel value)
	{
		string result;
		switch (value)
		{
		case ELogLevel.Error:
			result = "Error";
			break;
		case ELogLevel.Warn:
			result = "Warn";
			break;
		case ELogLevel.Info:
			result = "Info";
			break;
		case ELogLevel.Debug:
			result = "Debug";
			break;
		case ELogLevel.Max:
			result = "Max";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CA64 RID: 117348 RVA: 0x00898C44 File Offset: 0x00896E44
	public static ELogLevel FromString(string name)
	{
		ELogLevel result;
		if (!ELogLevelExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 ELogLevel 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CA65 RID: 117349 RVA: 0x00898C70 File Offset: 0x00896E70
	public static bool TryFromString(string name, out ELogLevel value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = ELogLevel.Error;
			return false;
		}
		if (name == "Error")
		{
			value = ELogLevel.Error;
			return true;
		}
		if (name == "Warn")
		{
			value = ELogLevel.Warn;
			return true;
		}
		if (name == "Info")
		{
			value = ELogLevel.Info;
			return true;
		}
		if (name == "Debug")
		{
			value = ELogLevel.Debug;
			return true;
		}
		if (!(name == "Max"))
		{
			value = ELogLevel.Error;
			return false;
		}
		value = ELogLevel.Max;
		return true;
	}

	// Token: 0x0601CA66 RID: 117350 RVA: 0x00898CEA File Offset: 0x00896EEA
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"Error",
			"Warn",
			"Info",
			"Debug",
			"Max"
		};
	}

	// Token: 0x0601CA67 RID: 117351 RVA: 0x00898D1A File Offset: 0x00896F1A
	public static ELogLevel[] GetValues()
	{
		return new ELogLevel[]
		{
			ELogLevel.Error,
			ELogLevel.Warn,
			ELogLevel.Info,
			ELogLevel.Debug,
			ELogLevel.Max
		};
	}

	// Token: 0x0601CA68 RID: 117352 RVA: 0x00898D2D File Offset: 0x00896F2D
	public static string[] GetNames()
	{
		return new string[]
		{
			"Error",
			"Warn",
			"Info",
			"Debug",
			"Max"
		};
	}
}
