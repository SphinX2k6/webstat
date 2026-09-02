using System;
using System.Collections.Generic;

// Token: 0x0200049B RID: 1179
// (Invoke) Token: 0x0600141F RID: 5151
[EventRule(EEventName.OnAggroRemoved)]
internal delegate void Delegate_OnAggroRemoved(IReadOnlyList<int> entityIds);
