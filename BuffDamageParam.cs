using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E56 RID: 11862
[NullableContext(1)]
[Nullable(0)]
public class BuffDamageParam : IBuffDamageParam
{
	// Token: 0x17002081 RID: 8321
	// (get) Token: 0x0601859C RID: 99740 RVA: 0x006D2B16 File Offset: 0x006D0D16
	// (set) Token: 0x0601859D RID: 99741 RVA: 0x006D2B1E File Offset: 0x006D0D1E
	public long? BuffId { get; set; }

	// Token: 0x17002082 RID: 8322
	// (get) Token: 0x0601859E RID: 99742 RVA: 0x006D2B27 File Offset: 0x006D0D27
	// (set) Token: 0x0601859F RID: 99743 RVA: 0x006D2B2F File Offset: 0x006D0D2F
	public long? BulletId { get; set; }

	// Token: 0x17002083 RID: 8323
	// (get) Token: 0x060185A0 RID: 99744 RVA: 0x006D2B38 File Offset: 0x006D0D38
	// (set) Token: 0x060185A1 RID: 99745 RVA: 0x006D2B40 File Offset: 0x006D0D40
	public long DamageDataId { get; set; }

	// Token: 0x17002084 RID: 8324
	// (get) Token: 0x060185A2 RID: 99746 RVA: 0x006D2B49 File Offset: 0x006D0D49
	// (set) Token: 0x060185A3 RID: 99747 RVA: 0x006D2B51 File Offset: 0x006D0D51
	public Entity Attacker { get; set; }

	// Token: 0x17002085 RID: 8325
	// (get) Token: 0x060185A4 RID: 99748 RVA: 0x006D2B5A File Offset: 0x006D0D5A
	// (set) Token: 0x060185A5 RID: 99749 RVA: 0x006D2B62 File Offset: 0x006D0D62
	public int SkillLevel { get; set; }

	// Token: 0x17002086 RID: 8326
	// (get) Token: 0x060185A6 RID: 99750 RVA: 0x006D2B6B File Offset: 0x006D0D6B
	// (set) Token: 0x060185A7 RID: 99751 RVA: 0x006D2B73 File Offset: 0x006D0D73
	public FVectorDouble HitPosition { get; set; }

	// Token: 0x060185A8 RID: 99752 RVA: 0x006D2B7C File Offset: 0x006D0D7C
	public BuffDamageParam()
	{
	}

	// Token: 0x060185A9 RID: 99753 RVA: 0x006D2B84 File Offset: 0x006D0D84
	public BuffDamageParam(IBuffDamageParam source)
	{
		this.BuffId = source.BuffId;
		this.BulletId = source.BulletId;
		this.DamageDataId = source.DamageDataId;
		this.Attacker = source.Attacker;
		this.SkillLevel = source.SkillLevel;
		this.HitPosition = source.HitPosition;
	}

	// Token: 0x060185AA RID: 99754 RVA: 0x006D2BDF File Offset: 0x006D0DDF
	public BuffDamageParam(IBuffDamageParam source, FVectorDouble hitPosition) : this(source)
	{
		this.HitPosition = hitPosition;
	}
}
