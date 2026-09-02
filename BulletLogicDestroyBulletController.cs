using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;

// Token: 0x02002DC1 RID: 11713
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicDestroyBulletController : BulletLogicController<LogicDataDestroyBullet, object>
{
	// Token: 0x060179EB RID: 96747 RVA: 0x00692F14 File Offset: 0x00691114
	public BulletLogicDestroyBulletController(LogicDataDestroyBullet bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x060179EC RID: 96748 RVA: 0x00692F28 File Offset: 0x00691128
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		if (this.Parameter.DestroyBulletRowName == "None")
		{
			return;
		}
		Entity victim = null;
		BulletHitActorData bulletHitActorData = param as BulletHitActorData;
		if (bulletHitActorData != null)
		{
			victim = bulletHitActorData.Entity;
		}
		IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(this.GetBulletCharacterEntity(new EBulletObject?(this.Parameter.BulletOwner), victim).Id);
		if (bulletSetByAttacker == null)
		{
			return;
		}
		foreach (BulletEntity bulletEntity in bulletSetByAttacker)
		{
			BulletInfo bulletInfo = bulletEntity.GetBulletInfo();
			if (bulletInfo.BulletRowName == this.Parameter.DestroyBulletRowName)
			{
				ControllerBase<BulletController>.Instance.DestroyBullet(bulletInfo.BulletEntityId, this.Parameter.SummonChildBullet, EBulletDestroyReason.Normal, false);
			}
		}
	}

	// Token: 0x060179ED RID: 96749 RVA: 0x00692FFC File Offset: 0x006911FC
	private Entity GetBulletCharacterEntity(EBulletObject? bulletObject, Entity victim)
	{
		if (bulletObject != null)
		{
			EBulletObject valueOrDefault = bulletObject.GetValueOrDefault();
			if (valueOrDefault == EBulletObject.攻击者)
			{
				return this.Bullet.GetBulletInfo().Attacker;
			}
			if (valueOrDefault == EBulletObject.受击者)
			{
				return victim;
			}
		}
		return this.Bullet.GetBulletInfo().Attacker;
	}

	// Token: 0x0400B5E9 RID: 46569
	private const string NONE_STRING = "None";

	// Token: 0x0400B5EA RID: 46570
	private readonly LogicDataDestroyBullet Parameter;
}
