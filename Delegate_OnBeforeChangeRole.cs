using System;
using System.Runtime.CompilerServices;

// Token: 0x02000190 RID: 400
// (Invoke) Token: 0x060007F3 RID: 2035
[EventRule(EEventName.OnBeforeChangeRole)]
internal delegate void Delegate_OnBeforeChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity);
