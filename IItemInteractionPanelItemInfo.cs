using System;

// Token: 0x02001972 RID: 6514
public interface IItemInteractionPanelItemInfo
{
	// Token: 0x17000F2D RID: 3885
	// (get) Token: 0x0600BB44 RID: 47940
	// (set) Token: 0x0600BB45 RID: 47941
	int ItemConfigId { get; set; }

	// Token: 0x17000F2E RID: 3886
	// (get) Token: 0x0600BB46 RID: 47942
	// (set) Token: 0x0600BB47 RID: 47943
	int CurrentCount { get; set; }

	// Token: 0x17000F2F RID: 3887
	// (get) Token: 0x0600BB48 RID: 47944
	// (set) Token: 0x0600BB49 RID: 47945
	int? NeedCount { get; set; }
}
