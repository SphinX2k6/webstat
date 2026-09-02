using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02003265 RID: 12901
public class VehicleAbilityComponent : BaseAbilityComponent
{
	// Token: 0x0601AF1C RID: 110364 RVA: 0x0080A9EC File Offset: 0x00808BEC
	[NullableContext(2)]
	protected override UBaseAbilitySystemComponent GetAbilitySystemComponent()
	{
		VehicleActorComponent component = base.Entity.GetComponent<VehicleActorComponent>();
		if (component == null)
		{
			return null;
		}
		component.Actor.TryAddTsAbilitySystemComponent();
		return component.Actor.AbilitySystemComponent;
	}

	// Token: 0x0601AF1D RID: 110365 RVA: 0x0080AA20 File Offset: 0x00808C20
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		VehicleAbilityComponent vehicleAbilityComponent = (VehicleAbilityComponent)componentTemplate;
		return true;
	}
}
