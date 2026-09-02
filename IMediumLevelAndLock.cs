using System;

// Token: 0x020019C8 RID: 6600
public interface IMediumLevelAndLock
{
	// Token: 0x17000F79 RID: 3961
	// (get) Token: 0x0600BD74 RID: 48500
	// (set) Token: 0x0600BD75 RID: 48501
	int? Level { get; set; }

	// Token: 0x17000F7A RID: 3962
	// (get) Token: 0x0600BD76 RID: 48502
	// (set) Token: 0x0600BD77 RID: 48503
	bool? IsLevelInfinite { get; set; }

	// Token: 0x17000F7B RID: 3963
	// (get) Token: 0x0600BD78 RID: 48504
	// (set) Token: 0x0600BD79 RID: 48505
	bool? IsLockVisible { get; set; }

	// Token: 0x17000F7C RID: 3964
	// (get) Token: 0x0600BD7A RID: 48506
	// (set) Token: 0x0600BD7B RID: 48507
	bool? IsLevelUseChangeColor { get; set; }

	// Token: 0x17000F7D RID: 3965
	// (get) Token: 0x0600BD7C RID: 48508
	// (set) Token: 0x0600BD7D RID: 48509
	bool? IsUseVision { get; set; }

	// Token: 0x17000F7E RID: 3966
	// (get) Token: 0x0600BD7E RID: 48510
	// (set) Token: 0x0600BD7F RID: 48511
	bool? IsDeprecate { get; set; }
}
