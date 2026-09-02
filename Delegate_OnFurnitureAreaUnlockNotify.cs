using System;
using System.Collections.Generic;
using Aki.Protocol;

// Token: 0x02000B2D RID: 2861
// (Invoke) Token: 0x06002E67 RID: 11879
[EventRule(EEventName.OnFurnitureAreaUnlockNotify)]
internal delegate void Delegate_OnFurnitureAreaUnlockNotify(int handleId, IReadOnlyList<AreaInfo> areaIds);
