using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F67 RID: 12135
[NullableContext(1)]
[Nullable(0)]
public class ModifyDamageElement : BuffEffect
{
	// Token: 0x06018CCA RID: 101578 RVA: 0x0070314F File Offset: 0x0070134F
	public ModifyDamageElement(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CCB RID: 101579 RVA: 0x0070316C File Offset: 0x0070136C
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		this.TargetType = (EElementType)int.Parse(parameters.ExtraEffectParameters_[0]);
		foreach (string s in parameters.ExtraEffectParameters_[1].Split(',', StringSplitOptions.None))
		{
			this.DamageIds.Add(long.Parse(s));
		}
	}

	// Token: 0x06018CCC RID: 101580 RVA: 0x007031C1 File Offset: 0x007013C1
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return this.TargetType;
	}

	// Token: 0x06018CCD RID: 101581 RVA: 0x007031D0 File Offset: 0x007013D0
	[NullableContext(2)]
	public static EElementType? ApplyEffects(BaseBuffComponent attacker, long damageId)
	{
		if (attacker == null)
		{
			return null;
		}
		foreach (ModifyDamageElement modifyDamageElement in attacker.BuffEffectManager.FilterById<ModifyDamageElement>(EExtraEffectId.ModifyDamageElement, null))
		{
			if (modifyDamageElement.DamageIds.Contains(damageId))
			{
				return new EElementType?(modifyDamageElement.TargetType);
			}
		}
		return null;
	}

	// Token: 0x06018CCE RID: 101582 RVA: 0x00703254 File Offset: 0x00701454
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
		defaultInterpolatedStringHandler.AppendLiteral("攻击时修改结算");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<long>("、", this.DamageIds));
		defaultInterpolatedStringHandler.AppendLiteral("的伤害属性为");
		defaultInterpolatedStringHandler.AppendFormatted<EElementType>(this.TargetType);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C166 RID: 49510
	public EElementType TargetType;

	// Token: 0x0400C167 RID: 49511
	public HashSet<long> DamageIds = new HashSet<long>();
}
