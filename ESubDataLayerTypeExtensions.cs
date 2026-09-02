using System;

// Token: 0x02003508 RID: 13576
public static class ESubDataLayerTypeExtensions
{
	// Token: 0x0601CAB4 RID: 117428 RVA: 0x008A0300 File Offset: 0x0089E500
	public static string ToEnumString(this ESubDataLayerType value)
	{
		string result;
		switch (value)
		{
		case ESubDataLayerType.Default:
			result = "";
			break;
		case ESubDataLayerType.Cave:
			result = "DataLayerRuntime_EncloseSpaceSub";
			break;
		case ESubDataLayerType.Room:
			result = "DataLayerRuntime_EncloseSpaceSubRoom";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CAB5 RID: 117429 RVA: 0x008A0348 File Offset: 0x0089E548
	public static ESubDataLayerType FromString(string name)
	{
		ESubDataLayerType result;
		if (!ESubDataLayerTypeExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 ESubDataLayerType 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CAB6 RID: 117430 RVA: 0x008A0374 File Offset: 0x0089E574
	public static bool TryFromString(string name, out ESubDataLayerType value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = ESubDataLayerType.Default;
			return false;
		}
		if (name != null && name.Length == 0)
		{
			value = ESubDataLayerType.Default;
			return true;
		}
		if (name == "DataLayerRuntime_EncloseSpaceSub")
		{
			value = ESubDataLayerType.Cave;
			return true;
		}
		if (!(name == "DataLayerRuntime_EncloseSpaceSubRoom"))
		{
			value = ESubDataLayerType.Default;
			return false;
		}
		value = ESubDataLayerType.Room;
		return true;
	}

	// Token: 0x0601CAB7 RID: 117431 RVA: 0x008A03C8 File Offset: 0x0089E5C8
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"",
			"DataLayerRuntime_EncloseSpaceSub",
			"DataLayerRuntime_EncloseSpaceSubRoom"
		};
	}

	// Token: 0x0601CAB8 RID: 117432 RVA: 0x008A03E8 File Offset: 0x0089E5E8
	public static ESubDataLayerType[] GetValues()
	{
		return new ESubDataLayerType[]
		{
			ESubDataLayerType.Default,
			ESubDataLayerType.Cave,
			ESubDataLayerType.Room
		};
	}

	// Token: 0x0601CAB9 RID: 117433 RVA: 0x008A03F8 File Offset: 0x0089E5F8
	public static string[] GetNames()
	{
		return new string[]
		{
			"Default",
			"Cave",
			"Room"
		};
	}
}
