using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E57 RID: 11863
[NullableContext(1)]
public interface IBulletDamageParam
{
	// Token: 0x17002087 RID: 8327
	// (get) Token: 0x060185AB RID: 99755
	// (set) Token: 0x060185AC RID: 99756
	long DamageDataId { get; set; }

	// Token: 0x17002088 RID: 8328
	// (get) Token: 0x060185AD RID: 99757
	// (set) Token: 0x060185AE RID: 99758
	long? BulletId { get; set; }

	// Token: 0x17002089 RID: 8329
	// (get) Token: 0x060185AF RID: 99759
	// (set) Token: 0x060185B0 RID: 99760
	Entity Attacker { get; set; }

	// Token: 0x1700208A RID: 8330
	// (get) Token: 0x060185B1 RID: 99761
	// (set) Token: 0x060185B2 RID: 99762
	Entity DirectTarget { get; set; }

	// Token: 0x1700208B RID: 8331
	// (get) Token: 0x060185B3 RID: 99763
	// (set) Token: 0x060185B4 RID: 99764
	int SkillLevel { get; set; }

	// Token: 0x1700208C RID: 8332
	// (get) Token: 0x060185B5 RID: 99765
	// (set) Token: 0x060185B6 RID: 99766
	FVectorDouble HitPosition { get; set; }

	// Token: 0x1700208D RID: 8333
	// (get) Token: 0x060185B7 RID: 99767
	// (set) Token: 0x060185B8 RID: 99768
	float ExtraRate { get; set; }

	// Token: 0x1700208E RID: 8334
	// (get) Token: 0x060185B9 RID: 99769
	// (set) Token: 0x060185BA RID: 99770
	bool IsAddEnergy { get; set; }

	// Token: 0x1700208F RID: 8335
	// (get) Token: 0x060185BB RID: 99771
	// (set) Token: 0x060185BC RID: 99772
	bool IsCounterAttack { get; set; }

	// Token: 0x17002090 RID: 8336
	// (get) Token: 0x060185BD RID: 99773
	// (set) Token: 0x060185BE RID: 99774
	bool ForceCritical { get; set; }

	// Token: 0x17002091 RID: 8337
	// (get) Token: 0x060185BF RID: 99775
	// (set) Token: 0x060185C0 RID: 99776
	bool IsBlocked { get; set; }

	// Token: 0x17002092 RID: 8338
	// (get) Token: 0x060185C1 RID: 99777
	// (set) Token: 0x060185C2 RID: 99778
	int PartId { get; set; }

	// Token: 0x17002093 RID: 8339
	// (get) Token: 0x060185C3 RID: 99779
	// (set) Token: 0x060185C4 RID: 99780
	long? CounterSkillMessageId { get; set; }

	// Token: 0x17002094 RID: 8340
	// (get) Token: 0x060185C5 RID: 99781
	// (set) Token: 0x060185C6 RID: 99782
	long? CounterSkillId { get; set; }

	// Token: 0x17002095 RID: 8341
	// (get) Token: 0x060185C7 RID: 99783
	// (set) Token: 0x060185C8 RID: 99784
	ECounterAttackType? CounterType { get; set; }
}
