using System;

// Token: 0x020027F9 RID: 10233
public class SkillSlotExtendData : ISkillSlotExtendData
{
	// Token: 0x170019F0 RID: 6640
	// (get) Token: 0x06014344 RID: 82756 RVA: 0x005A0CCB File Offset: 0x0059EECB
	// (set) Token: 0x06014345 RID: 82757 RVA: 0x005A0CD3 File Offset: 0x0059EED3
	public int RoleId { get; set; }

	// Token: 0x170019F1 RID: 6641
	// (get) Token: 0x06014346 RID: 82758 RVA: 0x005A0CDC File Offset: 0x0059EEDC
	// (set) Token: 0x06014347 RID: 82759 RVA: 0x005A0CE4 File Offset: 0x0059EEE4
	public int SkillNodeId { get; set; }

	// Token: 0x170019F2 RID: 6642
	// (get) Token: 0x06014348 RID: 82760 RVA: 0x005A0CED File Offset: 0x0059EEED
	// (set) Token: 0x06014349 RID: 82761 RVA: 0x005A0CF5 File Offset: 0x0059EEF5
	public int IconId { get; set; }

	// Token: 0x170019F3 RID: 6643
	// (get) Token: 0x0601434A RID: 82762 RVA: 0x005A0CFE File Offset: 0x0059EEFE
	// (set) Token: 0x0601434B RID: 82763 RVA: 0x005A0D06 File Offset: 0x0059EF06
	public int CurrentLevel { get; set; }

	// Token: 0x170019F4 RID: 6644
	// (get) Token: 0x0601434C RID: 82764 RVA: 0x005A0D0F File Offset: 0x0059EF0F
	// (set) Token: 0x0601434D RID: 82765 RVA: 0x005A0D17 File Offset: 0x0059EF17
	public int NormalTargetLevel { get; set; }

	// Token: 0x170019F5 RID: 6645
	// (get) Token: 0x0601434E RID: 82766 RVA: 0x005A0D20 File Offset: 0x0059EF20
	// (set) Token: 0x0601434F RID: 82767 RVA: 0x005A0D28 File Offset: 0x0059EF28
	public int PerfectTargetLevel { get; set; }

	// Token: 0x170019F6 RID: 6646
	// (get) Token: 0x06014350 RID: 82768 RVA: 0x005A0D31 File Offset: 0x0059EF31
	// (set) Token: 0x06014351 RID: 82769 RVA: 0x005A0D39 File Offset: 0x0059EF39
	public ESkillType SkillType { get; set; }

	// Token: 0x170019F7 RID: 6647
	// (get) Token: 0x06014352 RID: 82770 RVA: 0x005A0D42 File Offset: 0x0059EF42
	// (set) Token: 0x06014353 RID: 82771 RVA: 0x005A0D4A File Offset: 0x0059EF4A
	public int NodeIndex { get; set; }
}
