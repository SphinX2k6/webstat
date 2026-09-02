using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020004D5 RID: 1237
// (Invoke) Token: 0x06001507 RID: 5383
[EventRule(EEventName.OnAddCommonItemList)]
internal delegate void Delegate_OnAddCommonItemList(IReadOnlyList<IProto_NormalItem> normalItemList);
