using System;
using System.Runtime.CompilerServices;

// Token: 0x0200018E RID: 398
// (Invoke) Token: 0x060007EB RID: 2027
[EventRule(EEventName.OnOtherChangeRole)]
internal delegate void Delegate_OnOtherChangeRole(EntityHandle newEntity, [Nullable(2)] EntityHandle oldEntity);
