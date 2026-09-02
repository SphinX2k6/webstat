using System;
using System.Runtime.CompilerServices;

// Token: 0x02002BE3 RID: 11235
[NullableContext(2)]
[Nullable(0)]
public class TowerInformationData
{
	// Token: 0x0400AD87 RID: 44423
	public ETowerDetailInformationType Type;

	// Token: 0x0400AD88 RID: 44424
	[Nullable(1)]
	public string Title = string.Empty;

	// Token: 0x0400AD89 RID: 44425
	public int Priority;

	// Token: 0x0400AD8A RID: 44426
	public TowerDetailMonsterData MonsterData;

	// Token: 0x0400AD8B RID: 44427
	public TowerDetailBuffData TowerDetailBuffData;
}
