using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020011F8 RID: 4600
[NullableContext(2)]
public interface IBabelTowerSettlementViewData
{
	// Token: 0x17000A7B RID: 2683
	// (get) Token: 0x060079D3 RID: 31187
	// (set) Token: 0x060079D4 RID: 31188
	int LevelId { get; set; }

	// Token: 0x17000A7C RID: 2684
	// (get) Token: 0x060079D5 RID: 31189
	// (set) Token: 0x060079D6 RID: 31190
	int StarNum { get; set; }

	// Token: 0x17000A7D RID: 2685
	// (get) Token: 0x060079D7 RID: 31191
	// (set) Token: 0x060079D8 RID: 31192
	int PassTime { get; set; }

	// Token: 0x17000A7E RID: 2686
	// (get) Token: 0x060079D9 RID: 31193
	// (set) Token: 0x060079DA RID: 31194
	long PassDate { get; set; }

	// Token: 0x17000A7F RID: 2687
	// (get) Token: 0x060079DB RID: 31195
	// (set) Token: 0x060079DC RID: 31196
	[Nullable(1)]
	List<int> TeamRoleIdList { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17000A80 RID: 2688
	// (get) Token: 0x060079DD RID: 31197
	// (set) Token: 0x060079DE RID: 31198
	List<int> BuffIdList { get; set; }

	// Token: 0x17000A81 RID: 2689
	// (get) Token: 0x060079DF RID: 31199
	// (set) Token: 0x060079E0 RID: 31200
	List<int> DeTermIdList { get; set; }

	// Token: 0x17000A82 RID: 2690
	// (get) Token: 0x060079E1 RID: 31201
	// (set) Token: 0x060079E2 RID: 31202
	int OldLevelRank { get; set; }

	// Token: 0x17000A83 RID: 2691
	// (get) Token: 0x060079E3 RID: 31203
	// (set) Token: 0x060079E4 RID: 31204
	int NewLevelRank { get; set; }

	// Token: 0x17000A84 RID: 2692
	// (get) Token: 0x060079E5 RID: 31205
	// (set) Token: 0x060079E6 RID: 31206
	int OldTotalRank { get; set; }

	// Token: 0x17000A85 RID: 2693
	// (get) Token: 0x060079E7 RID: 31207
	// (set) Token: 0x060079E8 RID: 31208
	int NewTotalRank { get; set; }
}
