using System;

// Token: 0x02002E45 RID: 11845
// (Invoke) Token: 0x0601846B RID: 99435
[AbilityEventRule(EAbilityEventName.AddBuffToOthers)]
internal delegate void Delegate_Ability_AddBuffToOthers(long buffId, Entity victim, Entity attacker, bool? bornBuff);
