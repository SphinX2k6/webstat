using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using UnrealEngine;

// Token: 0x02003268 RID: 12904
[NullableContext(1)]
[Nullable(0)]
public class VehicleAudioComponent : BaseAudioComponent
{
	// Token: 0x170024CC RID: 9420
	// (get) Token: 0x0601AF92 RID: 110482 RVA: 0x0080E5BD File Offset: 0x0080C7BD
	[Nullable(2)]
	protected new VehicleActorComponent ActorComp
	{
		[NullableContext(2)]
		get
		{
			return this.ActorComp as VehicleActorComponent;
		}
	}

	// Token: 0x0601AF93 RID: 110483 RVA: 0x0080E5CC File Offset: 0x0080C7CC
	protected override bool OnInit()
	{
		base.OnInit();
		this.ActorComp = base.Entity.CheckGetComponent<VehicleActorComponent>();
		Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
		Singleton<EventSystem>.Instance.AddWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
		return true;
	}

	// Token: 0x0601AF94 RID: 110484 RVA: 0x0080E638 File Offset: 0x0080C838
	protected override bool OnClear()
	{
		if (Singleton<EventSystem>.Instance.HasWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenEntered, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenEntered));
		}
		if (Singleton<EventSystem>.Instance.HasWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<VehiclePassengerInfo, bool>(base.Entity, EEventName.OnVehicleBeenLeaved, new Action<VehiclePassengerInfo, bool>(this.OnVehicleBeenLeaved));
		}
		return base.OnClear();
	}

	// Token: 0x0601AF95 RID: 110485 RVA: 0x0080E6D9 File Offset: 0x0080C8D9
	protected override bool OnStart()
	{
		base.OnStart();
		VehicleActorComponent actorComp = this.ActorComp;
		if (actorComp == null || !actorComp.Valid || this.ActorComp.Owner == null)
		{
			return false;
		}
		this.InitVehicleAudioPlayPriority();
		return true;
	}

	// Token: 0x0601AF96 RID: 110486 RVA: 0x0080E70F File Offset: 0x0080C90F
	private void InitVehicleAudioPlayPriority()
	{
	}

	// Token: 0x0601AF97 RID: 110487 RVA: 0x0080E711 File Offset: 0x0080C911
	public virtual void UpdateVehicleMoveSound(float speed, AActor owner)
	{
	}

	// Token: 0x0601AF98 RID: 110488 RVA: 0x0080E713 File Offset: 0x0080C913
	protected virtual void OnVehicleBeenEntered(VehiclePassengerInfo info, bool byChangeRole)
	{
	}

	// Token: 0x0601AF99 RID: 110489 RVA: 0x0080E715 File Offset: 0x0080C915
	protected virtual void OnVehicleBeenLeaved(VehiclePassengerInfo info, bool byChangeRole)
	{
	}

	// Token: 0x0601AF9A RID: 110490 RVA: 0x0080E717 File Offset: 0x0080C917
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleAudioComponent vehicleAudioComponent = (VehicleAudioComponent)componentTemplate;
		return true;
	}
}
