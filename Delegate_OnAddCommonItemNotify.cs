using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020004D6 RID: 1238
// (Invoke) Token: 0x0600150B RID: 5387
[EventRule(EEventName.OnAddCommonItemNotify)]
internal delegate void Delegate_OnAddCommonItemNotify(IReadOnlyList<IProto_NormalItem> normalItemList);
