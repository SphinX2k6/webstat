using System;
using System.Collections.Generic;

// Token: 0x020001D9 RID: 473
// (Invoke) Token: 0x06000917 RID: 2327
[EventRule(EEventName.RoleRefreshAttribute)]
internal delegate void Delegate_RoleRefreshAttribute(IReadOnlyDictionary<int, int> baseAttr, IReadOnlyDictionary<int, int> addAttr);
