using System;
using System.Runtime.CompilerServices;

// Token: 0x02001179 RID: 4473
[NullableContext(1)]
[Nullable(0)]
public class IActivityLevelFunc
{
	// Token: 0x0400390E RID: 14606
	public Func<int, bool> CheckIsActivityLevel;

	// Token: 0x0400390F RID: 14607
	public Func<int, int, int> GetLevelRecommendLevel;
}
