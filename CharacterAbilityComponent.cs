using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E90 RID: 11920
public class CharacterAbilityComponent : BaseAbilityComponent
{
	// Token: 0x06018797 RID: 100247 RVA: 0x006DAC1C File Offset: 0x006D8E1C
	[NullableContext(2)]
	protected override UBaseAbilitySystemComponent GetAbilitySystemComponent()
	{
		CharacterActorComponent component = base.Entity.GetComponent<CharacterActorComponent>();
		if (component == null)
		{
			return null;
		}
		component.Actor.TryAddTsAbilitySystemComponent();
		return component.Actor.AbilitySystemComponent;
	}

	// Token: 0x06018798 RID: 100248 RVA: 0x006DAC50 File Offset: 0x006D8E50
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterAbilityComponent characterAbilityComponent = (CharacterAbilityComponent)componentTemplate;
		return true;
	}
}
