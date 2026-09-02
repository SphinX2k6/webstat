using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02003100 RID: 12544
public class PerformGroupHelper : IStaticVariableResetter
{
	// Token: 0x06019F01 RID: 106241 RVA: 0x00795AD0 File Offset: 0x00793CD0
	static PerformGroupHelper()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PerformGroupHelper.CreateStaticDefaultValue), new Action(PerformGroupHelper.ResetStaticDefaultValue));
	}

	// Token: 0x06019F02 RID: 106242 RVA: 0x00795AF0 File Offset: 0x00793CF0
	public static void CreateStaticDefaultValue()
	{
		Dictionary<EPerformGroup, string> dictionary = new Dictionary<EPerformGroup, string>();
		dictionary[EPerformGroup.DefaultGroup] = "DefaultGroup";
		dictionary[EPerformGroup.KuroPerformSubGroup] = "Kuro表演子状态";
		PerformGroupHelper._performGroupToSlotGroupName = dictionary;
		Dictionary<string, EPerformGroup> dictionary2 = new Dictionary<string, EPerformGroup>();
		dictionary2["DefaultGroup"] = EPerformGroup.DefaultGroup;
		dictionary2["Kuro表演子状态"] = EPerformGroup.KuroPerformSubGroup;
		PerformGroupHelper._slotGroupNameToPerformGroup = dictionary2;
	}

	// Token: 0x06019F03 RID: 106243 RVA: 0x00795B41 File Offset: 0x00793D41
	public static void ResetStaticDefaultValue()
	{
		PerformGroupHelper._performGroupToSlotGroupName = null;
		PerformGroupHelper._slotGroupNameToPerformGroup = null;
	}

	// Token: 0x06019F04 RID: 106244 RVA: 0x00795B50 File Offset: 0x00793D50
	[NullableContext(2)]
	public static string GetSlotGroupName(EPerformGroup group)
	{
		string result;
		if (!PerformGroupHelper._performGroupToSlotGroupName.TryGetValue(group, out result))
		{
			return null;
		}
		return result;
	}

	// Token: 0x06019F05 RID: 106245 RVA: 0x00795B70 File Offset: 0x00793D70
	[NullableContext(1)]
	public static EPerformGroup GetPerformGroup(string slotGroupName)
	{
		EPerformGroup result;
		if (!PerformGroupHelper._slotGroupNameToPerformGroup.TryGetValue(slotGroupName, out result))
		{
			return EPerformGroup.DefaultGroup;
		}
		return result;
	}

	// Token: 0x0400CFEF RID: 53231
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<EPerformGroup, string> _performGroupToSlotGroupName;

	// Token: 0x0400CFF0 RID: 53232
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<string, EPerformGroup> _slotGroupNameToPerformGroup;
}
