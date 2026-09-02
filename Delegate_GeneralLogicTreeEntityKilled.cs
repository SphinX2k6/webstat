using System;
using System.Collections.Generic;

// Token: 0x0200039C RID: 924
// (Invoke) Token: 0x06001023 RID: 4131
[EventRule(EEventName.GeneralLogicTreeEntityKilled)]
internal delegate void Delegate_GeneralLogicTreeEntityKilled(int nodeId, IReadOnlyList<int> entityDataIds);
