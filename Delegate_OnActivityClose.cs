using System;
using System.Collections.Generic;

// Token: 0x02000627 RID: 1575
// (Invoke) Token: 0x06001A4F RID: 6735
[EventRule(EEventName.OnActivityClose)]
internal delegate void Delegate_OnActivityClose(IReadOnlySet<int> closeActivities);
