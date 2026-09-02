using System;
using System.Runtime.CompilerServices;

// Token: 0x02001827 RID: 6183
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineTabCostItemData
{
	// Token: 0x0400537E RID: 21374
	public bool IsChosen;

	// Token: 0x0400537F RID: 21375
	public EVisionRefineCostType CostType;

	// Token: 0x04005380 RID: 21376
	public string TabTextId;

	// Token: 0x04005381 RID: 21377
	public Action OnClick;

	// Token: 0x04005382 RID: 21378
	public Func<EVisionRefineCostType, bool> CanChangeExecute;
}
