using System;

// Token: 0x02003504 RID: 13572
public static class ERichTextTypeExtensions
{
	// Token: 0x0601CAA2 RID: 117410 RVA: 0x0089FFC8 File Offset: 0x0089E1C8
	public static string ToEnumString(this ERichTextType value)
	{
		string result;
		switch (value)
		{
		case ERichTextType.PlayerName:
			result = "PlayerName";
			break;
		case ERichTextType.SexChooseName:
			result = "TA";
			break;
		case ERichTextType.SexShowName:
			result = "SexShowName";
			break;
		case ERichTextType.InputType:
			result = "Ipt";
			break;
		case ERichTextType.SingularAndPlural:
			result = "Sap";
			break;
		case ERichTextType.Var:
			result = "Var";
			break;
		default:
			result = value.ToString();
			break;
		}
		return result;
	}

	// Token: 0x0601CAA3 RID: 117411 RVA: 0x008A0034 File Offset: 0x0089E234
	public static ERichTextType FromString(string name)
	{
		ERichTextType result;
		if (!ERichTextTypeExtensions.TryFromString(name, out result))
		{
			throw new InvalidCastException("从字符串转成枚举 ERichTextType 失败, 字符串: " + name);
		}
		return result;
	}

	// Token: 0x0601CAA4 RID: 117412 RVA: 0x008A0060 File Offset: 0x0089E260
	public static bool TryFromString(string name, out ERichTextType value)
	{
		if (string.IsNullOrEmpty(name))
		{
			value = ERichTextType.PlayerName;
			return false;
		}
		if (name == "PlayerName")
		{
			value = ERichTextType.PlayerName;
			return true;
		}
		if (name == "TA")
		{
			value = ERichTextType.SexChooseName;
			return true;
		}
		if (name == "SexShowName")
		{
			value = ERichTextType.SexShowName;
			return true;
		}
		if (name == "Ipt")
		{
			value = ERichTextType.InputType;
			return true;
		}
		if (name == "Sap")
		{
			value = ERichTextType.SingularAndPlural;
			return true;
		}
		if (!(name == "Var"))
		{
			value = ERichTextType.PlayerName;
			return false;
		}
		value = ERichTextType.Var;
		return true;
	}

	// Token: 0x0601CAA5 RID: 117413 RVA: 0x008A00EC File Offset: 0x0089E2EC
	public static string[] GetStringValues()
	{
		return new string[]
		{
			"PlayerName",
			"TA",
			"SexShowName",
			"Ipt",
			"Sap",
			"Var"
		};
	}

	// Token: 0x0601CAA6 RID: 117414 RVA: 0x008A0124 File Offset: 0x0089E324
	public static ERichTextType[] GetValues()
	{
		return new ERichTextType[]
		{
			ERichTextType.PlayerName,
			ERichTextType.SexChooseName,
			ERichTextType.SexShowName,
			ERichTextType.InputType,
			ERichTextType.SingularAndPlural,
			ERichTextType.Var
		};
	}

	// Token: 0x0601CAA7 RID: 117415 RVA: 0x008A0137 File Offset: 0x0089E337
	public static string[] GetNames()
	{
		return new string[]
		{
			"PlayerName",
			"SexChooseName",
			"SexShowName",
			"InputType",
			"SingularAndPlural",
			"Var"
		};
	}
}
