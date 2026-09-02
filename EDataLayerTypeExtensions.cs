using System;

// Token: 0x02003506 RID: 13574
public static class EDataLayerTypeExtensions
{
	// Token: 0x0601CAAB RID: 117419 RVA: 0x008A01AC File Offset: 0x0089E3AC
	public static string ToEnumString(this EDataLayerType value)
	{
		string result;
		switch (value)
		{
		case EDataLayerType.Default:
			result = "";
			break;
		case EDataLayerType.Cave:
			result = "DataLayerRuntime_EncloseSpace";
			break;
		case EDataLayerType.Room:
			result = "DataLayerRuntime_EncloseSpaceRoom";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CAAC RID: 117420 RVA: 0x008A01F4 File Offset: 0x0089E3F4
	public static EDataLayerType FromString(string name)
	{
		EDataLayerType result;
		if (!EDataLayerTypeExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 EDataLayerType 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CAAD RID: 117421 RVA: 0x008A0220 File Offset: 0x0089E420
	public static bool TryFromString(string name, out EDataLayerType value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = EDataLayerType.Default;
			return false;
		}
		if (name != null && name.Length == 0)
		{
			value = EDataLayerType.Default;
			return true;
		}
		if (name == "DataLayerRuntime_EncloseSpace")
		{
			value = EDataLayerType.Cave;
			return true;
		}
		if (!(name == "DataLayerRuntime_EncloseSpaceRoom"))
		{
			value = EDataLayerType.Default;
			return false;
		}
		value = EDataLayerType.Room;
		return true;
	}

	// Token: 0x0601CAAE RID: 117422 RVA: 0x008A0274 File Offset: 0x0089E474
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"",
			"DataLayerRuntime_EncloseSpace",
			"DataLayerRuntime_EncloseSpaceRoom"
		};
	}

	// Token: 0x0601CAAF RID: 117423 RVA: 0x008A0294 File Offset: 0x0089E494
	public static EDataLayerType[] GetValues()
	{
		return new EDataLayerType[]
		{
			EDataLayerType.Default,
			EDataLayerType.Cave,
			EDataLayerType.Room
		};
	}

	// Token: 0x0601CAB0 RID: 117424 RVA: 0x008A02A4 File Offset: 0x0089E4A4
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
