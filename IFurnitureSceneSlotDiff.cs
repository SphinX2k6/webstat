using System;
using System.Runtime.CompilerServices;

// Token: 0x0200104F RID: 4175
[NullableContext(1)]
public interface IFurnitureSceneSlotDiff
{
	// Token: 0x1700088E RID: 2190
	// (get) Token: 0x06006CAF RID: 27823
	int RootFurnitureToPlace { get; }

	// Token: 0x1700088F RID: 2191
	// (get) Token: 0x06006CB0 RID: 27824
	int RootFurnitureToUnPlace { get; }

	// Token: 0x17000890 RID: 2192
	// (get) Token: 0x06006CB1 RID: 27825
	int[] SubFurnitureListToPlace { get; }

	// Token: 0x17000891 RID: 2193
	// (get) Token: 0x06006CB2 RID: 27826
	int[] SubFurnitureListToUnPlace { get; }
}
