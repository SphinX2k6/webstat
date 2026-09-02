using System;
using System.Runtime.CompilerServices;

// Token: 0x02001065 RID: 4197
[NullableContext(1)]
public interface IFurnitureDesignReportContext
{
	// Token: 0x170008BC RID: 2236
	// (get) Token: 0x06006CFE RID: 27902
	int AreaId { get; }

	// Token: 0x170008BD RID: 2237
	// (get) Token: 0x06006CFF RID: 27903
	EFurnitureDesignReportOperationType OperationType { get; }

	// Token: 0x170008BE RID: 2238
	// (get) Token: 0x06006D00 RID: 27904
	IFurnitureSlotContext SlotContext { get; }

	// Token: 0x170008BF RID: 2239
	// (get) Token: 0x06006D01 RID: 27905
	int? OldFurnitureId { get; }

	// Token: 0x170008C0 RID: 2240
	// (get) Token: 0x06006D02 RID: 27906
	int? NewFurnitureId { get; }
}
