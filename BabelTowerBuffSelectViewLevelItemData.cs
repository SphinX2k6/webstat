using System;

// Token: 0x020011D5 RID: 4565
public class BabelTowerBuffSelectViewLevelItemData : IBabelTowerBuffSelectViewLevelItemData
{
	// Token: 0x17000A24 RID: 2596
	// (get) Token: 0x06007882 RID: 30850 RVA: 0x001F8F48 File Offset: 0x001F7148
	// (set) Token: 0x06007883 RID: 30851 RVA: 0x001F8F50 File Offset: 0x001F7150
	public int LevelId { get; set; }

	// Token: 0x17000A25 RID: 2597
	// (get) Token: 0x06007884 RID: 30852 RVA: 0x001F8F59 File Offset: 0x001F7159
	// (set) Token: 0x06007885 RID: 30853 RVA: 0x001F8F61 File Offset: 0x001F7161
	public int BuffId { get; set; }

	// Token: 0x17000A26 RID: 2598
	// (get) Token: 0x06007886 RID: 30854 RVA: 0x001F8F6A File Offset: 0x001F716A
	// (set) Token: 0x06007887 RID: 30855 RVA: 0x001F8F72 File Offset: 0x001F7172
	public EBabelTowerBuffState State { get; set; }
}
