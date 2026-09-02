using System;
using System.Collections.Generic;

// Token: 0x02000B2E RID: 2862
// (Invoke) Token: 0x06002E6B RID: 11883
[EventRule(EEventName.OnFurnitureUnlockNotify)]
internal delegate void Delegate_OnFurnitureUnlockNotify(int handleId, IReadOnlyList<int> furnitureIds);
