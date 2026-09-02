using System;
using System.Runtime.CompilerServices;

// Token: 0x02001063 RID: 4195
[NullableContext(1)]
[Nullable(0)]
public class FurnitureSceneItemChangeAreaFurnitureContext : IFurnitureSceneItemChangeAreaFurnitureContext
{
	// Token: 0x170008BA RID: 2234
	// (get) Token: 0x06006CF9 RID: 27897 RVA: 0x001C5F0F File Offset: 0x001C410F
	// (set) Token: 0x06006CFA RID: 27898 RVA: 0x001C5F17 File Offset: 0x001C4117
	public FurnitureAreaData SourceAreaData { get; set; }

	// Token: 0x170008BB RID: 2235
	// (get) Token: 0x06006CFB RID: 27899 RVA: 0x001C5F20 File Offset: 0x001C4120
	// (set) Token: 0x06006CFC RID: 27900 RVA: 0x001C5F28 File Offset: 0x001C4128
	public FurnitureAreaData TargetAreaData { get; set; }
}
