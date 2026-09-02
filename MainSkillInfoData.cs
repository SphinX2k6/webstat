using System;
using System.Runtime.CompilerServices;

// Token: 0x02002456 RID: 9302
[NullableContext(1)]
[Nullable(0)]
public class MainSkillInfoData : IMainSkillInfoData
{
	// Token: 0x170016A0 RID: 5792
	// (get) Token: 0x06012020 RID: 73760 RVA: 0x004F5449 File Offset: 0x004F3649
	// (set) Token: 0x06012021 RID: 73761 RVA: 0x004F5451 File Offset: 0x004F3651
	public string MainSkillText { get; set; }

	// Token: 0x170016A1 RID: 5793
	// (get) Token: 0x06012022 RID: 73762 RVA: 0x004F545A File Offset: 0x004F365A
	// (set) Token: 0x06012023 RID: 73763 RVA: 0x004F5462 File Offset: 0x004F3662
	public string[] MainSkillParameter { get; set; }

	// Token: 0x170016A2 RID: 5794
	// (get) Token: 0x06012024 RID: 73764 RVA: 0x004F546B File Offset: 0x004F366B
	// (set) Token: 0x06012025 RID: 73765 RVA: 0x004F5473 File Offset: 0x004F3673
	public string MainSkillIcon { get; set; }
}
