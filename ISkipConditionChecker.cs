using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A76 RID: 10870
[NullableContext(1)]
public interface ISkipConditionChecker
{
	// Token: 0x06015C58 RID: 89176
	ISkipCondition<ESkipConditionType> Parse(int[] @params);

	// Token: 0x06015C59 RID: 89177
	bool Check(int[] @params);
}
