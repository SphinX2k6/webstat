using System;
using UnrealEngine;

// Token: 0x02000F34 RID: 3892
[StaticVariableRuleIgnore]
public class KscEntityRemoveReason
{
	// Token: 0x04002E9A RID: 11930
	public static readonly FName Dead = FNameUtil.GetDynamicFName("Dead").Value;

	// Token: 0x04002E9B RID: 11931
	public static readonly FName WorldKill = FNameUtil.GetDynamicFName("WorldKill").Value;

	// Token: 0x04002E9C RID: 11932
	public static readonly FName Arrival = FNameUtil.GetDynamicFName("Arrival").Value;

	// Token: 0x04002E9D RID: 11933
	public static readonly FName Coin = FNameUtil.GetDynamicFName("Coin").Value;

	// Token: 0x04002E9E RID: 11934
	public static readonly FName LandFire = KscData.landFireRemoveReason;

	// Token: 0x04002E9F RID: 11935
	public static readonly FName CombatDirty = FNameUtil.GetDynamicFName("CombatDirty").Value;

	// Token: 0x04002EA0 RID: 11936
	public static readonly FName Destroy = FNameUtil.GetDynamicFName("Destroy").Value;
}
