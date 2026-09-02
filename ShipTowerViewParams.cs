using System;

// Token: 0x020029E7 RID: 10727
public class ShipTowerViewParams
{
	// Token: 0x17001BE0 RID: 7136
	// (get) Token: 0x0601561F RID: 87583 RVA: 0x005ECA3A File Offset: 0x005EAC3A
	// (set) Token: 0x06015620 RID: 87584 RVA: 0x005ECA42 File Offset: 0x005EAC42
	public int ApplyTeamEditStageId { get; set; }

	// Token: 0x17001BE1 RID: 7137
	// (get) Token: 0x06015621 RID: 87585 RVA: 0x005ECA4B File Offset: 0x005EAC4B
	// (set) Token: 0x06015622 RID: 87586 RVA: 0x005ECA53 File Offset: 0x005EAC53
	public int? StageId { get; set; }

	// Token: 0x17001BE2 RID: 7138
	// (get) Token: 0x06015623 RID: 87587 RVA: 0x005ECA5C File Offset: 0x005EAC5C
	// (set) Token: 0x06015624 RID: 87588 RVA: 0x005ECA64 File Offset: 0x005EAC64
	public bool? IsOpenStageDesc { get; set; }

	// Token: 0x17001BE3 RID: 7139
	// (get) Token: 0x06015625 RID: 87589 RVA: 0x005ECA6D File Offset: 0x005EAC6D
	// (set) Token: 0x06015626 RID: 87590 RVA: 0x005ECA75 File Offset: 0x005EAC75
	public bool? IsFromInstanceDungeon { get; set; }

	// Token: 0x0400A49B RID: 42139
	public bool? IsOpenCover;
}
