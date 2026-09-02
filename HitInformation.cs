using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DDD RID: 11741
[NullableContext(1)]
[Nullable(0)]
public class HitInformation
{
	// Token: 0x06017AA6 RID: 96934 RVA: 0x0069A7D4 File Offset: 0x006989D4
	[NullableContext(2)]
	public HitInformation([Nullable(1)] Entity attacker, Entity target, SHitEffect hitEffect, long bulletId, FRotator? hitEffectRotation, bool isShaking, FName? hitPart, IVector hitPosition, int skillLevel, [Nullable(1)] BulletDataMain reBulletData, [Nullable(1)] string bulletRowName, long damageId, BulletLogicType_C bulletDataPreset, int bulletEntityId, int calculateType, bool ShouldOptimize)
	{
		if (hitPosition != null)
		{
			this.HitPosition.FromUeVector(hitPosition);
		}
		else
		{
			this.HitPosition.Reset();
		}
		if (hitEffectRotation != null)
		{
			Rotator hitEffectRotation2 = this.HitEffectRotation;
			FRotator value = hitEffectRotation.Value;
			hitEffectRotation2.FromUeRotator(value);
		}
		else
		{
			this.HitEffectRotation.Reset();
		}
		this.Target = target;
		this.HitPart = hitPart;
		this.BulletId = bulletId;
		this.SkillLevel = skillLevel;
		this.Attacker = attacker;
		this.IsShaking = isShaking;
		this.HitEffect = hitEffect;
		this.ReBulletData = reBulletData;
		this.BulletDataPreset = bulletDataPreset;
		this.BulletEntityId = bulletEntityId;
		this.BulletRowName = bulletRowName;
		this.CalculateType = calculateType;
		this.DamageId = damageId;
		this.DirectTarget = target;
		this.ShouldOptimize = ShouldOptimize;
		this.IsAddEnergy = false;
	}

	// Token: 0x06017AA7 RID: 96935 RVA: 0x0069A8C8 File Offset: 0x00698AC8
	public static HitInformation FromUeHitInformation(SHitInformation hitInfo)
	{
		return new HitInformation(ControllerBase<CharacterController>.Instance.GetEntityByUeTsBaseCharacter(hitInfo.攻击者), ControllerBase<CharacterController>.Instance.GetEntityByUeTsBaseCharacter(hitInfo.受击者), hitInfo.被击效果, (long)hitInfo.子弹ID, new FRotator?(hitInfo.受击特效旋转), hitInfo.是否震动, new FName?(hitInfo.受击部位), hitInfo.受击位置, hitInfo.技能等级, new BulletDataMain(hitInfo.重构子弹数据, "", false), hitInfo.子弹表ID, hitInfo.伤害ID, hitInfo.子弹逻辑预设, hitInfo.子弹ID, hitInfo.伤害类型, false);
	}

	// Token: 0x06017AA8 RID: 96936 RVA: 0x0069A964 File Offset: 0x00698B64
	public SHitInformation ToUeHitInformation()
	{
		SHitEffect 被击效果 = this.HitEffect ?? new SHitEffect();
		int 子弹ID = (this.BulletId >= -2147483648L && this.BulletId <= 2147483647L) ? ((int)this.BulletId) : int.MinValue;
		return new SHitInformation(ControllerBase<CharacterController>.Instance.GetUeTsBaseCharacterByEntity(this.Attacker), ControllerBase<CharacterController>.Instance.GetUeTsBaseCharacterByEntity(this.Target), 被击效果, 子弹ID, this.HitPosition.ToUeVectorOld(), this.HitEffectRotation.ToUeRotator(), this.IsShaking, this.HitPart.Value, this.HitPosition.ToUeVectorOld(), this.SkillLevel, this.ReBulletData.Data, this.BulletDataPreset, this.BulletRowName, this.CalculateType, this.DamageId);
	}

	// Token: 0x0400B67B RID: 46715
	public readonly Vector HitPosition = Vector.Create();

	// Token: 0x0400B67C RID: 46716
	public readonly Rotator HitEffectRotation = Rotator.Create();

	// Token: 0x0400B67D RID: 46717
	[Nullable(2)]
	public Entity Target;

	// Token: 0x0400B67E RID: 46718
	public FName? HitPart;

	// Token: 0x0400B67F RID: 46719
	public long BulletId;

	// Token: 0x0400B680 RID: 46720
	public string BulletRowName;

	// Token: 0x0400B681 RID: 46721
	public int SkillLevel;

	// Token: 0x0400B682 RID: 46722
	public Entity Attacker;

	// Token: 0x0400B683 RID: 46723
	public bool IsShaking;

	// Token: 0x0400B684 RID: 46724
	[Nullable(2)]
	public SHitEffect HitEffect;

	// Token: 0x0400B685 RID: 46725
	public BulletDataMain ReBulletData;

	// Token: 0x0400B686 RID: 46726
	[Nullable(2)]
	public BulletLogicType_C BulletDataPreset;

	// Token: 0x0400B687 RID: 46727
	public int BulletEntityId;

	// Token: 0x0400B688 RID: 46728
	public int CalculateType = -1;

	// Token: 0x0400B689 RID: 46729
	public long DamageId;

	// Token: 0x0400B68A RID: 46730
	[Nullable(2)]
	public Entity DirectTarget;

	// Token: 0x0400B68B RID: 46731
	public bool ShouldOptimize;

	// Token: 0x0400B68C RID: 46732
	public bool IsAddEnergy;
}
