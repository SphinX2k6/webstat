using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200326D RID: 12909
[NullableContext(1)]
[Nullable(0)]
public class VehicleGravityComponent : BaseGravityComponent
{
	// Token: 0x0601AFC4 RID: 110532 RVA: 0x0080FCE0 File Offset: 0x0080DEE0
	protected override bool OnStart()
	{
		this.VehicleMoveComp = base.Entity.GetComponent<VehicleMoveComponent>();
		if (this.VehicleMoveComp == null)
		{
			Singleton<Log>.Instance.Error(ELogModule.Movement, ELogAuthor.YZ, "[VehicleGravityComponent] VehicleMoveComponent not found", default(ReadOnlySpan<ValueTuple<string, object>>));
		}
		this.PerformComp = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		base.InitGravityDirect();
		return true;
	}

	// Token: 0x0601AFC5 RID: 110533 RVA: 0x0080FD39 File Offset: 0x0080DF39
	protected override bool OnEnd()
	{
		this.VehicleMoveComp = null;
		this.PerformComp = null;
		this.NeedResetPassengerGravity = false;
		return base.OnEnd();
	}

	// Token: 0x0601AFC6 RID: 110534 RVA: 0x0080FD56 File Offset: 0x0080DF56
	protected override void ApplyGravityToMoveComp(Vector direction, bool clearGround = true, float overrideSmoothTime = -1f, bool withoutRotate = false)
	{
		if (this.VehicleMoveComp == null)
		{
			return;
		}
		if (withoutRotate)
		{
			this.VehicleMoveComp.SetGravityDirectWithoutRotate(direction);
			return;
		}
		this.VehicleMoveComp.SetGravityDirect(direction, overrideSmoothTime);
	}

	// Token: 0x0601AFC7 RID: 110535 RVA: 0x0080FD80 File Offset: 0x0080DF80
	public void OnPassengerLeave(Entity entity)
	{
		if (!this.NeedResetPassengerGravity)
		{
			return;
		}
		BaseGravityComponent component = entity.GetComponent<BaseGravityComponent>();
		int? activePriority = base.GetActivePriority();
		if (activePriority != null)
		{
			int? num = activePriority;
			int num2 = 0;
			if ((num.GetValueOrDefault() > num2 & num != null) && component != null)
			{
				component.StopGravityByPriority(activePriority.Value, true, -1f, false);
			}
		}
	}

	// Token: 0x0601AFC8 RID: 110536 RVA: 0x0080FDDC File Offset: 0x0080DFDC
	public void SetGravityDirectForVehicle(int priority, IVector gravity, bool needResetPassengerGravity = false, float overrideSmoothTime = -1f, bool withoutRotate = false)
	{
		this.NeedResetPassengerGravity = needResetPassengerGravity;
		base.SetGravityByPriority(priority, gravity, true, overrideSmoothTime, withoutRotate);
		this.SyncPassengerGravity(gravity, priority);
	}

	// Token: 0x0601AFC9 RID: 110537 RVA: 0x0080FDFA File Offset: 0x0080DFFA
	public void StopGravityDirectForVehicle(int priority)
	{
		this.NeedResetPassengerGravity = false;
		base.StopGravityByPriority(priority, true, -1f, false);
		this.SyncPassengerGravityStop(priority);
	}

	// Token: 0x0601AFCA RID: 110538 RVA: 0x0080FE18 File Offset: 0x0080E018
	private void SyncPassengerGravity(IVector gravity, int priority)
	{
		if (this.PerformComp == null)
		{
			return;
		}
		foreach (VehiclePassengerInfo vehiclePassengerInfo in this.PerformComp.PassengerInfoMap.Values)
		{
			Entity passengerEntity = vehiclePassengerInfo.PassengerEntity;
			BaseGravityComponent baseGravityComponent = (passengerEntity != null) ? passengerEntity.GetComponent<BaseGravityComponent>() : null;
			if (baseGravityComponent != null)
			{
				baseGravityComponent.SetGravityByPriority(priority, gravity, true, -1f, true);
			}
		}
	}

	// Token: 0x0601AFCB RID: 110539 RVA: 0x0080FE9C File Offset: 0x0080E09C
	private void SyncPassengerGravityStop(int priority)
	{
		if (this.PerformComp == null)
		{
			return;
		}
		foreach (VehiclePassengerInfo vehiclePassengerInfo in this.PerformComp.PassengerInfoMap.Values)
		{
			Entity passengerEntity = vehiclePassengerInfo.PassengerEntity;
			BaseGravityComponent baseGravityComponent = (passengerEntity != null) ? passengerEntity.GetComponent<BaseGravityComponent>() : null;
			if (baseGravityComponent != null)
			{
				baseGravityComponent.StopGravityByPriority(priority, true, -1f, true);
			}
		}
	}

	// Token: 0x0601AFCC RID: 110540 RVA: 0x0080FF20 File Offset: 0x0080E120
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleGravityComponent vehicleGravityComponent = (VehicleGravityComponent)componentTemplate;
		if (base.CanResetComponentProperty("VehicleMoveComp"))
		{
			if (vehicleGravityComponent.VehicleMoveComp == null)
			{
				this.VehicleMoveComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleMoveComponent>(this.VehicleMoveComp), "VehicleMoveComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("PerformComp"))
		{
			if (vehicleGravityComponent.PerformComp == null)
			{
				this.PerformComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.PerformComp), "PerformComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("NeedResetPassengerGravity"))
		{
			this.NeedResetPassengerGravity = vehicleGravityComponent.NeedResetPassengerGravity;
		}
		return true;
	}

	// Token: 0x0400DB18 RID: 56088
	[Nullable(2)]
	private VehicleMoveComponent VehicleMoveComp;

	// Token: 0x0400DB19 RID: 56089
	[Nullable(2)]
	private BaseVehiclePerformComponent PerformComp;

	// Token: 0x0400DB1A RID: 56090
	public bool NeedResetPassengerGravity;
}
