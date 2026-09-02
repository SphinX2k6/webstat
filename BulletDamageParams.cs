using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E58 RID: 11864
[NullableContext(1)]
[Nullable(0)]
public class BulletDamageParams : IBulletDamageParam
{
	// Token: 0x17002096 RID: 8342
	// (get) Token: 0x060185C9 RID: 99785 RVA: 0x006D2BEF File Offset: 0x006D0DEF
	// (set) Token: 0x060185CA RID: 99786 RVA: 0x006D2BF7 File Offset: 0x006D0DF7
	public long DamageDataId { get; set; }

	// Token: 0x17002097 RID: 8343
	// (get) Token: 0x060185CB RID: 99787 RVA: 0x006D2C00 File Offset: 0x006D0E00
	// (set) Token: 0x060185CC RID: 99788 RVA: 0x006D2C08 File Offset: 0x006D0E08
	public long? BulletId { get; set; }

	// Token: 0x17002098 RID: 8344
	// (get) Token: 0x060185CD RID: 99789 RVA: 0x006D2C11 File Offset: 0x006D0E11
	// (set) Token: 0x060185CE RID: 99790 RVA: 0x006D2C19 File Offset: 0x006D0E19
	public Entity Attacker { get; set; }

	// Token: 0x17002099 RID: 8345
	// (get) Token: 0x060185CF RID: 99791 RVA: 0x006D2C22 File Offset: 0x006D0E22
	// (set) Token: 0x060185D0 RID: 99792 RVA: 0x006D2C2A File Offset: 0x006D0E2A
	public Entity DirectTarget { get; set; }

	// Token: 0x1700209A RID: 8346
	// (get) Token: 0x060185D1 RID: 99793 RVA: 0x006D2C33 File Offset: 0x006D0E33
	// (set) Token: 0x060185D2 RID: 99794 RVA: 0x006D2C3B File Offset: 0x006D0E3B
	public int SkillLevel { get; set; }

	// Token: 0x1700209B RID: 8347
	// (get) Token: 0x060185D3 RID: 99795 RVA: 0x006D2C44 File Offset: 0x006D0E44
	// (set) Token: 0x060185D4 RID: 99796 RVA: 0x006D2C4C File Offset: 0x006D0E4C
	public FVectorDouble HitPosition { get; set; }

	// Token: 0x1700209C RID: 8348
	// (get) Token: 0x060185D5 RID: 99797 RVA: 0x006D2C55 File Offset: 0x006D0E55
	// (set) Token: 0x060185D6 RID: 99798 RVA: 0x006D2C5D File Offset: 0x006D0E5D
	public float ExtraRate { get; set; }

	// Token: 0x1700209D RID: 8349
	// (get) Token: 0x060185D7 RID: 99799 RVA: 0x006D2C66 File Offset: 0x006D0E66
	// (set) Token: 0x060185D8 RID: 99800 RVA: 0x006D2C6E File Offset: 0x006D0E6E
	public bool IsAddEnergy { get; set; }

	// Token: 0x1700209E RID: 8350
	// (get) Token: 0x060185D9 RID: 99801 RVA: 0x006D2C77 File Offset: 0x006D0E77
	// (set) Token: 0x060185DA RID: 99802 RVA: 0x006D2C7F File Offset: 0x006D0E7F
	public bool IsCounterAttack { get; set; }

	// Token: 0x1700209F RID: 8351
	// (get) Token: 0x060185DB RID: 99803 RVA: 0x006D2C88 File Offset: 0x006D0E88
	// (set) Token: 0x060185DC RID: 99804 RVA: 0x006D2C90 File Offset: 0x006D0E90
	public bool ForceCritical { get; set; }

	// Token: 0x170020A0 RID: 8352
	// (get) Token: 0x060185DD RID: 99805 RVA: 0x006D2C99 File Offset: 0x006D0E99
	// (set) Token: 0x060185DE RID: 99806 RVA: 0x006D2CA1 File Offset: 0x006D0EA1
	public bool IsBlocked { get; set; }

	// Token: 0x170020A1 RID: 8353
	// (get) Token: 0x060185DF RID: 99807 RVA: 0x006D2CAA File Offset: 0x006D0EAA
	// (set) Token: 0x060185E0 RID: 99808 RVA: 0x006D2CB2 File Offset: 0x006D0EB2
	public int PartId { get; set; }

	// Token: 0x170020A2 RID: 8354
	// (get) Token: 0x060185E1 RID: 99809 RVA: 0x006D2CBB File Offset: 0x006D0EBB
	// (set) Token: 0x060185E2 RID: 99810 RVA: 0x006D2CC3 File Offset: 0x006D0EC3
	public long? CounterSkillMessageId { get; set; }

	// Token: 0x170020A3 RID: 8355
	// (get) Token: 0x060185E3 RID: 99811 RVA: 0x006D2CCC File Offset: 0x006D0ECC
	// (set) Token: 0x060185E4 RID: 99812 RVA: 0x006D2CD4 File Offset: 0x006D0ED4
	public long? CounterSkillId { get; set; }

	// Token: 0x170020A4 RID: 8356
	// (get) Token: 0x060185E5 RID: 99813 RVA: 0x006D2CDD File Offset: 0x006D0EDD
	// (set) Token: 0x060185E6 RID: 99814 RVA: 0x006D2CE5 File Offset: 0x006D0EE5
	public ECounterAttackType? CounterType { get; set; }
}
