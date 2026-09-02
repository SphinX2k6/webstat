using System;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002E5A RID: 11866
public class DamageResult
{
	// Token: 0x0400BB0D RID: 47885
	public Damage DamageData;

	// Token: 0x0400BB0E RID: 47886
	public float Damage;

	// Token: 0x0400BB0F RID: 47887
	public float ChangeLife;

	// Token: 0x0400BB10 RID: 47888
	public float ShieldCoverDamage;

	// Token: 0x0400BB11 RID: 47889
	public bool IsCounterAttack;

	// Token: 0x0400BB12 RID: 47890
	public bool IsCritical;

	// Token: 0x0400BB13 RID: 47891
	public bool IsTargetKilled;

	// Token: 0x0400BB14 RID: 47892
	public long KillerEntityId;

	// Token: 0x0400BB15 RID: 47893
	public bool IsBlocked;

	// Token: 0x0400BB16 RID: 47894
	public DamageSourceType SourceType;

	// Token: 0x0400BB17 RID: 47895
	public bool IsImmune;

	// Token: 0x0400BB18 RID: 47896
	public EElementType Element;
}
