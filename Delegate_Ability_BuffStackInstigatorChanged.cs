using System;

// Token: 0x02002E44 RID: 11844
// (Invoke) Token: 0x06018467 RID: 99431
[AbilityEventRule(EAbilityEventName.BuffStackInstigatorChanged)]
internal delegate void Delegate_Ability_BuffStackInstigatorChanged(long buffId, int oldStack, int newStack, Entity victim, Entity attacker);
