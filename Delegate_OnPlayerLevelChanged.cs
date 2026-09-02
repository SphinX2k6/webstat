using System;

// Token: 0x02000324 RID: 804
// (Invoke) Token: 0x06000E43 RID: 3651
[EventRule(EEventName.OnPlayerLevelChanged)]
internal delegate void Delegate_OnPlayerLevelChanged(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp);
