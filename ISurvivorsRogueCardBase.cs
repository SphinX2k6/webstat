using System;
using System.Runtime.CompilerServices;

// Token: 0x02002B94 RID: 11156
[NullableContext(2)]
public interface ISurvivorsRogueCardBase
{
	// Token: 0x17001CFE RID: 7422
	// (get) Token: 0x06016381 RID: 91009
	ESurvivorsRogueItemType Type { get; }

	// Token: 0x17001CFF RID: 7423
	// (get) Token: 0x06016382 RID: 91010
	int Id { get; }

	// Token: 0x17001D00 RID: 7424
	// (get) Token: 0x06016383 RID: 91011
	int? IncId { get; }

	// Token: 0x17001D01 RID: 7425
	// (get) Token: 0x06016384 RID: 91012
	int Index { get; }

	// Token: 0x17001D02 RID: 7426
	// (get) Token: 0x06016385 RID: 91013
	int QualityId { get; }

	// Token: 0x17001D03 RID: 7427
	// (get) Token: 0x06016386 RID: 91014
	string TitleId { get; }

	// Token: 0x17001D04 RID: 7428
	// (get) Token: 0x06016387 RID: 91015
	string TitleText { get; }

	// Token: 0x17001D05 RID: 7429
	// (get) Token: 0x06016388 RID: 91016
	[Nullable(1)]
	string DescId { [NullableContext(1)] get; }

	// Token: 0x17001D06 RID: 7430
	// (get) Token: 0x06016389 RID: 91017
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] DescParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }

	// Token: 0x17001D07 RID: 7431
	// (get) Token: 0x0601638A RID: 91018
	bool? TagVisible { get; }

	// Token: 0x17001D08 RID: 7432
	// (get) Token: 0x0601638B RID: 91019
	string TagId { get; }

	// Token: 0x17001D09 RID: 7433
	// (get) Token: 0x0601638C RID: 91020
	[Nullable(new byte[]
	{
		2,
		1
	})]
	string[] TagParams { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; }

	// Token: 0x17001D0A RID: 7434
	// (get) Token: 0x0601638D RID: 91021
	bool? UseToggle { get; }

	// Token: 0x17001D0B RID: 7435
	// (get) Token: 0x0601638E RID: 91022
	bool? IsLevelUp { get; }

	// Token: 0x17001D0C RID: 7436
	// (get) Token: 0x0601638F RID: 91023
	bool? NeedLock { get; }

	// Token: 0x17001D0D RID: 7437
	// (get) Token: 0x06016390 RID: 91024
	bool? LockState { get; }

	// Token: 0x17001D0E RID: 7438
	// (get) Token: 0x06016391 RID: 91025
	int? Cost { get; }

	// Token: 0x17001D0F RID: 7439
	// (get) Token: 0x06016392 RID: 91026
	bool? CostEnoughCheck { get; }
}
