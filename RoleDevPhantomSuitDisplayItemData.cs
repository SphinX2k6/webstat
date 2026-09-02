using System;
using System.Runtime.CompilerServices;

// Token: 0x0200280C RID: 10252
[NullableContext(2)]
[Nullable(0)]
public class RoleDevPhantomSuitDisplayItemData : IRoleDevPhantomSuitDisplayItemData
{
	// Token: 0x17001A05 RID: 6661
	// (get) Token: 0x060143B1 RID: 82865 RVA: 0x005A242C File Offset: 0x005A062C
	// (set) Token: 0x060143B2 RID: 82866 RVA: 0x005A2434 File Offset: 0x005A0634
	public IPhantomMonsterItemData MonsterData { get; set; }

	// Token: 0x17001A06 RID: 6662
	// (get) Token: 0x060143B3 RID: 82867 RVA: 0x005A243D File Offset: 0x005A063D
	// (set) Token: 0x060143B4 RID: 82868 RVA: 0x005A2445 File Offset: 0x005A0645
	public IDropRewardItemData RewardData { get; set; }
}
