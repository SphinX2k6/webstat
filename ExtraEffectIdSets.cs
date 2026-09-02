using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002EF2 RID: 12018
[NullableContext(1)]
[Nullable(0)]
public static class ExtraEffectIdSets
{
	// Token: 0x0400BFBC RID: 49084
	[StaticVariableRuleIgnore]
	public static readonly HashSet<EExtraEffectId> initExecutionIds = new HashSet<EExtraEffectId>
	{
		EExtraEffectId.AddBuffToAdjacentRole,
		EExtraEffectId.QteExecution
	};

	// Token: 0x0400BFBD RID: 49085
	[StaticVariableRuleIgnore]
	public static readonly HashSet<EExtraEffectId> periodExecutionIds = new HashSet<EExtraEffectId>
	{
		EExtraEffectId.AddBuffInstantByStackCount,
		EExtraEffectId.AddBulletInstantByStackCount,
		EExtraEffectId.AddEnergy,
		EExtraEffectId.ModifyFormationAttribute,
		EExtraEffectId.ExtendBuffDuration,
		EExtraEffectId.PeriodAddBuffToAdjacentEntity,
		EExtraEffectId.ModifyLife,
		EExtraEffectId.PeriodicExtraEffect,
		EExtraEffectId.PhantomAssist,
		EExtraEffectId.ReduceCd,
		EExtraEffectId.ReviveExecution,
		EExtraEffectId.ConvertBuffToAnother,
		EExtraEffectId.InvokePeriod,
		EExtraEffectId.ConvertAbnormalLight,
		EExtraEffectId.StartBattleQte,
		EExtraEffectId.RemoveBuffByFilter,
		EExtraEffectId.ModifyTeamMemberBuff,
		EExtraEffectId.BuffMapper,
		EExtraEffectId.AdjacentBuffStackToEffect
	};
}
