using System;
using System.Collections.Generic;

// Token: 0x02000498 RID: 1176
// (Invoke) Token: 0x06001413 RID: 5139
[EventRule(EEventName.OnAggroAdd)]
internal delegate void Delegate_OnAggroAdd(IReadOnlyList<int> entityIds);
