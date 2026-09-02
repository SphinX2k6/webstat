using System;

// Token: 0x02002916 RID: 10518
public class RouletteAssemblyOpenParam : IRouletteAssemblyOpenParam
{
	// Token: 0x17001B5F RID: 7007
	// (get) Token: 0x06014DE4 RID: 85476 RVA: 0x005C788F File Offset: 0x005C5A8F
	// (set) Token: 0x06014DE5 RID: 85477 RVA: 0x005C7897 File Offset: 0x005C5A97
	public ERouletteType? RouletteType { get; set; }

	// Token: 0x17001B60 RID: 7008
	// (get) Token: 0x06014DE6 RID: 85478 RVA: 0x005C78A0 File Offset: 0x005C5AA0
	// (set) Token: 0x06014DE7 RID: 85479 RVA: 0x005C78A8 File Offset: 0x005C5AA8
	public int? SelectGridId { get; set; }

	// Token: 0x17001B61 RID: 7009
	// (get) Token: 0x06014DE8 RID: 85480 RVA: 0x005C78B1 File Offset: 0x005C5AB1
	// (set) Token: 0x06014DE9 RID: 85481 RVA: 0x005C78B9 File Offset: 0x005C5AB9
	public int? SelectGridIndex { get; set; }

	// Token: 0x17001B62 RID: 7010
	// (get) Token: 0x06014DEA RID: 85482 RVA: 0x005C78C2 File Offset: 0x005C5AC2
	// (set) Token: 0x06014DEB RID: 85483 RVA: 0x005C78CA File Offset: 0x005C5ACA
	public ERouletteExploreId? EndSwitchSkillId { get; set; }
}
