using System;

// Token: 0x02002893 RID: 10387
public interface IStrengthUpgradeData
{
	// Token: 0x17001AF5 RID: 6901
	// (get) Token: 0x06014918 RID: 84248
	// (set) Token: 0x06014919 RID: 84249
	EFormationAttributeId AttributeId { get; set; }

	// Token: 0x17001AF6 RID: 6902
	// (get) Token: 0x0601491A RID: 84250
	// (set) Token: 0x0601491B RID: 84251
	int SingleStrengthValue { get; set; }

	// Token: 0x17001AF7 RID: 6903
	// (get) Token: 0x0601491C RID: 84252
	// (set) Token: 0x0601491D RID: 84253
	int MaxSingleStrengthItemCount { get; set; }

	// Token: 0x17001AF8 RID: 6904
	// (get) Token: 0x0601491E RID: 84254
	// (set) Token: 0x0601491F RID: 84255
	int MaxStrength { get; set; }
}
