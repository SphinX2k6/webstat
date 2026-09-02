using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000469 RID: 1129
// (Invoke) Token: 0x06001357 RID: 4951
[EventRule(EEventName.GachaResponse)]
internal delegate void Delegate_GachaResponse(IReadOnlyList<Aki.Protocol.GachaResult> result);
