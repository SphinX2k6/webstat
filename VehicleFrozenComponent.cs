using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x0200326C RID: 12908
[NullableContext(2)]
[Nullable(0)]
public class VehicleFrozenComponent : MonsterFrozenComponent
{
	// Token: 0x0601AFBB RID: 110523 RVA: 0x0080FAA4 File Offset: 0x0080DCA4
	protected override bool OnStart()
	{
		base.OnStart();
		this.AddEvent();
		this.VehiclePerformComponent = base.Entity.GetComponent<BaseVehiclePerformComponent>();
		return true;
	}

	// Token: 0x0601AFBC RID: 110524 RVA: 0x0080FAC5 File Offset: 0x0080DCC5
	protected override bool OnEnd()
	{
		base.OnEnd();
		this.RemoveEvent();
		return true;
	}

	// Token: 0x0601AFBD RID: 110525 RVA: 0x0080FAD8 File Offset: 0x0080DCD8
	private void AddEvent()
	{
		if (!Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		}
	}

	// Token: 0x0601AFBE RID: 110526 RVA: 0x0080FB2C File Offset: 0x0080DD2C
	private void RemoveEvent()
	{
		if (Singleton<EventSystem>.Instance.HasWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<Entity, Entity>(base.Entity, EEventName.OnVehicleDriverChange, new Action<Entity, Entity>(this.OnVehicleDriverChange));
		}
	}

	// Token: 0x0601AFBF RID: 110527 RVA: 0x0080FB80 File Offset: 0x0080DD80
	private void OnVehicleDriverChange(Entity preDriver, Entity newDriver)
	{
		if (preDriver != null && Singleton<EventSystem>.Instance.HasWithTarget<bool>(preDriver, EEventName.CharAfterFrozenChange, new Action<bool>(this.OnFrozenChange)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<bool>(preDriver, EEventName.CharAfterFrozenChange, new Action<bool>(this.OnFrozenChange));
		}
		if (newDriver != null && !Singleton<EventSystem>.Instance.HasWithTarget<bool>(newDriver, EEventName.CharAfterFrozenChange, new Action<bool>(this.OnFrozenChange)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<bool>(newDriver, EEventName.CharAfterFrozenChange, new Action<bool>(this.OnFrozenChange));
		}
		this.RefreshFrozen();
	}

	// Token: 0x0601AFC0 RID: 110528 RVA: 0x0080FC04 File Offset: 0x0080DE04
	protected override void RefreshFrozen()
	{
		if (this.FrozenLockSet.Count > 0)
		{
			this.SetFrozen(true);
			return;
		}
		BaseVehiclePerformComponent vehiclePerformComponent = this.VehiclePerformComponent;
		Entity entity = (vehiclePerformComponent != null) ? vehiclePerformComponent.Driver : null;
		bool flag;
		if (entity == null)
		{
			flag = false;
		}
		else
		{
			BaseFrozenComponent component = entity.GetComponent<BaseFrozenComponent>();
			flag = ((component != null) ? new bool?(component.IsFrozen()) : null).GetValueOrDefault();
		}
		if (flag)
		{
			this.SetFrozen(true);
			return;
		}
		this.SetFrozen(false);
	}

	// Token: 0x0601AFC1 RID: 110529 RVA: 0x0080FC77 File Offset: 0x0080DE77
	private void OnFrozenChange(bool _)
	{
		this.RefreshFrozen();
	}

	// Token: 0x0601AFC2 RID: 110530 RVA: 0x0080FC80 File Offset: 0x0080DE80
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleFrozenComponent vehicleFrozenComponent = (VehicleFrozenComponent)componentTemplate;
		if (base.CanResetComponentProperty("VehiclePerformComponent"))
		{
			if (vehicleFrozenComponent.VehiclePerformComponent == null)
			{
				this.VehiclePerformComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseVehiclePerformComponent>(this.VehiclePerformComponent), "VehiclePerformComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DB17 RID: 56087
	protected BaseVehiclePerformComponent VehiclePerformComponent;
}
