using System;
using System.Collections.Generic;

// Token: 0x02000456 RID: 1110
// (Invoke) Token: 0x0600130B RID: 4875
[EventRule(EEventName.UnLockGoods)]
internal delegate void Delegate_UnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap);
