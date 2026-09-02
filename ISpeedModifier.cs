using System;

// Token: 0x02000FB7 RID: 4023
public interface ISpeedModifier
{
	// Token: 0x17000802 RID: 2050
	// (get) Token: 0x06006701 RID: 26369
	// (set) Token: 0x06006702 RID: 26370
	EModifierType Type { get; set; }

	// Token: 0x17000803 RID: 2051
	// (get) Token: 0x06006703 RID: 26371
	// (set) Token: 0x06006704 RID: 26372
	float Value { get; set; }

	// Token: 0x17000804 RID: 2052
	// (get) Token: 0x06006705 RID: 26373
	// (set) Token: 0x06006706 RID: 26374
	int Priority { get; set; }
}
