using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020014B4 RID: 5300
[NullableContext(1)]
public interface IPinballSettleResultViewParam
{
	// Token: 0x17000C63 RID: 3171
	// (get) Token: 0x06009452 RID: 37970
	// (set) Token: 0x06009453 RID: 37971
	int LevelId { get; set; }

	// Token: 0x17000C64 RID: 3172
	// (get) Token: 0x06009454 RID: 37972
	// (set) Token: 0x06009455 RID: 37973
	EPinballLevelShowType LevelType { get; set; }

	// Token: 0x17000C65 RID: 3173
	// (get) Token: 0x06009456 RID: 37974
	// (set) Token: 0x06009457 RID: 37975
	bool IsWin { get; set; }

	// Token: 0x17000C66 RID: 3174
	// (get) Token: 0x06009458 RID: 37976
	// (set) Token: 0x06009459 RID: 37977
	int MostValuablePlayerRoleId { get; set; }

	// Token: 0x17000C67 RID: 3175
	// (get) Token: 0x0600945A RID: 37978
	// (set) Token: 0x0600945B RID: 37979
	Dictionary<int, float> Roles { get; set; }

	// Token: 0x17000C68 RID: 3176
	// (get) Token: 0x0600945C RID: 37980
	// (set) Token: 0x0600945D RID: 37981
	bool[] StarInfo { get; set; }

	// Token: 0x17000C69 RID: 3177
	// (get) Token: 0x0600945E RID: 37982
	// (set) Token: 0x0600945F RID: 37983
	int Score { get; set; }

	// Token: 0x17000C6A RID: 3178
	// (get) Token: 0x06009460 RID: 37984
	// (set) Token: 0x06009461 RID: 37985
	bool IsFirstPass { get; set; }
}
