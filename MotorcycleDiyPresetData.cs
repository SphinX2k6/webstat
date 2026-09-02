using System;
using System.Runtime.CompilerServices;

// Token: 0x020022E7 RID: 8935
[NullableContext(1)]
[Nullable(0)]
public class MotorcycleDiyPresetData
{
	// Token: 0x04008523 RID: 34083
	public int OfficialId;

	// Token: 0x04008524 RID: 34084
	public int CustomId;

	// Token: 0x04008525 RID: 34085
	public string Name = "";

	// Token: 0x04008526 RID: 34086
	public int SkinId;

	// Token: 0x04008527 RID: 34087
	public int FrameId;

	// Token: 0x04008528 RID: 34088
	public int[] StickerIds = Array.Empty<int>();

	// Token: 0x04008529 RID: 34089
	public int[] DecorateIds = Array.Empty<int>();

	// Token: 0x0400852A RID: 34090
	public bool IsCurEquipped;
}
