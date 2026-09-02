using System;
using System.Collections.Generic;

// Token: 0x02000613 RID: 1555
// (Invoke) Token: 0x060019FF RID: 6655
[EventRule(EEventName.OnReceiveActivityData)]
internal delegate void Delegate_OnReceiveActivityData(int type, IReadOnlyList<int> activityIds);
