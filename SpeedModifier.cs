using System;

// Token: 0x02000FB9 RID: 4025
public class SpeedModifier : ISpeedModifier
{
	// Token: 0x17000807 RID: 2055
	// (get) Token: 0x0600670B RID: 26379 RVA: 0x001AEBD4 File Offset: 0x001ACDD4
	// (set) Token: 0x0600670C RID: 26380 RVA: 0x001AEBDC File Offset: 0x001ACDDC
	public EModifierType Type { get; set; }

	// Token: 0x17000808 RID: 2056
	// (get) Token: 0x0600670D RID: 26381 RVA: 0x001AEBE5 File Offset: 0x001ACDE5
	// (set) Token: 0x0600670E RID: 26382 RVA: 0x001AEBED File Offset: 0x001ACDED
	public float Value { get; set; }

	// Token: 0x17000809 RID: 2057
	// (get) Token: 0x0600670F RID: 26383 RVA: 0x001AEBF6 File Offset: 0x001ACDF6
	// (set) Token: 0x06006710 RID: 26384 RVA: 0x001AEBFE File Offset: 0x001ACDFE
	public int Priority { get; set; }
}
