using System;

// Token: 0x02000AF1 RID: 2801
// (Invoke) Token: 0x06002D77 RID: 11639
[EventRule(EEventName.TsSyncTime)]
internal delegate void Delegate_TsSyncTime(double serverTime, double flowTime, double combatTime, double stopTime);
