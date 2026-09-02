using System;
using System.Runtime.CompilerServices;

// Token: 0x02001061 RID: 4193
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneItemApplyPresetContext : IFurnitureSceneItemApplyPresetContext
{
	// Token: 0x170008B6 RID: 2230
	// (get) Token: 0x06006CF2 RID: 27890 RVA: 0x001C5EE5 File Offset: 0x001C40E5
	// (set) Token: 0x06006CF3 RID: 27891 RVA: 0x001C5EED File Offset: 0x001C40ED
	public int PresetId { get; set; }

	// Token: 0x170008B7 RID: 2231
	// (get) Token: 0x06006CF4 RID: 27892 RVA: 0x001C5EF6 File Offset: 0x001C40F6
	// (set) Token: 0x06006CF5 RID: 27893 RVA: 0x001C5EFE File Offset: 0x001C40FE
	public FurnitureAreaData AreaData { get; set; }
}
