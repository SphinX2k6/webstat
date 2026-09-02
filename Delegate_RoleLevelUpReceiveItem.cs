using System;
using System.Collections.Generic;

// Token: 0x020001DC RID: 476
// (Invoke) Token: 0x06000923 RID: 2339
[EventRule(EEventName.RoleLevelUpReceiveItem)]
internal delegate void Delegate_RoleLevelUpReceiveItem(IReadOnlyList<TItem> itemList);
