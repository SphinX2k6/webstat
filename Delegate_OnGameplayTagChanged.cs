using System;

// Token: 0x02002E4B RID: 11851
// (Invoke) Token: 0x06018483 RID: 99459
[AbilityEventRule(EAbilityEventName.OnGameplayTagChanged)]
internal delegate void Delegate_OnGameplayTagChanged(int entityId, int gameplayTagId, int originTagCount, int newTagCount);
