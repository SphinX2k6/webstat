using System;

// Token: 0x020011D4 RID: 4564
public interface IBabelTowerBuffSelectViewLevelItemData
{
	// Token: 0x17000A21 RID: 2593
	// (get) Token: 0x0600787C RID: 30844
	// (set) Token: 0x0600787D RID: 30845
	int LevelId { get; set; }

	// Token: 0x17000A22 RID: 2594
	// (get) Token: 0x0600787E RID: 30846
	// (set) Token: 0x0600787F RID: 30847
	int BuffId { get; set; }

	// Token: 0x17000A23 RID: 2595
	// (get) Token: 0x06007880 RID: 30848
	// (set) Token: 0x06007881 RID: 30849
	EBabelTowerBuffState State { get; set; }
}
