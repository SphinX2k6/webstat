using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002505 RID: 9477
[NullableContext(1)]
[Nullable(0)]
public class RecommendItemData
{
	// Token: 0x04008F8E RID: 36750
	public int AttrId;

	// Token: 0x04008F8F RID: 36751
	public int AddType;

	// Token: 0x04008F90 RID: 36752
	public List<VisionSelectRecommendData> CurrentSelectArray = new List<VisionSelectRecommendData>();

	// Token: 0x04008F91 RID: 36753
	public string UsageText = "";

	// Token: 0x04008F92 RID: 36754
	public int Type;

	// Token: 0x04008F93 RID: 36755
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<RecommendItemData> OnSelectCallBack;
}
