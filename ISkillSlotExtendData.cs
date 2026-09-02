using System;

// Token: 0x020027F8 RID: 10232
public interface ISkillSlotExtendData
{
	// Token: 0x170019E8 RID: 6632
	// (get) Token: 0x06014334 RID: 82740
	// (set) Token: 0x06014335 RID: 82741
	int RoleId { get; set; }

	// Token: 0x170019E9 RID: 6633
	// (get) Token: 0x06014336 RID: 82742
	// (set) Token: 0x06014337 RID: 82743
	int SkillNodeId { get; set; }

	// Token: 0x170019EA RID: 6634
	// (get) Token: 0x06014338 RID: 82744
	// (set) Token: 0x06014339 RID: 82745
	int IconId { get; set; }

	// Token: 0x170019EB RID: 6635
	// (get) Token: 0x0601433A RID: 82746
	// (set) Token: 0x0601433B RID: 82747
	int CurrentLevel { get; set; }

	// Token: 0x170019EC RID: 6636
	// (get) Token: 0x0601433C RID: 82748
	// (set) Token: 0x0601433D RID: 82749
	int NormalTargetLevel { get; set; }

	// Token: 0x170019ED RID: 6637
	// (get) Token: 0x0601433E RID: 82750
	// (set) Token: 0x0601433F RID: 82751
	int PerfectTargetLevel { get; set; }

	// Token: 0x170019EE RID: 6638
	// (get) Token: 0x06014340 RID: 82752
	// (set) Token: 0x06014341 RID: 82753
	ESkillType SkillType { get; set; }

	// Token: 0x170019EF RID: 6639
	// (get) Token: 0x06014342 RID: 82754
	// (set) Token: 0x06014343 RID: 82755
	int NodeIndex { get; set; }
}
