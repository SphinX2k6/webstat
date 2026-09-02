using System;
using System.Runtime.CompilerServices;

// Token: 0x0200280B RID: 10251
[NullableContext(2)]
public interface IRoleDevPhantomSuitDisplayItemData
{
	// Token: 0x17001A03 RID: 6659
	// (get) Token: 0x060143AD RID: 82861
	// (set) Token: 0x060143AE RID: 82862
	IPhantomMonsterItemData MonsterData { get; set; }

	// Token: 0x17001A04 RID: 6660
	// (get) Token: 0x060143AF RID: 82863
	// (set) Token: 0x060143B0 RID: 82864
	IDropRewardItemData RewardData { get; set; }
}
