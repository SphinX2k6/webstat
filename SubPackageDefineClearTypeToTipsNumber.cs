using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002AA0 RID: 10912
public static class SubPackageDefineClearTypeToTipsNumber
{
	// Token: 0x06015D4B RID: 89419 RVA: 0x0060E9D0 File Offset: 0x0060CBD0
	// Note: this type is marked as 'beforefieldinit'.
	static SubPackageDefineClearTypeToTipsNumber()
	{
		Dictionary<ESubPackageDownLoadPackageType, int> dictionary = new Dictionary<ESubPackageDownLoadPackageType, int>();
		dictionary[ESubPackageDownLoadPackageType.Key] = 0;
		dictionary[ESubPackageDownLoadPackageType.Expand] = 0;
		dictionary[ESubPackageDownLoadPackageType.OptionalPlot] = 1;
		dictionary[ESubPackageDownLoadPackageType.OptionalScene] = 2;
		dictionary[ESubPackageDownLoadPackageType.Voice] = 3;
		SubPackageDefineClearTypeToTipsNumber.clearTypeToTipsNumber = dictionary;
	}

	// Token: 0x0400A791 RID: 42897
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	public static Dictionary<ESubPackageDownLoadPackageType, int> clearTypeToTipsNumber;
}
