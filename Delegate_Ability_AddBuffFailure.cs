using System;

// Token: 0x02002E46 RID: 11846
// (Invoke) Token: 0x0601846F RID: 99439
[AbilityEventRule(EAbilityEventName.AddBuffFailure)]
internal delegate void Delegate_Ability_AddBuffFailure(long buffId, Entity victim, Entity attacker, int stackCount, long? bulletContextId);
