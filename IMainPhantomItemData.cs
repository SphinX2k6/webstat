using System;
using System.Runtime.CompilerServices;

// Token: 0x02002506 RID: 9478
[NullableContext(1)]
public interface IMainPhantomItemData
{
	// Token: 0x17001768 RID: 5992
	// (get) Token: 0x0601268D RID: 75405
	// (set) Token: 0x0601268E RID: 75406
	MainPhantomRecommendInfo Info { get; set; }

	// Token: 0x17001769 RID: 5993
	// (get) Token: 0x0601268F RID: 75407
	// (set) Token: 0x06012690 RID: 75408
	[Nullable(2)]
	VisionMainSelectPhantomData CurrentSelectMainPhantom { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x1700176A RID: 5994
	// (get) Token: 0x06012691 RID: 75409
	// (set) Token: 0x06012692 RID: 75410
	Action<IMainPhantomItemData> OnMainPhantomCallBack { get; set; }
}
