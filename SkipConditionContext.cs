using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A6E RID: 10862
public class SkipConditionContext
{
	// Token: 0x06015C4A RID: 89162 RVA: 0x0060A79C File Offset: 0x0060899C
	[NullableContext(1)]
	public bool Check(ESkipConditionType conditionType, int[] @params)
	{
		ISkipConditionChecker skipConditionChecker;
		return SkipConditionDefine.SkipConditionCheckerMap.TryGetValue(conditionType, out skipConditionChecker) && skipConditionChecker.Check(@params);
	}
}
