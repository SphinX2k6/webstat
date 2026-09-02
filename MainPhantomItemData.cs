using System;
using System.Runtime.CompilerServices;

// Token: 0x02002507 RID: 9479
[NullableContext(1)]
[Nullable(0)]
public class MainPhantomItemData : IMainPhantomItemData
{
	// Token: 0x1700176B RID: 5995
	// (get) Token: 0x06012693 RID: 75411 RVA: 0x00510591 File Offset: 0x0050E791
	// (set) Token: 0x06012694 RID: 75412 RVA: 0x00510599 File Offset: 0x0050E799
	public MainPhantomRecommendInfo Info { get; set; }

	// Token: 0x1700176C RID: 5996
	// (get) Token: 0x06012695 RID: 75413 RVA: 0x005105A2 File Offset: 0x0050E7A2
	// (set) Token: 0x06012696 RID: 75414 RVA: 0x005105AA File Offset: 0x0050E7AA
	[Nullable(2)]
	public VisionMainSelectPhantomData CurrentSelectMainPhantom { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700176D RID: 5997
	// (get) Token: 0x06012697 RID: 75415 RVA: 0x005105B3 File Offset: 0x0050E7B3
	// (set) Token: 0x06012698 RID: 75416 RVA: 0x005105BB File Offset: 0x0050E7BB
	public Action<IMainPhantomItemData> OnMainPhantomCallBack { get; set; }
}
