using System;

// Token: 0x02002E48 RID: 11848
// (Invoke) Token: 0x06018477 RID: 99447
[AbilityEventRule(EAbilityEventName.ShieldChange)]
internal delegate void Delegate_Ability_ShieldChange(Entity victim, float oldShieldValue, float newShieldValue, int updateType, int shieldId);
