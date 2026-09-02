using System;

// Token: 0x02000326 RID: 806
// (Invoke) Token: 0x06000E4B RID: 3659
[EventRule(EEventName.OnLevelUpLevelRefresh)]
internal delegate void Delegate_OnLevelUpLevelRefresh(int lastLevel, int currentLevel, int currentExp, int lastExp, int addExp, int currentMaxExp, int lastMaxExp);
