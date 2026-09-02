using System;
using System.Runtime.CompilerServices;

// Token: 0x02002A72 RID: 10866
[NullableContext(1)]
public interface ISkipCondition<[Nullable(0)] T> where T : Enum
{
	// Token: 0x17001C31 RID: 7217
	// (get) Token: 0x06015C4C RID: 89164
	// (set) Token: 0x06015C4D RID: 89165
	T ConditionType { get; set; }
}
