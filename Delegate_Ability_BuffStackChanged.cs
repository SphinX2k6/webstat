using System;

// Token: 0x02002E43 RID: 11843
// (Invoke) Token: 0x06018463 RID: 99427
[AbilityEventRule(EAbilityEventName.BuffStackChanged)]
internal delegate void Delegate_Ability_BuffStackChanged(long buffId, int oldStack, int newStack, Entity victim);
