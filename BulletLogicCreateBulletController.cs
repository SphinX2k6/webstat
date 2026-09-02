using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;

// Token: 0x02002DBF RID: 11711
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class BulletLogicCreateBulletController : BulletLogicController<LogicDataCreateBullet, object>
{
	// Token: 0x060179DF RID: 96735 RVA: 0x0069249E File Offset: 0x0069069E
	public BulletLogicCreateBulletController(LogicDataCreateBullet bulletLogicBase, Entity bullet) : base(bulletLogicBase, bullet)
	{
		this.Parameter = bulletLogicBase;
	}

	// Token: 0x060179E0 RID: 96736 RVA: 0x006924B0 File Offset: 0x006906B0
	[NullableContext(2)]
	public override void BulletLogicAction(object param = null)
	{
		LogicDataCreateBullet parameter = this.Parameter;
		string createBulletRowName = parameter.CreateBulletRowName;
		if (createBulletRowName == "None")
		{
			return;
		}
		BulletInfo bulletInfo = this.Bullet.GetBulletInfo();
		Entity entity = null;
		BulletHitActorData bulletHitActorData = param as BulletHitActorData;
		if (bulletHitActorData != null)
		{
			entity = bulletHitActorData.Entity;
		}
		string flashBulletRowName = parameter.FlashBulletRowName;
		if (flashBulletRowName != "None")
		{
			IReadOnlyCollection<BulletEntity> bulletSetByAttacker = ModelBase<BulletModel>.Instance.GetBulletSetByAttacker(bulletInfo.Attacker.Id);
			bool flag = false;
			BaseActorComponent component = entity.GetComponent<BaseActorComponent>();
			if (bulletSetByAttacker != null && component is CharacterActorComponent)
			{
				TsBaseCharacter actor = (component as CharacterActorComponent).Actor;
				if (actor != null)
				{
					foreach (BulletEntity bulletEntity in bulletSetByAttacker)
					{
						BulletInfo bulletInfo2 = bulletEntity.GetBulletInfo();
						BaseActorComponent component2 = bulletEntity.GetComponent<BaseActorComponent>();
						AActor aactor;
						if (component2 == null)
						{
							aactor = null;
						}
						else
						{
							AActor owner = component2.Owner;
							aactor = ((owner != null) ? owner.GetAttachParentActor() : null);
						}
						AActor aactor2 = aactor;
						if (bulletInfo2.BulletRowName == flashBulletRowName && aactor2 == actor)
						{
							bulletInfo2.GenerateTime = (float)Singleton<Time>.Instance.WorldTime;
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				return;
			}
		}
		long? contextId = this.Bullet.GetBulletInfo().ContextId;
		BaseActorComponent bulletCharacterActor = this.GetBulletCharacterActor(parameter.BulletTransform, entity);
		HashSet<string> parentIds = BulletUtil.CollectParentsId(bulletInfo);
		BulletController instance = ControllerBase<BulletController>.Instance;
		BaseActorComponent bulletCharacterActor2 = this.GetBulletCharacterActor(parameter.BulletOwner, entity);
		Entity owner2 = (bulletCharacterActor2 != null) ? bulletCharacterActor2.Entity : null;
		string bulletRowName = createBulletRowName;
		FTransformDouble? initialTransform = new FTransformDouble?((bulletCharacterActor != null) ? bulletCharacterActor.ActorTransform : Singleton<MathUtils>.Instance.DefaultTransformDouble);
		BulletController.BulletCreateParams bulletCreateParams = new BulletController.BulletCreateParams();
		bulletCreateParams.SkillId = bulletInfo.BulletInitParams.SkillId;
		bulletCreateParams.SkillContextId = bulletInfo.BulletInitParams.SkillContextId;
		bulletCreateParams.ParentVictimId = ((entity != null) ? new int?(entity.Id) : null);
		Entity target = bulletInfo.Target;
		bulletCreateParams.ParentTargetId = ((target != null) ? new int?(target.Id) : null);
		bulletCreateParams.ParentId = this.Bullet.Id;
		bulletCreateParams.BattleContext = bulletInfo.BulletInitParams.BattleContext;
		bulletCreateParams.ParentIds = parentIds;
		BulletEntity bulletEntity2 = instance.CreateBulletCustomTarget(owner2, bulletRowName, initialTransform, bulletCreateParams, contextId, EBulletCreateSource.Others);
		if (bulletEntity2 == null)
		{
			return;
		}
		BulletInfo bulletInfo3 = bulletEntity2.GetBulletInfo();
		if (bulletInfo3.BulletDataMain.Render.HandOverParentEffect)
		{
			BulletStaticFunction.HandOverEffects(bulletInfo, bulletInfo3);
			return;
		}
		string attachToBoneName = parameter.AttachToBoneName;
		BaseActorComponent bulletCharacterActor3 = this.GetBulletCharacterActor(parameter.AttachToActor, entity);
		if (bulletCharacterActor3 == null || attachToBoneName == "None")
		{
			return;
		}
		FName? dynamicFName = FNameUtil.GetDynamicFName(attachToBoneName);
		BulletActorComponent component3 = bulletEntity2.GetComponent<BulletActorComponent>();
		component3.SetActorLocation(bulletCharacterActor3.GetSocketLocation(dynamicFName.Value), "unknown", true);
		USkeletalMeshComponent mesh = (bulletCharacterActor3.Owner as ABaseCharacter).Mesh;
		component3.SetAttachToComponent(mesh, dynamicFName.Value, EAttachmentRule.KeepWorld, EAttachmentRule.KeepRelative, EAttachmentRule.KeepRelative, false);
		component3.NeedDetach = true;
	}

	// Token: 0x060179E1 RID: 96737 RVA: 0x0069279C File Offset: 0x0069099C
	[return: Nullable(2)]
	private BaseActorComponent GetBulletCharacterActor(EBulletObject bulletObject, Entity victim)
	{
		if (bulletObject == EBulletObject.攻击者)
		{
			return this.Bullet.GetBulletInfo().AttackerActorComp;
		}
		if (bulletObject != EBulletObject.受击者)
		{
			return this.Bullet.GetBulletInfo().AttackerActorComp;
		}
		BaseActorComponent component = victim.GetComponent<BaseActorComponent>();
		if (component != null && component.Valid)
		{
			return component;
		}
		return this.Bullet.GetBulletInfo().AttackerActorComp;
	}

	// Token: 0x0400B5DE RID: 46558
	[Nullable(2)]
	private readonly LogicDataCreateBullet Parameter;
}
