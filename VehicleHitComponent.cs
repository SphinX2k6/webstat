using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Pawn.Component;
using UnrealEngine;

// Token: 0x0200326E RID: 12910
[NullableContext(2)]
[Nullable(0)]
public class VehicleHitComponent : BaseHitComponent
{
	// Token: 0x0601AFCE RID: 110542 RVA: 0x0080FFD4 File Offset: 0x0080E1D4
	protected override bool OnStart()
	{
		this.ActorComp = base.Entity.GetComponent<VehicleActorComponent>();
		this.DamageComp = base.Entity.GetComponent<BaseDamageComponent>();
		this.PerformComp = base.Entity.GetComponent<VehiclePerformComponent>();
		this.TimeScaleComp = base.Entity.GetComponent<PawnTimeScaleComponent>();
		VehicleActorComponent actorComp = this.ActorComp;
		CharRenderingComponent charRenderingComponent = (actorComp != null) ? actorComp.Actor.CharRenderingComponent : null;
		if (charRenderingComponent != null)
		{
			this.OnHitMaterialAction = new OnHitMaterialAction(charRenderingComponent, this.TimeScaleComp);
		}
		return true;
	}

	// Token: 0x0601AFCF RID: 110543 RVA: 0x00810054 File Offset: 0x0080E254
	[NullableContext(1)]
	public void OnHit(HitInformation hitData, BulletInfo bulletInfo)
	{
		long damageId = hitData.DamageId;
		if (damageId >= 1L)
		{
			long? contextId = bulletInfo.ContextId;
			BaseDamageComponent damageComp = this.DamageComp;
			if (damageComp != null)
			{
				damageComp.ExecuteBulletDamage(hitData.BulletEntityId, new BulletDamageParams
				{
					DamageDataId = damageId,
					SkillLevel = hitData.SkillLevel,
					Attacker = hitData.Attacker,
					DirectTarget = (hitData.DirectTarget ?? base.Entity),
					HitPosition = hitData.HitPosition.ToUeVector(false),
					IsAddEnergy = false,
					IsCounterAttack = false,
					ForceCritical = false,
					IsBlocked = false,
					PartId = -1,
					ExtraRate = 1f,
					BulletId = new long?(hitData.BulletId)
				}, contextId.Value);
			}
		}
		VehiclePerformComponent performComp = this.PerformComp;
		if (performComp == null || performComp.CheckCanPerformHit())
		{
			VehiclePerformComponent performComp2 = this.PerformComp;
			if (performComp2 != null)
			{
				performComp2.OnBulletHit(hitData, bulletInfo);
			}
			this.ProcessOnHitMaterial(hitData);
		}
		CreatureDataComponent attackerCreatureDataComp = bulletInfo.AttackerCreatureDataComp;
		long attackerCreatureDataId = (attackerCreatureDataComp != null) ? attackerCreatureDataComp.GetCreatureDataId() : 0L;
		base.HitRequest(bulletInfo.Entity, attackerCreatureDataId, hitData, 0, false, false, ECounterAttackType.None, null, false, null, null);
	}

	// Token: 0x0601AFD0 RID: 110544 RVA: 0x00810190 File Offset: 0x0080E390
	[NullableContext(1)]
	public void ProcessOnHitMaterial(HitInformation hitData)
	{
		if (!ModelBase<BulletModel>.Instance.OpenHitMaterial || this.OnHitMaterialAction == null)
		{
			return;
		}
		FName onHitMaterialEffect = hitData.ReBulletData.Render.OnHitMaterialEffect;
		if (FNameUtil.IsNothing(onHitMaterialEffect))
		{
			return;
		}
		Entity attacker = hitData.Attacker;
		int bulletEntityId = hitData.BulletEntityId;
		int id = attacker.Id;
		if (this.OnHitMaterialAction.ComparePriority((long)bulletEntityId, id))
		{
			this.OnHitMaterialAction.Stop(true);
			string text = null;
			BaseActorComponent baseActorComponent = (attacker != null) ? attacker.GetComponent<BaseActorComponent>() : null;
			if (baseActorComponent != null)
			{
				text = ((baseActorComponent != null) ? baseActorComponent.GetReplaceEffect(onHitMaterialEffect.ToString()) : null);
			}
			this.OnHitMaterialAction.Start(text ?? onHitMaterialEffect.ToString(), ModelBase<BulletModel>.Instance.OnHitMaterialMsDelay, (long)bulletEntityId, id, null);
		}
	}

	// Token: 0x0601AFD1 RID: 110545 RVA: 0x0081025C File Offset: 0x0080E45C
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleHitComponent vehicleHitComponent = (VehicleHitComponent)componentTemplate;
		if (base.CanResetComponentProperty("ActorComp"))
		{
			if (vehicleHitComponent.ActorComp == null)
			{
				this.ActorComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleActorComponent>(this.ActorComp), "ActorComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("DamageComp"))
		{
			if (vehicleHitComponent.DamageComp == null)
			{
				this.DamageComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseDamageComponent>(this.DamageComp), "DamageComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerformComp"))
		{
			if (vehicleHitComponent.PerformComp == null)
			{
				this.PerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehiclePerformComponent>(this.PerformComp), "PerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TimeScaleComp"))
		{
			if (vehicleHitComponent.TimeScaleComp == null)
			{
				this.TimeScaleComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<PawnTimeScaleComponent>(this.TimeScaleComp), "TimeScaleComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("OnHitMaterialAction"))
		{
			if (vehicleHitComponent.OnHitMaterialAction == null)
			{
				this.OnHitMaterialAction = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<OnHitMaterialAction>(this.OnHitMaterialAction), "OnHitMaterialAction"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DB1B RID: 56091
	private VehicleActorComponent ActorComp;

	// Token: 0x0400DB1C RID: 56092
	private BaseDamageComponent DamageComp;

	// Token: 0x0400DB1D RID: 56093
	private VehiclePerformComponent PerformComp;

	// Token: 0x0400DB1E RID: 56094
	private PawnTimeScaleComponent TimeScaleComp;

	// Token: 0x0400DB1F RID: 56095
	private OnHitMaterialAction OnHitMaterialAction;
}
