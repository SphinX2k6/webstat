using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Level.Vehicle;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;

// Token: 0x02003289 RID: 12937
[NullableContext(1)]
[Nullable(0)]
public class FishingBoatPerformComponent : GongduolaPerformComponent
{
	// Token: 0x0601B143 RID: 110915 RVA: 0x0081D45A File Offset: 0x0081B65A
	protected override bool OnInit()
	{
		if (!base.OnInit())
		{
			return false;
		}
		this.IsHidePassenger = true;
		return true;
	}

	// Token: 0x0601B144 RID: 110916 RVA: 0x0081D470 File Offset: 0x0081B670
	protected override bool OnStart()
	{
		if (!base.OnStart())
		{
			return false;
		}
		this.AttributeComp = base.Entity.GetComponent<BaseAttributeComponent>();
		if (this.AttributeComp != null)
		{
			this.AttributeComp.AddListener(EAttributeType.SpeedRatio, new Action<EAttributeType, float, float>(this.OnSpeedRatioChanged), "FishingBoatPerformComponent");
		}
		return true;
	}

	// Token: 0x0601B145 RID: 110917 RVA: 0x0081D4C0 File Offset: 0x0081B6C0
	protected override void OnActivate()
	{
		base.OnActivate();
		VehicleActorComponent actorComp = this.ActorComp;
		long? num;
		if (actorComp == null)
		{
			num = null;
		}
		else
		{
			CreatureDataComponent creatureData = actorComp.CreatureData;
			num = ((creatureData != null) ? new long?(creatureData.GetCreatureDataId()) : null);
		}
		long? num2 = num;
		long valueOrDefault = num2.GetValueOrDefault();
		ModelBase<FishingModel>.Instance.GetShipData().RefreshShipEntity(valueOrDefault);
	}

	// Token: 0x0601B146 RID: 110918 RVA: 0x0081D51F File Offset: 0x0081B71F
	protected override bool OnEnd()
	{
		if (this.AttributeComp != null)
		{
			this.AttributeComp.RemoveListener(EAttributeType.SpeedRatio, new Action<EAttributeType, float, float>(this.OnSpeedRatioChanged));
		}
		return base.OnEnd();
	}

	// Token: 0x0601B147 RID: 110919 RVA: 0x0081D54C File Offset: 0x0081B74C
	protected override bool InitVehicleConfig()
	{
		BP_VehicleConfig_C bp_VehicleConfig_C = this.LoadVehicleConfigAsset();
		if (bp_VehicleConfig_C == null || !bp_VehicleConfig_C.IsValid())
		{
			return false;
		}
		this.Config = new FishingBoatConfig(base.Entity, bp_VehicleConfig_C as BP_GongduolaConfig_C);
		this.ConfigInternal = this.Config.DeepCopy();
		return this.Config.Init();
	}

	// Token: 0x0601B148 RID: 110920 RVA: 0x0081D5A6 File Offset: 0x0081B7A6
	private void OnSpeedRatioChanged(EAttributeType attrId, float newValue, float oldValue)
	{
		if (!this.IsSprint)
		{
			(this.Config as FishingBoatConfig).SetBaseStateMoveConfig(this.ActorComp.Actor.VehicleMovementComponent);
		}
	}

	// Token: 0x0601B149 RID: 110921 RVA: 0x0081D5D0 File Offset: 0x0081B7D0
	public override bool CheckCanPerformHit()
	{
		foreach (VehiclePassengerInfo vehiclePassengerInfo in this.PassengerInfoMap.Values)
		{
			if (vehiclePassengerInfo.IsDriver && vehiclePassengerInfo.IsRolePassenger(false))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0601B14A RID: 110922 RVA: 0x0081D63C File Offset: 0x0081B83C
	public override void OnBulletHit(global::HitInformation hitData, BulletInfo bulletInfo)
	{
		if (this.ActorComp == null)
		{
			return;
		}
		BaseActorComponent attackerActorComp = bulletInfo.AttackerActorComp;
		if (attackerActorComp != null && attackerActorComp.Valid)
		{
			this.ActorComp.ActorLocationProxy.Subtraction(attackerActorComp.ActorLocationProxy, this.HitDirect);
			if (!this.HitDirect.Normalize(9.99999993922529E-09))
			{
				this.ActorComp.ActorForwardProxy.Multiply(-1.0, this.HitDirect);
			}
		}
		else
		{
			this.ActorComp.ActorForwardProxy.Multiply(-1.0, this.HitDirect);
		}
		this.CollisionStrength = 1f;
		this.HitDirect.GetSafeNormal2D(this.HitDirect, 9.99999993922529E-09);
		float num = (float)(Math.Acos(this.HitDirect.CosineAngle2D(this.ActorComp.ActorForwardProxy, 9.999999747378752E-05)) * 57.295780181884766);
		this.CollisionDirection = num * (float)Math.Sign(this.HitDirect.DotProduct(this.ActorComp.ActorRightProxy));
		base.BeginCollisionPerform(1000f);
	}

	// Token: 0x0601B14B RID: 110923 RVA: 0x0081D75D File Offset: 0x0081B95D
	public void FishingBoatEnterSprint(float sprintMaxSpeedRatio, float sprintExceedLimitDuration, float sprintDuration)
	{
		(this.Config as FishingBoatConfig).RefreshSprintConfig(sprintMaxSpeedRatio, sprintExceedLimitDuration, sprintDuration);
		this.TryEnterSprint(false);
	}

	// Token: 0x0601B14C RID: 110924 RVA: 0x0081D77A File Offset: 0x0081B97A
	public bool CheckCanSprint()
	{
		return !this.IsInSprintStartAction && this.ActorComp.InputDirectProxy.X >= 0.0;
	}

	// Token: 0x0601B14D RID: 110925 RVA: 0x0081D7A2 File Offset: 0x0081B9A2
	public override bool TryEnterSprint(bool fromEvent = false)
	{
		if (this.CheckCanSprint())
		{
			this.IsEnterSprint = true;
			return true;
		}
		return false;
	}

	// Token: 0x0601B14E RID: 110926 RVA: 0x0081D7B6 File Offset: 0x0081B9B6
	public override void HandlePendingDestroy()
	{
		ControllerBase<CreatureController>.Instance.DelayRemoveEntityFinished(base.Entity);
	}

	// Token: 0x0601B14F RID: 110927 RVA: 0x0081D7C8 File Offset: 0x0081B9C8
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		FishingBoatPerformComponent fishingBoatPerformComponent = (FishingBoatPerformComponent)componentTemplate;
		if (base.CanResetComponentProperty("AttributeComp"))
		{
			if (fishingBoatPerformComponent.AttributeComp == null)
			{
				this.AttributeComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseAttributeComponent>(this.AttributeComp), "AttributeComp"))
			{
				return false;
			}
		}
		return !base.CanResetComponentProperty("HitDirect") || fishingBoatPerformComponent.HitDirect == null || base.CheckClearObject(EntityComponentSystem.ClearObject<global::Vector>(this.HitDirect), "HitDirect");
	}

	// Token: 0x0400DC28 RID: 56360
	[Nullable(2)]
	private BaseAttributeComponent AttributeComp;

	// Token: 0x0400DC29 RID: 56361
	private readonly global::Vector HitDirect = global::Vector.Create();
}
