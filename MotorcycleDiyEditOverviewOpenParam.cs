using System;
using System.Runtime.CompilerServices;

// Token: 0x020022ED RID: 8941
[NullableContext(2)]
[Nullable(0)]
public class MotorcycleDiyEditOverviewOpenParam : IMotorcycleDiyEditOverviewOpenParam
{
	// Token: 0x170014F7 RID: 5367
	// (get) Token: 0x06010E66 RID: 69222 RVA: 0x004A0A64 File Offset: 0x0049EC64
	// (set) Token: 0x06010E67 RID: 69223 RVA: 0x004A0A6C File Offset: 0x0049EC6C
	public int PartId { get; set; }

	// Token: 0x170014F8 RID: 5368
	// (get) Token: 0x06010E68 RID: 69224 RVA: 0x004A0A75 File Offset: 0x0049EC75
	// (set) Token: 0x06010E69 RID: 69225 RVA: 0x004A0A7D File Offset: 0x0049EC7D
	public MotorcycleDiyPresetData LocalPresetData { get; set; }

	// Token: 0x170014F9 RID: 5369
	// (get) Token: 0x06010E6A RID: 69226 RVA: 0x004A0A86 File Offset: 0x0049EC86
	// (set) Token: 0x06010E6B RID: 69227 RVA: 0x004A0A8E File Offset: 0x0049EC8E
	public Action<EOutlookType, bool> OnEditPresetChanged { get; set; }
}
