using System;

// Token: 0x0200128A RID: 4746
public interface IChessItemParams
{
	// Token: 0x17000AC2 RID: 2754
	// (get) Token: 0x06007F19 RID: 32537
	// (set) Token: 0x06007F1A RID: 32538
	int Id { get; set; }

	// Token: 0x17000AC3 RID: 2755
	// (get) Token: 0x06007F1B RID: 32539
	// (set) Token: 0x06007F1C RID: 32540
	long CreatureDataId { get; set; }

	// Token: 0x17000AC4 RID: 2756
	// (get) Token: 0x06007F1D RID: 32541
	// (set) Token: 0x06007F1E RID: 32542
	bool RotationIsForward { get; set; }

	// Token: 0x17000AC5 RID: 2757
	// (get) Token: 0x06007F1F RID: 32543
	// (set) Token: 0x06007F20 RID: 32544
	int InitPointId { get; set; }
}
