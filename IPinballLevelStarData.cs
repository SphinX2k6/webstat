using System;
using System.Runtime.CompilerServices;

// Token: 0x020014A5 RID: 5285
[NullableContext(2)]
public interface IPinballLevelStarData
{
	// Token: 0x17000C40 RID: 3136
	// (get) Token: 0x06009403 RID: 37891
	// (set) Token: 0x06009404 RID: 37892
	int ConditionId { get; set; }

	// Token: 0x17000C41 RID: 3137
	// (get) Token: 0x06009405 RID: 37893
	// (set) Token: 0x06009406 RID: 37894
	bool Passed { get; set; }

	// Token: 0x17000C42 RID: 3138
	// (get) Token: 0x06009407 RID: 37895
	// (set) Token: 0x06009408 RID: 37896
	string ConfigConditionDesc { get; set; }

	// Token: 0x17000C43 RID: 3139
	// (get) Token: 0x06009409 RID: 37897
	// (set) Token: 0x0600940A RID: 37898
	int? ConfigTargetValue { get; set; }
}
