using System;
using Aki.Protocol;

// Token: 0x020004DA RID: 1242
// (Invoke) Token: 0x0600151B RID: 5403
[EventRule(EEventName.OnCommonItemCountRefresh)]
internal delegate void Delegate_OnCommonItemCountRefresh(IProto_NormalItem normalItem, int count, int lastCount);
