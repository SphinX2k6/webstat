using System;
using System.Runtime.CompilerServices;

// Token: 0x0200105C RID: 4188
[NullableContext(1)]
public interface IFurniturePlaceToNewSlotContext
{
	// Token: 0x170008AA RID: 2218
	// (get) Token: 0x06006CDF RID: 27871
	IFurnitureAreaSlotContext SourceContext { get; }

	// Token: 0x170008AB RID: 2219
	// (get) Token: 0x06006CE0 RID: 27872
	IFurnitureAreaSlotContext TargetContext { get; }
}
