using System;

// Token: 0x02002894 RID: 10388
public class StrengthUpgradeData : IStrengthUpgradeData
{
	// Token: 0x17001AF9 RID: 6905
	// (get) Token: 0x06014920 RID: 84256 RVA: 0x005B2CE4 File Offset: 0x005B0EE4
	// (set) Token: 0x06014921 RID: 84257 RVA: 0x005B2CEC File Offset: 0x005B0EEC
	public EFormationAttributeId AttributeId { get; set; }

	// Token: 0x17001AFA RID: 6906
	// (get) Token: 0x06014922 RID: 84258 RVA: 0x005B2CF5 File Offset: 0x005B0EF5
	// (set) Token: 0x06014923 RID: 84259 RVA: 0x005B2CFD File Offset: 0x005B0EFD
	public int SingleStrengthValue { get; set; }

	// Token: 0x17001AFB RID: 6907
	// (get) Token: 0x06014924 RID: 84260 RVA: 0x005B2D06 File Offset: 0x005B0F06
	// (set) Token: 0x06014925 RID: 84261 RVA: 0x005B2D0E File Offset: 0x005B0F0E
	public int MaxSingleStrengthItemCount { get; set; }

	// Token: 0x17001AFC RID: 6908
	// (get) Token: 0x06014926 RID: 84262 RVA: 0x005B2D17 File Offset: 0x005B0F17
	// (set) Token: 0x06014927 RID: 84263 RVA: 0x005B2D1F File Offset: 0x005B0F1F
	public int MaxStrength { get; set; }
}
