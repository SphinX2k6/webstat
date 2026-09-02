using System;
using System.Collections.Generic;

// Token: 0x020004EC RID: 1260
// (Invoke) Token: 0x06001563 RID: 5475
[EventRule(EEventName.AdventureTaskStateChange)]
internal delegate void Delegate_AdventureTaskStateChange(IReadOnlyList<int> ids);
