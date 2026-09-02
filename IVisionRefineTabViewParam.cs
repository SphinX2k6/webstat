using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020017DD RID: 6109
public interface IVisionRefineTabViewParam
{
	// Token: 0x17000E16 RID: 3606
	// (get) Token: 0x0600AD60 RID: 44384
	// (set) Token: 0x0600AD61 RID: 44385
	ERefineViewState ViewState { get; set; }

	// Token: 0x17000E17 RID: 3607
	// (get) Token: 0x0600AD62 RID: 44386
	// (set) Token: 0x0600AD63 RID: 44387
	EVisionRefineRefineType? RefineType { get; set; }

	// Token: 0x17000E18 RID: 3608
	// (get) Token: 0x0600AD64 RID: 44388
	// (set) Token: 0x0600AD65 RID: 44389
	int? UniqueId { get; set; }

	// Token: 0x17000E19 RID: 3609
	// (get) Token: 0x0600AD66 RID: 44390
	// (set) Token: 0x0600AD67 RID: 44391
	bool? ActiveCaptionItem { get; set; }

	// Token: 0x17000E1A RID: 3610
	// (get) Token: 0x0600AD68 RID: 44392
	// (set) Token: 0x0600AD69 RID: 44393
	bool? SlotInteractive { get; set; }

	// Token: 0x17000E1B RID: 3611
	// (get) Token: 0x0600AD6A RID: 44394
	// (set) Token: 0x0600AD6B RID: 44395
	bool? ResultShowTips { get; set; }

	// Token: 0x17000E1C RID: 3612
	// (get) Token: 0x0600AD6C RID: 44396
	// (set) Token: 0x0600AD6D RID: 44397
	bool? IsSingleMode { get; set; }

	// Token: 0x17000E1D RID: 3613
	// (get) Token: 0x0600AD6E RID: 44398
	// (set) Token: 0x0600AD6F RID: 44399
	[Nullable(new byte[]
	{
		2,
		1
	})]
	Action<int[]> CurrencyChangeCallback { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }

	// Token: 0x17000E1E RID: 3614
	// (get) Token: 0x0600AD70 RID: 44400
	// (set) Token: 0x0600AD71 RID: 44401
	[Nullable(new byte[]
	{
		2,
		1
	})]
	List<AttrRecommendInfo> RecommendRefineSubList { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
