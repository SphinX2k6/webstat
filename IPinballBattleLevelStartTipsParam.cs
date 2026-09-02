using System;

// Token: 0x02001D63 RID: 7523
public interface IPinballBattleLevelStartTipsParam : IPinballBattleTipsBaseParam
{
	// Token: 0x1700116C RID: 4460
	// (get) Token: 0x0600DD8F RID: 56719
	int CurWave { get; }

	// Token: 0x1700116D RID: 4461
	// (get) Token: 0x0600DD90 RID: 56720
	int MaxWave { get; }
}
