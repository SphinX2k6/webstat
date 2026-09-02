using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E55 RID: 11861
[NullableContext(1)]
public interface IBuffDamageParam
{
	// Token: 0x1700207B RID: 8315
	// (get) Token: 0x06018590 RID: 99728
	// (set) Token: 0x06018591 RID: 99729
	long? BuffId { get; set; }

	// Token: 0x1700207C RID: 8316
	// (get) Token: 0x06018592 RID: 99730
	// (set) Token: 0x06018593 RID: 99731
	long? BulletId { get; set; }

	// Token: 0x1700207D RID: 8317
	// (get) Token: 0x06018594 RID: 99732
	// (set) Token: 0x06018595 RID: 99733
	long DamageDataId { get; set; }

	// Token: 0x1700207E RID: 8318
	// (get) Token: 0x06018596 RID: 99734
	// (set) Token: 0x06018597 RID: 99735
	Entity Attacker { get; set; }

	// Token: 0x1700207F RID: 8319
	// (get) Token: 0x06018598 RID: 99736
	// (set) Token: 0x06018599 RID: 99737
	int SkillLevel { get; set; }

	// Token: 0x17002080 RID: 8320
	// (get) Token: 0x0601859A RID: 99738
	// (set) Token: 0x0601859B RID: 99739
	FVectorDouble HitPosition { get; set; }
}
