using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B6F RID: 7023
[NullableContext(2)]
public interface IPlayPointInfo
{
	// Token: 0x1700104D RID: 4173
	// (get) Token: 0x0600CBE2 RID: 52194
	// (set) Token: 0x0600CBE3 RID: 52195
	int PlayId { get; set; }

	// Token: 0x1700104E RID: 4174
	// (get) Token: 0x0600CBE4 RID: 52196
	// (set) Token: 0x0600CBE5 RID: 52197
	int EntityId { get; set; }

	// Token: 0x1700104F RID: 4175
	// (get) Token: 0x0600CBE6 RID: 52198
	// (set) Token: 0x0600CBE7 RID: 52199
	EPlayPointState PlayState { get; set; }

	// Token: 0x17001050 RID: 4176
	// (get) Token: 0x0600CBE8 RID: 52200
	// (set) Token: 0x0600CBE9 RID: 52201
	bool? IsClear { get; set; }

	// Token: 0x17001051 RID: 4177
	// (get) Token: 0x0600CBEA RID: 52202
	// (set) Token: 0x0600CBEB RID: 52203
	string ClearInfo { get; set; }

	// Token: 0x17001052 RID: 4178
	// (get) Token: 0x0600CBEC RID: 52204
	// (set) Token: 0x0600CBED RID: 52205
	bool? LevelPlayMarkUnlock { get; set; }

	// Token: 0x17001053 RID: 4179
	// (get) Token: 0x0600CBEE RID: 52206
	// (set) Token: 0x0600CBEF RID: 52207
	bool IsUnlock { get; set; }
}
