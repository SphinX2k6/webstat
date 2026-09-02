using System;
using System.Runtime.CompilerServices;

// Token: 0x02001067 RID: 4199
[NullableContext(1)]
public interface IFurnitureSaveReportContext
{
	// Token: 0x170008C6 RID: 2246
	// (get) Token: 0x06006D0E RID: 27918
	int AreaId { get; }

	// Token: 0x170008C7 RID: 2247
	// (get) Token: 0x06006D0F RID: 27919
	FurnitureAreaData OldAreaData { get; }

	// Token: 0x170008C8 RID: 2248
	// (get) Token: 0x06006D10 RID: 27920
	FurnitureAreaData NewAreaData { get; }

	// Token: 0x170008C9 RID: 2249
	// (get) Token: 0x06006D11 RID: 27921
	bool IsSave { get; }
}
