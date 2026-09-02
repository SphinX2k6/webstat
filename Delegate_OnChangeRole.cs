using System;
using System.Runtime.CompilerServices;

// Token: 0x0200018D RID: 397
// (Invoke) Token: 0x060007E7 RID: 2023
[EventRule(EEventName.OnChangeRole)]
internal delegate void Delegate_OnChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity);
