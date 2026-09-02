using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105A RID: 4186
[NullableContext(1)]
public interface IFurnitureAreaSlotContext
{
	// Token: 0x170008A6 RID: 2214
	// (get) Token: 0x06006CD8 RID: 27864
	FurnitureAreaData AreaData { get; }

	// Token: 0x170008A7 RID: 2215
	// (get) Token: 0x06006CD9 RID: 27865
	IFurnitureSlotContext SlotContext { get; }
}
