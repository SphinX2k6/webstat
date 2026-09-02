using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;

// Token: 0x02003011 RID: 12305
[NullableContext(1)]
[Nullable(0)]
[RequiredMember]
public class HitContext
{
	// Token: 0x0601914D RID: 102733 RVA: 0x00720C62 File Offset: 0x0071EE62
	[Obsolete("Constructors of types with required members are not supported in this version of your compiler.", true)]
	[CompilerFeatureRequired("RequiredMembers")]
	public HitContext()
	{
	}

	// Token: 0x0400C478 RID: 50296
	public bool HasBeHitAnim;

	// Token: 0x0400C479 RID: 50297
	public EHitAnim BeHitAnim;

	// Token: 0x0400C47A RID: 50298
	public int VisionCounterAttackId;

	// Token: 0x0400C47B RID: 50299
	public ECounterAttackType CounterAttackType;

	// Token: 0x0400C47C RID: 50300
	public int SkillId;

	// Token: 0x0400C47D RID: 50301
	public int? SkillHitCount;

	// Token: 0x0400C47E RID: 50302
	public int? SkillHitCountByVictim;

	// Token: 0x0400C47F RID: 50303
	public int? BulletHitCount;

	// Token: 0x0400C480 RID: 50304
	public int? BulletHitCountByVictim;

	// Token: 0x0400C481 RID: 50305
	public int SkillGenre;

	// Token: 0x0400C482 RID: 50306
	public string[] BattleFlags = Array.Empty<string>();

	// Token: 0x0400C483 RID: 50307
	[Nullable(2)]
	public Entity Attacker;

	// Token: 0x0400C484 RID: 50308
	[RequiredMember]
	public Entity Target;

	// Token: 0x0400C485 RID: 50309
	public long BulletId;
}
