using System;

// Token: 0x02002552 RID: 9554
public interface IVisionEquipmentViewOpenParam
{
	// Token: 0x17001786 RID: 6022
	// (get) Token: 0x06012956 RID: 76118
	// (set) Token: 0x06012957 RID: 76119
	int RoleId { get; set; }

	// Token: 0x17001787 RID: 6023
	// (get) Token: 0x06012958 RID: 76120
	// (set) Token: 0x06012959 RID: 76121
	int SelectIndex { get; set; }

	// Token: 0x17001788 RID: 6024
	// (get) Token: 0x0601295A RID: 76122
	// (set) Token: 0x0601295B RID: 76123
	ERoleViewSource? Source { get; set; }
}
