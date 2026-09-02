using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000F33 RID: 3891
[StaticVariableRuleIgnore]
public static class KscData
{
	// Token: 0x04002E98 RID: 11928
	public static readonly FName landFireRemoveReason = FNameUtil.GetDynamicFName("LandFireRemove").Value;

	// Token: 0x04002E99 RID: 11929
	[Nullable(1)]
	public static readonly FName[] kscEntityRemoveReasonList = new FName[]
	{
		KscEntityRemoveReason.Dead,
		KscEntityRemoveReason.WorldKill,
		KscEntityRemoveReason.Coin,
		KscEntityRemoveReason.CombatDirty,
		KscEntityRemoveReason.Destroy
	};
}
