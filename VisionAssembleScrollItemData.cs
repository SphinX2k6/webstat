using System;
using System.Runtime.CompilerServices;

// Token: 0x020024E4 RID: 9444
[NullableContext(1)]
[Nullable(0)]
public class VisionAssembleScrollItemData
{
	// Token: 0x04008EFC RID: 36604
	public int GroupIndex;

	// Token: 0x04008EFD RID: 36605
	public Action<VisionEquipGroupData> ClickCallback = delegate(VisionEquipGroupData _)
	{
	};

	// Token: 0x04008EFE RID: 36606
	public bool CurrentSelectState;

	// Token: 0x04008EFF RID: 36607
	[Nullable(2)]
	public VisionEquipGroupData VisionEquipGroupData;

	// Token: 0x04008F00 RID: 36608
	public Func<bool> CheckIfCanSelect = () => true;
}
