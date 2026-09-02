using System;

// Token: 0x0200122C RID: 4652
public class JumpToItemData : IJumpToItemData
{
	// Token: 0x17000AA7 RID: 2727
	// (get) Token: 0x06007BC2 RID: 31682 RVA: 0x0020709E File Offset: 0x0020529E
	// (set) Token: 0x06007BC3 RID: 31683 RVA: 0x002070A6 File Offset: 0x002052A6
	public int LevelId { get; set; }

	// Token: 0x17000AA8 RID: 2728
	// (get) Token: 0x06007BC4 RID: 31684 RVA: 0x002070AF File Offset: 0x002052AF
	// (set) Token: 0x06007BC5 RID: 31685 RVA: 0x002070B7 File Offset: 0x002052B7
	public bool Done { get; set; }

	// Token: 0x17000AA9 RID: 2729
	// (get) Token: 0x06007BC6 RID: 31686 RVA: 0x002070C0 File Offset: 0x002052C0
	// (set) Token: 0x06007BC7 RID: 31687 RVA: 0x002070C8 File Offset: 0x002052C8
	public bool IsUnlock { get; set; }

	// Token: 0x17000AAA RID: 2730
	// (get) Token: 0x06007BC8 RID: 31688 RVA: 0x002070D1 File Offset: 0x002052D1
	// (set) Token: 0x06007BC9 RID: 31689 RVA: 0x002070D9 File Offset: 0x002052D9
	public int StarNumber { get; set; }
}
