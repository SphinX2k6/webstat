using System;
using System.Collections.Generic;

// Token: 0x02000214 RID: 532
// (Invoke) Token: 0x06000A03 RID: 2563
[EventRule(EEventName.WeaponLevelUpReceiveItem)]
internal delegate void Delegate_WeaponLevelUpReceiveItem(IReadOnlyList<TItem> itemList);
