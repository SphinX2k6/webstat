using System;
using System.Collections.Generic;

// Token: 0x020004E6 RID: 1254
// (Invoke) Token: 0x0600154B RID: 5451
[EventRule(EEventName.OnRemovePhantomItem)]
internal delegate void Delegate_OnRemovePhantomItem(IReadOnlyList<int> uniqueIdList);
