using System;
using System.Collections.Generic;

// Token: 0x020004EB RID: 1259
// (Invoke) Token: 0x0600155F RID: 5471
[EventRule(EEventName.NotifyExpireConvertItem)]
internal delegate void Delegate_NotifyExpireConvertItem(IReadOnlyList<TItem> beforeItemList, IReadOnlyList<TItem> afterItemList);
