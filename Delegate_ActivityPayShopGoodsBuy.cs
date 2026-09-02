using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x0200045B RID: 1115
// (Invoke) Token: 0x0600131F RID: 4895
[EventRule(EEventName.ActivityPayShopGoodsBuy)]
internal delegate void Delegate_ActivityPayShopGoodsBuy(int payShopId, IReadOnlyList<ActivityBuyItem> buyItems, string version);
