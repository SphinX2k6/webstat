using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002A7D RID: 10877
public class SkipConditionDefine
{
	// Token: 0x0400A6FE RID: 42750
	[Nullable(1)]
	public static readonly Dictionary<ESkipConditionType, ISkipConditionChecker> SkipConditionCheckerMap = new Dictionary<ESkipConditionType, ISkipConditionChecker>
	{
		{
			ESkipConditionType.SystemFunction,
			new SystemFunctionConditionChecker()
		},
		{
			ESkipConditionType.QuestState,
			new QuestStateConditionChecker()
		},
		{
			ESkipConditionType.TeleportState,
			new TeleportStateConditionChecker()
		}
	};
}
