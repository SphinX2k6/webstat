using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000B48 RID: 2888
// (Invoke) Token: 0x06002ED3 RID: 11987
[EventRule(EEventName.OnPayShopConditionFinish)]
internal delegate void Delegate_OnPayShopConditionFinish(List<Aki.Protocol.PayShopItem> shopItemList);
