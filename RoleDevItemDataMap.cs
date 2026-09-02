using System;
using System.Runtime.CompilerServices;

// Token: 0x020027F7 RID: 10231
[NullableContext(1)]
[Nullable(0)]
public class RoleDevItemDataMap : IRoleDevItemDataMap
{
	// Token: 0x170019E5 RID: 6629
	// (get) Token: 0x0601432D RID: 82733 RVA: 0x005A0C90 File Offset: 0x0059EE90
	// (set) Token: 0x0601432E RID: 82734 RVA: 0x005A0C98 File Offset: 0x0059EE98
	public IMaterialItemData Material { get; set; }

	// Token: 0x170019E6 RID: 6630
	// (get) Token: 0x0601432F RID: 82735 RVA: 0x005A0CA1 File Offset: 0x0059EEA1
	// (set) Token: 0x06014330 RID: 82736 RVA: 0x005A0CA9 File Offset: 0x0059EEA9
	public IDropRewardItemData Reward { get; set; }

	// Token: 0x170019E7 RID: 6631
	// (get) Token: 0x06014331 RID: 82737 RVA: 0x005A0CB2 File Offset: 0x0059EEB2
	// (set) Token: 0x06014332 RID: 82738 RVA: 0x005A0CBA File Offset: 0x0059EEBA
	public IPhantomMonsterItemData Monster { get; set; }
}
