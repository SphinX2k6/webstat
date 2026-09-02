using System;
using System.Collections.Generic;

// Token: 0x0200039B RID: 923
// (Invoke) Token: 0x0600101F RID: 4127
[EventRule(EEventName.GeneralLogicTreeEntityInteractFinished)]
internal delegate void Delegate_GeneralLogicTreeEntityInteractFinished(int nodeId, IReadOnlyList<int> entityDataIds);
