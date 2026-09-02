using System;

// Token: 0x0200013C RID: 316
// (Invoke) Token: 0x060006A3 RID: 1699
[EventRule(EEventName.CharOnHealthChanged)]
internal delegate void Delegate_CharOnHealthChanged(int charId, float newValue, float oldValue);
