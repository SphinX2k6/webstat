using System;
using Aki.Protocol;

// Token: 0x020004D4 RID: 1236
// (Invoke) Token: 0x06001503 RID: 5379
[EventRule(EEventName.OnAddCommonItem)]
internal delegate void Delegate_OnAddCommonItem(IProto_NormalItem normalItem, bool isShowNewTips);
