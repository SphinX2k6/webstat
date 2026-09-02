using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002C71 RID: 11377
public class RoleSpecialCaseConfig : IStaticVariableResetter
{
	// Token: 0x06016D13 RID: 93459 RVA: 0x00654CF0 File Offset: 0x00652EF0
	static RoleSpecialCaseConfig()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleSpecialCaseConfig.CreateStaticDefaultValue), new Action(RoleSpecialCaseConfig.ResetStaticDefaultValue));
	}

	// Token: 0x17001DE9 RID: 7657
	// (get) Token: 0x06016D14 RID: 93460 RVA: 0x00654D0F File Offset: 0x00652F0F
	[Nullable(1)]
	public static IReadOnlyDictionary<int, RoleSpecialCaseData> RoleSpecialCaseMap
	{
		[NullableContext(1)]
		get
		{
			return RoleSpecialCaseConfig._roleSpecialCaseMap;
		}
	}

	// Token: 0x06016D15 RID: 93461 RVA: 0x00654D18 File Offset: 0x00652F18
	public static void CreateStaticDefaultValue()
	{
		Dictionary<int, RoleSpecialCaseData> dictionary = new Dictionary<int, RoleSpecialCaseData>();
		dictionary[1309] = new RoleSpecialCaseData
		{
			Tags = new string[]
			{
				"角色.R2T1ThunderNanzhuMd10011.角色ui.雷漂泊者.男"
			}
		};
		dictionary[1310] = new RoleSpecialCaseData
		{
			Tags = new string[]
			{
				"角色.R2T1ThunderNanzhuMd10011.角色ui.雷漂泊者.女"
			}
		};
		RoleSpecialCaseConfig._roleSpecialCaseMap = dictionary;
	}

	// Token: 0x06016D16 RID: 93462 RVA: 0x00654D7D File Offset: 0x00652F7D
	public static void ResetStaticDefaultValue()
	{
		RoleSpecialCaseConfig._roleSpecialCaseMap = null;
	}

	// Token: 0x0400AFED RID: 45037
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<int, RoleSpecialCaseData> _roleSpecialCaseMap;
}
