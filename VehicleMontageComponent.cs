using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003277 RID: 12919
[NullableContext(2)]
[Nullable(0)]
public class VehicleMontageComponent : BaseMontageComponent
{
	// Token: 0x0601B035 RID: 110645 RVA: 0x0081309E File Offset: 0x0081129E
	protected override bool OnStart()
	{
		this.AnimationComponent = base.Entity.GetComponent<VehicleAnimationComponent>();
		return base.OnStart();
	}

	// Token: 0x0601B036 RID: 110646 RVA: 0x008130BC File Offset: 0x008112BC
	public override UAnimInstance GetMainAnimInstance()
	{
		return this.AnimationComponent.MainAnimInstance;
	}

	// Token: 0x0601B037 RID: 110647 RVA: 0x008130CC File Offset: 0x008112CC
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleMontageComponent vehicleMontageComponent = (VehicleMontageComponent)componentTemplate;
		if (base.CanResetComponentProperty("AnimationComponent"))
		{
			if (vehicleMontageComponent.AnimationComponent == null)
			{
				this.AnimationComponent = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<VehicleAnimationComponent>(this.AnimationComponent), "AnimationComponent"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400DB76 RID: 56182
	public VehicleAnimationComponent AnimationComponent;
}
