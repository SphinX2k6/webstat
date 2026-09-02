using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;

// Token: 0x02001823 RID: 6179
[NullableContext(2)]
[Nullable(0)]
public class VisionRefineBatchResultViewData
{
	// Token: 0x0400536E RID: 21358
	public Func<UniTask> OnClickConfirm;

	// Token: 0x0400536F RID: 21359
	public Func<UniTask> OnClickCancel;

	// Token: 0x04005370 RID: 21360
	[Nullable(1)]
	public VisionRefineAttributeItemData[] LeftAttrList = new VisionRefineAttributeItemData[0];

	// Token: 0x04005371 RID: 21361
	[Nullable(1)]
	public VisionRefineAttributeItemData[] RightAttrList = new VisionRefineAttributeItemData[0];

	// Token: 0x04005372 RID: 21362
	public int? UniqueId;

	// Token: 0x04005373 RID: 21363
	public string ConfirmTipTextId;

	// Token: 0x04005374 RID: 21364
	public bool HasRecommendData;
}
