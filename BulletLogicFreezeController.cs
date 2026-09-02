using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DC5 RID: 11717
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicFreezeController : BulletLogicController<LogicDataFreeze, object>
{
	// Token: 0x06017A00 RID: 96768 RVA: 0x00693B1C File Offset: 0x00691D1C
	public BulletLogicFreezeController(LogicDataFreeze bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.BulletInfo = this.Bullet.GetBulletInfo();
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x06017A01 RID: 96769 RVA: 0x00693B40 File Offset: 0x00691D40
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		Entity victim = null;
		BulletHitActorData bulletHitActorData = param as BulletHitActorData;
		if (bulletHitActorData != null)
		{
			victim = bulletHitActorData.Entity;
		}
		Entity bulletCharacterEntity = this.GetBulletCharacterEntity(new EBulletObject?(this.Parameter.Target), victim);
		int num = this.Parameter.Tags.GameplayTags.Num();
		if (bulletCharacterEntity == null && num > 0)
		{
			return;
		}
		for (int i = 0; i < num; i++)
		{
			if (!bulletCharacterEntity.GetComponent<BaseTagComponent>().HasTag(this.Parameter.Tags.GameplayTags.Get(i).TagId()))
			{
				return;
			}
		}
		BulletUtil.FrozenBulletTime(this.BulletInfo, this.Parameter.FreezeTime);
	}

	// Token: 0x06017A02 RID: 96770 RVA: 0x00693BE8 File Offset: 0x00691DE8
	private Entity GetBulletCharacterEntity(EBulletObject? bulletObject, Entity victim)
	{
		if (bulletObject != null)
		{
			EBulletObject valueOrDefault = bulletObject.GetValueOrDefault();
			if (valueOrDefault == EBulletObject.攻击者)
			{
				return this.BulletInfo.Attacker;
			}
			if (valueOrDefault == EBulletObject.受击者)
			{
				return victim;
			}
		}
		return this.BulletInfo.Attacker;
	}

	// Token: 0x0400B601 RID: 46593
	private readonly LogicDataFreeze Parameter;

	// Token: 0x0400B602 RID: 46594
	private readonly BulletInfo BulletInfo;
}
