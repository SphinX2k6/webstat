using System;

// Token: 0x02002553 RID: 9555
public class VisionEquipmentViewOpenParam : IVisionEquipmentViewOpenParam
{
	// Token: 0x17001789 RID: 6025
	// (get) Token: 0x0601295C RID: 76124 RVA: 0x0051E58E File Offset: 0x0051C78E
	// (set) Token: 0x0601295D RID: 76125 RVA: 0x0051E596 File Offset: 0x0051C796
	public int RoleId { get; set; }

	// Token: 0x1700178A RID: 6026
	// (get) Token: 0x0601295E RID: 76126 RVA: 0x0051E59F File Offset: 0x0051C79F
	// (set) Token: 0x0601295F RID: 76127 RVA: 0x0051E5A7 File Offset: 0x0051C7A7
	public int SelectIndex { get; set; }

	// Token: 0x1700178B RID: 6027
	// (get) Token: 0x06012960 RID: 76128 RVA: 0x0051E5B0 File Offset: 0x0051C7B0
	// (set) Token: 0x06012961 RID: 76129 RVA: 0x0051E5B8 File Offset: 0x0051C7B8
	public ERoleViewSource? Source { get; set; }
}
