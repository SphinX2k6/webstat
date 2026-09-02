using System;

// Token: 0x020027F5 RID: 10229
public class PhantomMonsterItemData : IPhantomMonsterItemData, IUniversalSmallItemData<ERoleDevItemType>
{
	// Token: 0x170019DE RID: 6622
	// (get) Token: 0x0601431E RID: 82718 RVA: 0x005A0C44 File Offset: 0x0059EE44
	// (set) Token: 0x0601431F RID: 82719 RVA: 0x005A0C4C File Offset: 0x0059EE4C
	public ERoleDevItemType Type { get; set; }

	// Token: 0x170019DF RID: 6623
	// (get) Token: 0x06014320 RID: 82720 RVA: 0x005A0C55 File Offset: 0x0059EE55
	// (set) Token: 0x06014321 RID: 82721 RVA: 0x005A0C5D File Offset: 0x0059EE5D
	public int MonsterId { get; set; }

	// Token: 0x170019E0 RID: 6624
	// (get) Token: 0x06014322 RID: 82722 RVA: 0x005A0C66 File Offset: 0x0059EE66
	// (set) Token: 0x06014323 RID: 82723 RVA: 0x005A0C6E File Offset: 0x0059EE6E
	public int QualityId { get; set; }

	// Token: 0x170019E1 RID: 6625
	// (get) Token: 0x06014324 RID: 82724 RVA: 0x005A0C77 File Offset: 0x0059EE77
	// (set) Token: 0x06014325 RID: 82725 RVA: 0x005A0C7F File Offset: 0x0059EE7F
	public int RoleId { get; set; }
}
