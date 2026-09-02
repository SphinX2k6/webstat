using System;
using System.Runtime.CompilerServices;

// Token: 0x02002543 RID: 9539
public class FetterGroupContentData
{
	// Token: 0x040090A6 RID: 37030
	public int Index;

	// Token: 0x040090A7 RID: 37031
	public int CurrentSelectIndex;

	// Token: 0x040090A8 RID: 37032
	[Nullable(2)]
	public VisionFetterRecommendInfo VisionFetterRecommendInfo;

	// Token: 0x040090A9 RID: 37033
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<FetterGroupContentData> ClickCallBack;
}
