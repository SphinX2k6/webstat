using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002BE0 RID: 11232
public class TowerDetailMonsterData
{
	// Token: 0x0400AD80 RID: 44416
	[Nullable(1)]
	public string Title = string.Empty;

	// Token: 0x0400AD81 RID: 44417
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<TowerDetailMonster> MonsterInfos;

	// Token: 0x0400AD82 RID: 44418
	public int Priority;
}
