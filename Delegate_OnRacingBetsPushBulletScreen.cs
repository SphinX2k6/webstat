using System;
using System.Collections.Generic;

// Token: 0x02000879 RID: 2169
// (Invoke) Token: 0x06002397 RID: 9111
[EventRule(EEventName.OnRacingBetsPushBulletScreen)]
internal delegate void Delegate_OnRacingBetsPushBulletScreen(IReadOnlyList<int> bulletScreenList, bool isSelf);
