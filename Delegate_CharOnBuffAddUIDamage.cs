using System;
using Aki.Config;

// Token: 0x0200014B RID: 331
// (Invoke) Token: 0x060006DF RID: 1759
[EventRule(EEventName.CharOnBuffAddUIDamage)]
internal delegate void Delegate_CharOnBuffAddUIDamage(int entityId, GameplayCue cue, bool isAdd, int handleId);
