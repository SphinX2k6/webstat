using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F68 RID: 12136
[NullableContext(1)]
[Nullable(0)]
public class SnapReplacer : BuffEffect
{
	// Token: 0x06018CCF RID: 101583 RVA: 0x007032AE File Offset: 0x007014AE
	public SnapReplacer(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CD0 RID: 101584 RVA: 0x007032BD File Offset: 0x007014BD
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return base.InstigatorBuffComponent;
	}

	// Token: 0x06018CD1 RID: 101585 RVA: 0x007032C8 File Offset: 0x007014C8
	[return: Nullable(2)]
	public static CharacterBuffComponent ApplyEffects([Nullable(2)] RequirementPayload requirements, CharacterBuffComponent attacker, CharacterBuffComponent victim)
	{
		ExtraEffectManager buffEffectManager = attacker.BuffEffectManager;
		IEnumerable<SnapReplacer> enumerable = (buffEffectManager != null) ? buffEffectManager.FilterById<SnapReplacer>(EExtraEffectId.ReplaceSnapshotBeforeCalculation, null) : null;
		if (enumerable != null)
		{
			foreach (SnapReplacer snapReplacer in enumerable)
			{
				EntityHandle instigatorEntity = snapReplacer.InstigatorEntity;
				if (instigatorEntity != null && instigatorEntity.Valid && snapReplacer.InstigatorEntity.Entity.Id != snapReplacer.OwnerBuffComponent.GetEntity().Id && snapReplacer.Check(requirements ?? new Partial_RequirementPayload(), victim))
				{
					return snapReplacer.Execute(Array.Empty<object>()) as CharacterBuffComponent;
				}
			}
			return attacker;
		}
		return attacker;
	}
}
