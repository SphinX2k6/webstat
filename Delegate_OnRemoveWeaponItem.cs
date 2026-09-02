using System;
using System.Collections.Generic;

// Token: 0x020004E0 RID: 1248
// (Invoke) Token: 0x06001533 RID: 5427
[EventRule(EEventName.OnRemoveWeaponItem)]
internal delegate void Delegate_OnRemoveWeaponItem(IReadOnlyList<int> uniqueIdList);
