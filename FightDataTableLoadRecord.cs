using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003109 RID: 12553
[NullableContext(2)]
[Nullable(0)]
public class FightDataTableLoadRecord
{
	// Token: 0x0400D009 RID: 53257
	public UDataTable SkillDataTable;

	// Token: 0x0400D00A RID: 53258
	public UDataTable BulletDataTable;

	// Token: 0x0400D00B RID: 53259
	public UDataTable HitEffectDataTable;

	// Token: 0x0400D00C RID: 53260
	public UDataTable CameraDataTable;

	// Token: 0x0400D00D RID: 53261
	[Nullable(1)]
	public List<int> SkillIds = new List<int>();

	// Token: 0x0400D00E RID: 53262
	[Nullable(1)]
	public List<long> BulletIds = new List<long>();
}
