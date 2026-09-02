using System;
using System.Runtime.CompilerServices;

// Token: 0x020022EC RID: 8940
[NullableContext(2)]
public interface IMotorcycleDiyEditOverviewOpenParam
{
	// Token: 0x170014F4 RID: 5364
	// (get) Token: 0x06010E60 RID: 69216
	// (set) Token: 0x06010E61 RID: 69217
	int PartId { get; set; }

	// Token: 0x170014F5 RID: 5365
	// (get) Token: 0x06010E62 RID: 69218
	// (set) Token: 0x06010E63 RID: 69219
	MotorcycleDiyPresetData LocalPresetData { get; set; }

	// Token: 0x170014F6 RID: 5366
	// (get) Token: 0x06010E64 RID: 69220
	// (set) Token: 0x06010E65 RID: 69221
	Action<EOutlookType, bool> OnEditPresetChanged { get; set; }
}
