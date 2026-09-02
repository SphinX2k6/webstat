using System;
using System.Runtime.CompilerServices;

// Token: 0x020014C7 RID: 5319
[NullableContext(1)]
public interface IPinballBattleLevelInfoViewParam
{
	// Token: 0x17000C8E RID: 3214
	// (get) Token: 0x060094C1 RID: 38081
	// (set) Token: 0x060094C2 RID: 38082
	int LevelId { get; set; }

	// Token: 0x17000C8F RID: 3215
	// (get) Token: 0x060094C3 RID: 38083
	// (set) Token: 0x060094C4 RID: 38084
	EPinballLevelShowType LevelType { get; set; }

	// Token: 0x17000C90 RID: 3216
	// (get) Token: 0x060094C5 RID: 38085
	// (set) Token: 0x060094C6 RID: 38086
	int Score { get; set; }

	// Token: 0x17000C91 RID: 3217
	// (get) Token: 0x060094C7 RID: 38087
	// (set) Token: 0x060094C8 RID: 38088
	int[] StarInfo { get; set; }
}
