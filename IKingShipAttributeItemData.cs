using System;

// Token: 0x02002092 RID: 8338
public interface IKingShipAttributeItemData
{
	// Token: 0x170012E7 RID: 4839
	// (get) Token: 0x0600FE5E RID: 65118
	// (set) Token: 0x0600FE5F RID: 65119
	int AttributeId { get; set; }

	// Token: 0x170012E8 RID: 4840
	// (get) Token: 0x0600FE60 RID: 65120
	// (set) Token: 0x0600FE61 RID: 65121
	int MaxCount { get; set; }

	// Token: 0x170012E9 RID: 4841
	// (get) Token: 0x0600FE62 RID: 65122
	// (set) Token: 0x0600FE63 RID: 65123
	int MinCount { get; set; }

	// Token: 0x170012EA RID: 4842
	// (get) Token: 0x0600FE64 RID: 65124
	// (set) Token: 0x0600FE65 RID: 65125
	int Current { get; set; }

	// Token: 0x170012EB RID: 4843
	// (get) Token: 0x0600FE66 RID: 65126
	// (set) Token: 0x0600FE67 RID: 65127
	bool IsDefaultEnable { get; set; }
}
