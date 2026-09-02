using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x020004E3 RID: 1251
// (Invoke) Token: 0x0600153F RID: 5439
[EventRule(EEventName.OnAddPhantomItemList)]
internal delegate void Delegate_OnAddPhantomItemList(IReadOnlyList<PhantomItem> weaponItem, bool isCatch);
