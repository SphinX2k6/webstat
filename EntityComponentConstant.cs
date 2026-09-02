using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02000093 RID: 147
public class EntityComponentConstant : IStaticVariableResetter
{
	// Token: 0x0600039B RID: 923 RVA: 0x00016269 File Offset: 0x00014469
	static EntityComponentConstant()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(EntityComponentConstant.CreateStaticDefaultValue), new Action(EntityComponentConstant.ResetStaticDefaultValue));
	}

	// Token: 0x1700007F RID: 127
	// (get) Token: 0x0600039C RID: 924 RVA: 0x00016288 File Offset: 0x00014488
	[Nullable(new byte[]
	{
		1,
		1,
		1,
		2
	})]
	public static Dictionary<string, Stat[]> StatMap
	{
		[return: Nullable(new byte[]
		{
			1,
			1,
			1,
			2
		})]
		get
		{
			Dictionary<string, Stat[]> result;
			if ((result = EntityComponentConstant._statMap) == null)
			{
				result = (EntityComponentConstant._statMap = new Dictionary<string, Stat[]>());
			}
			return result;
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0001629E File Offset: 0x0001449E
	public static void CreateStaticDefaultValue()
	{
		EntityComponentConstant._statMap = new Dictionary<string, Stat[]>();
	}

	// Token: 0x0600039E RID: 926 RVA: 0x000162AA File Offset: 0x000144AA
	public static void ResetStaticDefaultValue()
	{
		EntityComponentConstant._statMap = null;
	}

	// Token: 0x0400038B RID: 907
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		2
	})]
	private static Dictionary<string, Stat[]> _statMap;
}
