using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105E RID: 4190
[NullableContext(1)]
public interface IFurnitureSceneItemPlaceContext
{
	// Token: 0x170008AE RID: 2222
	// (get) Token: 0x06006CE6 RID: 27878
	IFurnitureAreaSlotContext AreaSlotContext { get; }

	// Token: 0x170008AF RID: 2223
	// (get) Token: 0x06006CE7 RID: 27879
	int FurnitureId { get; }

	// Token: 0x170008B0 RID: 2224
	// (get) Token: 0x06006CE8 RID: 27880
	bool KeepSubFurniture { get; }
}
