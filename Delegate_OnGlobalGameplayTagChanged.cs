using System;

// Token: 0x02000355 RID: 853
// (Invoke) Token: 0x06000F07 RID: 3847
[EventRule(EEventName.OnGlobalGameplayTagChanged)]
internal delegate void Delegate_OnGlobalGameplayTagChanged(int entityId, int gameplayTagId, int originTagCount, int newTagCount);
