using System;

// Token: 0x020022E2 RID: 8930
public class MotorcycleDiyOutlookBoxItemData
{
	// Token: 0x06010E3F RID: 69183 RVA: 0x004A0955 File Offset: 0x0049EB55
	public MotorcycleDiyOutlookBoxItemData(EOutlookType outlookType, int itemId, int index)
	{
		this.OutlookType = outlookType;
		this.ItemId = itemId;
		this.JumpIndex = index;
	}

	// Token: 0x04008515 RID: 34069
	public EOutlookType OutlookType;

	// Token: 0x04008516 RID: 34070
	public int ItemId;

	// Token: 0x04008517 RID: 34071
	public int JumpIndex = -1;
}
